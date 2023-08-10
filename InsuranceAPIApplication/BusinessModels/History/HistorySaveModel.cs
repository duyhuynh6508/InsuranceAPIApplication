using InsuranceAPIApplication.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessModels.History
{
    public class HistorySaveModel
    {
        public HistoryTypeEnum HistoryTypeId { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }
        public Guid ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
        public Guid ActionTo { get; set; }

    }
}