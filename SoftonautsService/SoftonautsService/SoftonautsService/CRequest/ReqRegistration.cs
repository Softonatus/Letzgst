using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqRegistration
    {
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

        [DataMember]
        public string ContactNo
        {
            get;
            set;
        }
        [DataMember]
        public string RegisteredDate
        {
            get;
            set;
        }
        [DataMember]
        public string ExpiryDate
        {
            get;
            set;
        }

        [DataMember]
        public int? UserType
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

        [DataMember]
        public int? UserRoleAuth
        {
            get;
            set;
        }


        [DataMember]
        public bool? IsActive
        {
            get;
            set;
        }
    }

}
