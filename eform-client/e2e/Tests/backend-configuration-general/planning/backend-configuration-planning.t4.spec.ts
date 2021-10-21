import loginPage from '../../../Page objects/Login.page';
import backendConfigurationPropertiesPage, {
  PropertyCreateUpdate,
} from '../../../Page objects/BackendConfiguration/BackendConfigurationProperties.page';
import { expect } from 'chai';
import { generateRandmString } from '../../../Helpers/helper-functions';
import backendConfigurationPropertyWorkersPage from '../../../Page objects/BackendConfiguration/BackendConfigurationPropertyWorkers.page';
import backendConfigurationAreaRulesPage, {
  AreaRulePlanningCreateUpdate,
} from '../../../Page objects/BackendConfiguration/BackendConfigurationAreaRules.page';
import { format, sub } from 'date-fns';
import itemsPlanningPlanningPage from '../../../Page objects/ItemsPlanning/ItemsPlanningPlanningPage';

const property: PropertyCreateUpdate = {
  name: generateRandmString(),
  chrNumber: generateRandmString(),
  address: generateRandmString(),
  selectedLanguages: [{ languageId: 1, languageName: 'Danish' }],
};
const workerForCreate = {
  name: generateRandmString(),
  surname: generateRandmString(),
  language: 'Danish',
  properties: [0],
};

describe('Backend Configuration Area Rules Planning Type4', function () {
  before(async () => {
    await loginPage.open('/auth');
    await loginPage.login();
    await backendConfigurationPropertiesPage.goToProperties();
    await backendConfigurationPropertiesPage.createProperty(property);
    await backendConfigurationPropertyWorkersPage.goToPropertyWorkers();
    await backendConfigurationPropertyWorkersPage.create(workerForCreate);
    await backendConfigurationPropertiesPage.goToProperties();
    const lastProperty = await backendConfigurationPropertiesPage.getLastPropertyRowObject();
    await lastProperty.editBindWithAreas([12]); // bind specific type4
    await lastProperty.openAreasViewModal(0); // go to area rule page
  });
  it('should create new planning from default area rule', async () => {
    const rowNum = await backendConfigurationAreaRulesPage.rowNum();
    expect(rowNum, 'have some non-default area rules').eq(1);
    const areaRule = await backendConfigurationAreaRulesPage.getFirstAreaRuleRowObject();
    const areaRulePlanning: AreaRulePlanningCreateUpdate = {
      workers: [{ workerNumber: 0 }],
    };
    await areaRule.createUpdatePlanning(areaRulePlanning, false, false);
    const areaRulePlanningCreated = await areaRule.readPlanning(false);
    expect(areaRulePlanningCreated.workers[0].name).eq(
      `${workerForCreate.name} ${workerForCreate.surname}`
    );
    expect(areaRulePlanningCreated.workers[0].checked).eq(true);
    await itemsPlanningPlanningPage.goToPlanningsPage();
    expect(
      await itemsPlanningPlanningPage.rowNum(),
      'items planning not create or create not correct'
    ).eq(1);
    const itemPlanning = await itemsPlanningPlanningPage.getLastPlanningRowObject();
    expect(itemPlanning.eFormName).eq('13. APV Medarbejer');
    expect(itemPlanning.name).eq(areaRule.name);
    expect(itemPlanning.folderName).eq(
      `${property.name} - 13. Arbejdstilsynets Landbrugs APV`
    );
    expect(itemPlanning.repeatEvery).eq(12);
    expect(itemPlanning.repeatType).eq('Måned');
    const workers = await itemPlanning.readPairing();
    expect([
      {
        workerName: `${workerForCreate.name} ${workerForCreate.surname}`,
        workerValue: true,
      },
    ]).deep.eq(workers);
    // browser.back();
    // await areaRule.createUpdatePlanning({ status: false }, false, false);
  });
  after(async () => {
    await backendConfigurationPropertiesPage.goToProperties();
    await backendConfigurationPropertiesPage.clearTable();
    await backendConfigurationPropertyWorkersPage.goToPropertyWorkers();
    await backendConfigurationPropertyWorkersPage.clearTable();
  });
});
