using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{


    [DataContract]
    public class AdvanceGst1
    {
        [DataMember]
        public string PlaceOfSupply
        { get; set; }

        [DataMember]
        public string Rate
        { get; set; }

        [DataMember]
        public string GrossAdvanceReceived
        { get; set; }

        [DataMember]
        public string Cess
        { get; set; }

        [DataMember]
        public string Amount
        { get; set; }

    }

    [DataContract]
    public class AdvanceGst1List
    {
        [DataMember]
        public List<AdvanceGst1> listAdvanceGst1
        { get; set; }
    }
}