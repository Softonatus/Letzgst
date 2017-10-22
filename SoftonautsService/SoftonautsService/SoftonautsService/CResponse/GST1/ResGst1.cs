using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{
    [DataContract]
    public class ResGst1List : ResCommon
    {
        [DataMember]
        public List<ResGst1> resGst1
        {
            get;
            set;
        }

        [DataMember(Name = "Total Invoice Value")]
        public string TotalInvoiceValue
        {
            get;
            set;
        }
        [DataMember(Name = "Total Taxable Value")]
        public string TotalTaxableValue
        {
            get;
            set;
        }
        [DataMember(Name = "Total Cess")]
        public string TotalCess
        {
            get;
            set;
        }

        [DataMember(Name = "No. Of Invoices")]
        public string InvoiceCount
        {
            get;
            set;
        }
        [DataMember(Name = "No. of Recepients")]
        public string TotalNoOfrecepient
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ResGst1
    {
        [DataMember(Name = "GSTIN/UIN of Recipient")]
        public string GstinNo
        {
            get;
            set;
        }
        [DataMember]
        public string InvoiceId
        {
            get;
            set;
        }
        [DataMember(Name = "Invoice Number")]
        public string InvoiceNo
        {
            get;
            set;
        }

        [DataMember(Name = "Invoice date")]
        public string InvoiceDate
        {
            get;
            set;
        }

        [DataMember(Name = "Invoice Value")]
        public decimal TotalAmount
        {
            get;
            set;
        }
        [DataMember(Name = "Place Of Supply")]
        public string PlaceOfSupply
        {
            get;
            set;
        }
        [DataMember(Name = "Reverse Charge")]
        public bool? IsReverseCharge
        {
            get;
            set;
        }
        [DataMember(Name = "Invoice Type")]
        public string InvoiceType
        {
            get;
            set;
        }
        [DataMember(Name = "E-Commerce GSTIN")]
        public string EcommerceGstinNo
        {
            get;
            set;
        }
        [DataMember(Name = "Cess")]
        public string Cess
        {
            get;
            set;
        }
   

        [DataMember(Name = "Taxable Value")]
        public string TaxableValue
        {
            get;
            set;
        }

        [DataMember(Name = "Rate")]
        public string Rate
        {
            get;
            set;
        }

        [DataMember(Name = "Type")]
        public string Type_E_OE
        {
            get;
            set;
        }
    }


}