using InsuranceAPIApplication.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.Controllers.Invoice
{
    public class InsuranceInvoiceQueryFilter
    {
        public Guid? UserId { get; set; }
        public Guid? CustomerId { get; set; }
        public InsuranceInvoiceStatusEnum Status { get; set; } 
        public DateTime? InterventionDateFrom { get; set; }
        public DateTime? InterventionDateTo { get; set; }
        public bool isDelete { get; set; }

        public InsuranceInvoiceQueryFilter(Guid userGuid, Guid customerId, InsuranceInvoiceStatusEnum status, DateTime? dateFrom, DateTime? dateTo, bool isDelete)
        {
            UserId = userGuid;
            CustomerId = customerId;
            Status = status;
            InterventionDateFrom = dateFrom;
            InterventionDateTo = dateTo;
            this.isDelete = isDelete;
        }

    }
}