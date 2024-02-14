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

namespace BackendConfiguration.Pn.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Models.PropertyAreas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microting.eForm.Infrastructure.Models;
using Microting.eFormApi.BasePn.Infrastructure.Models.API;
using Services.BackendConfigurationPropertyAreasService;

[Authorize]
[Route("api/backend-configuration-pn")]
public class PropertyAreasController : Controller
{
    private readonly IBackendConfigurationPropertyAreasService _backendConfigurationPropertyAreasService;
        
    public PropertyAreasController(IBackendConfigurationPropertyAreasService backendConfigurationPropertyAreasService)
    {
        _backendConfigurationPropertyAreasService = backendConfigurationPropertyAreasService;
    }

    [HttpGet]
    [Route("property-areas")]
    public Task<OperationDataResult<List<PropertyAreaModel>>> Read(int propertyId)
    {
        return _backendConfigurationPropertyAreasService.Read(propertyId);
    }

    [HttpPut]
    [Route("property-areas")]
    public Task<OperationResult> Update([FromBody] PropertyAreasUpdateModel updateModel)
    {
        return _backendConfigurationPropertyAreasService.Update(updateModel);
    }

    [HttpGet]
    [Route("area")]
    public Task<OperationDataResult<AreaModel>> ReadAreaByPropertyAreaId(int propertyAreaId)
    {
        return _backendConfigurationPropertyAreasService.ReadAreaByPropertyAreaId(propertyAreaId);
    }
        
    [HttpGet]
    [Route("area-by-rule-id")]
    public Task<OperationDataResult<AreaModel>> ReadAreaByAreaRuleId(int areaRuleId)
    {
        return _backendConfigurationPropertyAreasService.ReadAreaByAreaRuleId(areaRuleId);
    }

    [HttpPost]
    [Route("property-areas/create-entity-list/{propertyAreaId}")]
    public Task<OperationResult> CreateEntityList([FromBody] List<EntityItem> entityItemsListForCreate, int propertyAreaId)
    {
        return _backendConfigurationPropertyAreasService.CreateEntityList(entityItemsListForCreate, propertyAreaId);
    }
}