using System.Runtime.Serialization;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqUpdateUser
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

        [DataMember]
        public int? UserRoleAuth
        {
            get;
            set;
        }
    }
}
