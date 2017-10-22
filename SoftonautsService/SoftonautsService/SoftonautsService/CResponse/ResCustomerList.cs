using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResCustomer
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }

        [DataMember]
        public string CustomerName
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

    [DataContract]
    public class ResCustomerList : ResCommon
    {
        [DataMember]
        public List<ResCustomer> resCustomer
        {
            get;
            set;
        }


    }
}