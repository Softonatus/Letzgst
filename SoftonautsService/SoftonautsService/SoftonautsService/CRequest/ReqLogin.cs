using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqLogin
    {
        [DataMember]
        public string EmailId
        {
            get;
            set;
        }

        [DataMember]
        public string Password
        {
            get;
            set;
        }

        [DataMember]
        public string authKey
        {
            get;
            set;
        }

       
    }
}