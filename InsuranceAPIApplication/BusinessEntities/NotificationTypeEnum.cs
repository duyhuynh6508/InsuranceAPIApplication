using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public enum NotificationTypeEnum : byte
    {
        InsuranceExpired = 1,
        RenewInsurance = 2,
        DeleteInsurance = 3
    }
}