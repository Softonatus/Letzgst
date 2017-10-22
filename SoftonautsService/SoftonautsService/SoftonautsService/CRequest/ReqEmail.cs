using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqEmail 
    {
        [DataMember]
        public string EmailId
        { get; set; }

        [DataMember]
        public string EmailFrom
        { get; set; }

        [DataMember]
        public string EmailSubject
        { get; set; }

        [DataMember]
        public string EmailBody
        { get; set; }

        [DataMember]
        public string HtmlType
        { get; set; }

        [DataMember]
        public string EmailAttachmentUrl
        { get; set; }

        [DataMember]
        public string UserName
        { get; set; }

    }
}