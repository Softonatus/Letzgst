using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqProfile
    {
        [DataMember]
        public string Name
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
        [DataMember]
        public string LogoUrl
        {
            get;
            set;
        }
        [DataMember]
        public string AddressLine1
        {
            get;
            set;
        }
        [DataMember]
        public string AddressLine2
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
        public string City
        {
            get;
            set;
        }
        [DataMember]
        public string PinCode
        {
            get;
            set;
        }
        [DataMember]
        public string Country
        {
            get;
            set;
        }
        [DataMember]
        public string CreatedDate
        {
            get;
            set;
        }
        [DataMember]
        public string PanNo
        {
            get;
            set;
        }
        [DataMember]
        public string CinNo
        {
            get;
            set;
        }
        [DataMember]
        public string ServiceTaxNo
        {
            get;
            set;
        }
        [DataMember]
        public string Vat_TinNo
        {
            get;
            set;
        }
        [DataMember]
        public string GstinNo
        {
            get;
            set;
        }
        [DataMember]
        public string TanNo
        {
            get;
            set;
        }
        [DataMember]
        public string WebsiteUrl
        {
            get;
            set;
        }
        [DataMember]
        public string MembershipId
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
        public string AadharNo
        {
            get;
            set;
        }


    }
}
