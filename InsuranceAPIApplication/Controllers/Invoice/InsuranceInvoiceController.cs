using InsuranceAPIApplication.BusinessEntities;
using InsuranceAPIApplication.BusinessLogicManagers.Customer;
using InsuranceAPIApplication.BusinessLogicManagers.History;
using InsuranceAPIApplication.BusinessLogicManagers.Invoice;
using InsuranceAPIApplication.BusinessModels.Customer;
using InsuranceAPIApplication.BusinessModels.History;
using InsuranceAPIApplication.BusinessModels.InsuranceInvoice;
using InsuranceAPIApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceAPIApplication.Controllers.Invoice
{
    public class InsuranceInvoiceController : BaseController
    {
        private IInsuranceInvoiceManager invoiceManager { get; }
        private IHistoryManager historyManager { get; set; }
        private ICustomerManager customerManager { get; set; }
        public InsuranceInvoiceController(IInsuranceInvoiceManager invoiceManager, IHistoryManager historyManager, ICustomerManager customerManager)
        {
            this.invoiceManager = invoiceManager;
            this.historyManager = historyManager;
            this.customerManager = customerManager;
        }

        public JsonResult GetInsuranceInvoices(int currentpage, int itemsPerpage, Guid customerId, int statusId, 
            string interventionDateFrom, string interventionDateTo, bool isDelete = false)
        {
            InsuranceInvoiceFilterErrors insuranceInvocieFilterErrorModel = new InsuranceInvoiceFilterErrors();
            PageListModel<InsuranceInvoicePageModel> invoices;

            insuranceInvocieFilterErrorModel.Validate(interventionDateFrom, interventionDateTo, out DateTime? dateFrom, out DateTime? dateTo);

            if (insuranceInvocieFilterErrorModel.isError)
            {
                return Json(new { isSucessfull = false, insuranceInvocieFilterErrorModel }, JsonRequestBehavior.AllowGet);
            }

            InsuranceInvoiceStatusEnum status = invoiceManager.GetInvoiceStatus(statusId);

            InsuranceInvoiceQueryFilter queryFilter = new InsuranceInvoiceQueryFilter(currentUser.UserGuid, customerId, status, dateFrom, dateTo , isDelete);

            invoices = invoiceManager.GetInsuranceInvoices(queryFilter, new PageQuery(currentpage, itemsPerpage));

            return Json(new { isSucessfull = false, invoices}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SubmitInsuranceInvoice(CustomerSaveModel customerSaveModel, InsuranceInvoiceSaveModel insuranceInvoiceSaveModel)
        {
            bool isSucessfull = false;
            CustomerErrorModel customerErrorModel = customerManager.ValidateForSaving(customerSaveModel);

            if (customerErrorModel.hasError())
            {
                return Json(new { isSucessfull, errorModel = customerErrorModel }, JsonRequestBehavior.AllowGet);
            }

            Guid customerGuid = customerManager.InsertCustomer(customerSaveModel);

            if(customerGuid == null || customerGuid == Guid.Empty)
            {
                return Json(new { isSucessfull, errorModel = customerErrorModel }, JsonRequestBehavior.AllowGet);
            }

            InsuranceInvoiceErrorModel errorModel = invoiceManager.ValidateForSaving(insuranceInvoiceSaveModel);
            
            if (errorModel.hasError())
            {
                return Json(new { isSucessfull, errorModel }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                string InvoiceNumber = invoiceManager.SubmitInsuranceInvoice(insuranceInvoiceSaveModel);

                if (!string.IsNullOrEmpty(InvoiceNumber))
                {
                    isSucessfull = true;

                    HistorySaveModel historySaveModel = new HistorySaveModel() { 
                        HistoryTypeId = HistoryTypeEnum.SubmitInvoice,
                        Description= $"Invoice @{InvoiceNumber} submit successfully",
                        ActionName="Submit invoice",
                        ActionBy = currentUser.UserGuid,
                        ActionDate = DateTime.Now
                    };

                    historyManager.InsertHistory(historySaveModel);
                }
            }
            catch
            {
                //errorModel.error = 
                return Json(new { isSucessfull, errorModel }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { isSucessfull }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteInvoice(Guid? invoiceGuid)
        {
            return null;
        }
    }
}