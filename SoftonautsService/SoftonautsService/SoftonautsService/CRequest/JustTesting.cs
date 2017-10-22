using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{

    public class JustTesting
    {

        public List<string> obj { get; set; }
    }


    public class ReqAdvanceItem
    {

        public int? Id
        { get; set; }


        public int? AdvanceNo
        { get; set; }


        public int? AdvanceId
        { get; set; }


        public int? ItemId
        { get; set; }


        public string Description
        { get; set; }


        public string Price
        { get; set; }


        public string Quantity
        { get; set; }


        public string Unit
        { get; set; }


        public string Amount
        { get; set; }


        public string Tax
        { get; set; }


        public string Igst
        { get; set; }


        public string Cgst
        { get; set; }


        public string Sgst
        { get; set; }


        public string Utgst
        { get; set; }


        public string Cess
        { get; set; }

    }


    public class ReqAdvance
    {

        public int? AdvanceId
        { get; set; }


        public int? UserId
        { get; set; }


        public int? CustomerId
        { get; set; }


        public int? AdvanceNo
        { get; set; }


        public DateTime AdvanceDate
        { get; set; }


        public string PaymentTerm
        { get; set; }


        public string ShippingAddress1
        { get; set; }


        public string ShippingAddress2
        { get; set; }


        public string City
        { get; set; }


        public string State
        { get; set; }


        public string PinCode
        { get; set; }


        public string Country
        { get; set; }


        public string RefNo
        { get; set; }


        public bool IsTaxInclusive
        { get; set; }


        public string Note
        { get; set; }


        public string AttachmentUrl
        { get; set; }


        public string TotalAmount
        { get; set; }


        public bool IsDeleted
        { get; set; }


        public int? CurrentUserId
        { get; set; }


        public List<ReqAdvanceItem> ReqAdvanceItemList
        { get; set; }
    }
}