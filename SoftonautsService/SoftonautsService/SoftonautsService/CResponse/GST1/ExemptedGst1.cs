using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{

    [DataContract]
    public class ExemptedGst1
    {
        [DataMember]
        public string Description
        { get; set; }

        [DataMember]
        public string NilRatedSupplies
        { get; set; }

        [DataMember]
        public string ExemptedotherthannilratednonGSTsupply
        { get; set; }

        [DataMember]
        public string NonGSTsupplies
        { get; set; }

    }

    [DataContract]
public class ExemptedGst1List
{
    [DataMember]
    public List<ExemptedGst1> listExemptedGst1
    { get; set; }
}
}