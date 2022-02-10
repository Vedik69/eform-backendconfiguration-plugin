import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {
  ComplianceCasePageComponent
} from 'src/app/plugins/modules/backend-configuration-pn/modules/compliance/components/compliance-case/compliance-case-page/compliance-case-page.component';

const routes: Routes = [
  {path: ':sdkCaseId/:templateId/:propertyId/:deadline/:thirtyDays/:complianceId', component: ComplianceCasePageComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComplianceCaseRoutingModule { }
