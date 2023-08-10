using InsuranceAPIApplication.BusinessModels.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPIApplication.BusinessLogicManagers.History
{
    public interface IHistoryManager
    {
        void InsertHistory(HistorySaveModel historySaveModel);
    }
}
