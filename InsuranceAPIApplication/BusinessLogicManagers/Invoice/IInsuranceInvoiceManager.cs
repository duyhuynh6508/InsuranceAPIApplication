using InsuranceAPIApplication.BusinessEntities;
using InsuranceAPIApplication.BusinessModels.InsuranceInvoice;
using InsuranceAPIApplication.Controllers.Invoice;
using InsuranceAPIApplication.Helpers;

namespace InsuranceAPIApplication.BusinessLogicManagers.Invoice
{
    public interface IInsuranceInvoiceManager
    {
        InsuranceInvoiceStatusEnum GetInvoiceStatus(int statusId);

        PageListModel<InsuranceInvoicePageModel> GetInsuranceInvoices(InsuranceInvoiceQueryFilter queryFilter , PageQuery pageQuery);

        InsuranceInvoiceErrorModel ValidateForSaving(InsuranceInvoiceSaveModel model);

        string SubmitInsuranceInvoice(InsuranceInvoiceSaveModel model);
    }
}
