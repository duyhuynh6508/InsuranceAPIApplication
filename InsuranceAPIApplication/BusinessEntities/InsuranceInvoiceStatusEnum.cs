using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public enum InsuranceInvoiceStatusEnum : int
    {
        Active = 1,
        OnHold = 2,
        InProgress = 3,
        Completed = 4,
        Deleted = 5
    }
}