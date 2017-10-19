<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LetzGST.Dashboard.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <!--Navbar ends here-->
  <%--  <div id="wrapper" class="toggled">--%>
      <%--  <div class="container-fluid">
         --%>

            <!-- main Content starts here-->
           <%-- <div id="page-content-wrapper">--%>
                <div class="container-fluid">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="box clearfix">
                            <div class="box-header with-border">
                                <h3 class="box-title">Expense</h3>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12 col-sm-4 colxs-12">
                                        <div id="expensechart" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                                    </div>

                                    <div class="col-md-12 col-sm-4 colxs-12">
                                        <div class="row">
                                            <div class="p-t-50">
                                                <div class="col-md-6 col-xs12">
                                                    <label class="control-label">Select Type</label>
                                                    <select id="dpSelectTypeExpense" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">                                                   
                                                    <option value="1">Monthly</option>
                                                    <option value="2"> Quarterly</option>
                                                </select>
                                                </div>
                                                <div class="col-md-6 col-xs12">
                                                    <label class="control-label">Select Month / Quarter</label>
                                                    <select id="drpMonthQurterExpense" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">  
                                               <%--     <option></option>
                                                    <option value="1">Jan</option>
                                                    <option value="2"> Feb</option>--%>
                                                </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix p-t-50">
                                            <div class="col-md-12">
                                                <label>Total Tax:</label> <i>&#8377;</i> <span id="exTotalTax"></span>
                                            </div>
                                            <div class="clearfix p-t-30">
                                                <div class="col-md-6">
                                                    <label>CGST:</label> <i>&#8377;</i> <span id="exCGST"></span>
                                                </div>
                                                <div class="col-md-6">
                                                    <label>SGST:</label> <i>&#8377;</i> <span id="exSGST"></span>
                                                </div>
                                            </div>
                                            <div class="clearfix p-t-10">
                                                <div class="col-md-6">
                                                    <label>IGST:</label> <i>&#8377;</i> <span id="exIGST"></span>
                                                </div>
                                                <div class="col-md-6">
                                                    <label>UTGST:</label> <i>&#8377;</i> <span id="exUTGST"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="box clearfix">
                            <div class="box-header with-border">
                                <h3 class="box-title">Invoice</h3>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12 col-sm-4 colxs-12">
                                        <div id="invoicechart" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                                    </div>

                                    <div class="col-md-12 col-sm-4 colxs-12">
                                        <div class="row">
                                            <div class="p-t-50">
                                                <div class="col-md-6 col-xs12">
                                                    <label class="control-label">Select Type</label>
                                                    <select id="dpSelectTypeInvoice" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">  
                                                   
                                                    <option value="1">Monthly</option>
                                                    <option value="2"> Quarterly</option>
                                                </select>
                                                </div>
                                                <div class="col-md-6 col-xs12">
                                                    <label class="control-label">Select Month / Quarter</label>
                                                    <select id="drpMonthQurterInvoice" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">  
                                                  <%--  <option></option>
                                                    <option value="1">Jan</option>
                                                    <option value="2"> Feb</option>--%>
                                                </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix p-t-50">
                                            <div class="col-md-12">
                                                <label>Total Tax:</label> <i>&#8377;</i> <span id="InTotalTax"></span>
                                            </div>
                                            <div class="clearfix p-t-30">
                                                <div class="col-md-6">
                                                    <label>CGST:</label> <i>&#8377;</i> <span id="InCGST"></span>
                                                </div>
                                                <div class="col-md-6">
                                                    <label>SGST:</label> <i>&#8377;</i> <span id="InSGST"></span>
                                                </div>
                                            </div>
                                            <div class="clearfix p-t-10">
                                                <div class="col-md-6">
                                                    <label>IGST:</label> <i>&#8377;</i> <span id="InIGST"></span>
                                                </div>
                                                <div class="col-md-6">
                                                    <label>UTGST:</label> <i>&#8377;</i> <span id="InUTGST"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--<div class="row">
                        <div class="col-lg-12">
                            <h3>Dashboard</h3>
                        </div>
                    </div>-->
                    <!---->
                </div>
        <%--    </div>--%>

            <!-- main content ends here -->



      <%--  </div>--%>

   <%-- </div>--%>
    <!-- /#wrapper -->


 
    <form id="userTypeid" runat="server">
        <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />
        <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />                 
        <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
        <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
        <asp:HiddenField ClientIDMode="Static" ID="hdn_Expiry" runat="server" Value="" />
    </form>
    
    <!-- JQuery -->
    <script type="text/javascript" src="../js/jquery-3.1.1.min.js"></script>
    <script src="https://npmcdn.com/tether@1.2.4/dist/js/tether.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="../js/chosen.jquery.js"></script>
    <script type="text/javascript" src="../js/dashboard.js"></script>
    <%--<script>
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

    </script>--%>
</asp:Content>

