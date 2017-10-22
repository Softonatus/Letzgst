using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqDashBoardContentTax
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public string Type
        {
            get;
            set;
        }

        [DataMember]
        public int? Month
        {
            get;
            set;
        }

        [DataMember]
        public int? CurrentUser
        {
            get;
            set;
        }

    }
    
    [DataContract]
    public class ReqDashBoard
    {
        [DataMember]
        public List<ReqExpenseStatus> statusExpenseList
        {
            get;
            set;
        }

        [DataMember]
        public List<ReqInvoiceStatus> statusInvoiceList
        {
            get;
            set;
        }

        [DataMember]
        public string billTotalTax
        {
            get;
            set;
        }

        [DataMember]
        public string billCgst
        {
            get;
            set;
        }

        [DataMember]
        public string billSgst
        {
            get;
            set;
        }

        [DataMember]
        public string billIgst
        {
            get;
            set;
        }

        [DataMember]
        public string billUtgst
        {
            get;
            set;
        }

        [DataMember]
        public string invoiceTotalTax
        {
            get;
            set;
        }

        [DataMember]
        public string invoiceCgst
        {
            get;
            set;
        }

        [DataMember]
        public string invoiceSgst
        {
            get;
            set;
        }

        [DataMember]
        public string invoiceIgst
        {
            get;
            set;
        }

        [DataMember]
        public string invoiceUtgst
        {
            get;
            set;
        }
    }

    [DataContract]
    public class BillTds : Tax
    {

    }

    [DataContract]
    public class ReqInvoicetax : Tax
    {

    }

    [DataContract]
    public class Tax
    {
        [DataMember]
        public string TotalTax
        {
            get;
            set;
        }

        [DataMember]
        public string Cgst
        {
            get;
            set;
        }

        [DataMember]
        public string Sgst
        {
            get;
            set;
        }

        [DataMember]
        public string Igst
        {
            get;
            set;
        }

        [DataMember]
        public string Utgst
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqExpenseStatus
    {
        [DataMember]
        public int? StatusCount
        {
            get;
            set;
        }

        [DataMember]
        public string Status
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqInvoiceStatus
    {
        [DataMember]
        public int? StatusCount
        {
            get;
            set;
        }

        [DataMember]
        public string Status
        {
            get;
            set;
        }
    }

    [DataContract]
    public class VendorDashBoard
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }

        [DataMember]
        public string VendorName
        {
            get;
            set;
        }

        [DataMember]
        public string PhoneNo
        {
            get;
            set;
        }
        [DataMember]
        public string State
        {
            get;
            set;
        }
    }

    [DataContract]
    public class BillDashBoard
    {
        [DataMember]
        public int? BillId
        {
            get;
            set;
        }

        [DataMember]
        public string VendorName
        {
            get;
            set;
        }

        [DataMember]
        public string ExpenseType
        {
            get;
            set;
        }

        [DataMember]
        public string TotalAmount
        {
            get;
            set;
        }

        [DataMember]
        public string DueDate
        {
            get;
            set;
        }
    }

}