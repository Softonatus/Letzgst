using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{

    [DataContract]
    public class ExportGst1
    {
        [DataMember]
        public string ExportType
        { get; set; }

        [DataMember]
        public string InvoiceNumber
        { get; set; }

        [DataMember]
        public string Invoicedate
        { get; set; }

        [DataMember]
        public string InvoiceValue
        { get; set; }

        [DataMember]
        public string PortCode
        { get; set; }

        [DataMember]
        public string ShippingBillNumber
        { get; set; }

        [DataMember]
        public string ShippingBillDate
        { get; set; }

        [DataMember]
        public string Rate
        { get; set; }

        [DataMember]
        public string TaxableValue
        { get; set; }

    }

    [DataContract]
    public class ExportGst1List
    {
        [DataMember]
        public List<ExportGst1> listExportGst1
        { get; set; }
    }

}