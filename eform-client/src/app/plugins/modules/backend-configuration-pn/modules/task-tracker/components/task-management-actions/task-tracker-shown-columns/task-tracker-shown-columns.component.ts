import {Component, EventEmitter, Inject, OnDestroy, OnInit} from '@angular/core';
import {AutoUnsubscribe} from 'ngx-auto-unsubscribe';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {TranslateService} from '@ngx-translate/core';
import {FormBuilder} from '@angular/forms';
import {Columns} from '../../../../../models';
import {FormControl, FormGroup} from '@angular/forms';

@AutoUnsubscribe()
@Component({
  selector: 'app-task-tracker-shown-columns-container',
  templateUrl: './task-tracker-shown-columns.component.html',
  styleUrls: ['./task-tracker-shown-columns.component.scss'],
})
export class TaskTrackerShownColumnsComponent implements OnInit, OnDestroy {
  public columnsChanged = new EventEmitter<Columns>();
  columns: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA) data: Columns,
    private translate: TranslateService,
    private _formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<TaskTrackerShownColumnsComponent>
  ) {
    this.columns = new FormGroup({
      property: new FormControl(data['property']),
      task: new FormControl(data['task']),
      tags: new FormControl(data['tags']),
      workers: new FormControl(data['workers']),
      start: new FormControl(data['start']),
      repeat: new FormControl(data['repeat']),
      deadline: new FormControl(data['deadline'])
    });
  }

  save() {
    this.columnsChanged.emit(this.columns.value);
  }

  hide() {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
