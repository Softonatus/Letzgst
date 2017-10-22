using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqUserHsn : ReqHsnOrHsc
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }

        [DataMember]
        public int? UserId
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqInsertUserHsn : ReqHsnOrHsc
    {
        [DataMember]
        public List<ReqUserHsn> reqUserHsnList
        {
            get;
            set;
        }
    }
}