<%@ Page Language="C#"   MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="LetzGST.Reports.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <%-- <div id="page-content-wrapper">--%>

                <div class="box clearfix">

                    <div class="box-header with-border">
                        <h3 class="box-title">Reports</h3>
                    </div>
                    <div class="box-body">
                        <div class="row p-t-30">
                            <div class="col-md-3">
                                <label class="control-label">Report For</label>
                                <select id="drpTypelist" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">  
                                            <option></option>
                                    <option value="3"> Advance </option>
                                            <option value="4"> Credit</option>
                                            <option value="5">Debit</option>
                                            <option value="1"> Expense</option>
                                            <option value="2"> Invoice </option>
                                            
                                        </select>
                            </div>
                            <div class="col-md-3" style="display:none">
                                <label class="control-label">Vendor / Company</label>
                                <select id="drpVendorCustomerlist" name="" data-placeholder="Select" class="form-control chosen-select-deselect" required="required">  
                                            <option></option>
                                            
                                        </select>


                            </div>
                            <div class="col-md-3">
                                <label class="control-label">From</label>
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="icon ico-calendar"></i>
                                    </div>
                                    <input type="text" class="form-control pull-right" id="rptfromdt">
                                </div>

                            </div>
                            <div class="col-md-3">
                                <label class="control-label">To</label>
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="icon ico-calendar"></i>
                                    </div>
                                    <input type="text" class="form-control pull-right" id="rpttodt">
                                </div>
                                <a class="btn btn-ltz m-t-20" id="rptok"><span class="icon ico-tick ico-2x"></span>  OK</a>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="brs-container rpt-container">
                                    <table id="rptexptbl" class="table table-bordered dt-responsive dataTable  dtr-inline ltz-table m-t-30" width="100%" cellspacing="0">
                                        <thead>
                                            <tr id="trReportHead">
                                                
                                                
                                            </tr>
                                        </thead>
                                        <tbody id="tbReport">
                                            

                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th>Total</th>
                                                <th>&#8377; <span></span></th>
                                                <th>&#8377; <span></span></th>
                                                <th>&#8377; <span></span></th>
                                                <th>&#8377; <span></span></th>
                                                <th>&#8377; <span></span></th>
                                                <th>&#8377; <span></span></th>
                                                <th>&#8377; <span></span></th>
                                                <th>&#8377; <span></span></th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </tfoot>

                                    </table>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>
            <form id="parentId" runat="server">
                <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />
                <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />
                <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />          
                <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
            </form>
          <%--  </div>--%>
 
        <%--<script id="tblVendorCustomerDropdown" type="text/x-jsrender">
        <option value="{{:Id}}"> {{:VendorName}} </option>
    </script>--%>
   <script type="text/javascript" src="../js/jquery-3.1.1.min.js"></script>
    <script src="https://npmcdn.com/tether@1.2.4/dist/js/tether.min.js"></script> 
      
     
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.16.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-filestyle.min.js"></script>

   <%-- <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>--%>
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs-3.3.7/jszip-3.1.3/pdfmake-0.1.27/dt-1.10.15/af-2.2.0/b-1.4.0/b-colvis-1.4.0/b-flash-1.4.0/b-html5-1.4.0/b-print-1.4.0/cr-1.3.3/fc-3.2.2/fh-3.1.2/kt-2.3.0/r-2.1.1/rg-1.0.0/rr-1.2.0/sc-1.4.2/se-1.2.2/datatables.min.js"></script>
    

    <!-- DataTables -->
    <!--<script src="../js/datatables.min.js"></script>-->
    
    <script type="text/javascript" src="../../js/jsrender.js"></script>
    
      <script src="../js/chosen.jquery.js"></script>
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../js/reports.js"></script>
    
    <script type="text/javascript" src="../js/custom.js"></script>
    

    <script id="tblReportListDetails" type="text/x-jsrender">
       <tr>
            
            <td>1</td>
            <td>{{:RefNo}}</td>
            <td>{{:TId}}</td>
            <td>{{:Date}}</td>
            <td>{{:Name}}</td>
            <td>{{:GstinNo}}</td>
           <td>{{:PanNo}}</td>
            <td>{{:ContactName}}</td>
            <td name="Ne">{{:Amount}}</td>
            <td>{{:Sgst}}</td>
            <td>{{:Cgst}}</td>
            <td>{{:Utgst}}</td>
           <td>{{:Igst}}</td>
           <td>{{:Status}}</td>
            
            
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
