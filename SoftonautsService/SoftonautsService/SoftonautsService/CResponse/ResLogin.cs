using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResLogin: ResCommon
    {
        [DataMember]
        public int? UserId
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
        } = null;

        [DataMember]
        public int? authId
        {
            get;
            set;
        }

        [DataMember]
        public string AuthKey
        {
            get;
            set;
        }

        [DataMember]
        public string State
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
        public string LogoUrl
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

    }
}