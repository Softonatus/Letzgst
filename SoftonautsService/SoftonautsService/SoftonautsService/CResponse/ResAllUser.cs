using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResAllUser
    {
        [DataMember]
        public string UserId
        {
            get;
            set;
        }

        [DataMember]
        public string UserType
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
        public string Password
        {
            get;
            set;
        }

    }

    public class ResAllUserList
    {
        [DataMember]
        public List<ResAllUser> resAllUserList
        {
            get;
            set;
        }


    }
}
