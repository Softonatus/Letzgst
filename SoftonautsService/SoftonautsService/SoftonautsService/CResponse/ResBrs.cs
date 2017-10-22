using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResBrs
    {
        [DataMember]
        public int? PId
        {
            get;
            set;
        }

        [DataMember]
        public int? TId
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
        public string Amount
        {
            get;
            set;
        }

        [DataMember]
        public string Date
        {
            get;
            set;
        }

        [DataMember]
        public string Status
        {
            get;
            set;
        }

        [DataMember]
        public string PendingAmount
        {
            get;
            set;
        }
        
    }

    [DataContract]
    public class ResBrsList :ResCommon
    {
        [DataMember]
        public List<ResBrs> resBrsList
        {
            get;
            set;
        }
    }
}