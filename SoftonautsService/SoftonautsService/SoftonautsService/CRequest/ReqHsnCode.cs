using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqHsnCode : ReqHsnOrHsc
    {
        [DataMember]
        public string HsnDetail
        {
            get;
            set;
        }
    }
}