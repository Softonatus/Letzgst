using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResInvoice
    {
        [DataMember]
        public int? InvoiceId
        { get; set; }

        [DataMember]
        public int? UserId
        { get; set; }

        [DataMember]
        public int? CustomerId
        { get; set; }

        [DataMember]
        public int? InvoiceNo
        { get; set; }

        [DataMember]
        public string InvoiceDate
        { get; set; }

        [DataMember]
        public string DueDate
        { get; set; }

        [DataMember]
        public string Frequency
        { get; set; }

        [DataMember]
        public string EndDate
        { get; set; }

        [DataMember]
        public string PaymentTerm
        { get; set; }

        [DataMember]
        public string ShippingAddress1
        { get; set; }

        [DataMember]
        public string ShippingAddress2
        { get; set; }

        [DataMember]
        public string City
        { get; set; }

        [DataMember]
        public string State
        { get; set; }

        [DataMember]
        public string PinCode
        { get; set; }

        [DataMember]
        public string Country
        { get; set; }

        [DataMember]
        public string RefNo
        { get; set; }

        [DataMember]
        public bool? IsTaxInclusive
        { get; set; }

        [DataMember]
        public string Note
        { get; set; }

        [DataMember]
        public string AttachmentUrl
        { get; set; }

        [DataMember]
        public string Discount
        { get; set; }

        [DataMember]
        public string Advance
        { get; set; }

        [DataMember]
        public string TotalAmount
        { get; set; }

        [DataMember]
        public string Status
        { get; set; }

        [DataMember]
        public bool? IsDeleted
        { get; set; }

        [DataMember]
        public string InvoiceType
        { get; set; }

        [DataMember]
        public string TransactionCode
        { get; set; }

        [DataMember]
        public bool? IsReverseCharge
        { get; set; }

        [DataMember]
        public string TransportMode
        { get; set; }

        [DataMember]
        public string SupplyDate
        { get; set; }

        [DataMember]
        public string PlaceOfSupply
        { get; set; }

        [DataMember]
        public string VehicleNo
        { get; set; }

        [DataMember]
        public string Frieght
        { get; set; }

        [DataMember]
        public string LabourCharge
        { get; set; }

        [DataMember]
        public string InsuranceAmount
        { get; set; }

        [DataMember]
        public string OtherCharge
        { get; set; }

        [DataMember]
        public string Cess
        { get; set; }

        [DataMember]
        public string Prefix
        { get; set; }

         [DataMember]
        public string Type_E_OE
        { get; set; }


        [DataMember]
        public string PortCode
        { get; set; }

        [DataMember]
        public string ShippingBillNo
        { get; set; }

        [DataMember]
        public List<ResInvoiceItem> ReqInvoiceItemList
        { get; set; }
    }

    [DataContract]
    public class ResInvoiceGet : ResCommon
    {
        [DataMember]
        public int? InvoiceId
        { get; set; }

        [DataMember]
        public int? UserId
        { get; set; }

        [DataMember]
        public int? CustomerId
        { get; set; }

        [DataMember]
        public string CustomerName
        { get; set; }

        [DataMember]
        public int? InvoiceNo
        { get; set; }

        [DataMember]
        public string InvoiceDate
        { get; set; }

        [DataMember]
        public string DueDate
        { get; set; }

        [DataMember]
        public string Frequency
        { get; set; }

        [DataMember]
        public string EndDate
        { get; set; }

        [DataMember]
        public string PaymentTerm
        { get; set; }

        [DataMember]
        public string ShippingAddress1
        { get; set; }

        [DataMember]
        public string ShippingAddress2
        { get; set; }

        [DataMember]
        public string City
        { get; set; }

        [DataMember]
        public string State
        { get; set; }

        [DataMember]
        public string PinCode
        { get; set; }

        [DataMember]
        public string Country
        { get; set; }

        [DataMember]
        public string RefNo
        { get; set; }

        [DataMember]
        public bool? IsTaxInclusive
        { get; set; }

        [DataMember]
        public string Note
        { get; set; }

        [DataMember]
        public string AttachmentUrl
        { get; set; }

        [DataMember]
        public string Discount
        { get; set; }

        [DataMember]
        public string Advance
        { get; set; }

        [DataMember]
        public string TotalAmount
        { get; set; }

        [DataMember]
        public bool? IsDeleted
        { get; set; }

        [DataMember]
        public string Status
        { get; set; }

        [DataMember]
        public string InvoiceType
        { get; set; }

        [DataMember]
        public string TransactionCode
        { get; set; }

        [DataMember]
        public bool? IsReverseCharge
        { get; set; }

        [DataMember]
        public string TransportMode
        { get; set; }

        [DataMember]
        public string SupplyDate
        { get; set; }

        [DataMember]
        public string PlaceOfSupply
        { get; set; }

        [DataMember]
        public string VehicleNo
        { get; set; }

        [DataMember]
        public string Frieght
        { get; set; }

        [DataMember]
        public string LabourCharge
        { get; set; }

        [DataMember]
        public string InsuranceAmount
        { get; set; }

        [DataMember]
        public string OtherCharge
        { get; set; }

        [DataMember]
        public string Cess
        { get; set; }

        [DataMember]
        public string Prefix
        { get; set; }

        [DataMember]
        public string Type_E_OE
        { get; set; }

        [DataMember]
        public string PortCode
        { get; set; }

        [DataMember]
        public string ShippingBillNo
        { get; set; }

        [DataMember]
        public string TermsCondition
        { get; set; }

        [DataMember]
        public string InvoiceDetailPayment
        { get; set; }


        [DataMember]
        public List<ResInvoiceItem> ResInvoiceItemList
        { get; set; }
    }


    [DataContract]
    public class ResInvoiceGetList : ResCommon
    {
        [DataMember]
        public List<ResInvoiceGet> resInvoiceGetList
        {
            get; set;
        }
    }

    [DataContract]
    public class ResInvoiceItem
    {
        [DataMember]
        public int? Id
        { get; set; }

        [DataMember]
        public int? InvoiceNo
        { get; set; }

        [DataMember]
        public int? InvoiceId
        { get; set; }

        [DataMember]
        public int? ItemId
        { get; set; }

        [DataMember]
        public string Description
        { get; set; }

        [DataMember]
        public string Price
        { get; set; }

        [DataMember]
        public string Quantity
        { get; set; }

        [DataMember]
        public string Unit
        { get; set; }

        [DataMember]
        public string Amount
        { get; set; }

        [DataMember]
        public string Tax
        { get; set; }

        [DataMember]
        public string Igst
        { get; set; }

        [DataMember]
        public string Cgst
        { get; set; }

        [DataMember]
        public string Sgst
        { get; set; }

        [DataMember]
        public string Utgst
        { get; set; }

        [DataMember]
        public string Cess
        { get; set; }

    }
}