using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResTds
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }

        [DataMember]
        public string TdsSection
        {
            get;
            set;
        }

        [DataMember]
        public string TdsDescription
        {
            get;
            set;
        }

        [DataMember]
        public string TdsRate
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ResTdsList :  ResCommon
    {
        [DataMember]
        public List<ResTds> resTdsList
        {
            get;
            set;
        }
    }
}
