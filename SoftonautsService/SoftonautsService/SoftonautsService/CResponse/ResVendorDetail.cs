using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResVendorDetail : ResCommon
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public string VendorName
        {
            get;
            set;
        }

        [DataMember]
        public string PrimaryContactPerson
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
        public string PhoneNo
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
        public string City
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
        public string PinCode
        {
            get;
            set;
        }

        [DataMember]
        public string PanCardNo
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
        public string TinVat
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
        public string AccountNo
        {
            get;
            set;
        }

        [DataMember]
        public string IfscCode
        {
            get;
            set;
        }

        [DataMember]
        public string AccountHolderName
        {
            get;
            set;
        }

        [DataMember]
        public string Note
        {
            get;
            set;
        }

        [DataMember]
        public bool? IsReverseCharge
        {
            get;
            set;
        }

        [DataMember]
        public bool? IsCompositionVendor
        {
            get;
            set;
        }
    }
}
