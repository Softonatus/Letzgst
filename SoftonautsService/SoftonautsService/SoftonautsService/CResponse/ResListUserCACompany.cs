using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResUserCACompany
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }
        [DataMember]
        public string Name
        {
            get;
            set;
        }
        [DataMember]
        public string EmailId
        {
            get;
            set;
        }
        [DataMember]
        public string ContactNo
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ResUserListCACompany: ResCommon
    {
        [DataMember]
        public List<ResUserCACompany> resUserCACompany
        {
            get;
            set;
        }
    }
}