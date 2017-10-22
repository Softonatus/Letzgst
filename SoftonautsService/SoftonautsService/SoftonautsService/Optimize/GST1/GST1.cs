using Newtonsoft.Json;
using SoftonautsService.CRequest.GST1;
using SoftonautsService.CResponse.GST1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SoftonautsService.Optimize.GST1
{
    public class GST1
    {
        #region GST1 Save Get All
        public static Gst1Save GetGstr1(ReqGst1 reqGst1, String spName)
        {
            #region Class Declaration
            Gst1Save resGst1Save = new Gst1Save();
            #endregion

            #region DataSet/DataTables
            DataSet dsGstSave = new DataSet();
            #endregion

            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqGst1.UserId));
                        cmd.Parameters.Add(new SqlParameter("@Year", reqGst1.Year));
                        cmd.Parameters.Add(new SqlParameter("@Month", reqGst1.Month));
                        cmd.Parameters.Add(new SqlParameter("@ReturnText", reqGst1.ReturnText));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dsGstSave);

                            if (dsGstSave.Tables[0].Rows.Count > 0)
                            {
                                resGst1Save.gstin = Convert.ToString(dsGstSave.Tables[0].Rows[0]["gstin"]);
                                resGst1Save.fp = Convert.ToString(dsGstSave.Tables[0].Rows[0]["fp"]);

                                if (!String.IsNullOrEmpty(Convert.ToString(dsGstSave.Tables[0].Rows[0]["gt"])))
                                    resGst1Save.gt = Convert.ToDouble(dsGstSave.Tables[0].Rows[0]["gt"]);

                                if(!String.IsNullOrEmpty(Convert.ToString(dsGstSave.Tables[0].Rows[0]["cur_gt"])))
                                    resGst1Save.cur_gt = Convert.ToDouble(dsGstSave.Tables[0].Rows[0]["cur_gt"]);
                                

                                resGst1Save.version = Convert.ToString(dsGstSave.Tables[0].Rows[0]["version"]);
                                resGst1Save.hash = Convert.ToString(dsGstSave.Tables[0].Rows[0]["hash"]);
                                resGst1Save.mode = Convert.ToString(dsGstSave.Tables[0].Rows[0]["mode"]);
                            }
                            //Merge Test
                            //dsGstSave.Tables[1].Columns.RemoveAt(9);
                            //DataTable sum = dsGstSave.Tables[1].Clone().Copy(); sum.Merge(dsGstSave.Tables[2], true);

                            if (dsGstSave.Tables[1].Rows.Count > 0 && dsGstSave.Tables[2].Rows.Count > 0)
                                resGst1Save.b2b = GetB2BGst1Save(dsGstSave.Tables[1],dsGstSave.Tables[2]);

                            if (dsGstSave.Tables[3].Rows.Count > 0 && dsGstSave.Tables[4].Rows.Count > 0)
                                resGst1Save.b2cl = GetB2clGst1Save(dsGstSave.Tables[3], dsGstSave.Tables[4]);

                            if (dsGstSave.Tables[5].Rows.Count > 0 && dsGstSave.Tables[6].Rows.Count > 0)
                                resGst1Save.b2cs = GetB2csGst1Save(dsGstSave.Tables[5], dsGstSave.Tables[6]);

                            if (dsGstSave.Tables[7].Rows.Count > 0 && dsGstSave.Tables[8].Rows.Count > 0)
                                resGst1Save.cdnr = GetCdnrGst1Save(dsGstSave.Tables[7], dsGstSave.Tables[8]);

                            if (dsGstSave.Tables[9].Rows.Count > 0 && dsGstSave.Tables[10].Rows.Count > 0)
                                resGst1Save.cdnur = GetCdnurGst1Save(dsGstSave.Tables[9], dsGstSave.Tables[10]);

                            if (dsGstSave.Tables[11].Rows.Count > 0 && dsGstSave.Tables[12].Rows.Count > 0)
                                resGst1Save.at = GetATGst1Save(dsGstSave.Tables[11], dsGstSave.Tables[12]);

                            if (dsGstSave.Tables[13].Rows.Count > 0 && dsGstSave.Tables[14].Rows.Count > 0)
                                resGst1Save.txpd = GetTxpdGst1Save(dsGstSave.Tables[13], dsGstSave.Tables[14]);

                            if (dsGstSave.Tables[15].Rows.Count > 0 && dsGstSave.Tables[16].Rows.Count > 0)
                                resGst1Save.exp = GetExpGst1Save(dsGstSave.Tables[15], dsGstSave.Tables[16]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return resGst1Save;
        }

        public static List<B2b> GetB2BGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region B2B Section
            List<B2b> _resB2BList = new List<B2b>();
          
            List<Inv> _resB2BInv = new List<Inv>();
            List<Itm> _resB2BItm = new List<Itm>();
            #endregion

            List<B2b> _b2bList = new List<B2b>();
            var distinctctin = (from DataRow dRow in dtInvoice.Rows
                                select new { col1 = dRow["ctin"] }).Distinct().ToList();

            for (int k = 0; k < distinctctin.Count(); k++)
            {
                B2b _b2b = new B2b();
                _b2b.ctin = distinctctin[k].ToString().Replace("col1 =", "").Replace("{", "").Replace("}", "");
                string _selectParam = "ctin =" + "'" + _b2b.ctin.TrimStart().TrimEnd() + "'";
                var currInvoiceLoop = dtInvoice.Select(_selectParam).CopyToDataTable();

                List<ItmDet> _itmdetList = new List<ItmDet>();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(currInvoiceLoop);
                _resB2BInv = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Inv>>(JSONString);

                string JSONStringItem = string.Empty;
                JSONStringItem = JsonConvert.SerializeObject(dtInvoiceItemRate);
                _itmdetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItmDet>>(JSONStringItem);
                _b2b.inv = _resB2BInv;
                List<Inv> _invList = new List<Inv>();
                for (int i = 0; i < currInvoiceLoop.Rows.Count; i++)
                {
                    Inv _inv = new Inv();
                    List<ItmDet> itmdetList = new List<ItmDet>();
                    List<Itm> _itmList = new List<Itm>();
                    string invoiceId = _b2b.inv[i].InvoiceId;
                    var _curritm = (List<ItmDet>)_itmdetList.Where(x => x.InvoiceId == invoiceId).Select(x => x).ToList();
                    _inv = _resB2BInv[i];

                    for (int j = 0; j < _curritm.Count(); j++)
                    {
                        Itm _itm = new Itm();
                        ItmDet _itmdet = new ItmDet();
                        _itmdet = (_curritm[j]);
                        _itm.num = i + 1;
                        _itm.itm_det = _itmdet;
                        _itmList.Add(_itm);
                        _inv.itms = _itmList;
                        _b2b.inv[i] = _inv;
                    }
                }
                _b2bList.Add(_b2b);
            }
            return _b2bList;

          
    }

        public static List<B2cl> GetB2clGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region B2CL Section
            List<B2cl> _resB2BList = new List<B2cl>();

            List<Inv2> _resB2clInv = new List<Inv2>();
            List<Itm2> _resB2clItm = new List<Itm2>();
            #endregion


            List<B2cl> _b2clList = new List<B2cl>();
            var distinctctin = (from DataRow dRow in dtInvoice.Rows
                                select new { col1 = dRow["pos"] }).Distinct().ToList();

            for (int k = 0; k < distinctctin.Count(); k++)
            {
                B2cl _b2cl = new B2cl();
                _b2cl.pos = distinctctin[k].ToString().Replace("col1 =", "").Replace("{", "").Replace("}", "");
                string _selectParam = "pos =" + "'" + _b2cl.pos.TrimStart().TrimEnd() + "'";
                var currInvoiceLoop = dtInvoice.Select(_selectParam).CopyToDataTable();

                List<ItmDet2> _itmdetList = new List<ItmDet2>();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(currInvoiceLoop);
                _resB2clInv = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Inv2>>(JSONString);

                string JSONStringItem = string.Empty;
                JSONStringItem = JsonConvert.SerializeObject(dtInvoiceItemRate);
                _itmdetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItmDet2>>(JSONStringItem);
                _b2cl.inv = _resB2clInv;
                List<Inv2> _invList = new List<Inv2>();
                for (int i = 0; i < currInvoiceLoop.Rows.Count; i++)
                {
                    Inv2 _inv = new Inv2();
                    List<ItmDet2> itmdetList = new List<ItmDet2>();
                    List<Itm2> _itmList = new List<Itm2>();
                    string invoiceId = _b2cl.inv[i].InvoiceId;
                    var _curritm = (List<ItmDet2>)_itmdetList.Where(x => x.InvoiceId == invoiceId).Select(x => x).ToList();
                    _inv = _resB2clInv[i];

                    for (int j = 0; j < _curritm.Count(); j++)
                    {
                        Itm2 _itm = new Itm2();
                        ItmDet2 _itmdet = new ItmDet2();
                        _itmdet = (_curritm[j]);
                        _itm.num = i + 1;
                        _itm.itm_det = _itmdet;
                        _itmList.Add(_itm);
                        _inv.itms = _itmList;
                        _b2cl.inv[i] = _inv;
                    }
                }
                _b2clList.Add(_b2cl);
            }
            return _b2clList;


        }

        public static List<B2cs> GetB2csGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region B2CS Section
            List<B2cs> _resB2CSList = new List<B2cs>();

            #endregion



            //dtInvoice.Columns.AddRange(new DataColumn[]{
            //    new DataColumn("InvoiceId",typeof(String)),
            //    new DataColumn("typ",typeof(String)),
            //     new DataColumn("pos",typeof(String)),
            //    new DataColumn("etin",typeof(String)),
            //    new DataColumn("sply_ty",typeof(String))
            //});


            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                 new DataColumn("InvoiceId",typeof(String)),
                new DataColumn("txval",typeof(String)),
                new DataColumn("rt",typeof(String)),
                 new DataColumn("iamt",typeof(String)),
                  new DataColumn("csamt",typeof(String))
            });
            try
            {
                for (int i = 0; i < dtInvoice.Rows.Count; i++)
                {
                    dt.Clear();
                    string invoiceId = Convert.ToString(dtInvoice.Rows[i]["InvoiceId"]);
                    var dr = dtInvoiceItemRate.Select("InvoiceId =" + invoiceId);// fetch data from Datatable with current looping invoiceId
                    //for (int k = 0; k < dr.Count(); k++)
                    //{
                    //    dt.Rows.Add(dr[k].ItemArray);
                    //}

                    for (int j = 0; j < dr.Count(); j++)
                    {
                        B2cs _b2cs = new B2cs();
                        _b2cs.InvoiceId = Convert.ToString(dtInvoice.Rows[i]["InvoiceId"]);
                        _b2cs.etin = Convert.ToString(dtInvoice.Rows[i]["etin"]);
                        _b2cs.typ = Convert.ToString(dtInvoice.Rows[i]["typ"]);
                        _b2cs.pos = Convert.ToString(dtInvoice.Rows[i]["pos"]);
                        _b2cs.txval = Convert.ToDecimal(dr[j]["txval"]);
                        _b2cs.rt = Convert.ToDecimal(dr[j]["rt"]);
                        _b2cs.csamt = Convert.ToDecimal(dr[j]["csamt"]);
                        _resB2CSList.Add(_b2cs);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resB2CSList;
        }

        public static List<Cdnr> GetCdnrGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region Cdnr Section
            List<Cdnr> _resCdnrList = new List<Cdnr>();
            List<Nt> _resCdnrInv = new List<Nt>();
            List<Itm3> _resCdnrItm = new List<Itm3>();
            #endregion

            List<Cdnr> _cdnrList = new List<Cdnr>();
            var distinctctin = (from DataRow dRow in dtInvoice.Rows
                                select new { col1 = dRow["ctin"] }).Distinct().ToList();

            for (int k = 0; k < distinctctin.Count(); k++)
            {
                Cdnr _cdnr = new Cdnr();
                _cdnr.ctin = distinctctin[k].ToString().Replace("col1 =", "").Replace("{", "").Replace("}", "");
                string _selectParam = "ctin =" + "'" + _cdnr.ctin.TrimStart().TrimEnd() + "'";
                var currInvoiceLoop = dtInvoice.Select(_selectParam).CopyToDataTable();

                List<ItmDet3> _itmdetList = new List<ItmDet3>();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(currInvoiceLoop);
                _resCdnrInv = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Nt>>(JSONString);

                string JSONStringItem = string.Empty;
                JSONStringItem = JsonConvert.SerializeObject(dtInvoiceItemRate);
                _itmdetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItmDet3>>(JSONStringItem);
                _cdnr.nt = _resCdnrInv;
                List<Inv> _invList = new List<Inv>();
                for (int i = 0; i < currInvoiceLoop.Rows.Count; i++)
                {
                    Nt _inv = new Nt();
                    List<ItmDet3> itmdetList = new List<ItmDet3>();
                    List<Itm3> _itmList = new List<Itm3>();
                    string invoiceId = _cdnr.nt[i].InvoiceId;
                    var _curritm = (List<ItmDet3>)_itmdetList.Where(x => x.InvoiceId == invoiceId).Select(x => x).ToList();
                    _inv = _resCdnrInv[i];

                    for (int j = 0; j < _curritm.Count(); j++)
                    {
                        Itm3 _itm = new Itm3();
                        ItmDet3 _itmdet = new ItmDet3();
                        _itmdet = (_curritm[j]);
                        _itm.num = i + 1;
                        _itm.itm_det = _itmdet;
                        _itmList.Add(_itm);
                        _inv.itms = _itmList;
                        _cdnr.nt[i] = _inv;
                    }
                }
                _cdnrList.Add(_cdnr);
            }
            return _cdnrList;
        }

        public static List<Cdnur> GetCdnurGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region Cdnur Section
            List<Cdnur> _resCdnurList = new List<Cdnur>();
            #endregion

            for (int k = 0; k < dtInvoice.Rows.Count; k++)
            {
                Cdnur _cdnur = new Cdnur();
                _cdnur.idt = Convert.ToString(dtInvoice.Rows[k]["idt"]);
                _cdnur.inum = Convert.ToString(dtInvoice.Rows[k]["inum"]);
                _cdnur.ntty = Convert.ToString(dtInvoice.Rows[k]["ntty"]);
                _cdnur.nt_dt = Convert.ToString(dtInvoice.Rows[k]["nt_dt"]);
                _cdnur.nt_num = Convert.ToString(dtInvoice.Rows[k]["nt_num"]);
                _cdnur.p_gst = Convert.ToString(dtInvoice.Rows[k]["p_gst"]);
                _cdnur.rsn = Convert.ToString(dtInvoice.Rows[k]["rsn"]);
                _cdnur.typ = Convert.ToString(dtInvoice.Rows[k]["typ"]);
                _cdnur.val = Convert.ToDecimal(dtInvoice.Rows[k]["val"].ToString());
              
                var currInvoiceLoop = dtInvoice.Rows[k]["InvoiceId"];
                string _selectParam = "InvoiceId =" + "'" + currInvoiceLoop + "'";

                DataTable currInvoiceItemRate = new DataTable();
                var drow = dtInvoiceItemRate.Select(_selectParam);

                if (drow.Count() > 0)
                {
                    currInvoiceItemRate = dtInvoiceItemRate.Select(_selectParam).CopyToDataTable();
                }

                List<Itm7> _itmList = new List<Itm7>();
           
                for (int i = 0; i < currInvoiceItemRate.Rows.Count; i++)
                {
                    Itm7 _itm7 = new Itm7();
                    ItmDet4 _itmDet4 = new ItmDet4();
                    _itm7.num = i;
                    _itmDet4.csamt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["csamt"]);
                    _itmDet4.iamt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["iamt"]);
                    _itmDet4.rt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["rt"]);
                    _itmDet4.txval = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["txval"]);

                    _itm7.itm_det = _itmDet4;
                    _itmList.Add(_itm7);
                }
                _cdnur.itms = _itmList;
                _resCdnurList.Add(_cdnur);
            }

            return _resCdnurList;
        }

        public static List<At> GetATGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region Cdnur Section
            List<At> _resAtList = new List<At>();
            #endregion

            for (int k = 0; k < dtInvoice.Rows.Count; k++)
            {
                At _at = new At();
                _at.pos = Convert.ToString(dtInvoice.Rows[k]["pos"]);
                _at.sply_ty = Convert.ToString(dtInvoice.Rows[k]["sply_ty"]);
               

                var currInvoiceLoop = dtInvoice.Rows[k]["AdvanceId"];
                string _selectParam = "AdvanceId =" + "'" + currInvoiceLoop + "'";

                DataTable currInvoiceItemRate = new DataTable();
                var drow = dtInvoiceItemRate.Select(_selectParam);

                if (drow.Count() > 0)
                {
                    currInvoiceItemRate = dtInvoiceItemRate.Select(_selectParam).CopyToDataTable();
                }

                List<Itm6> _itmList = new List<Itm6>();

                for (int i = 0; i < currInvoiceItemRate.Rows.Count; i++)
                {
                    Itm6 _itm6 = new Itm6();

                    _itm6.ad_amt = Convert.ToDecimal(dtInvoice.Rows[k]["ad_amt"]);
                    _itm6.csamt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["csamt"]);
                    _itm6.camt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["camt"]);
                    _itm6.iamt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["iamt"]);
                    _itm6.rt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["rt"]);
                    _itm6.samt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["samt"]);
                    
                    _itmList.Add(_itm6);
                }
                _at.itms = _itmList;
                _resAtList.Add(_at);
            }

            return _resAtList;
        }

        public static List<Txpd> GetTxpdGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region Txpd Section
            List<Txpd> _resTxpdList = new List<Txpd>();
            #endregion

            for (int k = 0; k < dtInvoice.Rows.Count; k++)
            {
                Txpd _txpd = new Txpd();
                _txpd.pos = Convert.ToString(dtInvoice.Rows[k]["pos"]);
                _txpd.sply_ty = Convert.ToString(dtInvoice.Rows[k]["supply"]);

                var currInvoiceLoop = dtInvoice.Rows[k]["AdvanceId"];
                string _selectParam = "AdvanceId =" + "'" + currInvoiceLoop + "'";

                DataTable currInvoiceItemRate = new DataTable();
                var drow = dtInvoiceItemRate.Select(_selectParam);

                if (drow.Count() > 0)
                {
                    currInvoiceItemRate = dtInvoiceItemRate.Select(_selectParam).CopyToDataTable();
                }

                List<Itm5> _itmList = new List<Itm5>();

                for (int i = 0; i < currInvoiceItemRate.Rows.Count; i++)
                {
                    Itm5 _itm5 = new Itm5();

                    _itm5.ad_amt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["ad_amt"]);
                    _itm5.csamt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["csamt"]);
                    _itm5.camt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["camt"]);
                    _itm5.iamt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["iamt"]);
                    _itm5.rt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["rt"]);
                    _itm5.samt = Convert.ToDecimal(currInvoiceItemRate.Rows[i]["samt"]);

                    _itmList.Add(_itm5);
                }
                _txpd.itms = _itmList;
                _resTxpdList.Add(_txpd);
            }

            return _resTxpdList;
        }

         public static List<Exp> GetExpGst1Save(DataTable dtInvoice, DataTable dtInvoiceItemRate)
        {
            #region B2B Section
            List<Exp> _resExpList = new List<Exp>();
          
            List<Inv3> _resExpInv = new List<Inv3>();
            List<Itm4> _resExpItm = new List<Itm4>();
            #endregion

            List<Exp> _expList = new List<Exp>();
            var distinctctin = (from DataRow dRow in dtInvoice.Rows
                                select new { col1 = dRow["InvoiceId"] }).Distinct().ToList();

            for (int k = 0; k < distinctctin.Count(); k++)
            {
                Exp _exp = new Exp();
                _exp.InvoiceId = distinctctin[k].ToString().Replace("col1 =", "").Replace("{", "").Replace("}", "");
                string _selectParam = "InvoiceId =" + "'" + _exp.InvoiceId.TrimStart().TrimEnd() + "'";
                var currInvoiceLoop = dtInvoice.Select(_selectParam).CopyToDataTable();

                List<Itm4> _itmList = new List<Itm4>();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(currInvoiceLoop);
                _resExpInv = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Inv3>>(JSONString);

                //string JSONStringItem = string.Empty;
                //JSONStringItem = JsonConvert.SerializeObject(dtInvoiceItemRate);
                //_itmdetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItmDet>>(JSONStringItem);
                _exp.inv = _resExpInv;
               // List<Inv3> _invList = new List<Inv3>();
                for (int i = 0; i < currInvoiceLoop.Rows.Count; i++)
                {
                    Inv3 _inv = new Inv3();
                    //List<ItmDet> itmdetList = new List<ItmDet>();
                   // List<Itm4> _itmList = new List<Itm4>();
                    string invoiceId = _exp.inv[i].InvoiceId;
                    var _curritm = (List<Itm4>)_itmList.Where(x => x.InvoiceId == invoiceId).Select(x => x).ToList();
                    _inv = _resExpInv[i];

                    for (int j = 0; j < _curritm.Count(); j++)
                    {
                        Itm4 _itm = new Itm4();
                        //ItmDet _itmdet = new ItmDet();
                        //_itmdet = (_curritm[j]);
                        _itm.iamt = Convert.ToDecimal(_curritm[j].iamt);
                        _itm.rt = Convert.ToDecimal(_curritm[j].rt);
                        _itm.txval = Convert.ToDecimal(_curritm[j].txval);

                       
                        _itmList.Add(_itm);
                        _inv.itms = _itmList;
                        _exp.inv[i] = _inv;
                    }
                }
                _expList.Add(_exp);
            }
            return _expList;

          
    }

        public static Hsn GetHSNGst1Save(DataTable dtHsn)
        {
            Hsn _hsn = new Hsn();
            List<Datum> _datumList = new List<Datum>();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dtHsn);
            _datumList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Datum>>(JSONString);
            _hsn.data = _datumList;

            return _hsn;
        }

        public static Nil GetNILGst1Save(DataSet dsNil)
        {
            Nil _nil = new Nil();
            List<Inv4> _inv4 = new List<Inv4>();

            //iterate Dataset
            for (int i = 0; i < dsNil.Tables.Count; i++)
            {
                List<Inv4> _inv = new List<Inv4>();//require  list for all table in dataset
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dsNil.Tables[i]);
                _inv = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Inv4>>(JSONString);
                _inv4.AddRange(_inv4);
            }

            _nil.inv = _inv4;
            return _nil;
        }

        #endregion

        #region GST1 Previous Need to remove
        public static ResGst1List GetB2BGst1(ReqGst1 reqGst1, String spName)
        {
            ResGst1List resGst1List = new ResGst1List();
            List<ResGst1> _resGstList = new List<ResGst1>();
            DataSet dsB2B = new DataSet();
            DataTable dtInvoice = new DataTable();
            DataTable dtInvoiceItemRate = new DataTable();

            dtInvoice.Columns.AddRange(new DataColumn[]{
                new DataColumn("GstinNo",typeof(String)),
                new DataColumn("InvoiceId",typeof(String)),
                new DataColumn("InvoiceNo",typeof(String)),
                new DataColumn("InvoiceDate",typeof(String)),
                new DataColumn("TotalAmount",typeof(decimal)),
                new DataColumn("PlaceOfSupply",typeof(String)),
                new DataColumn("IsReverseCharge",typeof(String)),
                 new DataColumn("InvoiceType",typeof(String)),
                  new DataColumn("EcommerceGstinNo",typeof(String)),
                new DataColumn("Cess",typeof(String)),
            });


            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                 new DataColumn("InvoiceId",typeof(String)),
                new DataColumn("TaxableValue",typeof(String)),
                new DataColumn("Rate",typeof(String))
            });
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqGst1.UserId));
                        cmd.Parameters.Add(new SqlParameter("@Year", reqGst1.Year));
                        cmd.Parameters.Add(new SqlParameter("@Month", reqGst1.Month));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsB2B);
                            dtInvoice = dsB2B.Tables[0];
                            dtInvoiceItemRate = dsB2B.Tables[1];
                            //var a = (decimal)dtInvoice.Compute("Sum(TotalAmount)", "");
                            //  var sum = dtInvoice.AsEnumerable().ToList().Sum(r => r.Field<decimal>("TotalAmount"));
                            //int omarks = dtInvoice.AsEnumerable().Select(dr => (int)dr["TotalAmount"]).Sum();
                            //tbobtained.Text = omarks.ToString();

                            resGst1List.InvoiceCount = Convert.ToString(dtInvoice.Rows.Count);
                            for (int i = 0; i < dtInvoice.Rows.Count; i++)
                            {

                                //var tempdt = dtInvoice;

                                //dt = tempdt.Clone();
                                dt.Clear();
                                string invoiceId = Convert.ToString(dtInvoice.Rows[i]["InvoiceId"]);
                                var dr = dtInvoiceItemRate.Select("InvoiceId =" + invoiceId);// fetch data from Datatable with current looping invoiceId

                                //dt.Rows.Add(dtInvoice.Select("InvoiceId =" + invoiceId));

                                for (int k = 0; k < dr.Count(); k++)
                                {
                                    dt.Rows.Add(dr[k].ItemArray);
                                }


                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    ResGst1 resGst1 = new ResGst1();
                                    resGst1.InvoiceId = Convert.ToString(dtInvoice.Rows[i]["invoiceId"]);
                                    resGst1.Cess = Convert.ToString(dtInvoice.Rows[i]["Cess"]);
                                    resGst1.EcommerceGstinNo = Convert.ToString(dtInvoice.Rows[i]["EcommerceGstinNo"]);
                                    resGst1.GstinNo = Convert.ToString(dtInvoice.Rows[i]["GstinNo"]);
                                    resGst1.InvoiceDate = Convert.ToString(dtInvoice.Rows[i]["InvoiceDate"]);
                                    resGst1.InvoiceNo = Convert.ToString(dtInvoice.Rows[i]["InvoiceNo"]);
                                    resGst1.InvoiceType = Convert.ToString(dtInvoice.Rows[i]["InvoiceType"]);
                                    if (!(dtInvoice.Rows[i]["IsReverseCharge"] is DBNull))
                                        resGst1.IsReverseCharge = Convert.ToBoolean(dtInvoice.Rows[i]["IsReverseCharge"]);

                                    resGst1.PlaceOfSupply = Convert.ToString(dtInvoice.Rows[i]["PlaceOfSupply"]);
                                    resGst1.TotalAmount = Convert.ToDecimal(dtInvoice.Rows[i]["TotalAmount"]);

                                    resGst1.TaxableValue = Convert.ToString(dt.Rows[j]["TaxableValue"]);
                                    resGst1.Rate = Convert.ToString(dt.Rows[j]["Rate"]);
                                    _resGstList.Add(resGst1);
                                }
                            }


                            if (dtInvoice.Rows.Count > 0 && dtInvoiceItemRate.Rows.Count > 0)
                            {

                                resGst1List.resGst1 = _resGstList;
                                resGst1List.ResponseCode = 0;
                                resGst1List.ResponseMessage = "B2B detail Fetched Sucessfully";
                            }
                            else
                            {
                                resGst1List.ResponseCode = 0;
                                resGst1List.ResponseMessage = "No records found for B2B";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return resGst1List;
        }
        public static ResGst1List GetB2CLGst1(ReqGst1 reqGst1, String spName)
        {
            ResGst1List resGst1List = new ResGst1List();
            List<ResGst1> _resGstList = new List<ResGst1>();
            DataSet dsB2B = new DataSet();
            DataTable dtInvoice = new DataTable();
            DataTable dtInvoiceItemRate = new DataTable();

            dtInvoice.Columns.AddRange(new DataColumn[]{
                new DataColumn("InvoiceId",typeof(String)),
                new DataColumn("InvoiceNo",typeof(String)),
                new DataColumn("InvoiceDate",typeof(String)),
                new DataColumn("TotalAmount",typeof(decimal)),
                new DataColumn("PlaceOfSupply",typeof(String)),
                  new DataColumn("EcommerceGstinNo",typeof(String)),
                new DataColumn("Cess",typeof(String))
            });


            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                 new DataColumn("InvoiceId",typeof(String)),
                new DataColumn("TaxableValue",typeof(String)),
                new DataColumn("Rate",typeof(String))
            });
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqGst1.UserId));
                        cmd.Parameters.Add(new SqlParameter("@Year", reqGst1.Year));
                        cmd.Parameters.Add(new SqlParameter("@Month", reqGst1.Month));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsB2B);
                            dtInvoice = dsB2B.Tables[0];
                            dtInvoiceItemRate = dsB2B.Tables[1];
                            //var a = (decimal)dtInvoice.Compute("Sum(TotalAmount)", "");
                            //  var sum = dtInvoice.AsEnumerable().ToList().Sum(r => r.Field<decimal>("TotalAmount"));
                            //int omarks = dtInvoice.AsEnumerable().Select(dr => (int)dr["TotalAmount"]).Sum();
                            //tbobtained.Text = omarks.ToString();

                            resGst1List.InvoiceCount = Convert.ToString(dtInvoice.Rows.Count);
                            for (int i = 0; i < dtInvoice.Rows.Count; i++)
                            {

                                //var tempdt = dtInvoice;

                                //dt = tempdt.Clone();
                                dt.Clear();
                                string invoiceId = Convert.ToString(dtInvoice.Rows[i]["InvoiceId"]);
                                var dr = dtInvoiceItemRate.Select("InvoiceId =" + invoiceId);// fetch data from Datatable with current looping invoiceId

                                //dt.Rows.Add(dtInvoice.Select("InvoiceId =" + invoiceId));

                                for (int k = 0; k < dr.Count(); k++)
                                {
                                    dt.Rows.Add(dr[k].ItemArray);
                                }


                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    ResGst1 resGst1 = new ResGst1();
                                    resGst1.InvoiceId = Convert.ToString(dtInvoice.Rows[i]["InvoiceId"]);
                                    resGst1.Cess = Convert.ToString(dtInvoice.Rows[i]["Cess"]);
                                    resGst1.EcommerceGstinNo = Convert.ToString(dtInvoice.Rows[i]["EcommerceGstinNo"]);
                                    resGst1.InvoiceDate = Convert.ToString(dtInvoice.Rows[i]["InvoiceDate"]);
                                    resGst1.InvoiceNo = Convert.ToString(dtInvoice.Rows[i]["InvoiceNo"]);
                                    resGst1.PlaceOfSupply = Convert.ToString(dtInvoice.Rows[i]["PlaceOfSupply"]);
                                    resGst1.TotalAmount = Convert.ToDecimal(dtInvoice.Rows[i]["TotalAmount"]);
                                    resGst1.TaxableValue = Convert.ToString(dt.Rows[j]["TaxableValue"]);
                                    resGst1.Rate = Convert.ToString(dt.Rows[j]["Rate"]);
                                    _resGstList.Add(resGst1);
                                }
                            }


                            if (dtInvoice.Rows.Count > 0 && dtInvoiceItemRate.Rows.Count > 0)
                            {

                                resGst1List.resGst1 = _resGstList;
                                resGst1List.ResponseCode = 0;
                                resGst1List.ResponseMessage = "B2CL detail Fetched Sucessfully";
                            }
                            else
                            {
                                resGst1List.ResponseCode = 0;
                                resGst1List.ResponseMessage = "No records found for B2CL";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return resGst1List;
        }
        public static ResGst1List GetB2CSGst1(ReqGst1 reqGst1, String spName)
        {
            ResGst1List resGst1List = new ResGst1List();
            List<ResGst1> _resGstList = new List<ResGst1>();
            DataSet dsB2B = new DataSet();
            DataTable dtInvoice = new DataTable();
            DataTable dtInvoiceItemRate = new DataTable();

            dtInvoice.Columns.AddRange(new DataColumn[]{
                new DataColumn("InvoiceId",typeof(String)),
                new DataColumn("Type",typeof(String)),
                 new DataColumn("PlaceOfSupply",typeof(String)),
                new DataColumn("Cess",typeof(String)),
                new DataColumn("EcommerceGstinNo",typeof(String))
            });


            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                 new DataColumn("InvoiceId",typeof(String)),
                new DataColumn("TaxableValue",typeof(String)),
                new DataColumn("Rate",typeof(String))
            });
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqGst1.UserId));
                        cmd.Parameters.Add(new SqlParameter("@Year", reqGst1.Year));
                        cmd.Parameters.Add(new SqlParameter("@Month", reqGst1.Month));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsB2B);
                            dtInvoice = dsB2B.Tables[0];
                            dtInvoiceItemRate = dsB2B.Tables[1];

                            resGst1List.InvoiceCount = Convert.ToString(dtInvoice.Rows.Count);
                            for (int i = 0; i < dtInvoice.Rows.Count; i++)
                            {
                                dt.Clear();
                                string invoiceId = Convert.ToString(dtInvoice.Rows[i]["InvoiceId"]);
                                var dr = dtInvoiceItemRate.Select("InvoiceId =" + invoiceId);// fetch data from Datatable with current looping invoiceId
                                for (int k = 0; k < dr.Count(); k++)
                                {
                                    dt.Rows.Add(dr[k].ItemArray);
                                }

                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    ResGst1 resGst1 = new ResGst1();
                                    resGst1.InvoiceId = Convert.ToString(dtInvoice.Rows[i]["InvoiceId"]);
                                    resGst1.Cess = Convert.ToString(dtInvoice.Rows[i]["Cess"]);
                                    resGst1.EcommerceGstinNo = Convert.ToString(dtInvoice.Rows[i]["EcommerceGstinNo"]);
                                    resGst1.Type_E_OE = Convert.ToString(dtInvoice.Rows[i]["Type"]);

                                    resGst1.PlaceOfSupply = Convert.ToString(dtInvoice.Rows[i]["PlaceOfSupply"]);
                                    resGst1.TaxableValue = Convert.ToString(dt.Rows[j]["TaxableValue"]);
                                    resGst1.Rate = Convert.ToString(dt.Rows[j]["Rate"]);
                                    _resGstList.Add(resGst1);
                                }
                            }
                            if (dtInvoice.Rows.Count > 0 && dtInvoiceItemRate.Rows.Count > 0)
                            {

                                resGst1List.resGst1 = _resGstList;
                                resGst1List.ResponseCode = 0;
                                resGst1List.ResponseMessage = "B2CS detail Fetched Sucessfully";
                            }
                            else
                            {
                                resGst1List.ResponseCode = 0;
                                resGst1List.ResponseMessage = "No records found for B2CS";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return resGst1List;
        }
        public static CreditDebitRegisteredGst1List GetCDNRGst1(ReqGst1 reqGst1, String spName)
        {
            CreditDebitRegisteredGst1List creditDebitRegisteredGst1List = new CreditDebitRegisteredGst1List();
            List<CreditDebitRegisteredGst1> _resCreditDebitRegisteredGst1 = new List<CreditDebitRegisteredGst1>();
            DataSet dsCDNR = new DataSet();
            DataTable dtCredit = new DataTable();
            DataTable dtDebit = new DataTable();
            DataTable dtCreditItemRate = new DataTable();
            DataTable dtDebitItemRate = new DataTable();

            var dt_RateCredit = new DataTable();
            dt_RateCredit.Columns.AddRange(new DataColumn[]{
                 new DataColumn("CreditId",typeof(String)),
                new DataColumn("TaxableValue",typeof(String)),
                new DataColumn("Rate",typeof(String))
            });

            var dt_RateDebit = new DataTable();
            dt_RateDebit.Columns.AddRange(new DataColumn[]{
                 new DataColumn("DebitId",typeof(String)),
                new DataColumn("TaxableValue",typeof(String)),
                new DataColumn("Rate",typeof(String))
            });
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqGst1.UserId));
                        cmd.Parameters.Add(new SqlParameter("@Year", reqGst1.Year));
                        cmd.Parameters.Add(new SqlParameter("@Month", reqGst1.Month));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsCDNR);
                            dtCredit = dsCDNR.Tables[0];
                            dtCreditItemRate = dsCDNR.Tables[1];
                            dtDebit = dsCDNR.Tables[2];
                            dtDebitItemRate = dsCDNR.Tables[3];
                            //var a = (decimal)dtInvoice.Compute("Sum(TotalAmount)", "");
                            //  var sum = dtInvoice.AsEnumerable().ToList().Sum(r => r.Field<decimal>("TotalAmount"));
                            //int omarks = dtInvoice.AsEnumerable().Select(dr => (int)dr["TotalAmount"]).Sum();
                            //tbobtained.Text = omarks.ToString();

                            //  resGst1List.InvoiceCount = Convert.ToString(dtInvoice.Rows.Count);
                            for (int i = 0; i < dtCredit.Rows.Count; i++)
                            {
                                dt_RateCredit.Clear();
                                string invoiceId = Convert.ToString(dtCredit.Rows[i]["CreditId"]);
                                var dr = dtCreditItemRate.Select("CreditId =" + invoiceId);// fetch data from Datatable with current looping invoiceId

                                //dt.Rows.Add(dtInvoice.Select("InvoiceId =" + invoiceId));

                                for (int k = 0; k < dr.Count(); k++)
                                {
                                    dt_RateCredit.Rows.Add(dr[k].ItemArray);
                                }


                                for (int j = 0; j < dt_RateCredit.Rows.Count; j++)
                                {
                                    CreditDebitRegisteredGst1 creditDebitRegisteredGst1 = new CreditDebitRegisteredGst1();
                                    creditDebitRegisteredGst1.CreditId = Convert.ToString(dtCredit.Rows[i]["CreditId"]);
                                    creditDebitRegisteredGst1.CessAmount = Convert.ToString(dtCredit.Rows[i]["Cess"]);
                                    creditDebitRegisteredGst1.DocumentType = Convert.ToString(dtCredit.Rows[i]["DocumentType"]);
                                    creditDebitRegisteredGst1.GSTINUINofRecipient = Convert.ToString(dtCredit.Rows[i]["GstinNo"]);
                                    creditDebitRegisteredGst1.InvoiceAdvanceReceiptdate = Convert.ToString(dtCredit.Rows[i]["InvoiceDate"]);
                                    creditDebitRegisteredGst1.InvoiceAdvanceReceiptNumber = Convert.ToString(dtCredit.Rows[i]["InvoiceNo"]);
                                    creditDebitRegisteredGst1.NoteRefundVoucherdate = Convert.ToString(dtCredit.Rows[i]["CreditDate"]);
                                    creditDebitRegisteredGst1.NoteRefundVoucherNumber = Convert.ToString(dtCredit.Rows[j]["CreditNo"]);
                                    creditDebitRegisteredGst1.DocumentType = Convert.ToString(dtCredit.Rows[j]["DocumentType"]);
                                    creditDebitRegisteredGst1.PlaceOfSupplyNoteRefundVoucherValue = Convert.ToString(dtCredit.Rows[j]["PlaceOfSupply"]);
                                    creditDebitRegisteredGst1.PreGST = Convert.ToString(dtCredit.Rows[j]["PreGst"]);
                                    creditDebitRegisteredGst1.ReasonForIssuingdocument = Convert.ToString(dtCredit.Rows[j]["ReasonOfIssuingDocument"]);

                                    creditDebitRegisteredGst1.Rate = Convert.ToString(dt_RateCredit.Rows[j]["Rate"]);
                                    creditDebitRegisteredGst1.TaxableValue = Convert.ToString(dt_RateCredit.Rows[j]["Tax"]);

                                    _resCreditDebitRegisteredGst1.Add(creditDebitRegisteredGst1);


                                }
                            }

                            creditDebitRegisteredGst1List.listCreditDebitRegisteredGst1 = _resCreditDebitRegisteredGst1;
                            if ((dtCredit.Rows.Count > 0 && dtCreditItemRate.Rows.Count > 0))
                            {

                                creditDebitRegisteredGst1List.ResponseCode = 0;
                                creditDebitRegisteredGst1List.ResponseMessage = "CDNR detail Fetched Sucessfully";
                            }
                            else
                            {
                                //resGst1List.ResponseCode = 0;
                                //resGst1List.ResponseMessage = "No records found for B2CL";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return creditDebitRegisteredGst1List;
        }

        #endregion
    }
}
