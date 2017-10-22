using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResRegistration:ResCommon
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public int? ParentId
        {
            get;
            set;
        }
    }
}