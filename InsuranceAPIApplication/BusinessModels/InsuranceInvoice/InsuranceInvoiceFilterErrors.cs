using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessModels.InsuranceInvoice
{
    public class InsuranceInvoiceFilterErrors
    {
        public string interventionDateFromErrorMessage;
        public string interventionDateToErrorMessage;
        public bool isError => !string.IsNullOrEmpty(interventionDateFromErrorMessage) || !string.IsNullOrEmpty(interventionDateToErrorMessage);

        public void Validate(string fromDate, string toDate, out DateTime? from, out DateTime? to)
        {
            from = DateTime.TryParse(fromDate, out DateTime fromTemp) ? fromTemp : (DateTime?)null;
            to = DateTime.TryParse(toDate, out DateTime toTemp) ? toTemp : (DateTime?)null;

            if (!string.IsNullOrEmpty(fromDate))
            {
                if (!from.HasValue)
                {
                    interventionDateFromErrorMessage = "Please enter a valid date";
                }
            }
            else if (!from.HasValue)
            {
                // Start date is a required field
                interventionDateFromErrorMessage = "Please enter a date";
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                if (!to.HasValue)
                {
                    interventionDateToErrorMessage = "Please enter a valid date";
                }
            }

            /* 
             * Start date with no end date is a valid filter, as it will just retrieve all items from start date into the future.
             * End date with no start date is invalid, because retrieving all past items would return too much.
             */

            if (from.HasValue && to.HasValue)
            {
                if (from.Value > to.Value)
                {
                    interventionDateToErrorMessage = "End date must be on or after the start date";
                }
            }

            if (to.HasValue && !from.HasValue && !isError)
            {
                // If only end date filter exists, force them to enter a start date
                interventionDateFromErrorMessage = "A start date filter must be set if an end date filter exists";
            }

            if (from.HasValue && !isError)
            {
                // If there is a from date, but no end date. Treat the end date like it's today for validation purposes.
                DateTime assumedEndDate = to.HasValue ? to.Value : DateTime.Today;
                if (from.Value.Date.AddYears(1) < assumedEndDate.Date)
                {
                    interventionDateFromErrorMessage = "Date period must be less than one year.";
                }
            }
        }
    }
}