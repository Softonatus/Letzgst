using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResCompanyListCA : ResCommon
    {
        [DataMember]
        public List<ResCompany_CA> resCompany_CA
        {
            get;
            set;
        }

    }

    [DataContract]
    public class ResCompany_CA
    {
        [DataMember]
        public int? UserId
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
        public string Name
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
}
