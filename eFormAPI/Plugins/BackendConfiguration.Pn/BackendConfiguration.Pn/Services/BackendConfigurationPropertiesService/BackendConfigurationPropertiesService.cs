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

namespace BackendConfiguration.Pn.Services.BackendConfigurationPropertiesService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BackendConfigurationLocalizationService;
    using Infrastructure.Models.Properties;
    using Microsoft.EntityFrameworkCore;
    using Microting.eForm.Infrastructure.Constants;
    using Microting.eFormApi.BasePn.Abstractions;
    using Microting.eFormApi.BasePn.Infrastructure.Helpers;
    using Microting.eFormApi.BasePn.Infrastructure.Models.API;
    using Microting.eFormApi.BasePn.Infrastructure.Models.Common;
    using Microting.EformBackendConfigurationBase.Infrastructure.Data;
    using Microting.EformBackendConfigurationBase.Infrastructure.Data.Entities;

    public class BackendConfigurationPropertiesService: IBackendConfigurationPropertiesService
    {
        //private readonly IEFormCoreService _coreHelper;
        private readonly IBackendConfigurationLocalizationService _backendConfigurationLocalizationService;
        private readonly IUserService _userService;
        private readonly BackendConfigurationPnDbContext _backendConfigurationPnDbContext;

        public BackendConfigurationPropertiesService(
            //IEFormCoreService coreHelper,
            IUserService userService,
            BackendConfigurationPnDbContext backendConfigurationPnDbContext,
            IBackendConfigurationLocalizationService backendConfigurationLocalizationService)
        {
            //_coreHelper = coreHelper;
            _userService = userService;
            _backendConfigurationLocalizationService = backendConfigurationLocalizationService;
            _backendConfigurationPnDbContext = backendConfigurationPnDbContext;
        }

        public async Task<OperationDataResult<Paged<PropertiesModel>>> Index(ProperiesRequesModel request)
        {
            try
            {
                // get query
                var propertiesQuery = _backendConfigurationPnDbContext.Properties
                    .Where(x => x.WorkflowState != Constants.WorkflowStates.Removed);

                // add sort
                //propertiesQuery = QueryHelper.AddSortToQuery(propertiesQuery, request.Sort, request.IsSortDsc);

                // add filtering
                //if (!string.IsNullOrEmpty(request.NameFilter))
                //{
                //    propertiesQuery = QueryHelper
                //        .AddFilterToQuery(propertiesQuery, new List<string>
                //        {
                //            "Name",
                //            "CHR",
                //            "Address",
                //        }, request.NameFilter);
                //}

                // get total
                var total = await propertiesQuery.Select(x => x.Id).CountAsync();

                var properties = new List<PropertiesModel>();

                if (total > 0)
                {
                    // pagination
                    //propertiesQuery = propertiesQuery
                    //    .Skip(request.Offset)
                    //    .Take(request.PageSize);

                    // add select to query and get from db
                    properties = await propertiesQuery
                        .Select(x => new PropertiesModel
                        {
                            Id = x.Id,
                            PropertyAddressType = x.Address,
                            PropertyCHRNumber = x.CHR,
                            PropertyName = x.Name,
                        }).ToListAsync();
                }

                return new OperationDataResult<Paged<PropertiesModel>>(true,
                    new Paged<PropertiesModel> {Entities = properties, Total = total});
            }
            catch (Exception ex)
            {
                Log.LogException(ex.Message);
                Log.LogException(ex.StackTrace);
                return new OperationDataResult<Paged<PropertiesModel>>(false, _backendConfigurationLocalizationService.GetString("ErrorWhileObtainingProperties"));
            }
        }

        public async Task<OperationResult> Create(PropertiesCreateModel propertiesCreateModel)
        {
            try
            {
                var newProperty = new Properties
                {
                    Address = propertiesCreateModel.PropertyAddressType,
                    CHR = propertiesCreateModel.PropertyCHRNumber,
                    Name = propertiesCreateModel.PropertyName,
                    CreatedByUserId = _userService.UserId,
                };
                await newProperty.Create(_backendConfigurationPnDbContext);
                return new OperationResult(true, _backendConfigurationLocalizationService.GetString("SuccessfullyCreatingProperties"));
            }
            catch (Exception e)
            {
                Log.LogException(e.Message);
                Log.LogException(e.StackTrace);
                return new OperationResult(false, _backendConfigurationLocalizationService.GetString("ErrorWhileCreatingProperties"));
            }
        }

        public async Task<OperationDataResult<PropertiesModel>> Read(int id)
        {
            try
            {
                var property = await _backendConfigurationPnDbContext.Properties
                    .Where(x => x.WorkflowState != Constants.WorkflowStates.Removed)
                    .Where(x => x.Id == id)
                    .Select(x => new PropertiesModel()
                    {
                        Id = x.Id,
                        PropertyAddressType = x.Address,
                        PropertyCHRNumber = x.CHR,
                        PropertyName = x.Name,
                    })
                    .FirstOrDefaultAsync();

                if (property == null)
                {
                    return new OperationDataResult<PropertiesModel>(false, _backendConfigurationLocalizationService.GetString("PropertyNotFound"));
                }

                return new OperationDataResult<PropertiesModel>(true, property);
            }
            catch (Exception e)
            {
                Log.LogException(e.Message);
                Log.LogException(e.StackTrace);
                return new OperationDataResult<PropertiesModel>(false, _backendConfigurationLocalizationService.GetString("ErrorWhileReadProperty"));
            }
        }

        public async Task<OperationResult> Update(PropertiesModel updateModel)
        {
            try
            {
                var property = await _backendConfigurationPnDbContext.Properties
                    .Where(x => x.Id == updateModel.Id)
                    .Where(x => x.WorkflowState != Constants.WorkflowStates.Removed)
                    .FirstOrDefaultAsync();

                if (property == null)
                {
                    return new OperationResult(false, _backendConfigurationLocalizationService.GetString("PropertyNotFound"));
                }

                property.Address = updateModel.PropertyAddressType;
                property.CHR = updateModel.PropertyCHRNumber;
                property.Name = updateModel.PropertyName;
                property.UpdatedByUserId = _userService.UserId;

                await property.Update(_backendConfigurationPnDbContext);

                return new OperationResult(true, _backendConfigurationLocalizationService.GetString("SuccessfullyUpdateProperties"));
            }
            catch (Exception e)
            {
                Log.LogException(e.Message);
                Log.LogException(e.StackTrace);
                return new OperationResult(false, _backendConfigurationLocalizationService.GetString("ErrorWhileUpdateProperties"));
            }
        }

        public async Task<OperationResult> Delete(int id)
        {
            try
            {
                var property = await _backendConfigurationPnDbContext.Properties
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (property == null)
                {
                    return new OperationResult(false, _backendConfigurationLocalizationService.GetString("PropertyNotFound"));
                }
                
                property.UpdatedByUserId = _userService.UserId;

                await property.Delete(_backendConfigurationPnDbContext);

                return new OperationResult(true, _backendConfigurationLocalizationService.GetString("SuccessfullyDeleteProperties"));
            }
            catch (Exception e)
            {
                Log.LogException(e.Message);
                Log.LogException(e.StackTrace);
                return new OperationResult(false, _backendConfigurationLocalizationService.GetString("ErrorWhileDeleteProperties"));
            }
        }

        public async Task<OperationDataResult<List<CommonDictionaryModel>>> GetCommonDictionary()
        {
            try
            {
                var properties = await _backendConfigurationPnDbContext.Properties
                    .Where(x => x.WorkflowState != Constants.WorkflowStates.Removed)
                    .Select(x => new CommonDictionaryModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = "",
                    }).ToListAsync(); ;
                return new OperationDataResult<List<CommonDictionaryModel>>(true, properties);
            }
            catch (Exception ex)
            {
                Log.LogException(ex.Message);
                Log.LogException(ex.StackTrace);
                return new OperationDataResult<List<CommonDictionaryModel>>(false, _backendConfigurationLocalizationService.GetString("ErrorWhileObtainingProperties"));
            }
        }
    }
}
