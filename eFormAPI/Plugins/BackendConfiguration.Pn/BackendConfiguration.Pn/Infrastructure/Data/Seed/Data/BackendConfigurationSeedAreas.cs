﻿/*
The MIT License (MIT)

Copyright (c) 2007 - 2021 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace BackendConfiguration.Pn.Infrastructure.Data.Seed.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Microting.EformBackendConfigurationBase.Infrastructure.Data.Entities;
    using Microting.EformBackendConfigurationBase.Infrastructure.Enum;

    public static class BackendConfigurationSeedAreas
    {
        public static int LastIndexAreaRules => AreasSeed.SelectMany(x => x.AreaRules).Count();

        public static List<Area> AreasSeed => new()
        {
            new Area
            {
                Id = 1,
                Name = "01. Environmental Management (kun IE-husdyrbrug)",
                Description = @"https://www.microting.dk/eform/landbrug/01-milj%C3%B8ledelse",
                Type = AreaTypesEnum.Type1,
                AreaRules =new List<AreaRule>()
                {
                    new()
                    {
                        Id = 1,
                        EformName = "01. Vandforbrug",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "01. Vandforbrug" },
                            new() { LanguageId = 2, Name = "01. Water consumption" },
                            new() { LanguageId = 3, Name = "01. Wasserverbrauch" }
                        },
                    },
                    new()
                    {
                        Id = 2,
                        EformName = "01. Elforbrug",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "01. Elforbrug" },
                            new() { LanguageId = 2, Name = "01. Electricity consumption" },
                            new() { LanguageId = 3, Name = "01. Stromverbrauch" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new() {
                        AreaId = 1,
                        Name = "01. Environmental Management (kun IE-husdyrbrug)",
                        Description = @"https://www.microting.dk/eform/landbrug/01-milj%C3%B8ledelse",
                        LanguageId = 1
                    },
                    new() {
                        AreaId = 1,
                        Name = "01. Environmental Management (kun IE-husdyrbrug)",
                        Description = @"https://www.microting.dk/eform/landbrug/01-milj%C3%B8ledelse",
                        LanguageId = 2
                    },
                    new() {
                        AreaId = 1,
                        Name = "01. Environmental Management (kun IE-husdyrbrug)",
                        Description = @"https://www.microting.dk/eform/landbrug/01-milj%C3%B8ledelse",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 2,
                Name = "02. Contingency",
                Description = @"https://www.microting.dk/eform/landbrug/02-beredskab",
                Type = AreaTypesEnum.Type1,
                AreaRules = new List<AreaRule>()
                {
                    new()
                    {
                        Id = 3,
                        EformName = "02. Brandudstyr",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "02. Brandudstyr" },
                            new() { LanguageId = 2, Name = "02. Fire equipment" },
                            new() { LanguageId = 3, Name = "02. Feuer-Ausrüstung" }
                        },
                    },
                    new()
                    {
                        Id = 4,
                        EformName = "02. Sikkerhedsudstyr/værnemidler",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "02. Sikkerhedsudstyr/værnemidler" },
                            new() { LanguageId = 2, Name = "02. Safety equipment / protective equipment" },
                            new() { LanguageId = 3, Name = "02. Sicherheitsausrüstung / Schutzausrüstung" }
                        },
                    },
                    new()
                    {
                        Id = 5,
                        EformName = "02. Førstehjælp",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "02. Førstehjælp" },
                            new() { LanguageId = 2, Name = "02. First aid" },
                            new() { LanguageId = 3, Name = "02. Erste Hilfe" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 2,
                        Name = "02. Contingency",
                        Description = @"https://www.microting.dk/eform/landbrug/02-beredskab",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 2,
                        Name = "02. Contingency",
                        Description = @"https://www.microting.dk/eform/landbrug/02-beredskab",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 2,
                        Name = "02. Contingency",
                        Description = @"https://www.microting.dk/eform/landbrug/02-beredskab",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 3,
                Name = "03. Slurry tanks",
                Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                Type = AreaTypesEnum.Type2,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 3,
                        Name = "03. Slurry tanks",
                        Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 3,
                        Name = "03. Slurry tanks",
                        Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 3,
                        Name = "03. Slurry tanks",
                        Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 4,
                Name = "04. Feeding documentation (kun IE-husdyrbrug)",
                Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 4,
                        Name = "04. Feeding documentation (kun IE-husdyrbrug)",
                        Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 4,
                        Name = "04. Feeding documentation (kun IE-husdyrbrug)",
                        Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 4,
                        Name = "04. Feeding documentation (kun IE-husdyrbrug)",
                        Description = @"https://www.microting.dk/eform/landbrug/03-gyllebeholdere",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 5,
                Name = "05. Stable preparations and tail bite documentation",
                Description = @"https://www.microting.dk/eform/landbrug/05-klarg%C3%B8ring-af-stalde-og-dokumentation-af-halebid",
                Type = AreaTypesEnum.Type3,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 5,
                        Name = "05. Stable preparations and tail bite documentation",
                        Description = @"https://www.microting.dk/eform/landbrug/05-klarg%C3%B8ring-af-stalde-og-dokumentation-af-halebid",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 5,
                        Name = "05. Stable preparations and tail bite documentation",
                        Description = @"https://www.microting.dk/eform/landbrug/05-klarg%C3%B8ring-af-stalde-og-dokumentation-af-halebid",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 5,
                        Name = "05. Stable preparations and tail bite documentation",
                        Description = @"https://www.microting.dk/eform/landbrug/05-klarg%C3%B8ring-af-stalde-og-dokumentation-af-halebid",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 6,
                Name = "06. Silos",
                Description = @"https://www.microting.dk/eform/landbrug/06-fodersiloer",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 6,
                        Name = "06. Silos",
                        Description = @"https://www.microting.dk/eform/landbrug/06-fodersiloer",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 6,
                        Name = "06. Silos",
                        Description = @"https://www.microting.dk/eform/landbrug/06-fodersiloer",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 6,
                        Name = "06. Silos",
                        Description = @"https://www.microting.dk/eform/landbrug/06-fodersiloer",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 7,
                Name = "07. Pest control",
                Description = @"https://www.microting.dk/eform/landbrug/07-skadedyr",
                Type = AreaTypesEnum.Type1,
                AreaRules = new List<AreaRule>()
                {
                    new()
                    {
                        Id = 6,
                        EformName = "07. Rotter",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "07. Rotter" },
                            new() { LanguageId = 2, Name = "07. Rats" },
                            new() { LanguageId = 3, Name = "07. Ratten" }
                        },
                    },
                    new()
                    {
                        Id = 7,
                        EformName = "07. Fluer",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "07. Fluer" },
                            new() { LanguageId = 2, Name = "07. Flies" },
                            new() { LanguageId = 3, Name = "07. Fliegen" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 7,
                        Name = "07. Pest control",
                        Description = @"https://www.microting.dk/eform/landbrug/07-skadedyr",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 7,
                        Name = "07. Pest control",
                        Description = @"https://www.microting.dk/eform/landbrug/07-skadedyr",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 7,
                        Name = "07. Pest control",
                        Description = @"https://www.microting.dk/eform/landbrug/07-skadedyr",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 8,
                Name = "08. Aircleaning",
                Description = @"https://www.microting.dk/eform/landbrug/08-luftrensning",
                Type = AreaTypesEnum.Type1,
                AreaRules = new List<AreaRule>()
                {
                    new()
                    {
                        Id = 8,
                        EformName = "08. Luftrensning timer",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "08. Luftrensning timer" },
                            new() { LanguageId = 2, Name = "08. Air cleaning timer" },
                            new() { LanguageId = 3, Name = "08. Luftreinigungstimer" }
                        },
                    },
                    new()
                    {
                        Id = 9,
                        EformName = "08. Luftrensning serviceaftale",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "08. Luftrensning serviceaftale" },
                            new() { LanguageId = 2, Name = "08. Air cleaning service agreement" },
                            new() { LanguageId = 3, Name = "08. Luftreinigungsservicevertrag" }
                        },
                    },
                    new()
                    {
                        Id = 10,
                        EformName = "08. Luftrensning driftsstop",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "08. Luftrensning driftsstop" },
                            new() { LanguageId = 2, Name = "08. Air cleaning downtime" },
                            new() { LanguageId = 3, Name = "08. Ausfallzeit der Luftreinigung" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 8,
                        Name = "08. Aircleaning",
                        Description = @"https://www.microting.dk/eform/landbrug/08-luftrensning",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 8,
                        Name = "08. Aircleaning",
                        Description = @"https://www.microting.dk/eform/landbrug/08-luftrensning",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 8,
                        Name = "08. Aircleaning",
                        Description = @"https://www.microting.dk/eform/landbrug/08-luftrensning",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 9,
                Name = "09. Acidification",
                Description = @"https://www.microting.dk/eform/landbrug/09-forsuring",
                Type = AreaTypesEnum.Type1,
                AreaRules = new List<AreaRule>()
                {
                    new()
                    {
                        Id = 11,
                        EformName = "09. Forsuring pH værdi",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "09. Forsuring pH værdi" },
                            new() { LanguageId = 2, Name = "09. Acidification pH value" },
                            new() { LanguageId = 3, Name = "09. Ansäuerung pH-Wert" }
                        },
                    },
                    new()
                    {
                        Id = 12,
                        EformName = "09. Forsuring serviceaftale",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "09. Forsuring serviceaftale" },
                            new() { LanguageId = 2, Name = "09. Acidification service agreement" },
                            new() { LanguageId = 3, Name = "09. Säuerungsservicevertrag" }
                        },
                    },
                    new()
                    {
                        Id = 13,
                        EformName = "09. Forsuring driftsstop",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "09. Forsuring driftsstop" },
                            new() { LanguageId = 2, Name = "09. Acidification downtime" },
                            new() { LanguageId = 3, Name = "09. Ausfallzeit der Ansäuerung" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 9,
                        Name = "09. Acidification",
                        Description = @"https://www.microting.dk/eform/landbrug/09-forsuring",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 9,
                        Name = "09. Acidification",
                        Description = @"https://www.microting.dk/eform/landbrug/09-forsuring",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 9,
                        Name = "09. Acidification",
                        Description = @"https://www.microting.dk/eform/landbrug/09-forsuring",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 10,
                Name = "10. Heat pumps",
                Description = @"https://www.microting.dk/eform/landbrug/10-varmepumper",
                Type = AreaTypesEnum.Type1,
                AreaRules = new List<AreaRule>()
                {
                    new()
                    {
                        Id = 14,
                        EformName = "10. Varmepumpe timer og energi",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "10. Varmepumpe timer og energi" },
                            new() { LanguageId = 2, Name = "10. Heat pumps hours and energy" },
                            new() { LanguageId = 3, Name = "10. Wärmepumpenstunden und Energie" }
                        },
                    },
                    new()
                    {
                        Id = 15,
                        EformName = "10. Varmepumpe serviceaftale",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "10. Varmepumpe serviceaftale" },
                            new() { LanguageId = 2, Name = "10. Heat pump service agreement" },
                            new() { LanguageId = 3, Name = "10. Servicevertrag für Wärmepumpen" }
                        },
                    },
                    new()
                    {
                        Id = 16,
                        EformName = "10. Varmepumpe driftsstop",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "10. Varmepumpe driftsstop" },
                            new() { LanguageId = 2, Name = "10. Heat pump downtime" },
                            new() { LanguageId = 3, Name = "10. Ausfallzeit der Wärmepumpe" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 11,
                        Name = "10. Heat pumps",
                        Description = @"https://www.microting.dk/eform/landbrug/10-varmepumper",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 11,
                        Name = "10. Heat pumps",
                        Description = @"https://www.microting.dk/eform/landbrug/10-varmepumper",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 11,
                        Name = "10. Heat pumps",
                        Description = @"https://www.microting.dk/eform/landbrug/10-varmepumper",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 11,
                Name = "11. Pellot stoves",
                Description = @"https://www.microting.dk/eform/landbrug/11-pillefyr",
                Type = AreaTypesEnum.Type1,
                AreaRules = new List<AreaRule>()
                {
                    new()
                    {
                        Id = 17,
                        EformName = "11. Pillefyr",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "11. Pillefyr" },
                            new() { LanguageId = 2, Name = "11. Pellet stove" },
                            new() { LanguageId = 3, Name = "11. Pelletofen" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 11,
                        Name = "11. Pellot stoves",
                        Description = @"https://www.microting.dk/eform/landbrug/11-pillefyr",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 11,
                        Name = "11. Pellot stoves",
                        Description = @"https://www.microting.dk/eform/landbrug/11-pillefyr",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 11,
                        Name = "11. Pellot stoves",
                        Description = @"https://www.microting.dk/eform/landbrug/11-pillefyr",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 12,
                Name = "12. Environmentally hazardous substances",
                Description = @"https://www.microting.dk/eform/landbrug/12-milj%C3%B8farlige-stoffer",
                Type = AreaTypesEnum.Type1,
                AreaRules = new List<AreaRule>()
                {
                    new()
                    {
                        Id = 18,
                        EformName = "12. Dieseltank",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "12. Dieseltank" },
                            new() { LanguageId = 2, Name = "12. Diesel tank" },
                            new() { LanguageId = 3, Name = "12. Dieseltank" }
                        },
                    },
                    new()
                    {
                        Id = 19,
                        EformName = "12. Motor- og spildolie",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "12. Motor- og spildolie" },
                            new() { LanguageId = 2, Name = "12. Motor oil and waste oil" },
                            new() { LanguageId = 3, Name = "12. Motoröl und Altöl" }
                        },
                    },
                    new()
                    {
                        Id = 20,
                        EformName = "12. Kemi",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "12. Kemi" },
                            new() { LanguageId = 2, Name = "12. Chemistry" },
                            new() { LanguageId = 3, Name = "12. Chemie" }
                        },
                    },
                    new()
                    {
                        Id = 21,
                        EformName = "12. Affald og farligt affald",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "12. Affald og farligt affald" },
                            new() { LanguageId = 2, Name = "12. Trash" },
                            new() { LanguageId = 3, Name = "12. Müll" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 12,
                        Name = "12. Environmentally hazardous substances",
                        Description = @"https://www.microting.dk/eform/landbrug/12-milj%C3%B8farlige-stoffer",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 12,
                        Name = "12. Environmentally hazardous substances",
                        Description = @"https://www.microting.dk/eform/landbrug/12-milj%C3%B8farlige-stoffer",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 12,
                        Name = "12. Environmentally hazardous substances",
                        Description = @"https://www.microting.dk/eform/landbrug/12-milj%C3%B8farlige-stoffer",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 13,
                Name = "13. Work Place Assesment",
                Description = @"https://www.microting.dk/eform/landbrug/13-apv",
                Type = AreaTypesEnum.Type4,
                AreaRules = new List<AreaRule>
                {
                    new()
                    {
                        Id = 22,
                        AreaId = 13,
                        EformName = "13. APV Medarbejer",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "13. APV Medarbejer" },
                            new() { LanguageId = 2, Name = "13. WPA Agriculture" },
                            new() { LanguageId = 3, Name = "13. Arbeitsplatz Landwirtschaft" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 13,
                        Name = "13. Work Place Assesment",
                        Description = @"https://www.microting.dk/eform/landbrug/13-apv",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 13,
                        Name = "13. Work Place Assesment",
                        Description = @"https://www.microting.dk/eform/landbrug/13-apv",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 13,
                        Name = "13. Work Place Assesment",
                        Description = @"https://www.microting.dk/eform/landbrug/13-apv",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 14,
                Name = "14. Machines",
                Description = @"https://www.microting.dk/eform/landbrug/14-maskiner",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 14,
                        Name = "14. Machines",
                        Description = @"https://www.microting.dk/eform/landbrug/14-maskiner",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 14,
                        Name = "14. Machines",
                        Description = @"https://www.microting.dk/eform/landbrug/14-maskiner",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 14,
                        Name = "14. Machines",
                        Description = @"https://www.microting.dk/eform/landbrug/14-maskiner",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 15,
                Name = "15. Inspection of power tools",
                Description = @"https://www.microting.dk/eform/landbrug/15-elv%C3%A6rkt%C3%B8j",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 15,
                        Name = "15. Inspection of power tools",
                        Description = @"https://www.microting.dk/eform/landbrug/15-elv%C3%A6rkt%C3%B8j",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 15,
                        Name = "15. Inspection of power tools",
                        Description = @"https://www.microting.dk/eform/landbrug/15-elv%C3%A6rkt%C3%B8j",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 15,
                        Name = "15. Inspection of power tools",
                        Description = @"https://www.microting.dk/eform/landbrug/15-elv%C3%A6rkt%C3%B8j",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 16,
                Name = "16. Inspection of wagons",
                Description = @"https://www.microting.dk/eform/landbrug/16-stiger",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 16,
                        Name = "16. Inspection of wagons",
                        Description = @"https://www.microting.dk/eform/landbrug/16-stiger",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 16,
                        Name = "16. Inspection of wagons",
                        Description = @"https://www.microting.dk/eform/landbrug/16-stiger",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 16,
                        Name = "16. Inspection of wagons",
                        Description = @"https://www.microting.dk/eform/landbrug/16-stiger",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 17,
                Name = "17. Inspection of ladders",
                Description = @"https://www.microting.dk/eform/landbrug/17-brandslukkere",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 17,
                        Name = "17. Inspection of ladders",
                        Description = @"https://www.microting.dk/eform/landbrug/17-brandslukkere",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 17,
                        Name = "17. Inspection of ladders",
                        Description = @"https://www.microting.dk/eform/landbrug/17-brandslukkere",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 17,
                        Name = "17. Inspection of ladders",
                        Description = @"https://www.microting.dk/eform/landbrug/17-brandslukkere",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 18,
                Name = "18. Alarm",
                Description = @"https://www.microting.dk/eform/landbrug/18-alarm",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 18,
                        Name = "18. Alarm",
                        Description = @"https://www.microting.dk/eform/landbrug/18-alarm",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 18,
                        Name = "18. Alarm",
                        Description = @"https://www.microting.dk/eform/landbrug/18-alarm",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 18,
                        Name = "18. Alarm",
                        Description = @"https://www.microting.dk/eform/landbrug/18-alarm",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 19,
                Name = "19. Ventilation",
                Description = @"https://www.microting.dk/eform/landbrug/19-ventilation",
                Type = AreaTypesEnum.Type1,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 19,
                        Name = "19. Ventilation",
                        Description = @"https://www.microting.dk/eform/landbrug/19-ventilation",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 19,
                        Name = "19. Ventilation",
                        Description = @"https://www.microting.dk/eform/landbrug/19-ventilation",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 19,
                        Name = "19. Ventilation",
                        Description = @"https://www.microting.dk/eform/landbrug/19-ventilation",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 20,
                Name = "20. Recurring tasks (mon-sun)",
                Description = @"https://www.microting.dk/eform/landbrug/20-arbejdsopgaver",
                Type = AreaTypesEnum.Type5,
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 20,
                        Name = "20. Recurring tasks (mon-sun)",
                        Description = @"https://www.microting.dk/eform/landbrug/20-arbejdsopgaver",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 20,
                        Name = "20. Recurring tasks (mon-sun)",
                        Description = @"https://www.microting.dk/eform/landbrug/20-arbejdsopgaver",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 20,
                        Name = "20. Recurring tasks (mon-sun)",
                        Description = @"https://www.microting.dk/eform/landbrug/20-arbejdsopgaver",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 21,
                Name = "21. DANISH Standard",
                Description = @"https://www.microting.dk/eform/landbrug/21-danish-produktstandard",
                Type = AreaTypesEnum.Type4,
                AreaRules = new List<AreaRule>
                {
                    new()
                    {
                        Id = 23,
                        AreaId = 13,
                        EformName = "21. DANISH Produktstandard v_1_01",
                        AreaRuleTranslations = new List<AreaRuleTranslation>
                        {
                            new() { LanguageId = 1, Name = "21. DANISH Standard v. 1.01" },
                            new() { LanguageId = 2, Name = "21. DANISH Standard v. 1.01" },
                            new() { LanguageId = 3, Name = "21. DÄNISCHER Standard v. 1.01" }
                        },
                    },
                },
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 21,
                        Name = "21. DANISH Standard",
                        Description = @"https://www.microting.dk/eform/landbrug/21-danish-produktstandard",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 21,
                        Name = "21. DANISH Standard",
                        Description = @"https://www.microting.dk/eform/landbrug/21-danish-produktstandard",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 21,
                        Name = "21. DANISH Standard",
                        Description = @"https://www.microting.dk/eform/landbrug/21-danish-produktstandard",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 22,
                Name = "22. Sieve test",
                Description = @"https://www.microting.dk/eform/landbrug/22-sigtetest",
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 22,
                        Name = "22. Sieve test",
                        Description = @"https://www.microting.dk/eform/landbrug/22-sigtetest",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 22,
                        Name = "22. Sieve test",
                        Description = @"https://www.microting.dk/eform/landbrug/22-sigtetest",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 22,
                        Name = "22. Sieve test",
                        Description = @"https://www.microting.dk/eform/landbrug/22-sigtetest",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 23,
                Name = "23. Water consumption",
                Description = @"https://www.microting.dk/eform/landbrug/23-vandforbrug",
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 23,
                        Name = "23. Water consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/23-vandforbrug",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 23,
                        Name = "23. Water consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/23-vandforbrug",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 23,
                        Name = "23. Water consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/23-vandforbrug",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 24,
                Name = "24. Electricity consumption",
                Description = @"https://www.microting.dk/eform/landbrug/24-elforbrug",
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 24,
                        Name = "24. Electricity consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/24-elforbrug",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 24,
                        Name = "24. Electricity consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/24-elforbrug",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 24,
                        Name = "24. Electricity consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/24-elforbrug",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 25,
                Name = "25. Field irrigation consumption",
                Description = @"https://www.microting.dk/eform/landbrug/25-markvandingsforbrug",
                AreaTranslations = new List<AreaTranslation>()
                {
                    new()
                    {
                        AreaId = 25,
                        Name = "25. Field irrigation consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/25-markvandingsforbrug",
                        LanguageId = 1
                    },
                    new()
                    {
                        AreaId = 25,
                        Name = "25. Field irrigation consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/25-markvandingsforbrug",
                        LanguageId = 2
                    },
                    new()
                    {
                        AreaId = 25,
                        Name = "25. Field irrigation consumption",
                        Description = @"https://www.microting.dk/eform/landbrug/25-markvandingsforbrug",
                        LanguageId = 3
                    }
                }
            },
            new Area
            {
                Id = 26,
                Name = "100. Miscellaneous",
                Description = @"https://www.microting.dk/eform/landbrug/100-diverse",
                AreaTranslations = new List<AreaTranslation>()
                {
                    new() {
                        AreaId = 26,
                        Name = "100. Diverse",
                        Description = @"https://www.microting.dk/eform/landbrug/100-diverse",
                        LanguageId = 1
                    },
                    new() {
                        AreaId = 26,
                        Name = "100. Miscellaneous",
                        Description = @"https://www.microting.dk/eform/landbrug/100-diverse",
                        LanguageId = 2
                    },
                    new() {
                        AreaId = 26,
                        Name = "100. Sonstig",
                        Description = @"https://www.microting.dk/eform/landbrug/100-diverse",
                        LanguageId = 3
                    }
                }
            },
        };
    }
}