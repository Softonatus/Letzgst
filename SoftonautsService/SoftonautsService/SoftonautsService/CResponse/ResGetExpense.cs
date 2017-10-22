using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResGetExpense
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }

        [DataMember]
        public string ExpenseType
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ResGetExpenseList : ResCommon
    {
        [DataMember]
        public List<ResGetExpense> resExpenseList
        {
            get;
            set;
        }
    }
}
