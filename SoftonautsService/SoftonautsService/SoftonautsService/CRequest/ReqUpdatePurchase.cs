﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqUpdatePurchase : ReqPurchase
    {
        [DataMember]
        public int? PurchaseIdTest
        {
            get;
            set;
        }
    }
}
