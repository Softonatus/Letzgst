using SoftonautsService.CRequest;
using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SoftonautsService.Optimize
{
    public static class DBCall
    {
        public static ResUserListCACompany GetUserListCompanyCA(ReqListUserCACompany reqListUserCACompany, String spName)
        {
            DataTable dt = new DataTable();
            ResUserListCACompany resUserListCACompany = new ResUserListCACompany();
            List<ResUserCACompany> resListUserCACompany = new List<ResUserCACompany>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@ParentId", reqListUserCACompany.ParentId));
                    cmd.Parameters.Add(new SqlParameter("@UserType", reqListUserCACompany.UserType));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(dt);
                    }
                }
            }
            try { 
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                ResUserCACompany resUserCACompany = new ResUserCACompany();
                resUserCACompany.Name = Convert.ToString(dt.Rows[i]["Name"]);
                resUserCACompany.EmailId = Convert.ToString(dt.Rows[i]["EmailId"]);
                    if (!(dt.Rows[i]["UserId"] is DBNull))
                        resUserCACompany.UserId = Convert.ToInt16(dt.Rows[i]["UserId"]);
                resUserCACompany.ContactNo = Convert.ToString(dt.Rows[i]["ContactNo"]);
                    resListUserCACompany.Add(resUserCACompany);
            }
                resUserListCACompany.resUserCACompany = resListUserCACompany;
                resUserListCACompany.ResponseCode = 0;
                resUserListCACompany.ResponseMessage = "Fetched detail successfully";
}
    catch(Exception ex){}

            return resUserListCACompany;

        }

        public static ResCompanyListCA GetListCompanyCA(ReqUserId reqUserId, String spName)
        {
            DataTable dt = new DataTable();
            ResCompanyListCA resListCACompany = new ResCompanyListCA();
            List<ResCompany_CA> resListCACompanyList = new List<ResCompany_CA>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@ParentId", reqUserId.UserId));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResCompany_CA resCACompany = new ResCompany_CA();
                    resCACompany.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    resCACompany.EmailId = Convert.ToString(dt.Rows[i]["EmailId"]);
                    if (!(dt.Rows[i]["UserId"] is DBNull))
                        resCACompany.UserId = Convert.ToInt16(dt.Rows[i]["UserId"]);
                    resCACompany.ContactNo = Convert.ToString(dt.Rows[i]["ContactNo"]);
                    resListCACompanyList.Add(resCACompany);
                }
                resListCACompany.resCompany_CA = resListCACompanyList;
                resListCACompany.ResponseCode = 0;
                resListCACompany.ResponseMessage = "Fetched detail successfully";
            }
            catch (Exception ex) { }

            return resListCACompany;

        }
        public static ResListHsnCodeGoods GetListHsnCode(ReqHsnCode reqHsnCode, String spName)
        {
            DataTable dt = new DataTable();
            ResListHsnCodeGoods resListHsnCodeGoods = new ResListHsnCodeGoods();
            List<ResHsnCodeGoods> resHsnCodeGoods = new List<ResHsnCodeGoods>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@HsnDetail", reqHsnCode.HsnDetail));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(dt);
                    }
                }
            }
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResHsnCodeGoods _resHsnCodeGoods = new ResHsnCodeGoods();
                    _resHsnCodeGoods.HsnCodeId = Convert.ToString(dt.Rows[i]["HsnCodeId"]);
                    _resHsnCodeGoods.HsnCode = Convert.ToString(dt.Rows[i]["HsnCode"]);
                    _resHsnCodeGoods.HsnDetail = Convert.ToString(dt.Rows[i]["HsnDetail"]);
                    _resHsnCodeGoods.HsnRate = Convert.ToString(dt.Rows[i]["HsnRate"]);

                    resHsnCodeGoods.Add(_resHsnCodeGoods);
                }
                resListHsnCodeGoods.resHsnCodeGoods = resHsnCodeGoods;
                resListHsnCodeGoods.ResponseCode = 0;
                resListHsnCodeGoods.ResponseMessage = "Fetched detail successfully";

            }
            catch (Exception ex) { }

            return resListHsnCodeGoods;

        }

        public static ResListHsnCodeGoods GetUserHsnDetail(int reqUserId, String spName)
        {
            DataTable dt = new DataTable();
            ResListHsnCodeGoods resListHsnCodeGoods = new ResListHsnCodeGoods();
            List<ResHsnCodeGoods> resHsnCodeGoods = new List<ResHsnCodeGoods>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResHsnCodeGoods _resHsnCodeGoods = new ResHsnCodeGoods();
                    _resHsnCodeGoods.HsnCodeId = Convert.ToString(dt.Rows[i]["HsnCodeId"]);
                    _resHsnCodeGoods.HsnCode = Convert.ToString(dt.Rows[i]["HsnCode"]);
                    _resHsnCodeGoods.HsnDetail = Convert.ToString(dt.Rows[i]["HsnDetail"]);
                    _resHsnCodeGoods.HsnRate = Convert.ToString(dt.Rows[i]["HsnRate"]);

                    resHsnCodeGoods.Add(_resHsnCodeGoods);
                }
                resListHsnCodeGoods.resHsnCodeGoods = resHsnCodeGoods;
                resListHsnCodeGoods.ResponseCode = 0;
                resListHsnCodeGoods.ResponseMessage = "Fetched detail successfully";

            }
            catch (Exception ex) { }

            return resListHsnCodeGoods;

        }

        public static ResCommon InsertUserHSNCode(ReqInsertUserHsn reqInsertUserHsn, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dtHsnUserCode = new DataTable();
            DataTable dt = new DataTable();
            dtHsnUserCode.Columns.Add("UserId");
            dtHsnUserCode.Columns.Add("HsnCodeId");
            DataRow row;
            for (int i = 0; i < reqInsertUserHsn.reqUserHsnList.Count(); i++)
            {
         
                row = dtHsnUserCode.NewRow();
                row["UserId"] = reqInsertUserHsn.reqUserHsnList[i].UserId;
                row["HsnCodeId"] = reqInsertUserHsn.reqUserHsnList[i].Id;
                dtHsnUserCode.Rows.Add(row);
            }
          
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@User_HsnCode", dtHsnUserCode));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
            resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
            return resCommon;

        }

        public static ResUserHsnHscCode GetUserHsn_HscCode(ReqUserId reqUserId, String spName)
        {
            DataSet ds = new DataSet();
            ResUserHsnHscCode resUserHsnHscCode = new ResUserHsnHscCode();

            ResListHsnCodeGoods resListHsnCodeGoods = new ResListHsnCodeGoods();
            List<ResHsnCodeGoods> resHsnCodeGoods = new List<ResHsnCodeGoods>();

            ResListHsnCodeGoods resListHsnCodeService = new ResListHsnCodeGoods();
            List<ResHsnCodeGoods> resHsnCodeService = new List<ResHsnCodeGoods>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            try
            {
                //Fill Hsc code from Table 1
                DataTable dtHsnService = new DataTable();
                dtHsnService = ds.Tables[0];
                if (dtHsnService.Rows.Count > 0)
                {
                    for (int i = 0; i < dtHsnService.Rows.Count; i++)
                    {
                        ResHsnCodeGoods _resHsnCodeService = new ResHsnCodeGoods();
                        _resHsnCodeService.HsnCodeId = Convert.ToString(dtHsnService.Rows[i]["HsnCodeId"]);
                        _resHsnCodeService.HsnCode = Convert.ToString(dtHsnService.Rows[i]["HsnCode"]);
                        _resHsnCodeService.HsnDetail = Convert.ToString(dtHsnService.Rows[i]["HsnDetail"]);
                        _resHsnCodeService.HsnRate = Convert.ToString(dtHsnService.Rows[i]["HsnRate"]);

                        resHsnCodeService.Add(_resHsnCodeService);
                    }
                    resUserHsnHscCode.reqUserHscList = resHsnCodeService;

                }

                //Fill HSN Code from Table 2
                DataTable dtHsnGoods = new DataTable();
                dtHsnGoods = ds.Tables[1];
                if (dtHsnGoods.Rows.Count > 0)
                {
                    for (int i = 0; i < dtHsnGoods.Rows.Count; i++)
                    {
                        ResHsnCodeGoods _resHsnCodeGoods = new ResHsnCodeGoods();
                        _resHsnCodeGoods.HsnCodeId = Convert.ToString(dtHsnGoods.Rows[i]["HsnCodeId"]);
                        _resHsnCodeGoods.HsnCode = Convert.ToString(dtHsnGoods.Rows[i]["HsnCode"]);
                        _resHsnCodeGoods.HsnDetail = Convert.ToString(dtHsnGoods.Rows[i]["HsnDetail"]);
                        _resHsnCodeGoods.HsnRate = Convert.ToString(dtHsnGoods.Rows[i]["HsnRate"]);

                        resHsnCodeGoods.Add(_resHsnCodeGoods);
                    }
                    resUserHsnHscCode.reqUserHsnList = resHsnCodeGoods;
                }
                    resUserHsnHscCode.ResponseCode = 0;
                    resUserHsnHscCode.ResponseMessage = "Fetched detail successfully";
                
            }
            catch (Exception ex) { }

            return resUserHsnHscCode;

        }

        public static ResCommon DeleteUserHsn(ReqUserHsn reqInsertUserHsn, String spName)
        {
            ResCommon resCommon = new ResCommon();
            
            DataTable dt = new DataTable();
           

            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqInsertUserHsn.UserId));
                        cmd.Parameters.Add(new SqlParameter("@Id", reqInsertUserHsn.Id));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
            resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
            return resCommon;

        }

        public static ResVendorList GetVendorList(ReqUserId reqUserId, String spName)
        {
            ResVendorList resVendorList = new ResVendorList();

            List<ResVendor> resListVendor = new List<ResVendor>();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                       
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResVendor resVendor = new ResVendor();
                        resVendor.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                        resVendor.VendorName = Convert.ToString(dt.Rows[i]["VendorName"]);
                        resVendor.State = Convert.ToString(dt.Rows[i]["State"]);
                        resListVendor.Add(resVendor);
                    }
                    resVendorList.ResponseCode = 0;
                    resVendorList.ResponseMessage = "Fetched detail successfully";
                    resVendorList.resVendor = resListVendor;
                }
                else {
                    resVendorList.ResponseCode = 0;
                    resVendorList.ResponseMessage = "No record Found";
                }
                
            }
            catch (Exception ex) { }
            return resVendorList;
        }

        public static ResGetExpenseList GetExpenseList(ReqUserId reqUserId, String spName)
        {
            ResGetExpenseList resGetExpenseList = new ResGetExpenseList();

            List<ResGetExpense> resListGetExpense = new List<ResGetExpense>();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResGetExpense resGetExpense = new ResGetExpense();
                        resGetExpense.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                        resGetExpense.ExpenseType = Convert.ToString(dt.Rows[i]["ExpenseType"]);
                        resListGetExpense.Add(resGetExpense);
                    }
                    resGetExpenseList.ResponseCode = 0;
                    resGetExpenseList.ResponseMessage = "Fetched detail successfully";
                    resGetExpenseList.resExpenseList = resListGetExpense;
                }
                else {
                    resGetExpenseList.ResponseCode = 0;
                    resGetExpenseList.ResponseMessage = "No records found";
                }

            }
            catch (Exception ex) { }
            return resGetExpenseList;
        }

        public static ResUserItemsList GetUserItemList(ReqUserId reqUserId, String spName)
        {
            ResUserItemsList resUserItemsList = new ResUserItemsList();
            List<ResUserItems> _resUserItemsList = new List<ResUserItems>();


            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResUserItems resUserItems = new ResUserItems();
                        resUserItems.Id = Convert.ToInt16(dt.Rows[i]["Id"]);
                        resUserItems.HsnCodeId = Convert.ToString(dt.Rows[i]["HsnCodeId"]);
                        resUserItems.ItemDescription = Convert.ToString(dt.Rows[i]["ItemDescription"]);
                        resUserItems.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);
                        resUserItems.Price = Convert.ToString(dt.Rows[i]["Price"]);
                        resUserItems.UnitOfMeasures = Convert.ToString(dt.Rows[i]["UnitOfMeasures"]);
                        resUserItems.Tax = Convert.ToString(dt.Rows[i]["Tax"]);
                        _resUserItemsList.Add(resUserItems);
                    }
                    resUserItemsList.resUserItemsList = _resUserItemsList;
                    resUserItemsList.ResponseCode = 0;
                    resUserItemsList.ResponseMessage = "Fetched detail successfully";
                  
                }
                else {
                    resUserItemsList.ResponseCode = 0;
                    resUserItemsList.ResponseMessage = "No records found";
                }

            }
            catch (Exception ex) { }
            return resUserItemsList;
        }

        #region Purchase

        public static ResCommon InsertPurchase(ReqPurchase reqPurchase, String spName)
        {
            ResCommon resCommon = new ResCommon();
            List<ReqPurchaseItem> listreqPurchaseItem = new List<ReqPurchaseItem>();
            DataTable dt = new DataTable();
            DataTable dtPurchaseItem = new DataTable();
            dtPurchaseItem.Columns.Add("PoId");
            dtPurchaseItem.Columns.Add("PurchaseId");
            dtPurchaseItem.Columns.Add("ItemId");
            dtPurchaseItem.Columns.Add("Description");
            dtPurchaseItem.Columns.Add("Price");
            dtPurchaseItem.Columns.Add("Quantity");
            dtPurchaseItem.Columns.Add("Unit");
            dtPurchaseItem.Columns.Add("Tax");
           
            DataRow row;

            for (int i = 0; i < reqPurchase.PurchaseItemList.Count(); i++)
            {
                row = dtPurchaseItem.NewRow();
                
                ReqPurchaseItem _reqPurchaseItem = new ReqPurchaseItem();
                row["PoId"] = reqPurchase.PurchaseItemList[i].PoId;
                row["PurchaseId"] = reqPurchase.PurchaseId;
                row["ItemId"] = reqPurchase.PurchaseItemList[i].ItemId;
                row["Description"] = reqPurchase.PurchaseItemList[i].Description;
                row["Price"] = reqPurchase.PurchaseItemList[i].Price;
                row["Quantity"] = reqPurchase.PurchaseItemList[i].Quantity;
                row["Unit"] = reqPurchase.PurchaseItemList[i].Unit;
                row["Tax"] = reqPurchase.PurchaseItemList[i].Tax;
               
                dtPurchaseItem.Rows.Add(row);
            }
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqPurchase.UserId));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseVendorId", reqPurchase.PurchaseVendorId));
                        cmd.Parameters.Add(new SqlParameter("@PoId", reqPurchase.PoId));
                        cmd.Parameters.Add(new SqlParameter("@PoDate", reqPurchase.PoDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqPurchase.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqPurchase.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseType", reqPurchase.ExpenseType));
                        cmd.Parameters.Add(new SqlParameter("@RefId", reqPurchase.RefId));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqPurchase.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Notes", reqPurchase.Notes));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqPurchase.TotalAmount));

                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqPurchase.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqPurchase.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyType", reqPurchase.SupplyType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillType", reqPurchase.ExpenseBillType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillHead", reqPurchase.ExpenseBillHead));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqPurchase.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqPurchase.Freight));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqPurchase.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqPurchase.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqPurchase.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqPurchase.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqPurchase.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseType", reqPurchase.PurchaseType));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseCode", reqPurchase.PurchaseCode));
                        cmd.Parameters.Add(new SqlParameter("@TypeOfCredit", reqPurchase.TypeOfCredit));
                        cmd.Parameters.Add(new SqlParameter("@PurchasePaymentDetail", reqPurchase.PurchasePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqPurchase.TermCondition));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseItemType", dtPurchaseItem));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            resCommon.ResponseCode =Convert.ToInt16(dt.Rows[0][0]);
                            resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
           
            return resCommon;
        }

        public static ResCommon UpdatePurchase(ReqPurchase reqUpdatePurchase, String spName)
        {
            ResCommon resCommon = new ResCommon();
            List<ReqPurchaseItem> listreqPurchaseItem = new List<ReqPurchaseItem>();
            DataTable dt = new DataTable();
            DataTable dtPurchaseItem = new DataTable();
            dtPurchaseItem.Columns.Add("PoId");
            dtPurchaseItem.Columns.Add("PurchaseId");
            dtPurchaseItem.Columns.Add("ItemId");
            dtPurchaseItem.Columns.Add("Description");
            dtPurchaseItem.Columns.Add("Price");
            dtPurchaseItem.Columns.Add("Quantity");
            dtPurchaseItem.Columns.Add("Unit");
            dtPurchaseItem.Columns.Add("Tax");
           
            DataRow row;

            for (int i = 0; i < reqUpdatePurchase.PurchaseItemList.Count(); i++)
            {
                row = dtPurchaseItem.NewRow();
                ReqPurchaseItem _reqPurchaseItem = new ReqPurchaseItem();
                row["PoId"] = reqUpdatePurchase.PurchaseItemList[i].PoId;
                row["PurchaseId"] = reqUpdatePurchase.PurchaseId;
                row["ItemId"] = reqUpdatePurchase.PurchaseItemList[i].ItemId;
                row["Description"] = reqUpdatePurchase.PurchaseItemList[i].Description;
                row["Price"] = reqUpdatePurchase.PurchaseItemList[i].Price;
                row["Quantity"] = reqUpdatePurchase.PurchaseItemList[i].Quantity;
                row["Unit"] = reqUpdatePurchase.PurchaseItemList[i].Unit;
                row["Tax"] = reqUpdatePurchase.PurchaseItemList[i].Tax;
                dtPurchaseItem.Rows.Add(row);
            }

            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUpdatePurchase.UserId));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseId", reqUpdatePurchase.PurchaseId));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseVendorId", reqUpdatePurchase.PurchaseVendorId));
                        cmd.Parameters.Add(new SqlParameter("@PoId", reqUpdatePurchase.PoId));
                        cmd.Parameters.Add(new SqlParameter("@PoDate", reqUpdatePurchase.PoDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqUpdatePurchase.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqUpdatePurchase.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseType", reqUpdatePurchase.ExpenseType));
                        cmd.Parameters.Add(new SqlParameter("@RefId", reqUpdatePurchase.RefId));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqUpdatePurchase.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Notes", reqUpdatePurchase.Notes));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqUpdatePurchase.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseItemType", dtPurchaseItem));

                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqUpdatePurchase.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqUpdatePurchase.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyType", reqUpdatePurchase.SupplyType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillType", reqUpdatePurchase.ExpenseBillType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillHead", reqUpdatePurchase.ExpenseBillHead));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqUpdatePurchase.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@Freight", reqUpdatePurchase.Freight));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqUpdatePurchase.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqUpdatePurchase.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqUpdatePurchase.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqUpdatePurchase.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqUpdatePurchase.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseType", reqUpdatePurchase.PurchaseType));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseCode", reqUpdatePurchase.PurchaseCode));
                        cmd.Parameters.Add(new SqlParameter("@TypeOfCredit", reqUpdatePurchase.TypeOfCredit));
                        cmd.Parameters.Add(new SqlParameter("@PurchasePaymentDetail", reqUpdatePurchase.PurchasePaymentDetail));
                        cmd.Parameters.Add(new SqlParameter("@TermCondition", reqUpdatePurchase.TermCondition));

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
                    catch (Exception ex) { }
                }
            }

            return resCommon;
        }

        public static ReqPurchaseList GetPurchaseList(ReqUserId reqUserId, String spName)
        {
            DataTable dt = new DataTable();
            ReqPurchaseList reqPurchaseList = new ReqPurchaseList();
            List<ReqPurchase> _reqPurchase = new List<ReqPurchase>();
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
                    }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ReqPurchase reqPurchase = new ReqPurchase();
                        if (!(dt.Rows[i]["PurchaseId"] is DBNull))
                            reqPurchase.PurchaseId = Convert.ToInt16(dt.Rows[i]["PurchaseId"]);
                        if (!(dt.Rows[i]["PurchaseVendorId"] is DBNull))
                            reqPurchase.PurchaseVendorId = Convert.ToInt16(dt.Rows[i]["PurchaseVendorId"]);
                        reqPurchase.VendorName = Convert.ToString(dt.Rows[i]["VendorName"]);
                        if (!(dt.Rows[i]["PoId"] is DBNull))
                            reqPurchase.PoId = Convert.ToInt16(dt.Rows[i]["PoId"]);
                        reqPurchase.PoDate = Convert.ToString(dt.Rows[i]["PoDate"]);
                        reqPurchase.PaymentTerm = Convert.ToString(dt.Rows[i]["PaymentTerm"]);
                        reqPurchase.DueDate = Convert.ToString(dt.Rows[i]["DueDate"]);
                        if (!(dt.Rows[i]["ExpenseType"] is DBNull))
                            reqPurchase.ExpenseType = Convert.ToInt16(dt.Rows[i]["ExpenseType"]);
                        reqPurchase.RefId = Convert.ToString(dt.Rows[i]["RefId"]);
                        reqPurchase.AttachmentUrl = Convert.ToString(dt.Rows[i]["AttachmentUrl"]);
                        reqPurchase.Notes = Convert.ToString(dt.Rows[i]["Notes"]);
                        reqPurchase.TotalAmount = Convert.ToString(dt.Rows[i]["TotalAmount"]);


                        _reqPurchase.Add(reqPurchase);
                    }
                    reqPurchaseList.reqPurchaseList = _reqPurchase;
                    reqPurchaseList.ResponseCode = 0;
                    reqPurchaseList.ResponseMessage = "Fetched detail successfully";
                }
                else {
                    reqPurchaseList.ResponseCode = 0;
                    reqPurchaseList.ResponseMessage = "No Records Found";
                }

            }
            catch (Exception ex) { }

            return reqPurchaseList;

        }

        public static ResPurchase_PurchaseItem GetPurchaseDetail(ReqId reqId, String spName)
        {
            DataSet ds = new DataSet();
            ResPurchase_PurchaseItem resPurchase_PurchaseItem = new ResPurchase_PurchaseItem();
         
            List<ReqPurchaseItem> _reqPurchaseItemList = new List<ReqPurchaseItem>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@PurchaseId", reqId.Id));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            try
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                DataTable dtPurchaseItem = new DataTable();
                dtPurchaseItem = ds.Tables[1];
                if (ds.Tables[0].Rows.Count > 0)
                {
                        ReqPurchase reqPurchase = new ReqPurchase();
                    if (!(dt.Rows[0]["PurchaseId"] is DBNull))
                        reqPurchase.PurchaseId = Convert.ToInt16(dt.Rows[0]["PurchaseId"]);
                    if (!(dt.Rows[0]["PurchaseVendorId"] is DBNull))
                        reqPurchase.PurchaseVendorId = Convert.ToInt16(dt.Rows[0]["PurchaseVendorId"]);
                    reqPurchase.VendorName = Convert.ToString(dt.Rows[0]["VendorName"]);
                    if (!(dt.Rows[0]["PoId"] is DBNull))
                        reqPurchase.PoId = Convert.ToInt16(dt.Rows[0]["PoId"]);
                        reqPurchase.PoDate = Convert.ToString(dt.Rows[0]["PoDate"]);
                        reqPurchase.PaymentTerm = Convert.ToString(dt.Rows[0]["PaymentTerm"]);
                        reqPurchase.DueDate = Convert.ToString(dt.Rows[0]["DueDate"]);
                    if (!(dt.Rows[0]["ExpenseType"] is DBNull))
                        reqPurchase.ExpenseType = Convert.ToInt16(dt.Rows[0]["ExpenseType"]);
                        reqPurchase.RefId = Convert.ToString(dt.Rows[0]["RefId"]);
                        reqPurchase.AttachmentUrl = Convert.ToString(dt.Rows[0]["AttachmentUrl"]);
                        reqPurchase.Notes = Convert.ToString(dt.Rows[0]["Notes"]);
                        reqPurchase.TotalAmount = Convert.ToString(dt.Rows[0]["TotalAmount"]);

                    reqPurchase.PlaceOfSupply = Convert.ToString(dt.Rows[0]["PlaceOfSupply"]);
                    reqPurchase.PortCode = Convert.ToString(dt.Rows[0]["PortCode"]);
                    reqPurchase.SupplyType = Convert.ToString(dt.Rows[0]["SupplyType"]);
                    reqPurchase.ExpenseBillType = Convert.ToString(dt.Rows[0]["ExpenseBillType"]);
                    reqPurchase.ExpenseBillHead = Convert.ToString(dt.Rows[0]["ExpenseBillHead"]);
                    reqPurchase.IsReverseCharge = Convert.ToBoolean(dt.Rows[0]["IsReverseCharge"]);
                    reqPurchase.Freight = Convert.ToString(dt.Rows[0]["Freight"]);
                    reqPurchase.LabourCharge = Convert.ToString(dt.Rows[0]["LabourCharge"]);
                    reqPurchase.InsuranceAmount = Convert.ToString(dt.Rows[0]["InsuranceAmount"]);
                    reqPurchase.OtherCharge = Convert.ToString(dt.Rows[0]["OtherCharge"]);
                    reqPurchase.Cess = Convert.ToString(dt.Rows[0]["Cess"]);
                    reqPurchase.Prefix = Convert.ToString(dt.Rows[0]["Prefix"]);

                    reqPurchase.PurchaseType = Convert.ToString(dt.Rows[0]["PurchaseType"]);
                    reqPurchase.PurchaseCode = Convert.ToString(dt.Rows[0]["PurchaseCode"]);
                    reqPurchase.TypeOfCredit = Convert.ToString(dt.Rows[0]["TypeOfCredit"]);
                    reqPurchase.TermCondition = Convert.ToString(dt.Rows[0]["TermCondition"]);
                    reqPurchase.PurchasePaymentDetail = Convert.ToString(dt.Rows[0]["PurchasePaymentDetail"]);

                    resPurchase_PurchaseItem.resPurchase = reqPurchase;

                    for (int i = 0; i < dtPurchaseItem.Rows.Count; i++)
                    {
                        ReqPurchaseItem _reqPurchaseItem = new ReqPurchaseItem();
                        if (!(dt.Rows[0]["PoId"] is DBNull))
                            _reqPurchaseItem.PoId = Convert.ToInt16(dtPurchaseItem.Rows[i]["PoId"]);
                        _reqPurchaseItem.Description = Convert.ToString(dtPurchaseItem.Rows[i]["Description"]);
                        if (!(dtPurchaseItem.Rows[i]["ItemId"] is DBNull))
                            _reqPurchaseItem.ItemId = Convert.ToInt16(dtPurchaseItem.Rows[i]["ItemId"]);
                        _reqPurchaseItem.Price = Convert.ToString(dtPurchaseItem.Rows[i]["Price"]);
                        _reqPurchaseItem.Quantity = Convert.ToString(dtPurchaseItem.Rows[i]["Quantity"]);
                        _reqPurchaseItem.Tax = Convert.ToString(dtPurchaseItem.Rows[i]["Tax"]);
                        _reqPurchaseItem.Unit = Convert.ToString(dtPurchaseItem.Rows[i]["Unit"]);



                        _reqPurchaseItemList.Add(_reqPurchaseItem);
                       

                    }
                    resPurchase_PurchaseItem.resPurchaseItemList = _reqPurchaseItemList;
                    resPurchase_PurchaseItem.ResponseCode = 0;
                    resPurchase_PurchaseItem.ResponseMessage = "Fetched detail successfully";
                }

            }
            catch (Exception ex) { }

            return resPurchase_PurchaseItem;

        }

        public static ResCommon BulkInsertPurchase(ResPurchase_PurchaseItemList resPurchase_PurchaseItemList, String spName)
        {
            ResCommon resCommon = new ResCommon();
            List<ReqPurchase> listreqPurchase = new List<ReqPurchase>();
            List<ReqPurchaseItem> listreqPurchaseItem = new List<ReqPurchaseItem>();
            DataTable dt = new DataTable();

            DataTable dtPurchase = new DataTable();
            dtPurchase.Columns.Add("UserId");
            dtPurchase.Columns.Add("PurchaseVendorId");
            //dtPurchase.Columns.Add("VendorName");
            dtPurchase.Columns.Add("PoId");
            dtPurchase.Columns.Add("PoDate");
            dtPurchase.Columns.Add("Paymentterm");
            dtPurchase.Columns.Add("DueDate");
            dtPurchase.Columns.Add("ExpenseType");
            dtPurchase.Columns.Add("RefId");
            dtPurchase.Columns.Add("AttachmentUrl");
            dtPurchase.Columns.Add("Notes");
            dtPurchase.Columns.Add("TotalAmount");
            DataRow rowPurchase;
            for (int i = 0; i < resPurchase_PurchaseItemList.resPurchaseList.Count(); i++)
            {
                rowPurchase = dtPurchase.NewRow();
                ReqPurchase _reqPurchase = new ReqPurchase();
                rowPurchase["UserId"] = resPurchase_PurchaseItemList.resPurchaseList[i].UserId;
                rowPurchase["PurchaseVendorId"] = resPurchase_PurchaseItemList.resPurchaseList[i].PurchaseVendorId;
                //rowPurchase["VendorName"] = resPurchase_PurchaseItemList.resPurchaseList[i].VendorName;
                rowPurchase["PoId"] = resPurchase_PurchaseItemList.resPurchaseList[i].PoId;
                rowPurchase["PoDate"] = resPurchase_PurchaseItemList.resPurchaseList[i].PoDate;
                rowPurchase["PaymentTerm"] = resPurchase_PurchaseItemList.resPurchaseList[i].PaymentTerm;
                rowPurchase["DueDate"] = resPurchase_PurchaseItemList.resPurchaseList[i].DueDate;
                rowPurchase["ExpenseType"] = resPurchase_PurchaseItemList.resPurchaseList[i].ExpenseType;
                rowPurchase["RefId"] = resPurchase_PurchaseItemList.resPurchaseList[i].RefId;
                rowPurchase["AttachmentUrl"] = resPurchase_PurchaseItemList.resPurchaseList[i].AttachmentUrl;
                rowPurchase["Notes"] = resPurchase_PurchaseItemList.resPurchaseList[i].Notes;
                rowPurchase["TotalAmount"] = resPurchase_PurchaseItemList.resPurchaseList[i].TotalAmount;

                dtPurchase.Rows.Add(rowPurchase);
            }

            DataTable dtPurchaseItem = new DataTable();
            dtPurchaseItem.Columns.Add("PoId");
            dtPurchaseItem.Columns.Add("Description");
            dtPurchaseItem.Columns.Add("ItemId");
            dtPurchaseItem.Columns.Add("Price");
            dtPurchaseItem.Columns.Add("Quantity");
            dtPurchaseItem.Columns.Add("Tax");
            dtPurchaseItem.Columns.Add("Unit");
            DataRow rowPurchaseItem;

            for (int i = 0; i < resPurchase_PurchaseItemList.resPurchaseItemList.Count(); i++)
            {
                rowPurchaseItem = dtPurchaseItem.NewRow();

                ReqPurchaseItem _reqPurchaseItem = new ReqPurchaseItem();
                rowPurchaseItem["PoId"] = resPurchase_PurchaseItemList.resPurchaseItemList[i].PoId;
                rowPurchaseItem["Description"] = resPurchase_PurchaseItemList.resPurchaseItemList[i].Description;
                rowPurchaseItem["ItemId"] = resPurchase_PurchaseItemList.resPurchaseItemList[i].ItemId;
                rowPurchaseItem["Price"] = resPurchase_PurchaseItemList.resPurchaseItemList[i].Price;
                rowPurchaseItem["Quantity"] = resPurchase_PurchaseItemList.resPurchaseItemList[i].Quantity;
                rowPurchaseItem["Tax"] = resPurchase_PurchaseItemList.resPurchaseItemList[i].Tax;
                rowPurchaseItem["Unit"] = resPurchase_PurchaseItemList.resPurchaseItemList[i].Unit;
                dtPurchaseItem.Rows.Add(rowPurchaseItem);
                //  listreqPurchaseItem.Add(_reqPurchaseItem);
            }

            //reqPurchase.PurchaseItemList = listreqPurchaseItem;
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@PurchaseType", dtPurchase));
                        cmd.Parameters.Add(new SqlParameter("@PurchaseItemType", dtPurchaseItem));

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
                    catch (Exception ex) { }
                }
            }

            return resCommon;
        }

        #endregion

        #region Purchase Order Bill

        public static ResCommon InsertBill(ReqBill reqBill, String spName)
        {
            ResCommon resCommon = new ResCommon();
            List<ReqBillItem> listreqBillItem = new List<ReqBillItem>();
            DataTable dt = new DataTable();
            DataTable dtBillItem = new DataTable();
            dtBillItem.Columns.Add("BillId");
            dtBillItem.Columns.Add("BillNo");
            dtBillItem.Columns.Add("ItemId");
            dtBillItem.Columns.Add("Description");
            dtBillItem.Columns.Add("Price");
            dtBillItem.Columns.Add("Quantity");
            dtBillItem.Columns.Add("Unit");
            dtBillItem.Columns.Add("Tax");
            dtBillItem.Columns.Add("Sgst");
            dtBillItem.Columns.Add("Cgst");
            dtBillItem.Columns.Add("Igst");
            dtBillItem.Columns.Add("Utgst");
            dtBillItem.Columns.Add("Cess");
            dtBillItem.Columns.Add("PurchaseType");
            dtBillItem.Columns.Add("TaxCredit");
            DataRow row;

            for (int i = 0; i < reqBill.reqBillItemList.Count(); i++)
            {
                row = dtBillItem.NewRow();

               // ReqBillItem _reqPurchaseItem = new ReqPurchaseItem();
                row["BillId"] = reqBill.reqBillItemList[i].BillId;
                row["BillNo"] = reqBill.reqBillItemList[i].BillNo;
                row["ItemId"] = reqBill.reqBillItemList[i].ItemId;
                row["Description"] = reqBill.reqBillItemList[i].Description;
                row["Price"] = reqBill.reqBillItemList[i].Price;
                row["Quantity"] = reqBill.reqBillItemList[i].Quantity;
                row["Unit"] = reqBill.reqBillItemList[i].Unit;
                row["Tax"] = reqBill.reqBillItemList[i].Tax;
                row["Sgst"] = reqBill.reqBillItemList[i].Sgst;
                row["Cgst"] = reqBill.reqBillItemList[i].Cgst;
                row["Igst"] = reqBill.reqBillItemList[i].Igst;
                row["Utgst"] = reqBill.reqBillItemList[i].Utgst;
                row["Cess"] = reqBill.reqBillItemList[i].Cess;
                row["PurchaseType"] = reqBill.reqBillItemList[i].PurchaseType;
                row["TaxCredit"] = reqBill.reqBillItemList[i].TaxCredit;
              
                dtBillItem.Rows.Add(row);
                //  listreqPurchaseItem.Add(_reqPurchaseItem);
            }

            //reqPurchase.PurchaseItemList = listreqPurchaseItem;
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqBill.UserId));
                        cmd.Parameters.Add(new SqlParameter("@BillNo", reqBill.BillNo));
                        cmd.Parameters.Add(new SqlParameter("@BillVendorId", reqBill.BillVendorId));
                        cmd.Parameters.Add(new SqlParameter("@BillDate", reqBill.BillDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqBill.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@PaymentMethod", reqBill.PaymentMethod));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqBill.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@EndDate", reqBill.EndDate));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseTypeId", reqBill.ExpenseTypeId));
                        cmd.Parameters.Add(new SqlParameter("@RefId", reqBill.RefId));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqBill.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Notes", reqBill.Notes));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqBill.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Tds", reqBill.Tds));
                        cmd.Parameters.Add(new SqlParameter("@TdsSection", reqBill.TdsSection));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseChargeBill", reqBill.IsreverseChargeBill));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqBill.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@IsRecurring", reqBill.IsRecurring));
                        cmd.Parameters.Add(new SqlParameter("@RecurringFrequency", reqBill.RecurringFrequency));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqBill.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@Status", reqBill.Status));
                        cmd.Parameters.Add(new SqlParameter("@BillParentId", reqBill.BillParentId));
                        cmd.Parameters.Add(new SqlParameter("@State", reqBill.State));

                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqBill.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqBill.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyType", reqBill.SupplyType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillType", reqBill.ExpenseBillType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillHead", reqBill.ExpenseBillHead));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqBill.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqBill.Freight));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqBill.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqBill.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqBill.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqBill.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqBill.Prefix));
                        


                        cmd.Parameters.Add(new SqlParameter("@BillItemType", dtBillItem));

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
                    catch (Exception ex) { }
                }
            }

            return resCommon;
        }

        public static ResCommon BulkInsertBill(ReqBill_BillItem reqBill, String spName)
        {
            ResCommon resCommon = new ResCommon();
            List<ReqBillItem> listreqBillItem = new List<ReqBillItem>();
            DataTable dt = new DataTable();
          
            DataTable dtBill = new DataTable();
          
            dtBill.Columns.Add("UserId");
            dtBill.Columns.Add("BillVendorId");
            dtBill.Columns.Add("BillNo");
            dtBill.Columns.Add("EndDate");
            dtBill.Columns.Add("BillDate");
            dtBill.Columns.Add("PaymentTerm");
            dtBill.Columns.Add("PaymentMethod");
         
            dtBill.Columns.Add("DueDate");
            dtBill.Columns.Add("ExpenseTypeId");
            dtBill.Columns.Add("RefId");
            dtBill.Columns.Add("AttachmentUrl");
            dtBill.Columns.Add("Notes");
            dtBill.Columns.Add("Discount");
            dtBill.Columns.Add("Tds");
            dtBill.Columns.Add("TdsSection");
            dtBill.Columns.Add("IsReverseChargeBill");
            dtBill.Columns.Add("IsDeleted");
            dtBill.Columns.Add("IsRecurring");
            dtBill.Columns.Add("RecurringFrequency");
            dtBill.Columns.Add("TotalAmount");
            dtBill.Columns.Add("Status");
            dtBill.Columns.Add("BillParentId");
            DataRow rowBill;

            for (int i = 0; i < reqBill.reqBillList.Count(); i++)
            {
                rowBill = dtBill.NewRow();
                rowBill["UserId"] = reqBill.reqBillList[i].UserId;
                rowBill["BillNo"] = Convert.ToString(reqBill.reqBillList[i].BillNo);
                rowBill["BillVendorId"] = reqBill.reqBillList[i].BillVendorId;
                if (reqBill.reqBillList[i].BillDate != null)
                    rowBill["BillDate"] = DateTime.Now;//Convert.ToString(reqBill.reqBillList[i].BillDate);
                else rowBill["BillDate"] = null;
                rowBill["PaymentTerm"] = reqBill.reqBillList[i].PaymentTerm;
                rowBill["PaymentMethod"] = reqBill.reqBillList[i].PaymentMethod;
                if (reqBill.reqBillList[i].EndDate != null)
                    rowBill["EndDate"] = DateTime.Now;//Convert.ToString(reqBill.reqBillList[i].EndDate);
                else rowBill["EndDate"] = null;
                if (reqBill.reqBillList[i].DueDate != null)
                    rowBill["DueDate"] = DateTime.Now;//Convert.ToString(reqBill.reqBillList[i].DueDate);
                else rowBill["DueDate"] = null;
                rowBill["ExpenseTypeId"] = reqBill.reqBillList[i].ExpenseTypeId;
                rowBill["RefId"] = reqBill.reqBillList[i].RefId;
                rowBill["AttachmentUrl"] = reqBill.reqBillList[i].AttachmentUrl;
                rowBill["Notes"] = reqBill.reqBillList[i].Notes;
                rowBill["Discount"] = reqBill.reqBillList[i].Discount;
                rowBill["Tds"] = reqBill.reqBillList[i].Tds;
                rowBill["TdsSection"] = reqBill.reqBillList[i].TdsSection;
                rowBill["IsreverseChargeBill"] = reqBill.reqBillList[i].IsreverseChargeBill;
                rowBill["IsDeleted"] = Convert.ToBoolean(reqBill.reqBillList[i].IsDeleted);
                rowBill["IsRecurring"] = reqBill.reqBillList[i].IsRecurring;
                rowBill["RecurringFrequency"] = reqBill.reqBillList[i].RecurringFrequency;
                rowBill["TotalAmount"] = reqBill.reqBillList[i].TotalAmount;
                rowBill["Status"] = reqBill.reqBillList[i].Status;
                if (reqBill.reqBillList[i].BillParentId != null)
                    rowBill["BillParentId"] = reqBill.reqBillList[i].BillParentId;
                else rowBill["BillParentId"] = 0;
                dtBill.Rows.Add(rowBill);
                //  listreqPurchaseItem.Add(_reqPurchaseItem);
            }

            DataTable dtBillItem = new DataTable();
            dtBillItem.Columns.Add("BillId");
            dtBillItem.Columns.Add("BillNo");
            dtBillItem.Columns.Add("Description");
            dtBillItem.Columns.Add("ItemId");
            dtBillItem.Columns.Add("Price");
            dtBillItem.Columns.Add("Quantity");
            dtBillItem.Columns.Add("Tax");
            dtBillItem.Columns.Add("Sgst");
            dtBillItem.Columns.Add("Cgst");
            dtBillItem.Columns.Add("Igst");
            dtBillItem.Columns.Add("Utgst");
            dtBillItem.Columns.Add("Cess");
            dtBillItem.Columns.Add("Unit");
            dtBillItem.Columns.Add("PurchaseType");
            dtBillItem.Columns.Add("TaxCredit");
            DataRow row;

            for (int i = 0; i < reqBill.reqBillItemList.Count(); i++)
            {
                row = dtBillItem.NewRow();

                row["BillId"] = reqBill.reqBillItemList[i].BillId;
                row["BillNo"] = reqBill.reqBillItemList[i].BillNo;
                row["ItemId"] = reqBill.reqBillItemList[i].ItemId;
                row["Description"] = reqBill.reqBillItemList[i].Description;
                row["Price"] = reqBill.reqBillItemList[i].Price;
                row["Quantity"] = reqBill.reqBillItemList[i].Quantity;
                row["Unit"] = reqBill.reqBillItemList[i].Unit;
                row["Tax"] = reqBill.reqBillItemList[i].Tax;
                row["Sgst"] = reqBill.reqBillItemList[i].Sgst;
                row["Cgst"] = reqBill.reqBillItemList[i].Cgst;
                row["Igst"] = reqBill.reqBillItemList[i].Igst;
                row["Utgst"] = reqBill.reqBillItemList[i].Utgst;
                row["Cess"] = reqBill.reqBillItemList[i].Cess;
                row["PurchaseType"] = reqBill.reqBillItemList[i].PurchaseType;
                row["TaxCredit"] = reqBill.reqBillItemList[i].TaxCredit;
                dtBillItem.Rows.Add(row);
                //  listreqPurchaseItem.Add(_reqPurchaseItem);
            }

            //reqPurchase.PurchaseItemList = listreqPurchaseItem;
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                       
                        cmd.Parameters.Add(new SqlParameter("@BillType", dtBill));
                        cmd.Parameters.Add(new SqlParameter("@BillItemType", dtBillItem));

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
                    catch (Exception ex) { }
                }
            }

            return resCommon;
        }

        public static ResBillPaymentList GetBillPaymentList(ReqId reqId,string spName)
        {
            ResBillPaymentList resBillPaymentList = new ResBillPaymentList();

            List<ResBillPayment> resListBillPayment = new List<ResBillPayment>();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@BillId", reqId.Id));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResBillPayment resBillPayment = new ResBillPayment();
                        resBillPayment.BillId = Convert.ToInt32(dt.Rows[i]["BillId"]);
                        resBillPayment.PaymentDate = Convert.ToString(dt.Rows[i]["PaymentDate"]);
                        resBillPayment.PaymentMode = Convert.ToString(dt.Rows[i]["PaymentMode"]);
                        resBillPayment.Amount = Convert.ToString(dt.Rows[i]["Amount"]);
                        resBillPayment.Memo = Convert.ToString(dt.Rows[i]["Memo"]);
                        resListBillPayment.Add(resBillPayment);
                    }
                    resBillPaymentList.ResponseCode = 0;
                    resBillPaymentList.ResponseMessage = "Fetched detail successfully";
                    resBillPaymentList.resBillPaymentList = resListBillPayment;
                }
                else {
                    resBillPaymentList.ResponseCode = 0;
                    resBillPaymentList.ResponseMessage = "No Records Found";
                }

            }
            catch (Exception ex) { }
            return resBillPaymentList;
        }

        public static ResBillList GetUserBillList(ReqUserId reqUserId, String spName)
        {
            DataTable dt = new DataTable();
            ResBillList resBillList = new ResBillList();
            List<ReqBill> _reqBill = new List<ReqBill>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            da.Fill(dt);
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ReqBill reqBill = new ReqBill();
                       
                        reqBill.BillId = Convert.ToInt16(dt.Rows[i]["BillId"]);
                        reqBill.VendorName = Convert.ToString(dt.Rows[i]["VendorName"]);
                       
                            reqBill.BillDate = Convert.ToString(dt.Rows[i]["BillDate"]);
                        reqBill.PaymentTerm = Convert.ToString(dt.Rows[i]["PaymentTerm"]);
                        reqBill.PaymentMethod = Convert.ToString(dt.Rows[i]["PaymentMethod"]);
                        reqBill.DueDate = Convert.ToString(dt.Rows[i]["DueDate"]);
                        // reqBill.EndDate = Convert.ToString(dt.Rows[i]["EndDate"]);
                        if (!(dt.Rows[i]["Status"] is DBNull))
                            reqBill.Status = Convert.ToString(dt.Rows[i]["Status"]);
                        if (!(dt.Rows[i]["ExpenseTypeId"] is DBNull))
                            reqBill.ExpenseTypeId = Convert.ToInt16(dt.Rows[i]["ExpenseTypeId"]);
                        reqBill.ExpenseType = Convert.ToString(dt.Rows[i]["ExpenseType"]);
                        reqBill.RefId = Convert.ToString(dt.Rows[i]["RefId"]);
                        reqBill.AttachmentUrl = Convert.ToString(dt.Rows[i]["AttachmentUrl"]);
                        reqBill.Notes = Convert.ToString(dt.Rows[i]["Notes"]);
                        reqBill.TotalAmount = Convert.ToString(dt.Rows[i]["TotalAmount"]);
                        if (!(dt.Rows[i]["BillParentId"] is DBNull))
                            reqBill.BillParentId = Convert.ToInt32(dt.Rows[i]["BillParentId"]);

                        _reqBill.Add(reqBill);
                    }
                    resBillList.reqBillList = _reqBill;
                    resBillList.ResponseCode = 0;
                    resBillList.ResponseMessage = "Fetched detail successfully";
                }
                else {
                    resBillList.ResponseCode = 0;
                    resBillList.ResponseMessage = "No Records Found";
                }

            }
            catch (Exception ex) { }

            return resBillList;

        }

        public static ResBillList GetUserOverDueList(ReqUserId reqUserId, String spName)
        {
            DataTable dt = new DataTable();
            ResBillList resBillList = new ResBillList();
            List<ReqBill> _reqBill = new List<ReqBill>();
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
                    }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ReqBill reqBill = new ReqBill();

                        reqBill.BillId = Convert.ToInt16(dt.Rows[i]["BillId"]);
                        reqBill.VendorName = Convert.ToString(dt.Rows[i]["VendorName"]);

                        reqBill.BillDate = Convert.ToString(dt.Rows[i]["BillDate"]);
                        reqBill.PaymentTerm = Convert.ToString(dt.Rows[i]["PaymentTerm"]);
                        reqBill.PaymentTerm = Convert.ToString(dt.Rows[i]["Term"]);
                        reqBill.EndDate = Convert.ToString(dt.Rows[i]["EndDate"]);
                        reqBill.DueDate = Convert.ToString(dt.Rows[i]["DueDate"]);
                        if (!(dt.Rows[i]["ExpenseType"] is DBNull))
                            reqBill.ExpenseTypeId = Convert.ToInt16(dt.Rows[i]["ExpenseTypeId"]);
                        reqBill.ExpenseType = Convert.ToString(dt.Rows[i]["ExpenseType"]);
                        reqBill.RefId = Convert.ToString(dt.Rows[i]["RefId"]);
                        reqBill.AttachmentUrl = Convert.ToString(dt.Rows[i]["AttachmentUrl"]);
                        reqBill.Notes = Convert.ToString(dt.Rows[i]["Notes"]);
                        reqBill.TotalAmount = Convert.ToString(dt.Rows[i]["TotalAmount"]);


                        _reqBill.Add(reqBill);
                    }
                    resBillList.reqBillList = _reqBill;
                    resBillList.ResponseCode = 0;
                    resBillList.ResponseMessage = "Fetched detail successfully";
                }
                else {
                    resBillList.ResponseCode = 0;
                    resBillList.ResponseMessage = "No Records Found";
                }

            }
            catch (Exception ex) { }

            return resBillList;

        }

        public static ResCommon UpdateBill(ReqBill reqBill, String spName)
        {
            ResCommon resCommon = new ResCommon();
            List<ReqBillItem> listreqBillItem = new List<ReqBillItem>();
            DataTable dt = new DataTable();
            DataTable dtBillItem = new DataTable();
            dtBillItem.Columns.Add("BillId");
            dtBillItem.Columns.Add("BillNo");
            dtBillItem.Columns.Add("ItemId");
            dtBillItem.Columns.Add("Description");
            dtBillItem.Columns.Add("Price");
            dtBillItem.Columns.Add("Quantity");
            dtBillItem.Columns.Add("Unit");
            dtBillItem.Columns.Add("Tax");
            dtBillItem.Columns.Add("Sgst");
            dtBillItem.Columns.Add("Cgst");
            dtBillItem.Columns.Add("Igst");
            dtBillItem.Columns.Add("Utgst");
            dtBillItem.Columns.Add("Cess");
            dtBillItem.Columns.Add("PurchaseType");
            dtBillItem.Columns.Add("TaxCredit");
            DataRow row;

            for (int i = 0; i < reqBill.reqBillItemList.Count(); i++)
            {
                row = dtBillItem.NewRow();

                // ReqBillItem _reqPurchaseItem = new ReqPurchaseItem();
                row["BillId"] = reqBill.reqBillItemList[i].BillId;
                row["BillNo"] = reqBill.reqBillItemList[i].BillNo;
                row["ItemId"] = reqBill.reqBillItemList[i].ItemId;
                row["Description"] = reqBill.reqBillItemList[i].Description;
                row["Price"] = reqBill.reqBillItemList[i].Price;
                row["Quantity"] = reqBill.reqBillItemList[i].Quantity;
                row["Unit"] = reqBill.reqBillItemList[i].Unit;
                row["Tax"] = reqBill.reqBillItemList[i].Tax;
                row["Sgst"] = reqBill.reqBillItemList[i].Sgst;
                row["Cgst"] = reqBill.reqBillItemList[i].Cgst;
                row["Igst"] = reqBill.reqBillItemList[i].Igst;
                row["Utgst"] = reqBill.reqBillItemList[i].Utgst;
                row["Cess"] = reqBill.reqBillItemList[i].Cess;
                row["PurchaseType"] = reqBill.reqBillItemList[i].PurchaseType;
                row["TaxCredit"] = reqBill.reqBillItemList[i].TaxCredit;
                dtBillItem.Rows.Add(row);
                //  listreqPurchaseItem.Add(_reqPurchaseItem);
            }

            //reqPurchase.PurchaseItemList = listreqPurchaseItem;
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqBill.UserId));
                        cmd.Parameters.Add(new SqlParameter("@BillId", reqBill.BillId));
                        cmd.Parameters.Add(new SqlParameter("@BillNo", reqBill.BillNo));
                        cmd.Parameters.Add(new SqlParameter("@BillVendorId", reqBill.BillVendorId));
                        cmd.Parameters.Add(new SqlParameter("@BillDate", reqBill.BillDate));
                        cmd.Parameters.Add(new SqlParameter("@PaymentTerm", reqBill.PaymentTerm));
                        cmd.Parameters.Add(new SqlParameter("@PaymentMethod", reqBill.PaymentMethod));
                        cmd.Parameters.Add(new SqlParameter("@EndDate", reqBill.EndDate));
                        cmd.Parameters.Add(new SqlParameter("@DueDate", reqBill.DueDate));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseTypeId", reqBill.ExpenseTypeId));
                        cmd.Parameters.Add(new SqlParameter("@RefId", reqBill.RefId));
                        cmd.Parameters.Add(new SqlParameter("@AttachmentUrl", reqBill.AttachmentUrl));
                        cmd.Parameters.Add(new SqlParameter("@Notes", reqBill.Notes));
                        cmd.Parameters.Add(new SqlParameter("@Discount", reqBill.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Tds", reqBill.Tds));
                        cmd.Parameters.Add(new SqlParameter("@TdsSection", reqBill.TdsSection));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseChargeBill", reqBill.IsreverseChargeBill));
                        cmd.Parameters.Add(new SqlParameter("@IsDeleted", reqBill.IsDeleted));
                        cmd.Parameters.Add(new SqlParameter("@IsRecurring", reqBill.IsRecurring));
                        cmd.Parameters.Add(new SqlParameter("@RecurringFrequency", reqBill.RecurringFrequency));
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", reqBill.TotalAmount));
                        cmd.Parameters.Add(new SqlParameter("@State", reqBill.State));
                        cmd.Parameters.Add(new SqlParameter("@Status", reqBill.Status));

                        cmd.Parameters.Add(new SqlParameter("@PlaceOfSupply", reqBill.PlaceOfSupply));
                        cmd.Parameters.Add(new SqlParameter("@PortCode", reqBill.PortCode));
                        cmd.Parameters.Add(new SqlParameter("@SupplyType", reqBill.SupplyType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillType", reqBill.ExpenseBillType));
                        cmd.Parameters.Add(new SqlParameter("@ExpenseBillHead", reqBill.ExpenseBillHead));
                        cmd.Parameters.Add(new SqlParameter("@IsReverseCharge", reqBill.IsReverseCharge));
                        cmd.Parameters.Add(new SqlParameter("@Frieght", reqBill.Freight));
                        cmd.Parameters.Add(new SqlParameter("@LabourCharge", reqBill.LabourCharge));
                        cmd.Parameters.Add(new SqlParameter("@InsuranceAmount", reqBill.InsuranceAmount));
                        cmd.Parameters.Add(new SqlParameter("@OtherCharge", reqBill.OtherCharge));
                        cmd.Parameters.Add(new SqlParameter("@Cess", reqBill.Cess));
                        cmd.Parameters.Add(new SqlParameter("@Prefix", reqBill.Prefix));
                        cmd.Parameters.Add(new SqlParameter("@BillItemType", dtBillItem));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                resCommon.ResponseCode = Convert.ToInt16(dt.Rows[0][0]);
                                resCommon.ResponseMessage = Convert.ToString(dt.Rows[0][1]);
                            }
                            else {
                                resCommon.ResponseCode = 0;
                                resCommon.ResponseMessage = "Unable to Update";
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }

            return resCommon;
        }

        public static ReqBill GetBillDetail(ReqId reqId, String spName)
        {
            DataSet ds = new DataSet();
            ReqBill reqBill = new ReqBill();

            List<ReqBillItem> _resBillItem = new List<ReqBillItem>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@BillId", reqId.Id));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            da.Fill(ds);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            try
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                DataTable dtBillItem = new DataTable();
                dtBillItem = ds.Tables[1];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!(dt.Rows[0]["BillId"] is DBNull))
                        reqBill.BillNo = Convert.ToInt16(dt.Rows[0]["BillId"]);
                    if (!(dt.Rows[0]["UserId"] is DBNull))
                        reqBill.BillNo = Convert.ToInt16(dt.Rows[0]["UserId"]);
                    if (!(dt.Rows[0]["BillVendorId"] is DBNull))
                        reqBill.BillVendorId = Convert.ToInt16(dt.Rows[0]["BillVendorId"]);
                    reqBill.VendorName = Convert.ToString(dt.Rows[0]["VendorName"]);
                    if (!(dt.Rows[0]["BillNo"] is DBNull))
                        reqBill.BillNo = Convert.ToInt16(dt.Rows[0]["BillNo"]);
                    reqBill.Discount = Convert.ToString(dt.Rows[0]["Discount"]);
                    reqBill.BillDate = Convert.ToString(dt.Rows[0]["BillDate"]);
                    reqBill.PaymentTerm = Convert.ToString(dt.Rows[0]["PaymentTerm"]);
                   // reqBill.Term = Convert.ToString(dt.Rows[0]["Term"]);
                    //reqBill.Term = Convert.ToString(dt.Rows[0]["Term"]);
                    reqBill.PaymentMethod = Convert.ToString(dt.Rows[0]["PaymentMethod"]);
                    reqBill.EndDate = Convert.ToString(dt.Rows[0]["EndDate"]);
                    reqBill.DueDate = Convert.ToString(dt.Rows[0]["DueDate"]);
                    if (!(dt.Rows[0]["ExpenseTypeId"] is DBNull))
                        reqBill.ExpenseTypeId = Convert.ToInt16(dt.Rows[0]["ExpenseTypeId"]);
                    reqBill.ExpenseType = Convert.ToString(dt.Rows[0]["ExpenseType"]);
                    reqBill.RefId = Convert.ToString(dt.Rows[0]["RefId"]);
                    reqBill.AttachmentUrl = Convert.ToString(dt.Rows[0]["AttachmentUrl"]);
                    reqBill.Notes = Convert.ToString(dt.Rows[0]["Notes"]);
                    reqBill.TotalAmount = Convert.ToString(dt.Rows[0]["TotalAmount"]);
                    reqBill.Tds = Convert.ToString(dt.Rows[0]["Tds"]);
                    reqBill.TdsSection = Convert.ToString(dt.Rows[0]["TdsSection"]);
                    reqBill.IsreverseChargeBill = Convert.ToBoolean(dt.Rows[0]["IsreverseChargeBill"]);
                    reqBill.IsRecurring = Convert.ToBoolean(dt.Rows[0]["IsRecurring"]);
                    reqBill.IsDeleted = Convert.ToBoolean(dt.Rows[0]["IsDeleted"]);
                    reqBill.RecurringFrequency = Convert.ToString(dt.Rows[0]["RecurringFrequency"]);
                    reqBill.Status = Convert.ToString(dt.Rows[0]["Status"]);
                    reqBill.State = Convert.ToString(dt.Rows[0]["State"]);

                    reqBill.PlaceOfSupply = Convert.ToString(dt.Rows[0]["PlaceOfSupply"]);
                    reqBill.PortCode = Convert.ToString(dt.Rows[0]["PortCode"]);
                    reqBill.SupplyType = Convert.ToString(dt.Rows[0]["SupplyType"]);
                    reqBill.ExpenseBillType = Convert.ToString(dt.Rows[0]["ExpenseBillType"]);
                    reqBill.ExpenseBillHead = Convert.ToString(dt.Rows[0]["ExpenseBillHead"]);
                    reqBill.IsReverseCharge = Convert.ToString(dt.Rows[0]["IsReverseCharge"]);
                    reqBill.Freight = Convert.ToString(dt.Rows[0]["Freight"]);
                    reqBill.LabourCharge = Convert.ToString(dt.Rows[0]["LabourCharge"]);
                    reqBill.InsuranceAmount = Convert.ToString(dt.Rows[0]["InsuranceAmount"]);
                    reqBill.OtherCharge = Convert.ToString(dt.Rows[0]["OtherCharge"]);
                    reqBill.Cess = Convert.ToString(dt.Rows[0]["Cess"]);
                    reqBill.Prefix = Convert.ToString(dt.Rows[0]["Prefix"]);

                    for (int i = 0; i < dtBillItem.Rows.Count; i++)
                    {
                        ReqBillItem _reqBillItem = new ReqBillItem();
                        if (!(dt.Rows[0]["BillNo"] is DBNull))
                            _reqBillItem.BillNo = Convert.ToInt16(dtBillItem.Rows[i]["BillNo"]);
                        _reqBillItem.BillId = Convert.ToInt16(dtBillItem.Rows[i]["BillId"]);
                        _reqBillItem.Description = Convert.ToString(dtBillItem.Rows[i]["Description"]);
                        if (!(dtBillItem.Rows[i]["ItemId"] is DBNull))
                            _reqBillItem.ItemId = Convert.ToInt16(dtBillItem.Rows[i]["ItemId"]);
                        _reqBillItem.ItemName = Convert.ToString(dtBillItem.Rows[i]["ItemName"]);
                        _reqBillItem.Price = Convert.ToString(dtBillItem.Rows[i]["Price"]);
                        _reqBillItem.Quantity = Convert.ToString(dtBillItem.Rows[i]["Quantity"]);
                        _reqBillItem.PurchaseType = Convert.ToString(dtBillItem.Rows[i]["PurchaseType"]);
                        _reqBillItem.Tax = Convert.ToString(dtBillItem.Rows[i]["Tax"]);
                        _reqBillItem.Cgst = Convert.ToString(dtBillItem.Rows[i]["Cgst"]);
                        _reqBillItem.Sgst = Convert.ToString(dtBillItem.Rows[i]["Sgst"]);
                        _reqBillItem.Igst = Convert.ToString(dtBillItem.Rows[i]["Igst"]);
                        _reqBillItem.TaxCredit = Convert.ToString(dtBillItem.Rows[i]["TaxCredit"]);
                        _reqBillItem.Unit = Convert.ToString(dtBillItem.Rows[i]["Unit"]);

                        _resBillItem.Add(_reqBillItem);


                    }
                    reqBill.reqBillItemList = _resBillItem;
                    reqBill.ResponseCode = 0;
                    reqBill.ResponseMessage = "Fetched detail successfully";
                }

            }
            catch (Exception ex) { }

            return reqBill;

        }

        public static ResCommon BulkInsertRecurringBill(ReqBill_BillItem reqBill, String spName)
        {
            ResCommon resCommon = new ResCommon();
            List<ReqBillItem> listreqBillItem = new List<ReqBillItem>();
            DataTable dt = new DataTable();

            DataTable dtBill = new DataTable();
            dtBill.Columns.Add("UserId");
            dtBill.Columns.Add("BillVendorId");
            dtBill.Columns.Add("BillNo");
            dtBill.Columns.Add("EndDate");
            dtBill.Columns.Add("BillDate");
            dtBill.Columns.Add("PaymentTerm");
            dtBill.Columns.Add("PaymentMethod");

            dtBill.Columns.Add("DueDate");
            dtBill.Columns.Add("ExpenseTypeId");
            dtBill.Columns.Add("RefId");
            dtBill.Columns.Add("AttachmentUrl");
            dtBill.Columns.Add("Notes");
            dtBill.Columns.Add("Discount");
            dtBill.Columns.Add("Tds");
            dtBill.Columns.Add("TdsSection");
            dtBill.Columns.Add("IsReverseChargeBill");
            dtBill.Columns.Add("IsDeleted");
            dtBill.Columns.Add("IsRecurring");
            dtBill.Columns.Add("RecurringFrequency");
            dtBill.Columns.Add("TotalAmount");
            dtBill.Columns.Add("Status");
            dtBill.Columns.Add("BillParentId");
            DataRow rowBill;
            int count = 0;
            /*Logic for series Start
            1. Days between  Start and End Date
                
             End*/
            int _term = 0;
            int noOfslab = 0;
            if (String.IsNullOrEmpty(reqBill.reqBillList[0].RecurringFrequency)) reqBill.reqBillList[0].RecurringFrequency = "Monthly";
            switch (reqBill.reqBillList[0].RecurringFrequency)
            {
                case "Daily":
                    _term = 1;
                    break;
                case "Weekly":
                    _term = 7;
                    break;
                case "Monthly":
                    _term = 30;
                    break;
                case "Quaterly":
                    _term = 90;
                    break;
                case "Bi-Anually":
                    _term = 180;
                    break;
                case "Anually":
                    _term = 365;
                    break;
                default:
                    _term =  30;
                    break;
            }
            int days = Convert.ToInt32((Convert.ToDateTime(reqBill.reqBillList[0].EndDate).Subtract(Convert.ToDateTime(reqBill.reqBillList[0].BillDate))).TotalDays);
            if (days >= _term)
            {
                noOfslab = days / (_term);
            }


            DataTable dtBillItem = new DataTable();
            dtBillItem.Columns.Add("BillId");
            dtBillItem.Columns.Add("BillNo");
            dtBillItem.Columns.Add("Description");
            dtBillItem.Columns.Add("ItemId");
            dtBillItem.Columns.Add("Price");
            dtBillItem.Columns.Add("Quantity");
            dtBillItem.Columns.Add("Tax");
            dtBillItem.Columns.Add("Cgst");
            dtBillItem.Columns.Add("Sgst");
            dtBillItem.Columns.Add("Igst");
            dtBillItem.Columns.Add("Unit");
            dtBillItem.Columns.Add("PurchaseType");
            dtBillItem.Columns.Add("TaxCredit");
            DataRow row;

            for (int i = 0; i < noOfslab; i++)
            {
                i = 0;
                rowBill = dtBill.NewRow();
                rowBill["UserId"] = reqBill.reqBillList[i].UserId;
                if(reqBill.reqBillList[i].BillId != null)
                    rowBill["BillId"] = reqBill.reqBillList[i].BillId;
                rowBill["BillNo"] = reqBill.reqBillList[i].BillNo;
                rowBill["BillVendorId"] = reqBill.reqBillList[i].BillVendorId;
                rowBill["BillDate"] = Convert.ToDateTime(reqBill.reqBillList[i].BillDate).AddDays(_term);
                rowBill["PaymentTerm"] = reqBill.reqBillList[i].PaymentTerm;
                rowBill["EndDate"] = reqBill.reqBillList[i].EndDate;
                rowBill["DueDate"] = Convert.ToDateTime(reqBill.reqBillList[i].DueDate).AddDays(_term);
                rowBill["ExpenseTypeId"] = reqBill.reqBillList[i].ExpenseTypeId;
                rowBill["RefId"] = reqBill.reqBillList[i].RefId;
                rowBill["AttachmentUrl"] = reqBill.reqBillList[i].AttachmentUrl;
                rowBill["Notes"] = reqBill.reqBillList[i].Notes;
                rowBill["Discount"] = reqBill.reqBillList[i].Discount;
                rowBill["Tds"] = reqBill.reqBillList[i].Tds;
                rowBill["TdsSection"] = reqBill.reqBillList[i].TdsSection;
                rowBill["IsreverseChargeBill"] = reqBill.reqBillList[i].IsreverseChargeBill;
                rowBill["IsDeleted"] = Convert.ToBoolean(reqBill.reqBillList[i].IsDeleted);
                rowBill["IsRecurring"] = Convert.ToBoolean(reqBill.reqBillList[i].IsRecurring);
                rowBill["RecurringFrequency"] = reqBill.reqBillList[i].RecurringFrequency;
                rowBill["TotalAmount"] = reqBill.reqBillList[i].TotalAmount;
                rowBill["Status"] = reqBill.reqBillList[i].Status;
                if (reqBill.reqBillList[i].BillId != null)
                    rowBill["BillParentId"] = reqBill.reqBillList[i].BillId;
                dtBill.Rows.Add(rowBill);


                for (int j = 0; j < reqBill.reqBillItemList.Count(); j++)
                {
                    row = dtBillItem.NewRow();

                    // ReqBillItem _reqPurchaseItem = new ReqPurchaseItem();
                    row["BillId"] = reqBill.reqBillItemList[j].BillId;
                    row["BillNo"] = reqBill.reqBillItemList[j].BillNo;
                    row["Description"] = reqBill.reqBillItemList[j].Description;
                    row["ItemId"] = reqBill.reqBillItemList[j].ItemId;
                    row["Price"] = reqBill.reqBillItemList[j].Price;
                    row["Quantity"] = reqBill.reqBillItemList[j].Quantity;
                    row["Tax"] = reqBill.reqBillItemList[j].Tax;
                    row["Cgst"] = reqBill.reqBillItemList[j].Cgst;
                    row["Sgst"] = reqBill.reqBillItemList[j].Sgst;
                    row["Igst"] = reqBill.reqBillItemList[j].Igst;
                    row["Unit"] = reqBill.reqBillItemList[j].Unit;
                    row["TaxCredit"] = reqBill.reqBillItemList[j].TaxCredit;
                    row["PurchaseType"] = reqBill.reqBillItemList[j].PurchaseType;
                    dtBillItem.Rows.Add(row);
                    //  listreqPurchaseItem.Add(_reqPurchaseItem);
                }
                //  listreqPurchaseItem.Add(_reqPurchaseItem);
            }



           

            

            //reqPurchase.PurchaseItemList = listreqPurchaseItem;
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@BillType", dtBill));
                        cmd.Parameters.Add(new SqlParameter("@BillItemType", dtBillItem));

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
                    catch (Exception ex) { }
                }
            }

            return resCommon;
        }

        #endregion

        public static ResTdsList GetTdsList(ReqUserId reqUserId, String spName)
        {
            ResTdsList _resTdsList = new ResTdsList();

            List<ResTds> resListTds = new List<ResTds>();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResTds resTds = new ResTds();
                        resTds.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                        //if (!(dt.Rows[0]["TdsDescription"] is DBNull))
                        //    resTds.TdsDescription = Convert.ToString(dt.Rows[i]["TdsDescription"]);
                        resTds.TdsSection = Convert.ToString(dt.Rows[i]["TdsSection"]);
                        resTds.TdsRate = Convert.ToString(dt.Rows[i]["TdsRate"]);
                        resListTds.Add(resTds);
                    }
                    _resTdsList.ResponseCode = 0;
                    _resTdsList.ResponseMessage = "Fetched Tds detail successfully";
                    _resTdsList.resTdsList = resListTds;
                }
                else {
                    _resTdsList.ResponseCode = 0;
                    _resTdsList.ResponseMessage = "No Tds records found";
                }

            }
            catch (Exception ex) { }
            return _resTdsList;
        }

        public static ResAllUserList GetAllUser(string spName)
        {
            DataTable dt = new DataTable();
            ResAllUserList resAllUserList = new ResAllUserList();
            List<ResAllUser> _resAllUserList = new List<ResAllUser>();
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(dt);
                    }
                }
            }
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResAllUser _resAllUser = new ResAllUser();
                    _resAllUser.UserId = Convert.ToString(dt.Rows[i]["UserId"]);
                    _resAllUser.UserType = Convert.ToString(dt.Rows[i]["UserType"]);
                    _resAllUser.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    _resAllUser.EmailId = Convert.ToString(dt.Rows[i]["EmailId"]);
                    _resAllUser.Password = Convert.ToString(dt.Rows[i]["Password"]);


                    _resAllUserList.Add(_resAllUser);
                }
                resAllUserList.resAllUserList = _resAllUserList;
                

            }
            catch (Exception ex) { }

            return resAllUserList;
        }

        public static ResCommon BulkInsertVendor(ReqVendorList reqVendorList, String spName)
        {
            ResCommon resCommon = new ResCommon();
            DataTable dt = new DataTable();
            try
            {
                string json = JsonConvert.SerializeObject(reqVendorList);
                JObject jObject = JObject.Parse(json);
                var jarray = Convert.ToString(jObject["reqVendor"]);
                DataTable dtVendorList = (DataTable)JsonConvert.DeserializeObject(jarray, (typeof(DataTable)));
            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                  
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@VendorType", dtVendorList));
                     
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

        public static ResGetPaymentTermList GetPaymentTermList(ReqUserId reqUserId, String spName)
        {
            ResGetPaymentTermList resGetPaymentTermList = new ResGetPaymentTermList();

            List<ResGetPaymentTerm> resListPaymentTerm = new List<ResGetPaymentTerm>();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResGetPaymentTerm resGetPaymentTerm = new ResGetPaymentTerm();
                        resGetPaymentTerm.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                        resGetPaymentTerm.Term = Convert.ToString(dt.Rows[i]["Term"]);
                        resListPaymentTerm.Add(resGetPaymentTerm);
                    }
                    resGetPaymentTermList.ResponseCode = 0;
                    resGetPaymentTermList.ResponseMessage = "Fetched Payment Term Successfully";
                    resGetPaymentTermList.resGetPaymentTermList = resListPaymentTerm;
                }
                else {
                    resGetPaymentTermList.ResponseCode = 0;
                    resGetPaymentTermList.ResponseMessage = "No records found";
                }
            }
            catch (Exception ex) { }
            return resGetPaymentTermList;
        }


        public static CResponse.ResDashBoard GetDashBoardContentInvoice(ReqDashBoardContentTax reqDashBoardContentTax, String spName)
        {
            CResponse.ResDashBoard resDashBoard = new CResponse.ResDashBoard();
            List<InvoiceStatus> _invoicestatusList = new List<InvoiceStatus>();
            Invoicetax _invoicetax = new Invoicetax();
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        try
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            con.Open();
                            cmd.Parameters.Add(new SqlParameter("@UserId", reqDashBoardContentTax.UserId));
                            cmd.Parameters.Add(new SqlParameter("@Month", reqDashBoardContentTax.Month));
                            cmd.Parameters.Add(new SqlParameter("@Type", reqDashBoardContentTax.Type));
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(ds);
                            }
                        }
                        catch (Exception ex) { }
                    }
                }


                DataTable dtInvoiceStatus = ds.Tables[0];

                DataTable dtInvoiceTax = ds.Tables[1];
                if (dtInvoiceStatus.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInvoiceStatus.Rows.Count; i++)
                    {
                        InvoiceStatus invoiceStatus = new InvoiceStatus();
                        invoiceStatus.StatusCount = Convert.ToInt16(dtInvoiceStatus.Rows[i]["StatusCount"]);
                        invoiceStatus.Status = Convert.ToString(dtInvoiceStatus.Rows[i]["Status"]);
                        _invoicestatusList.Add(invoiceStatus);
                    }
                }

                if (dtInvoiceTax.Rows.Count > 0 && dtInvoiceTax.Rows != null)
                {
                    resDashBoard.invoiceTotalTax = Convert.ToString(dtInvoiceTax.Rows[0]["TotalTax"]);
                    resDashBoard.invoiceIgst = Convert.ToString(dtInvoiceTax.Rows[0]["Igst"]);
                    resDashBoard.invoiceCgst = Convert.ToString(dtInvoiceTax.Rows[0]["Cgst"]);
                    resDashBoard.invoiceSgst = Convert.ToString(dtInvoiceTax.Rows[0]["Sgst"]);
                    resDashBoard.invoiceUtgst = Convert.ToString(dtInvoiceTax.Rows[0]["Utgst"]);
                }
                resDashBoard.statusInvoiceList = _invoicestatusList;

            }
            catch (Exception ex)
            {
            }
            return resDashBoard;
        }

        public static CResponse.ResDashBoard GetDashBoardContentExpense(ReqDashBoardContentTax reqDashBoardContentTax, String spName)
        {
            ResDashBoard resDashBoard = new ResDashBoard();
            List<CResponse.ExpenseStatus> _expensestatusList = new List<CResponse.ExpenseStatus>();
            CResponse.BillTds _billTds = new CResponse.BillTds();

            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        try
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            con.Open();
                            cmd.Parameters.Add(new SqlParameter("@UserId", reqDashBoardContentTax.UserId));
                            cmd.Parameters.Add(new SqlParameter("@Month", reqDashBoardContentTax.Month));
                            cmd.Parameters.Add(new SqlParameter("@Type", reqDashBoardContentTax.Type));
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(ds);
                            }
                        }
                        catch (Exception ex) { }
                    }
                }

                DataTable dtExpenseStatus = ds.Tables[0];

                DataTable dtBillTds = ds.Tables[1];

                if (dtExpenseStatus.Rows.Count > 0)
                {
                    for (int i = 0; i < dtExpenseStatus.Rows.Count; i++)
                    {
                        ExpenseStatus expenseStatus = new ExpenseStatus();
                        expenseStatus.StatusCount = Convert.ToInt16(dtExpenseStatus.Rows[i]["StatusCount"]);
                        expenseStatus.Status = Convert.ToString(dtExpenseStatus.Rows[i]["Status"]);
                        _expensestatusList.Add(expenseStatus);
                    }
                }

                if (dtBillTds.Rows.Count > 0)
                {
                    resDashBoard.billTotalTax = Convert.ToString(dtBillTds.Rows[0]["TotalTax"]);
                    resDashBoard.billIgst = Convert.ToString(dtBillTds.Rows[0]["Igst"]);
                    resDashBoard.billCgst = Convert.ToString(dtBillTds.Rows[0]["Cgst"]);
                    resDashBoard.billSgst = Convert.ToString(dtBillTds.Rows[0]["Sgst"]);
                    resDashBoard.billUtgst = Convert.ToString(dtBillTds.Rows[0]["Utgst"]);
                }
                resDashBoard.statusExpenseList = _expensestatusList;

            }
            catch (Exception ex)
            {
            }
            return resDashBoard;
        }

        public static ResrefIdList GetInvoiceRef(ReqUserId reqUserId, String spName)
        {
            ResrefIdList resrefIdList = new ResrefIdList();

            List<ResrefId> _resrefIdList = new List<ResrefId>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResrefId resrefId = new ResrefId();
                        resrefId.RefId = Convert.ToInt32(dt.Rows[i]["InvoiceId"]);
                        resrefId.RefNo = Convert.ToInt32(dt.Rows[i]["InvoiceNo"]);
                        _resrefIdList.Add(resrefId);
                    }
                    resrefIdList.resrefIdList = _resrefIdList;
                    resrefIdList.ResponseMessage = "Invoice ref Fetched successfully";
                    resrefIdList.ResponseCode = 0;
                }
                else
                {
                    resrefIdList.ResponseMessage = "Unable to Fetch Invoice ref";
                    resrefIdList.ResponseCode = 0;
                }
            }
            catch (Exception ex) { }
            return resrefIdList;
        }

        public static ResrefIdList GetBillRef(ReqUserId reqUserId, String spName)
        {
            ResrefIdList resrefIdList = new ResrefIdList();

            List<ResrefId> _resrefIdList = new List<ResrefId>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResrefId resrefId = new ResrefId();
                        resrefId.RefId = Convert.ToInt32(dt.Rows[i]["BillId"]);
                        resrefId.RefNo = Convert.ToInt32(dt.Rows[i]["BillNo"]);
                        _resrefIdList.Add(resrefId);
                    }
                    resrefIdList.resrefIdList = _resrefIdList;
                    resrefIdList.ResponseMessage = "Bill ref Fetched successfully";
                    resrefIdList.ResponseCode = 0;
                }
                else
                {
                    resrefIdList.ResponseMessage = "Unable to fetch bill Ref";
                    resrefIdList.ResponseCode = 0;
                }
            }
            catch (Exception ex) { }
            return resrefIdList;
        }


        public static ResCustomerList GetCustomerList(ReqUserId reqUserId, String spName)
        {
            ResCustomerList resCustomerList = new ResCustomerList();

            List<ResCustomer> _resCustomerList = new List<ResCustomer>();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqUserId.UserId));

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ResCustomer resCustomer = new ResCustomer();
                        resCustomer.Id = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                        resCustomer.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                        resCustomer.State = Convert.ToString(dt.Rows[i]["State"]);
                        resCustomer.ShippingAddress1 = Convert.ToString(dt.Rows[i]["ShippingAddress1"]);
                        resCustomer.ShippingAddress2 = Convert.ToString(dt.Rows[i]["ShippingAddress2"]);
                        resCustomer.ShippingCity = Convert.ToString(dt.Rows[i]["ShippingCity"]);
                        resCustomer.ShippingCountry = Convert.ToString(dt.Rows[i]["ShippingCountry"]);
                        resCustomer.ShippingPinCode = Convert.ToString(dt.Rows[i]["ShippingPinCode"]);
                        _resCustomerList.Add(resCustomer);
                    }
                    resCustomerList.ResponseCode = 0;
                    resCustomerList.ResponseMessage = "Fetched Customer detail successfully";
                    resCustomerList.resCustomer = _resCustomerList;
                }
                else
                {
                    resCustomerList.ResponseCode = 0;
                    resCustomerList.ResponseMessage = "No record Found";
                }

            }
            catch (Exception ex) { }
            return resCustomerList;
        }

    }
}

