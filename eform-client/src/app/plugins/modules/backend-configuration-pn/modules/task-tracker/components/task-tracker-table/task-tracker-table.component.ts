import {
  Component,
  EventEmitter,
  Input, OnChanges,
  OnInit,
  Output, SimpleChanges,
} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {Columns, ColumnsModel, DateListModel, TaskModel} from '../../../../models';
import {RepeatTypeEnum} from '../../../../enums';
import {TranslateService} from '@ngx-translate/core';
import * as R from 'ramda';
import {TaskTrackerStateService} from '../store';
import {set} from 'date-fns';
import {MtxGridColumn, MtxGridRowClassFormatter} from '@ng-matero/extensions/grid';
import {AbstractControl} from "@angular/forms";
import {Store} from "@ngrx/store";

@Component({
  selector: 'app-task-tracker-table',
  templateUrl: './task-tracker-table.component.html',
  styleUrls: ['./task-tracker-table.component.scss'],
})
export class TaskTrackerTableComponent implements OnInit, OnChanges {
  @Input() columnsFromDb: Columns;
  @Input() tasks: TaskModel[] = [];
  @Output() updateTable: EventEmitter<void> = new EventEmitter<void>();
  @Output() openAreaRulePlanningModal: EventEmitter<TaskModel> = new EventEmitter<TaskModel>();

  days: Date[] = [];
  daysInTable: Date[] = [];
  weeks: { weekNumber: number, length: number }[] = [];
  enabledHeadersNumber: number = 7;
  propertyHeaderEnabled: boolean = false;
  currentDate: Date = this.setDate(new Date());

  tableHeaders: MtxGridColumn[] = [
    {header: this.translateService.stream('Id'), field: 'complianceId', sortProp: {id: 'Id'}, sortable: false},
    {header: this.translateService.stream('CaseId'), field: 'sdkCaseId', sortProp: {id: 'CaseId'}, sortable: false},
    {header: this.translateService.stream('Property'), sortProp: {id: 'Property'}, field: 'property', sortable: false},
    {header: this.translateService.stream('Task'), field: 'taskName', sortable: false},
    {header: this.translateService.stream('Tags'), sortProp: {id: 'Tags'}, field: 'tags', sortable: false},
    {header: this.translateService.stream('Workers'), sortProp: {id: 'Workers'}, field: 'workers', sortable: false},
    {header: this.translateService.stream('Start'), sortProp: {id: 'Start'}, field: 'startTask', sortable: false,
      type: 'date',
      typeParameter: {format: 'dd.MM.y'}},
    {header: this.translateService.stream('Repeated'), sortProp: {id: 'Repeated'}, field: 'repeated', sortable: false,
    formatter: (data: TaskModel) => {
      return this.getRepeatEveryAndRepeatTypeByTask(data);
    }},
    {header: this.translateService.stream('Deadline'), sortProp: {id: 'Deadline'}, field: 'deadlineTask', sortable: false,
      type: 'date',
      typeParameter: {format: 'dd.MM.y'}},
    // actions column with custom buttons
    {header: this.translateService.stream('Actions'), field: 'actions', sortable: false, width: '100px',
      pinned: 'right',
      type: 'button',
      buttons: [  // action buttons for each row
        {
          type: 'icon',
          icon: 'edit',
          tooltip: this.translateService.stream('Edit'),
          click: (record: TaskModel) => this.redirectToCompliance(record),
        },
      ],
    },
  ];

  get columns() {
    return this.tableHeaders.map(x => x.field);
  }
  rowClassFormatter: MtxGridRowClassFormatter = {
    'background-red-light': (data, index) => data.taskIsExpired === true && index % 2 === 0,
    'background-red-dark': (data, index) => data.taskIsExpired === true && index % 2 === 1,
    //'background-yellow': (data, index) => data.taskIsExpired === false,
  };

  constructor(
    private store: Store,
    private translateService: TranslateService,
    private taskTrackerStateService: TaskTrackerStateService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    // this.taskTrackerStateService.getFiltersAsync().subscribe(filters => {
    //   this.propertyHeaderEnabled = !(filters.propertyIds.length === 1);
    //   this.recalculateColumns();
    // });
  }

  initTable() {
    this.currentDate = this.setDate(new Date());
    if (this.tasks && this.tasks.length) {
      this.daysInTable = R.flatten(this.tasks[this.tasks.length - 1].weeks.map(x => x.dateList.map(y => y.date)));
      this.weeks = this.tasks[this.tasks.length - 1].weeks.map(x => {
        return {weekNumber: x.weekNumber, length: x.weekRange};
      });
    }
  }

  getColorByDayAndTask(day: Date, task: TaskModel): string {
    const dateList: DateListModel[] = R.flatten(task.weeks.map(x => x.dateList));
    const index = dateList.findIndex(x => x.date.toISOString() === day.toISOString());
    if (index !== -1) {
      if (dateList[index].isTask) {
        return 'white-yellow';
      } else {
        return 'yellow';
      }
    }
    return '';
  }

  getRepeatEveryAndRepeatTypeByTask(task: TaskModel): string {
    return `${task.repeatEvery} ${this.translateService.instant(RepeatTypeEnum[task.repeatType])}`;
  }

  recalculateColumns() {
    let columns: ColumnsModel[] = [];
    if (this.columnsFromDb) {
      // this.columnsFromDb.property = this.propertyHeaderEnabled;
      for (let [key, value] of Object.entries(this.columnsFromDb)) {
        if (this.columnsFromDb.hasOwnProperty(key)) {
          columns = [...columns, {columnName: key, isColumnEnabled: value}];
        }
      }
      if (!this.propertyHeaderEnabled) {
        columns.find(x => x.columnName === 'property').isColumnEnabled = this.propertyHeaderEnabled;
      }
      this.enabledHeadersNumber = columns
        .filter(x => x.columnName !== 'calendar')
        .filter(x => x.isColumnEnabled)
        .length;
    }
  }

  redirectToCompliance(task: TaskModel) {
    if (task.taskIsExpired) { // When clicking on a task
      // eslint-disable-next-line max-len
      // that is overdue, the ones marked with red background, the user should navigate to plugins/backend-configuration-pn/compliances/case/121/21/1/2023-01-31T00:00:00/false/34
      this.router.navigate([
        '/plugins/backend-configuration-pn/compliances/case/'+task.sdkCaseId +'/'+ task.templateId+'/'+ task.propertyId+'/'+ task.deadlineTask.toISOString()+'/'+false+'/'+ task.complianceId,
      ], {relativeTo: this.route, queryParams: {
          reverseRoute: '/plugins/backend-configuration-pn/task-tracker/'}}).then();
    } else { // When clicking on a task that is not overdue, the user should be presented with the area rule planning modal for assigning workers
      this.openAreaRulePlanningModal.emit(task);
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes && changes.columnsFromDb && !changes.columnsFromDb.isFirstChange()) {
      this.recalculateColumns();
    }
    if (changes && changes.tasks && !changes.tasks.isFirstChange()) {
      this.initTable();
    }
  }

  /**
   * Sets the time components of a given date object to zero.
   * @param date The input date object.
   * @returns A new Date object with the time components set to zero.
   */
  private setDate(date: Date): Date {
    return set(date, {
      hours: 0,
      minutes: 0,
      seconds: 0,
      milliseconds: 0,
    });
  }
}
