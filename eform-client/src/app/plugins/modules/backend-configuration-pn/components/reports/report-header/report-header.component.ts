import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  OnDestroy,
} from '@angular/core';
import { format } from 'date-fns';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReportPnGenerateModel } from '../../../models/report';
import { DateTimeAdapter } from '@danielmoncada/angular-datetime-picker';
import { SharedTagModel } from 'src/app/common/models';
import { AuthStateService } from 'src/app/common/store';
import { ReportQuery, ReportStateService } from '../store';
import { AutoUnsubscribe } from 'ngx-auto-unsubscribe';
import { Subscription } from 'rxjs';
import {MatIconRegistry} from '@angular/material/icon';
import {DomSanitizer} from '@angular/platform-browser';
import {ExcelIcon, WordIcon} from 'src/app/common/const';

@AutoUnsubscribe()
@Component({
  selector: 'app-items-planning-pn-report-header',
  templateUrl: './report-header.component.html',
  styleUrls: ['./report-header.component.scss'],
})
export class ReportHeaderComponent implements OnInit, OnDestroy {
  @Output()
  generateReport: EventEmitter<ReportPnGenerateModel> = new EventEmitter();
  @Output()
  downloadReport: EventEmitter<ReportPnGenerateModel> = new EventEmitter();
  @Output()
  downloadExcelReport: EventEmitter<ReportPnGenerateModel> = new EventEmitter();
  @Input() range: Date[];
  @Input() availableTags: SharedTagModel[] = [];
  generateForm: FormGroup;
  valueChangesSub$: Subscription;

  constructor(
    dateTimeAdapter: DateTimeAdapter<any>,
    private formBuilder: FormBuilder,
    private reportStateService: ReportStateService,
    private reportQuery: ReportQuery,
    authStateService: AuthStateService,
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
  ) {
    iconRegistry.addSvgIconLiteral('file-word', sanitizer.bypassSecurityTrustHtml(WordIcon));
    iconRegistry.addSvgIconLiteral('file-excel', sanitizer.bypassSecurityTrustHtml(ExcelIcon));
    dateTimeAdapter.setLocale(authStateService.currentUserLocale);
  }

  ngOnInit() {
    this.generateForm = this.formBuilder.group({
      dateRange: [
        this.reportQuery.pageSetting.dateRange,
        Validators.required,
      ],
      tagIds: [this.reportQuery.pageSetting.filters.tagIds],
    });
    this.valueChangesSub$ = this.generateForm.valueChanges.subscribe(
      (value: { tagIds: number[]; dateRange: Date[] }) => {
        if (value.dateRange.length) {
          const template = `yyyy-MM-dd'T00:00:00.000Z'`;
          const dateFrom = format(value.dateRange[0], template);
          const dateTo = format(value.dateRange[1], template);
          this.reportStateService.updateDateRange([dateFrom, dateTo]);
        }
      }
    );
    if (!!this.range[0].getDate()) {
      this.generateForm.get('dateRange').setValue(this.range);
    }
  }

  onSubmit() {
    const model = this.extractData();
    this.generateReport.emit(model);
  }

  onSave() {
    const model = this.extractData();
    model.type = 'docx';
    this.downloadReport.emit(model);
  }

  onExcelSave() {
    const model = this.extractData();
    model.type = 'xlsx';
    this.downloadExcelReport.emit(model);
  }

  private extractData(): ReportPnGenerateModel {
    return new ReportPnGenerateModel({
      dateFrom: this.reportQuery.pageSetting.dateRange[0],
      dateTo: this.reportQuery.pageSetting.dateRange[1],
      tagIds: [...this.reportQuery.pageSetting.filters.tagIds],
    });
  }

  addOrDeleteTagId(tag: SharedTagModel) {
    this.reportStateService.addOrRemoveTagIds(tag.id);
  }

  ngOnDestroy(): void {}
}
