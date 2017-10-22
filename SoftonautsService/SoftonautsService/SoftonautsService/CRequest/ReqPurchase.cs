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
    public class ReqPurchase : ReqUserId
    {
        [DataMember]
        public int? PurchaseId
        {
            get;
            set;
        }

        [DataMember]
        public int? PurchaseVendorId
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
        public int? PoId
        {
            get;
            set;
        }

        [DataMember]
        public string PoDate
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
        public string DueDate
        {
            get;
            set;
        }

        [DataMember]
        public int? ExpenseType
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
        public bool? IsReverseCharge
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
        public string PurchaseType
        {
            get;
            set;
        }
        [DataMember]
        public string PurchaseCode
        {
            get;
            set;
        }
        [DataMember]
        public string TypeOfCredit
        {
            get;
            set;
        }
        [DataMember]
        public string PurchasePaymentDetail
        {
            get;
            set;
        }
        [DataMember]
        public string TermCondition
        {
            get;
            set;
        }

        [DataMember]
        public List<ReqPurchaseItem> PurchaseItemList
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqPurchaseItem
    {
        [DataMember]
        public int? PoId
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
     
    }

    [DataContract]
    public class ReqPurchaseList : ResCommon
    {
        [DataMember]
        public  List<ReqPurchase> reqPurchaseList
        {
            get;
            set;
        }

    }

    
}
