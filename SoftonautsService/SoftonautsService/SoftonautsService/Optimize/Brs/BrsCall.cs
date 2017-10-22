using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SoftonautsService.CRequest;
using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoftonautsService.Optimize.Brs
{
    public static class BrsCall
    {
        public static ResBrsList GetBrsList(ReqBrs reqBrs,string spName)
        {
            ResBrsList resBrsList = new ResBrsList();
            List<ResBrs> _resBrsList = new List<ResBrs>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqBrs.UserId));
                        cmd.Parameters.Add(new SqlParameter("@tableName", reqBrs.tableName));
                        cmd.Parameters.Add(new SqlParameter("@Month", reqBrs.Month));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ResBrs resBrs = new ResBrs();
                                    resBrs.PId = Convert.ToInt16(dt.Rows[i]["PId"]);
                                    resBrs.TId = Convert.ToInt16(dt.Rows[i]["TId"]);
                                    resBrs.VendorName = Convert.ToString(dt.Rows[i]["Name"]);
                                    resBrs.Amount = Convert.ToString(dt.Rows[i]["Amount"]);
                                    resBrs.Date = Convert.ToString(dt.Rows[i]["Date"]);
                                    resBrs.Status = Convert.ToString(dt.Rows[i]["Status"]);
                                    resBrs.PendingAmount = Convert.ToString(dt.Rows[i]["PendingAmount"]);
                                    _resBrsList.Add(resBrs);
                                }
                                resBrsList.resBrsList = _resBrsList;
                                resBrsList.ResponseCode = 0;
                                resBrsList.ResponseMessage = "Detail fetched successfully";
                            }
                            else
                            {
                                resBrsList.ResponseCode = 0;
                                resBrsList.ResponseMessage = "No Records Found";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return resBrsList;
        }

        public static ResCommon InsertBrsPayment(ReqBrsPaymentList reqBrsPayment , string spName)
        {
            ResCommon resCommon = new ResCommon();
           
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        string json = JsonConvert.SerializeObject(reqBrsPayment);
                        JObject jObject = JObject.Parse(json);
                        var jarray = Convert.ToString(jObject["reqBrsPaymentList"]);
                        DataTable dtReqBrsPaymentList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                        dtReqBrsPaymentList.Columns.Remove("Type");
                        dtReqBrsPaymentList.Columns.Remove("ResponseMessage");
                        dtReqBrsPaymentList.Columns.Remove("ResponseCode");

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        
                        cmd.Parameters.Add(new SqlParameter("@BrsPaymentType", dtReqBrsPaymentList));
                        cmd.Parameters.Add(new SqlParameter("@Type", reqBrsPayment.Type));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = 0;
                                resCommon.ResponseMessage = reqBrsPayment.Type+" Inserted Successfully";
                            }
                            else
                            {
                                resCommon.ResponseCode = 0;
                                resCommon.ResponseMessage = "No Records Found";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return resCommon;
        }

        public static ResCommon UpdateBrsPayment(ReqBrsPaymentList reqUpdateBrsPayment, string spName)
        {
            ResCommon resCommon = new ResCommon();

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        string json = JsonConvert.SerializeObject(reqUpdateBrsPayment);
                        JObject jObject = JObject.Parse(json);
                        var jarray = Convert.ToString(jObject["reqBrsPaymentList"]);
                        DataTable dtReqBrsPaymentList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                        dtReqBrsPaymentList.Columns.Remove("Type");
                        dtReqBrsPaymentList.Columns.Remove("ResponseMessage");
                        dtReqBrsPaymentList.Columns.Remove("ResponseCode");

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@BrsPaymentType", dtReqBrsPaymentList));
                        cmd.Parameters.Add(new SqlParameter("@Type", reqUpdateBrsPayment.Type));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = 0;
                                resCommon.ResponseMessage = reqUpdateBrsPayment.Type + " Updated Successfully";
                            }
                            else
                            {
                                resCommon.ResponseCode = 0;
                                resCommon.ResponseMessage = "No Records Found";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return resCommon;
        }

        public static ReqBrsPaymentList GetBrsPayment(ReqGetBrsPayment reqGetBrsPayment, string spName)
        {
            ReqBrsPaymentList _reqBrsPaymentList = new ReqBrsPaymentList();
            List<ReqBrsPayment> reqBrsPaymentList = new List<ReqBrsPayment>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@Id", reqGetBrsPayment.Id));
                        cmd.Parameters.Add(new SqlParameter("@Type", reqGetBrsPayment.Type));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i< dt.Rows.Count; i++)
                                {
                            
                                    ReqBrsPayment resqBrsPayment = new ReqBrsPayment();
                                    resqBrsPayment.Amount = Convert.ToString(dt.Rows[i]["Amount"]);
                                    resqBrsPayment.Id = Convert.ToInt16(dt.Rows[i]["Id"]);
                                    resqBrsPayment.Memo = Convert.ToString(dt.Rows[i]["Memo"]);
                                    resqBrsPayment.ModeNo = Convert.ToString(dt.Rows[i]["ModeNo"]);
                                    resqBrsPayment.PaidDate = Convert.ToString(dt.Rows[i]["PaidDate"]);
                                    resqBrsPayment.PaymentMode = Convert.ToString(dt.Rows[i]["PaymentMode"]);
                                    resqBrsPayment.RealizationDate = Convert.ToString(dt.Rows[i]["RealizationDate"]);

                                    reqBrsPaymentList.Add(resqBrsPayment);
                                }
                                _reqBrsPaymentList.reqBrsPaymentList = reqBrsPaymentList;
                                _reqBrsPaymentList.ResponseCode = 0;
                                _reqBrsPaymentList.ResponseMessage = "Fetched Detail Successfully";
                            }
                            else
                            {
                                _reqBrsPaymentList.ResponseCode = 0;
                                _reqBrsPaymentList.ResponseMessage = "No Records found";
                            }

                            
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _reqBrsPaymentList;
        }
    }
}