using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{
    [DataContract]
    public class HsnGst1
    {
        [DataMember]
        public string HSN
        { get; set; }

        [DataMember]
        public string Description
        { get; set; }

        [DataMember]
        public string UQC
        { get; set; }

        [DataMember]
        public string TotalQuantity
        { get; set; }

        [DataMember]
        public string TotalValue
        { get; set; }

        [DataMember]
        public string TaxableValue
        { get; set; }

        [DataMember]
        public string IntegratedTaxAmount
        { get; set; }

        [DataMember]
        public string CentralTaxAmount
        { get; set; }

        [DataMember]
        public string StateUTTaxAmount
        { get; set; }

        [DataMember]
        public string CessAmount
        { get; set; }

    }

    [DataContract]
    public class HsnGst1List
    {
        [DataMember]
        public List<HsnGst1> listHsnGst1
        { get; set; }
    }
}