using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest.GST1
{
    [DataContract]
    public class ReqGst1
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public int? Month
        {
            get;
            set;
        }

        [DataMember]
        public int? Year
        {
            get;
            set;
        }

        [DataMember]
        public string Status
        {
            get;
            set;
        }


        [DataMember]
        public string ReturnText
        {
            get;
            set;
        }
    }
}