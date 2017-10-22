using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqBill : ResCommon
    {
        [DataMember]
        public int? BillId
        {
            get;
            set;
        }

        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public int? BillVendorId
        {
            get;
            set;
        }

        [DataMember]
        public int? BillNo
        {
            get;
            set;
        }

        [DataMember]
        public string Discount
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
        public string BillDate
        {
            get;
            set;
        }


        [DataMember]
        public string EndDate
        {
            get;
            set;
        }

        [DataMember]
        public string PaymentTerm
        {
            get;
            set;
        }

        [DataMember]
        public string Term
        {
            get;
            set;
        }

        [DataMember]
        public string PaymentMethod
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

        [DataMember]
        public int? ExpenseTypeId
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
        public string RefId
        {
            get;
            set;
        }
        [DataMember]
        public string AttachmentUrl
        {
            get;
            set;
        }
        [DataMember]
        public string Notes
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
        public string Tds
        {
            get;
            set;
        }

        [DataMember]
        public string TdsSection
        {
            get;
            set;
        }

        [DataMember]
        public bool? IsreverseChargeBill
        {
            get;
            set;
        }

        [DataMember]
        public bool? IsRecurring
        {
            get;
            set;
        }
        [DataMember]
        public bool? IsDeleted
        {
            get;
            set;
        }

        [DataMember]
        public string RecurringFrequency
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

        [DataMember]
        public int? BillParentId
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

        [DataMember]
        public string PlaceOfSupply
        {
            get;
            set;
        }
        [DataMember]
        public string PortCode
        {
            get;
            set;
        }
        [DataMember]
        public string SupplyType
        {
            get;
            set;
        }
        [DataMember]
        public string ExpenseBillType
        {
            get;
            set;
        }
        [DataMember]
        public string ExpenseBillHead
        {
            get;
            set;
        }
        [DataMember]
        public string IsReverseCharge
        {
            get;
            set;
        }
        [DataMember]
        public string Freight
        {
            get;
            set;
        }
        [DataMember]
        public string LabourCharge
        {
            get;
            set;
        }
        [DataMember]
        public string InsuranceAmount
        {
            get;
            set;
        }
        [DataMember]
        public string OtherCharge
        {
            get;
            set;
        }
        [DataMember]
        public string Cess
        {
            get;
            set;
        }
        [DataMember]
        public string Prefix
        {
            get;
            set;
        }
        [DataMember]
        public List<ReqBillItem> reqBillItemList
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqBillItem
    {
        [DataMember]
        public int? BillId
        {
            get;
            set;
        }

        [DataMember]
        public int? BillNo
        {
            get;
            set;
        }

        [DataMember]
        public int? ItemId
        {
            get;
            set;
        }
        [DataMember]
        public string ItemName
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

       
        [DataMember]
        public string Price
        {
            get;
            set;
        }

        [DataMember]
        public string Quantity
        {
            get;
            set;
        }

        [DataMember]
        public string Unit
        {
            get;
            set;
        }

        [DataMember]
        public string Tax
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
        public string Cgst
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

        [DataMember]
        public string Cess
        {
            get;
            set;
        }

        [DataMember]
        public string PurchaseType
        {
            get;
            set;
        }

        [DataMember]
        public string TaxCredit
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqBill_BillItem
    {
        //[DataMember]
        //public int? UserId
        //{
        //    get;
        //    set;
        //}

        [DataMember]
        public List<ReqBill> reqBillList
        {
            get;
            set;
        }

        [DataMember]
        public List<ReqBillItem> reqBillItemList
        {
            get;
            set;
        }

    }

    [DataContract]
    public class ReqBillPayment
    {
        [DataMember]
        public int? BillId
        {
            get;
            set;
        }

        [DataMember]
        public string PaymentDate
        {
            get;
            set;
        }

        [DataMember]
        public string PaymentMode
        {
            get;
            set;
        }

        [DataMember]
        public string Memo
        {
            get;
            set;
        }
    }


    [DataContract]
    public class ResBillList : ResCommon
    {
        [DataMember]
        public List<ReqBill> reqBillList
        {
            get;
            set;
        }
    }

}
