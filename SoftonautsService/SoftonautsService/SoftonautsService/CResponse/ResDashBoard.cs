using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResDashBoard
    {
        [DataMember]
        public List<ExpenseStatus> statusExpenseList
        {
            get;
            set;
        }

        [DataMember]
        public List<InvoiceStatus> statusInvoiceList
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

        //[DataMember]
        //public List<VendorDashBoard> VendorDashBoard
        //{
        //    get;
        //    set;
        //}

        //[DataMember]
        //public List<BillDashBoard> billDashBoard
        //{
        //    get;
        //    set;
        //}
    }

    [DataContract]
    public class BillTds : Tax
    {

    }

    [DataContract]
    public class Invoicetax : Tax
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
    public class ExpenseStatus
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
    public class InvoiceStatus
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
