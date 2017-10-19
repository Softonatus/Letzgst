<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BRS.aspx.cs" Inherits="LetzGST.BRS.BRS" MasterPageFile="~/GSTSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        
            <!-- Sidebar starts here-->
            
            <!-- sidebar ends here -->

            <!-- main Content starts here-->
           <%-- <div id="page-content-wrapper">--%>

                <div class="box clearfix">

                    <div class="box-header with-border">
                        <h3 class="box-title">Bank Reconcile</h3>
                    </div>
                    <div class="box-body">
                        <div class="row p-t-30">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="control-label">Reconcile For</label>
                                        <select id="ddReconcile" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">  
                                            <option></option>
                                            <option value="1">Expense</option>
                                            <option value="2">Invoice</option>
                                            <option value="3">Advance</option>
                                            <option value="4">Credit</option>
                                            <option value="5">Debit</option>
                                        </select>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="control-label">Select Month</label>
                                        <select id="ddMonth" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">  
                                            <option></option>
                                                <option value='1'>Janaury</option>
                                                <option value='2'>February</option>
                                                <option value='3'>March</option>
                                                <option value='4'>April</option>
                                                <option value='5'>May</option>
                                                <option value='6'>June</option>
                                                <option value='7'>July</option>
                                                <option value='8'>August</option>
                                                <option value='9'>September</option>
                                                <option value='10'>October</option>
                                                <option value='11'>November</option>
                                                <option value='12'>December</option>
                                        </select>
                                    </div>
                                </div>


                            </div>
                            <div class="col-md-6" id="btnReconcile">
                                <a class="btn btn-ltz m-t-20 pull-right" id="addinvoice"><span class="icon ico-repeat ico-2x"></span>  Reconsile</a>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="brs-container">
                                    <table id="brstoptbl" class="table table-striped table-bordered dt-responsive dataTable no-footer dtr-inline ltz-table" width="100%" cellspacing="0">
                                        <thead>
                                            <tr>
                                                <th class="w-1"></th>
                                                <th class="w-1">Invoice.no</th>
                                                <th class="w-2">Vendor / Company Name</th>
                                                <th class="w-2">Date</th>
                                                <th class="w-2">Amount</th>
                                                <th class="w-2">Pending Amount</th>
                                                <th class="w-2">Status</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbBrsList">
                                            
                                        </tbody>
                                    </table>

                                </div>
                            </div>
                            <div id="dvBrsPayment" class="col-md-12" style="display:none">
                                <div class="brs-container">

                                    <table id="brbottomtbl" class="table table-striped table-bordered dt-responsive dataTable no-footer dtr-inline ltz-table" width="100%" cellspacing="0">
                                        <thead>
                                            <tr>
                                                <th class="w-1">Sr.no</th>
                                                <th class="w-4">Amount</th>
                                                <th class="w-2">Description</th>
                                                <th class="w-3">Realization Date</th>
                                                <th class="w-3">Paid Date</th>
                                                <th class="w-2">Payment Method</th>
                                                <th class="w-5"></th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbBrsPaymentList">
                                            <%--<tr>
                                                <td>1</td>
                                                <td>
                                                    <input type="text" name="BrsPayAmount" class="form-control" id="">
                                                </td>
                                                <td>
                                                    <textarea name="BrsPayDescription" class="form-control"></textarea>
                                                </td>
                                                <td>
                                                    <div class="input-group date">
                                                        <div class="input-group-addon">
                                                            <i class="icon ico-calendar"></i>
                                                        </div>
                                                        <input type="text" name="BrsPayRealDate" class="form-control pull-right editme brspydate" id="brspydate">
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="input-group date">
                                                        <div class="input-group-addon">
                                                            <i class="icon ico-calendar"></i>
                                                        </div>
                                                        <input type="text" name="BrsPayPaidDate" class="form-control pull-right editme brspydate" >
                                                    </div>
                                                </td>
                                                <td>
                                                    <select id="brspaymentmethod" name="BrsPayMethod" data-placeholder="Payment Terms" name="brspaymentmethod" class="form-control editme" required="required">
                                                        <option selected></option>
                                                        <option value="cash"> Cash </option>
                                                        <option value="cheque"> Cheque</option>
                                                        <option value="banktransfer"> Bank Transfer</option>
                                                        <option value="creditcard">Credit Card</option>
                                                        <option value="debitcard">Debit Card</option>
                                                        <option value="online">Online</option>
                                                        <option value="others">Others</option>
                                                    </select>
                                                </td>
                                                <td>
                                                    <input type='button' class='add tbl-btn editme' value='' title="Add More Items" />
                                                    <a class="actions-btn btn-edit" id="edit-brspayment" title="Edit"><span class="icon ico-edit ico-2x"></span></a>
                                                </td>

                                            </tr>--%>


                                        </tbody>
                                    </table>



                                </div>

                                <div class="col-md-6" id="btnSubmit">
                                <a class="btn btn-ltz m-t-20 pull-right" id="">  Submit</a>
                            </div>

                            </div>
                        </div>
                        <form id="parentId" runat="server">
                            <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />
                            <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />              
                            <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
                            <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
                        </form>
                    </div>

                </div>

            <%--</div>--%>
            <!-- main content ends here -->

        
    <!-- JQuery -->
    <script type="text/javascript" src="../js/jquery-3.1.1.min.js"></script>
    <script src="https://npmcdn.com/tether@1.2.4/dist/js/tether.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.16.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-filestyle.min.js"></script>

    <!-- DataTables -->
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    
    <script type="text/javascript" language="javascript" src="https://cdn.datatables.net/select/1.2.2/js/dataTables.select.min.js">


    </script>

    <!----plugins----->
    <script src="../js/chosen.jquery.js"></script>
    <script type="text/javascript" src="../../js/jsrender.js"></script> 
    <script type="text/javascript" src="../js/charts.js"></script>
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>

    <script type="text/javascript" src="../js/pdfobject.min.js"></script>
    <script type="text/javascript" src="/BRS/brs.js"></script>
    <script type="text/javascript" src="../js/custom.js"></script>
    <script>
        //$sidebarMenu($('.sidebar-menu'))
        

    </script>
    <script id="tblBrsListDetails" type="text/x-jsrender">
       <tr >
            <td><input type="radio" id="brs_{{:PId}}"  name="rd_BRS" data-status="{{:Status}}" data-TId={{:TId}} data-PendingAmount={{:PendingAmount}} ></td>
            <td>{{:PId}}</td>
            <td>{{:VendorName}}</td>
            <td>{{:Date}}</td>
            <td><span class="icon ico-rupees ico-3x"></span> {{:Amount}}</td>
           <td><span class="icon ico-rupees ico-3x"></span> {{:PendingAmount}}</td>
            <td>
                {{:Status}}
            </td>
        </tr>
    </script>

    <script>
        $(function() {

            $(".chosen-select").chosen({
                width: "100%"
            });
            $('.chosen-select-deselect').chosen({
                width: "100%",
                allow_single_deselect: true,
                include_group_label_in_selected: true
            });

        });

    </script>
    </asp:Content>