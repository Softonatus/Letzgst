using SoftonautsService.CRequest;
using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SoftonautsService.Optimize.Invoice
{
    public static class InvoiceCall
    {
        #region INSERT of Advance/Credit/Debit/Estimate/Invoiice
        public static ResCommon InsertAdvance(ReqAdvance reqAdvance, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqAdvance);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqAdvanceItemList"]);
                DataTable dtReqAdvanceItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqAdvanceItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqAdvance.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqAdvance.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@AdvanceNo", reqAdvance.AdvanceNo));
                        cmd.Parameters.Add(new SqlParameter("@AdvanceDate", reqAdvance.AdvanceDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqAdvance.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqAdvance.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqAdvance.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqAdvance.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqAdvance.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqAdvance.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqAdvance.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqAdvance.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqAdvance.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqAdvance.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqAdvance.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqAdvance.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqAdvance.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqAdvance.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqAdvance.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqAdvance.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqAdvance.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqAdvance.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqAdvance.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqAdvance.InvoicePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqAdvance.TermCondition));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceRefNo", reqAdvance.InvoiceRefNo));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqAdvance.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqAdvance.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqAdvance.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@AdvanceItemType", dtReqAdvanceItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqAdvance.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon InsertCredit(ReqCreditNote reqCredit, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqCredit);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqCreditItemList"]);
                DataTable dtReqCreditItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqCreditItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqCredit.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqCredit.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@CreditNo", reqCredit.CreditNo));
                        cmd.Parameters.Add(new SqlParameter("@CreditDate", reqCredit.CreditDate));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqCredit.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqCredit.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqCredit.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqCredit.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqCredit.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqCredit.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqCredit.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceRefNo", reqCredit.InvoiceRefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqCredit.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqCredit.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqCredit.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqCredit.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Advance", reqCredit.Advance));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqCredit.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqCredit.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqCredit.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqCredit.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqCredit.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqCredit.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqCredit.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqCredit.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqCredit.InvoicePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@ReasonOfIssuingDocument", reqCredit.ReasonOfIssuingDocument));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqCredit.TermCondition));
                        cmd.Parameters.Add(new SqlParameter("@DocumentType", reqCredit.DocumentType));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqCredit.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqCredit.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqCredit.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@CreditItemType", dtReqCreditItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqCredit.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon InsertDebit(ReqDebitNote reqDebit, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqDebit);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqDebitItemList"]);
                DataTable dtReqDebitItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqDebitItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqDebit.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqDebit.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@DebitNo", reqDebit.DebitNo));
                        cmd.Parameters.Add(new SqlParameter("@DebitDate", reqDebit.DebitDate));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqDebit.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqDebit.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqDebit.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqDebit.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqDebit.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqDebit.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqDebit.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqDebit.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqDebit.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceRefNo", reqDebit.InvoiceRefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqDebit.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqDebit.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqDebit.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqDebit.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Advance", reqDebit.Advance));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqDebit.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqDebit.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqDebit.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqDebit.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqDebit.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqDebit.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqDebit.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqDebit.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqDebit.InvoicePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@ReasonOfIssuingDocument", reqDebit.ReasonOfIssuingDocument));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqDebit.TermCondition));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqDebit.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqDebit.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqDebit.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@DebitItemType", dtReqDebitItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqDebit.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon InsertEstimate(ReqEstimate reqEstimate, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqEstimate);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqEstimateItemList"]);
                DataTable dtReqEstimateItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqEstimateItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqEstimate.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqEstimate.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@EstimateNo", reqEstimate.EstimateNo));
                        cmd.Parameters.Add(new SqlParameter("@EstimateDate", reqEstimate.EstimateDate));
                        cmd.Parameters.Add(new SqlParameter("@ExpiryDate", reqEstimate.ExpiryDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqEstimate.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqEstimate.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqEstimate.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqEstimate.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqEstimate.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqEstimate.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqEstimate.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqEstimate.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqEstimate.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqEstimate.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqEstimate.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqEstimate.Discount));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqEstimate.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqEstimate.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Status", reqEstimate.Status));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceType", reqEstimate.InvoiceType));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqEstimate.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqEstimate.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@TransportMode", reqEstimate.TransportMode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyDate", reqEstimate.SupplyDate));
                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqEstimate.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@VehicleNo", reqEstimate.VehicleNo));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqEstimate.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqEstimate.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqEstimate.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqEstimate.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqEstimate.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqEstimate.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqEstimate.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqEstimate.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@ShippingBillNo", reqEstimate.ShippingBillNo));
                        cmd.Parameters.Add(new SqlParameter("@TermsCondition", reqEstimate.TermsCondition));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqEstimate.InvoiceDetailPayment));
                        cmd.Parameters.Add(new SqlParameter("@EstimateItemType", dtReqEstimateItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqEstimate.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon InsertInvoice(ReqInvoice reqInvoice, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqInvoice);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqInvoiceItemList"]);
                DataTable dtReqInvoiceItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqInvoiceItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqInvoice.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqInvoice.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceNo", reqInvoice.InvoiceNo));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceDate", reqInvoice.InvoiceDate));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqInvoice.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@Frequency", reqInvoice.Frequency));
                        cmd.Parameters.Add(new SqlParameter("@EndDate", reqInvoice.EndDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqInvoice.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqInvoice.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqInvoice.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqInvoice.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqInvoice.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqInvoice.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqInvoice.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqInvoice.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqInvoice.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqInvoice.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqInvoice.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqInvoice.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Advance", reqInvoice.Advance));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqInvoice.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqInvoice.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Status", reqInvoice.Status));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceType", reqInvoice.InvoiceType));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqInvoice.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqInvoice.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@TransportMode", reqInvoice.TransportMode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyDate", reqInvoice.SupplyDate));
                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqInvoice.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@VehicleNo", reqInvoice.VehicleNo));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqInvoice.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqInvoice.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqInvoice.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqInvoice.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqInvoice.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqInvoice.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqInvoice.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqInvoice.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@ShippingBillNo", reqInvoice.ShippingBillNo));
                        cmd.Parameters.Add(new SqlParameter("@TermsCondition", reqInvoice.TermsCondition));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqInvoice.InvoiceDetailPayment));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceItemType", dtReqInvoiceItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqInvoice.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        #endregion

        #region Update of Advance/Credit/Debit/Estimate/Invoiice
        public static ResCommon UpdateAdvance(ReqAdvance reqAdvance, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqAdvance);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqAdvanceItemList"]);
                DataTable dtReqAdvanceItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqAdvanceItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@AdvanceId", reqAdvance.AdvanceId));
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqAdvance.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqAdvance.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@AdvanceNo", reqAdvance.AdvanceNo));
                        cmd.Parameters.Add(new SqlParameter("@AdvanceDate", reqAdvance.AdvanceDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqAdvance.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqAdvance.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqAdvance.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqAdvance.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqAdvance.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqAdvance.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqAdvance.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqAdvance.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqAdvance.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqAdvance.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqAdvance.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqAdvance.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqAdvance.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqAdvance.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqAdvance.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqAdvance.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqAdvance.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqAdvance.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqAdvance.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqAdvance.InvoicePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqAdvance.TermCondition));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceRefNo", reqAdvance.InvoiceRefNo));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqAdvance.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqAdvance.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqAdvance.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@AdvanceItemType", dtReqAdvanceItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqAdvance.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon UpdateCredit(ReqCreditNote reqCredit, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqCredit);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqCreditItemList"]);
                DataTable dtReqCreditItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqCreditItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@CreditId", reqCredit.CreditId));
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqCredit.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqCredit.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@CreditNo", reqCredit.CreditNo));
                        cmd.Parameters.Add(new SqlParameter("@CreditDate", reqCredit.CreditDate));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqCredit.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqCredit.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqCredit.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqCredit.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqCredit.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqCredit.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqCredit.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceRefNo", reqCredit.InvoiceRefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqCredit.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqCredit.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqCredit.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqCredit.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Advance", reqCredit.Advance));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqCredit.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqCredit.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqCredit.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqCredit.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqCredit.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqCredit.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqCredit.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqCredit.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqCredit.InvoicePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@ReasonOfIssuingDocument", reqCredit.ReasonOfIssuingDocument));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqCredit.TermCondition));
                        cmd.Parameters.Add(new SqlParameter("@DocumentType", reqCredit.DocumentType));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqCredit.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqCredit.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqCredit.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@CreditItemType", dtReqCreditItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqCredit.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon UpdateDebit(ReqDebitNote reqDebit, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqDebit);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqDebitItemList"]);
                DataTable dtReqDebitItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqDebitItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@DebitId", reqDebit.DebitId));
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqDebit.UserId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqDebit.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@DebitNo", reqDebit.DebitNo));
                        cmd.Parameters.Add(new SqlParameter("@DebitDate", reqDebit.DebitDate));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqDebit.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqDebit.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqDebit.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqDebit.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqDebit.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqDebit.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqDebit.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqDebit.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqDebit.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceRefNo", reqDebit.InvoiceRefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqDebit.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqDebit.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqDebit.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqDebit.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Advance", reqDebit.Advance));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqDebit.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqDebit.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqDebit.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqDebit.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqDebit.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqDebit.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqDebit.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqDebit.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqDebit.InvoicePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@ReasonOfIssuingDocument", reqDebit.ReasonOfIssuingDocument));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqDebit.TermCondition));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqDebit.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqDebit.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqDebit.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@DebitItemType", dtReqDebitItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqDebit.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon UpdateEstimate(ReqEstimate reqEstimate, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqEstimate);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqEstimateItemList"]);
                DataTable dtReqEstimateItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqEstimateItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@EstimateId", reqEstimate.EstimateId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqEstimate.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@EstimateNo", reqEstimate.EstimateNo));
                        cmd.Parameters.Add(new SqlParameter("@EstimateDate", reqEstimate.EstimateDate));
                        cmd.Parameters.Add(new SqlParameter("@ExpiryDate", reqEstimate.ExpiryDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqEstimate.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqEstimate.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqEstimate.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqEstimate.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqEstimate.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqEstimate.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqEstimate.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqEstimate.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqEstimate.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqEstimate.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqEstimate.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqEstimate.Discount));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqEstimate.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqEstimate.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Status", reqEstimate.Status));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceType", reqEstimate.InvoiceType));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqEstimate.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqEstimate.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@TransportMode", reqEstimate.TransportMode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyDate", reqEstimate.SupplyDate));
                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqEstimate.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@VehicleNo", reqEstimate.VehicleNo));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqEstimate.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqEstimate.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqEstimate.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqEstimate.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqEstimate.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqEstimate.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqEstimate.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqEstimate.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@ShippingBillNo", reqEstimate.ShippingBillNo));
                        cmd.Parameters.Add(new SqlParameter("@TermsCondition", reqEstimate.TermsCondition));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqEstimate.InvoiceDetailPayment));
                        cmd.Parameters.Add(new SqlParameter("@EstimateItemType", dtReqEstimateItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqEstimate.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        public static ResCommon UpdateInvoice(ReqInvoice reqInvoice, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqInvoice);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["ReqInvoiceItemList"]);
                DataTable dtReqInvoiceItemList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
                dtReqInvoiceItemList.Columns.RemoveAt(0);
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@InvoiceId", reqInvoice.InvoiceId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", reqInvoice.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceNo", reqInvoice.InvoiceNo));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceDate", reqInvoice.InvoiceDate));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqInvoice.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@Frequency", reqInvoice.Frequency));
                        cmd.Parameters.Add(new SqlParameter("@EndDate", reqInvoice.EndDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqInvoice.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress1", reqInvoice.ShippingAddress1));
                        cmd.Parameters.Add(new SqlParameter("@ShippingAddress2", reqInvoice.ShippingAddress2));
                        cmd.Parameters.Add(new SqlParameter("@City", reqInvoice.City));
                        cmd.Parameters.Add(new SqlParameter("@State", reqInvoice.State));
                        cmd.Parameters.Add(new SqlParameter("@PinCode", reqInvoice.PinCode));
                        cmd.Parameters.Add(new SqlParameter("@Country", reqInvoice.Country));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", reqInvoice.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@IsTaxInclusive", reqInvoice.IsTaxInclusive));
                        cmd.Parameters.Add(new SqlParameter("@Note", reqInvoice.Note));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqInvoice.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqInvoice.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Advance", reqInvoice.Advance));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqInvoice.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqInvoice.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@Status", reqInvoice.Status));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceType", reqInvoice.InvoiceType));
                        cmd.Parameters.Add(new SqlParameter("@TransactionCode", reqInvoice.TransactionCode));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqInvoice.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@TransportMode", reqInvoice.TransportMode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyDate", reqInvoice.SupplyDate));
                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqInvoice.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@VehicleNo", reqInvoice.VehicleNo));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqInvoice.Frieght));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqInvoice.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqInvoice.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqInvoice.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqInvoice.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqInvoice.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@Type_E_OE", reqInvoice.Type_E_OE));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqInvoice.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@ShippingBillNo", reqInvoice.ShippingBillNo));
                        cmd.Parameters.Add(new SqlParameter("@TermsCondition", reqInvoice.TermsCondition));
                        cmd.Parameters.Add(new SqlParameter("@InvoicePaymentDetail", reqInvoice.InvoiceDetailPayment));
                        cmd.Parameters.Add(new SqlParameter("@InvoiceItemType", dtReqInvoiceItemList));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqInvoice.CurrentUserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
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

        #endregion

        #region Get Advance/Credit/Debit/Estimate/Invoice
        public static ResAdvanceGetList GetAdvance(ReqUserId reqUserId, String spName)
        {
            ResAdvanceGetList _resAdvanceGetList = new ResAdvanceGetList();
            List<ResAdvanceGet> resAdvanceGetList = new List<ResAdvanceGet>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dt);
                                resAdvanceGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResAdvanceGet>>(JSONString);
                                _resAdvanceGetList.resAdvanceGetList = resAdvanceGetList;
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseCode = 0;
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseMessage = "Advance Detail Fetched Successfully";
                            }
                            else
                            {
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseCode = 0;
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseMessage = "Unable to Fetch Advance Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resAdvanceGetList;
        }

        public static ResCreditNoteGetList GetCredit(ReqUserId reqUserId, String spName)
        {
            ResCreditNoteGetList _resCreditNoteGetList = new ResCreditNoteGetList();
            List<ResCreditNoteGet> resCreditGetList = new List<ResCreditNoteGet>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dt);
                                resCreditGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResCreditNoteGet>>(JSONString);
                                _resCreditNoteGetList.resCreditGetList = resCreditGetList;
                                _resCreditNoteGetList.resCreditGetList[0].ResponseCode = 0;
                                _resCreditNoteGetList.resCreditGetList[0].ResponseMessage = "Credit Detail Fetched Successfully";
                            }
                            else
                            {
                                _resCreditNoteGetList.resCreditGetList[0].ResponseCode = 0;
                                _resCreditNoteGetList.resCreditGetList[0].ResponseMessage = "Unable to Fetch Credit Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resCreditNoteGetList;
        }

        public static ResDebitNoteGetList GetDebit(ReqUserId reqUserId, String spName)
        {
            ResDebitNoteGetList _resDebitNoteGetList = new ResDebitNoteGetList();
            List<ResDebitNoteGet> resDebitNoteGetList = new List<ResDebitNoteGet>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dt);
                                resDebitNoteGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResDebitNoteGet>>(JSONString);
                                _resDebitNoteGetList.resDebitNoteGet = resDebitNoteGetList;
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseCode = 0;
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseMessage = "Debit Detail Fetched Successfully";
                            }
                            else
                            {
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseCode = 0;
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseMessage = "Unable to Fetch Debit Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resDebitNoteGetList;
        }

        public static ResEstimateGetList GetEstimate(ReqUserId reqUserId, String spName)
        {
            ResEstimateGetList _resEstimateGetList = new ResEstimateGetList();
            List<ResEstimateGet> resEstimateGetList = new List<ResEstimateGet>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dt);
                                resEstimateGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResEstimateGet>>(JSONString);
                                _resEstimateGetList.resEstimateGetList = resEstimateGetList;
                                _resEstimateGetList.ResponseCode = 0;
                                _resEstimateGetList.ResponseMessage = "Estimate Detail Fetched Successfully";
                            }
                            else
                            {
                                _resEstimateGetList.resEstimateGetList[0].ResponseCode = 0;
                                _resEstimateGetList.resEstimateGetList[0].ResponseMessage = "Unable to Fetch Estimate Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resEstimateGetList;
        }

        public static ResInvoiceGetList GetInvoice(ReqUserId reqUserId, String spName)
        {
            ResInvoiceGetList _resInvoiceGetList = new ResInvoiceGetList();
            List<ResInvoiceGet> resInvoiceGetList = new List<ResInvoiceGet>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dt);
                                resInvoiceGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResInvoiceGet>>(JSONString);
                                _resInvoiceGetList.resInvoiceGetList = resInvoiceGetList;
                                _resInvoiceGetList.ResponseCode = 0;
                                _resInvoiceGetList.ResponseMessage = "Invoice Detail Fetched Successfully";
                            }
                            else
                            {
                                _resInvoiceGetList.ResponseCode = 0;
                               _resInvoiceGetList.ResponseMessage = "Unable to Fetch Invoice Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resInvoiceGetList;
        }

        public static ResAdvanceGetList GetAdvanceDetail(ReqId reqId, String spName)
        {
            ResAdvanceGetList _resAdvanceGetList = new ResAdvanceGetList();
            List<ResAdvanceGet> resAdvanceGetList = new List<ResAdvanceGet>();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@Id", reqId.Id));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            DataTable dtAdvance = ds.Tables[0];
                            DataTable dtAdvanceItem = ds.Tables[1];
                            if (dtAdvance.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dtAdvance);
                                resAdvanceGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResAdvanceGet>>(JSONString);
                                _resAdvanceGetList.resAdvanceGetList = resAdvanceGetList;

                                string JSONStringAdvItem = string.Empty;
                                JSONStringAdvItem = JsonConvert.SerializeObject(dtAdvanceItem);
                                _resAdvanceGetList.resAdvanceGetList[0].ResAdvanceItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResAdvanceItem>>(JSONStringAdvItem);
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseCode = 0;
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseMessage = "Advance Detail Fetched Successfully";
                            }
                            else
                            {
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseCode = 0;
                                _resAdvanceGetList.resAdvanceGetList[0].ResponseMessage = "Unable to Fetch Advance Detail";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resAdvanceGetList;
        }

        public static ResCreditNoteGetList GetCreditDetail(ReqId reqId, String spName)
        {
            ResCreditNoteGetList _resCreditNoteGetList = new ResCreditNoteGetList();
            List<ResCreditNoteGet> resCreditNoteGetList = new List<ResCreditNoteGet>();
            List<ResCreditItem> resCreditGetList = new List<ResCreditItem>();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@Id", reqId.Id));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            DataTable dtCredit = ds.Tables[0];
                            DataTable dtCreditItem = ds.Tables[1];
                            if (dtCredit.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dtCredit);
                                resCreditNoteGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResCreditNoteGet>>(JSONString);
                                string JSONStringItem = string.Empty;
                                JSONStringItem = JsonConvert.SerializeObject(dtCreditItem);

                                _resCreditNoteGetList.resCreditGetList = resCreditNoteGetList;
                                _resCreditNoteGetList.resCreditGetList[0].ResCreditItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResCreditItem>>(JSONStringItem);
                                _resCreditNoteGetList.resCreditGetList[0].ResponseCode = 0;
                                _resCreditNoteGetList.resCreditGetList[0].ResponseMessage = "Credit Detail Fetched Successfully";
                            }
                            else
                            {
                                _resCreditNoteGetList.resCreditGetList[0].ResponseCode = 0;
                                _resCreditNoteGetList.resCreditGetList[0].ResponseMessage = "Unable to Fetch Credit Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resCreditNoteGetList;
        }

        public static ResDebitNoteGetList GetDebitDetail(ReqId reqId, String spName)
        {
            ResDebitNoteGetList _resDebitNoteGetList = new ResDebitNoteGetList();
            List<ResDebitNoteGet> resDebitNoteGetList = new List<ResDebitNoteGet>();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@Id", reqId.Id));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            DataTable dtCredit = ds.Tables[0];
                            DataTable dtCreditItem = ds.Tables[1];
                            if (dtCredit.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dtCredit);
                                string JSONStringItem = string.Empty;
                                JSONStringItem = JsonConvert.SerializeObject(dtCreditItem);
                                resDebitNoteGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResDebitNoteGet>>(JSONString);
                                _resDebitNoteGetList.resDebitNoteGet = resDebitNoteGetList;
                                _resDebitNoteGetList.resDebitNoteGet[0].ResDebitItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResDebitItem>>(JSONStringItem);
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseCode = 0;
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseMessage = "Debit Detail Fetched Successfully";
                            }
                            else
                            {
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseCode = 0;
                                _resDebitNoteGetList.resDebitNoteGet[0].ResponseMessage = "Unable to Fetch Debit Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resDebitNoteGetList;
        }

        public static ResEstimateGetList GetEstimateDetail(ReqId reqId, String spName)
        {
            ResEstimateGetList _resEstimateGetList = new ResEstimateGetList();
            List<ResEstimateGet> resEstimateGetList = new List<ResEstimateGet>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        DataSet ds = new DataSet();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@Id", reqId.Id));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            DataTable dtEstimate = ds.Tables[0];
                            DataTable dtEstimateItem = ds.Tables[1];
                            if (dtEstimate.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dtEstimate);
                                string JSONStringItem = string.Empty;
                                JSONStringItem = JsonConvert.SerializeObject(dtEstimateItem);
                                resEstimateGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResEstimateGet>>(JSONString);
                                resEstimateGetList[0].ResEstimateItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResEstimateItem>>(JSONStringItem);
                                _resEstimateGetList.resEstimateGetList = resEstimateGetList;
                                _resEstimateGetList.ResponseCode = 0;
                                _resEstimateGetList.ResponseMessage = "Estimate Detail Fetched Successfully";
                            }
                            else
                            {
                                _resEstimateGetList.resEstimateGetList[0].ResponseCode = 0;
                                _resEstimateGetList.resEstimateGetList[0].ResponseMessage = "Unable to Fetch Estimate Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resEstimateGetList;
        }

        public static ResInvoiceGetList GetInvoiceDetail(ReqId reqId, String spName)
        {
            ResInvoiceGetList _resInvoiceGetList = new ResInvoiceGetList();
            List<ResInvoiceGet> resInvoiceGetList = new List<ResInvoiceGet>();
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@Id", reqId.Id));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            DataTable dtInvoice = ds.Tables[0];
                            DataTable dtInvoiceItem = ds.Tables[1];
                            if (dtInvoice.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dtInvoice);
                                string JSONStringItem = string.Empty;
                                resInvoiceGetList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResInvoiceGet>>(JSONString);
                                JSONStringItem = JsonConvert.SerializeObject(dtInvoiceItem);
                                resInvoiceGetList[0].ResInvoiceItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResInvoiceItem>>(JSONStringItem);
                                _resInvoiceGetList.resInvoiceGetList = resInvoiceGetList;
                                _resInvoiceGetList.ResponseCode = 0;
                                _resInvoiceGetList.ResponseMessage = "Invoice Detail Fetched Successfully";
                            }
                            else
                            {
                                _resInvoiceGetList.ResponseCode = 0;
                                _resInvoiceGetList.ResponseMessage = "Unable to Fetch Invoice Detail";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _resInvoiceGetList;
        }

        #endregion
    }
}
