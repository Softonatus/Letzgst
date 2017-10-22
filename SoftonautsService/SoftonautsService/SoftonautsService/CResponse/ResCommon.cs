using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResCommon
    {
        [DataMember]
        public int? ResponseCode
        {
            get;
            set;
        }

        [DataMember]
        public string ResponseMessage
        {
            get;
            set;
        }
    }
}