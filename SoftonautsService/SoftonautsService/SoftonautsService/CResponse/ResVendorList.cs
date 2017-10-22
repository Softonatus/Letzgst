using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResVendor
    {
        [DataMember]
        public int? Id
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
        public string State
        {
            get;
            set;
        }


        [DataMember]
        public string ShippingAddress1
        {
            get;
            set;
        }

        [DataMember]
        public string ShippingAddress2
        {
            get;
            set;
        }

        [DataMember]
        public string ShippingCity
        {
            get;
            set;
        }
        [DataMember]
        public string ShippingState
        {
            get;
            set;
        }

        [DataMember]
        public string ShippingPinCode
        {
            get;
            set;
        }
        [DataMember]

        public string ShippingCountry
        {
            get;
            set;
        }
    }

    public class ResVendorList : ResCommon
    {
        [DataMember]
        public List<ResVendor> resVendor
        {
            get;
            set;
        }

        
    }
}
