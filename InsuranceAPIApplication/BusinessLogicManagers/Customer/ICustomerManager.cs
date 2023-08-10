using InsuranceAPIApplication.BusinessModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPIApplication.BusinessLogicManagers.Customer
{
    public interface ICustomerManager
    {
        CustomerErrorModel ValidateForSaving(CustomerSaveModel model);

        Guid InsertCustomer(CustomerSaveModel model);
    }
}
