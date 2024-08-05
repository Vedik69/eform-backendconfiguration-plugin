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

using System;
using System.Collections.Generic;

namespace BackendConfiguration.Pn.Infrastructure.Models.Report;

public class ReportEformItemModel
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public DateTime? MicrotingSdkCaseDoneAt { get; set; }
    public DateTime ServerTime { get; set; }
    public int MicrotingSdkCaseId { get; set; }
    public int eFormId { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public string DoneBy { get; set; } // worker name
    public string EmployeeNo { get; set; }
    public int PostsCount { get; set; }
    public int ImagesCount { get; set; }
    public string PropertyName { get; set; }
    public List<KeyValuePair<string, string>> CaseFields { get; set; } = [];
}