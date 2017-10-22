using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResId : ResCommon
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }
    }

    public class ResrefId 
    {
        [DataMember]
        public int? RefId
        {
            get;
            set;
        }

        [DataMember]
        public int? RefNo
        {
            get;
            set;
        }
    }


    [DataContract]
    public class ResrefIdList : ResCommon
    {
        [DataMember]
        public List<ResrefId> resrefIdList
        {
            get;
            set;
        }
    }
}