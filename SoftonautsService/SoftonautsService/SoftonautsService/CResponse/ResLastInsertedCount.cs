using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResLastInsertedCount : ResCommon
    {
        [DataMember]
        public int? Count
        {
            get;
            set;
        }
    }
}