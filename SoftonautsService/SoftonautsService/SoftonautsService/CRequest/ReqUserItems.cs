using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqUserItems : ReqInsertUserItems
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }
       
    }

    [DataContract]
    public class ReqInsertUserItems : ReqUserId
    {
       
        [DataMember]
        public string ItemName
        {
            get;
            set;
        }
        [DataMember]
        public string HsnCodeId
        {
            get;
            set;
        }
        [DataMember]
        public string ItemDescription
        {
            get;
            set;
        }

        [DataMember]
        public string Price
        {
            get;
            set;
        }

        [DataMember]
        public string UnitOfMeasures
        {
            get;
            set;
        }

        [DataMember]
        public string Tax
        {
            get;
            set;
        }
    }
}

