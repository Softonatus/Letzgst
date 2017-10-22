using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqCustomer
    {
       
        [DataMember]
        public int? UserId
        { get; set; }

        [DataMember]
        public string CustomerName
        { get; set; }

        [DataMember]
        public string PrimaryContact
        { get; set; }

        [DataMember]
        public string EmailId
        { get; set; }

        [DataMember]
        public string PhoneNo
        { get; set; }

        [DataMember]
        public string BillingAddress1
        { get; set; }

        [DataMember]
        public string BillingAddress2
        { get; set; }

        [DataMember]
        public string BillingCity
        { get; set; }

        [DataMember]
        public string BillingState
        { get; set; }

        [DataMember]
        public string BillingPinCode
        { get; set; }

        [DataMember]
        public string BillingCountry
        { get; set; }

        [DataMember]
        public string ShippingAddress1
        { get; set; }

        [DataMember]
        public string ShippingAddress2
        { get; set; }

        [DataMember]
        public string ShippingCity
        { get; set; }

        [DataMember]
        public string ShippingState
        { get; set; }

        [DataMember]
        public string ShippingPinCode
        { get; set; }

        [DataMember]
        public string ShippingCountry
        { get; set; }

        [DataMember]
        public string CurrencyType
        { get; set; }

        [DataMember]
        public bool? Sez
        { get; set; }

        [DataMember]
        public string PanNo
        { get; set; }

        [DataMember]
        public string ServiceTaxNo
        { get; set; }

        [DataMember]
        public string TinVatNo
        { get; set; }

        [DataMember]
        public string GstinNo
        { get; set; }

        [DataMember]
        public string TdsSection
        { get; set; }

        [DataMember]
        public string TdsRate
        { get; set; }

        [DataMember]
        public bool? ShowTdsInvoice
        { get; set; }

        [DataMember]
        public string Note
        { get; set; }

    }


    [DataContract]
    public class ReqCustomerList : ResCommon
    {
        [DataMember]
        public List<ResCustomer> resCustomer
        {
            get;
            set;
        }


    }
}


