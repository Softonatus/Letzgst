using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqReports
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public string tableName
        {
            get;
            set;
        }

        [DataMember]
        public string StartDate
        {
            get;
            set;
        }

        [DataMember]
        public string EndDate
        {
            get;
            set;
        }

        [DataMember]
        public int? CurrentUserId
        {
            get;
            set;
        }

        [DataMember]
        public int? VendorCustomerId
        {
            get;
            set;
        }
    }
}




