using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResUserItems
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }
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

    [DataContract]
    public class ResUserItemsList : ResCommon
    {
        [DataMember]
        public List<ResUserItems> resUserItemsList
        {
            get;
            set;
        }
    }
}
