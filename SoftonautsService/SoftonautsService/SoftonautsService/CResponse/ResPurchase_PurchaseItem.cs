using SoftonautsService.CRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResPurchase_PurchaseItem :ResCommon
    {
        [DataMember]
        public ReqPurchase resPurchase
        {
            get;
            set;
        }

        [DataMember]
        public List<ReqPurchaseItem> resPurchaseItemList
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ResPurchase_PurchaseItemList : ResCommon
    {
        [DataMember]
        public List<ReqPurchase> resPurchaseList
        {
            get;
            set;
        }

        [DataMember]
        public List<ReqPurchaseItem> resPurchaseItemList
        {
            get;
            set;
        }
    }
}
