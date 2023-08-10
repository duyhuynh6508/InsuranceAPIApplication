using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public enum HistoryTypeEnum : int
    {
        SubmitInvoice = 1000,
        EditInvoice = 1010,
        DeleteInvoice = 1020,
        CopyInvoice = 1030,
        ProcessClaim = 1040,
    }
}