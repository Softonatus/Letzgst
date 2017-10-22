using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{
    [DataContract]
    public class AdvanceAdjustmentGst1
    {
        [DataMember]
        public string PlaceOfSupply
        { get; set; }

        [DataMember]
        public string Rate
        { get; set; }

        [DataMember]
        public string GrossAdvanceAdjusted
        { get; set; }

        [DataMember]
        public string Cess
        { get; set; }

        [DataMember]
        public string Amount
        { get; set; }

    }

    [DataContract]
    public class AdvanceAdjustmentGst1List
    {
        [DataMember]
        public List<AdvanceAdjustmentGst1> listAdvanceAdjustmentGst1
        { get; set; }
    }

}