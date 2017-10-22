using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{
    public class Gst1Save
    {
        public string gstin { get; set; }

        public string fp { get; set; }

        public double? gt { get; set; }

        public double? cur_gt { get; set; }

        public string version { get; set; }

        public string hash { get; set; }

        public string mode { get; set; }

        public List<B2b> b2b { get; set; }

        public List<B2cl> b2cl { get; set; }

        public List<Cdnr> cdnr { get; set; }

        public List<Cdnur> cdnur { get; set; }

        public List<B2cs> b2cs { get; set; }

        public List<At> at { get; set; }

        public List<Txpd> txpd { get; set; }

        public List<Exp> exp { get; set; }

        public Hsn hsn { get; set; }

        public Nil nil { get; set; }

        public DocIssue doc_issue { get; set; }

    }

    public class ItmDet
    {
        public string InvoiceId { get; set; }//Extra parameter
        public decimal rt { get; set; }
        public decimal txval { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class Itm
    {
        
        public int num { get; set; }
        public ItmDet itm_det { get; set; }
    }

    public class Inv
    {
        public string InvoiceId { get; set; }//Extra parameter
        public string inum { get; set; }
        public string idt { get; set; }
        public decimal val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string etin { get; set; }
        public string inv_typ { get; set; }
        public List<Itm> itms { get; set; }
    }

    public class B2b
    {
        public string ctin { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class ItmDet2
    {
        public string InvoiceId { get; set; }//Extra parameter
        public decimal rt { get; set; }
        public decimal txval { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class Itm2
    {
        public int num { get; set; }
        public ItmDet2 itm_det { get; set; }
    }

    public class Inv2
    {
        public string InvoiceId { get; set; }//Extra parameter
        public string inum { get; set; }
        public string idt { get; set; }
        public decimal val { get; set; }
        public string etin { get; set; }
        public List<Itm2> itms { get; set; }
    }

    public class B2cl
    {
        public string pos { get; set; }
        public List<Inv2> inv { get; set; }
    }

    public class ItmDet3
    {
        public string InvoiceId { get; set; }//Extra parameter
        public decimal rt { get; set; }
        public decimal txval { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class Itm3
    {
        public int num { get; set; }
        public ItmDet3 itm_det { get; set; }
    }

    public class Nt
    {
        public string InvoiceId { get; set; }//Extra parameter
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string p_gst { get; set; }
        public string rsn { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public decimal val { get; set; }
        public List<Itm3> itms { get; set; }
    }

    public class Cdnr
    {
      
        public string ctin { get; set; }
        public List<Nt> nt { get; set; }
    }

    public class B2cs
    {
        public string InvoiceId { get; set; }//Extra parameter
        public string sply_ty { get; set; }
        public decimal rt { get; set; }
        public string typ { get; set; }
        public string etin { get; set; }
        public string pos { get; set; }
        public decimal txval { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class Itm4
    {
        public string InvoiceId { get; set; }//Extra parameter
        public decimal txval { get; set; }
        public decimal rt { get; set; }
        public decimal iamt { get; set; }
    }

    public class Inv3
    {
        public string InvoiceId { get; set; }//Extra parameter
        public string inum { get; set; }
        public string idt { get; set; }
        public decimal val { get; set; }
        public string sbpcode { get; set; }
        public int sbnum { get; set; }
        public string sbdt { get; set; }
        public List<Itm4> itms { get; set; }
    }

    public class Exp
    {
        public string InvoiceId { get; set; }//Extra parameter
        public string exp_typ { get; set; }
        public List<Inv3> inv { get; set; }
    }

    public class Datum
    {
        public int num { get; set; }
        public string hsn_sc { get; set; }
        public string desc { get; set; }
        public string uqc { get; set; }
        public decimal qty { get; set; }
        public decimal val { get; set; }
        public decimal txval { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class Hsn
    {
        public List<Datum> data { get; set; }
    }

    public class Inv4
    {
        public string sply_ty { get; set; }
        public decimal expt_amt { get; set; }
        public decimal nil_amt { get; set; }
        public decimal ngsup_amt { get; set; }
    }

    public class Nil
    {
        public List<Inv4> inv { get; set; }
    }

    public class Itm5
    {
        public string AdvanceId { get; set; }//Extra parameter
        public decimal rt { get; set; }
        public decimal ad_amt { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class Txpd
    {
        public string AdvanceId { get; set; }//Extra parameter
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public List<Itm5> itms { get; set; }
    }

    public class Itm6
    {
        public string AdvanceId { get; set; }//Extra parameter
        public decimal rt { get; set; }
        public decimal ad_amt { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class At
    {
        public string AdvanceId { get; set; }//Extra parameter
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public List<Itm6> itms { get; set; }
    }

    public class Doc
    {
        public int num { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int totnum { get; set; }
        public int cancel { get; set; }
        public int net_issue { get; set; }
    }

    public class DocDet
    {
        public int doc_num { get; set; }
        public List<Doc> docs { get; set; }
    }

    public class DocIssue
    {
        public List<DocDet> doc_det { get; set; }
    }

    public class ItmDet4
    {
        public decimal rt { get; set; }
        public decimal txval { get; set; }
        public decimal iamt { get; set; }
        public decimal csamt { get; set; }
        public decimal camt { get; set; }
        public decimal samt { get; set; }
    }

    public class Itm7
    {
        public string InvoiceId { get; set; }//Extra parameter

        public int num { get; set; }
        public ItmDet4 itm_det { get; set; }
    }

    public class Cdnur
    {
        public string InvoiceId { get; set; }//Extra parameter

        public string typ { get; set; }
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string p_gst { get; set; }
        public string rsn { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public decimal val { get; set; }
        public List<Itm7> itms { get; set; }
    }
}