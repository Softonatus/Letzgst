<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="GSTR-1.aspx.cs" Inherits="LetzGST.GST.GSTR_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="box clearfix">

                    <div class="box-header with-border">
                        <h3 class="box-title"> Tax Transition : GSTR 1</h3>
                    </div>
                    <div class="box-body">
                        <div class="box-border">
                            <div class="clearfix">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <p>
                                        <label>GSTN :</label> <span></span>
                                    </p>
                                    <p>
                                        <label>Legal name of registred person :</label> <span></span>
                                    </p>
                                    <p>
                                        <label>Trade name (if any) :</label> <span></span>
                                    </p>
                                </div>
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label>Aggredate Turnover in the preceding Finacial Year</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label>Aggredate Turnover -<span> April to June, 2017</span></label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <label class="control-label">Month Of Return</label>
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="icon ico-calendar"></i>
                                            </div>
                                            <input type="text" class="form-control pull-right" id="rtnmonth">
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="gstr-container box-border m-t-15">
                            <!-- Nav tabs -->
                            <div class="pull-right">
                                <a href="" class="btn btn-ltz btn-outline" data-toggle="modal" data-target="#sendquote"><span class="icon ico-sendbtn ico-2x"></span> Send GSTR 1 for approval</a>
                                <a class="btn letz-btn btn-ltz"><span class="icon ico-printer ico-2x"></span> Print GSTR 1 From</a>
                            </div>
                            <ul class="nav nav-tabs customtabtop" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#tab2" role="tab" aria-expanded="true">
                                        <span class="hidden-sm-up"><i class="ti-user"></i></span>
                                        <span class="hidden-xs-down">View Invoices</span>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#tab3" role="tab" aria-expanded="false">
                                        <span class="hidden-sm-up"><i class="ti-email"></i></span>
                                        <span class="hidden-xs-down">Reconsile GSTR-1</span>
                                    </a>
                                </li>
                            </ul>
                            <!-- Tab panes -->
                            <div class="panel-body">
                                <div class="tab-content">
                                    <!-- View My Invoices -->
                                    <div class="tab-pane view-my-invoice active" id="tab2" role="tabpanel" aria-expanded="true">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 gstr-type-bar">
                                                <!-- Nav tabs -->
                                                <ul class="nav nav-tabs customtabbtm" role="tablist">
                                                    <li class="nav-item">
                                                        <a class="nav-link active" data-toggle="tab" href="#b2bTab" role="tab">
                                                            <span class="hidden-xs-down">B2B</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#b2clTab" role="tab">
                                                            <span class="hidden-xs-down">B2CL</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#b2csTab" role="tab">
                                                            <span class="hidden-xs-down">B2CS</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#cdnrTab" role="tab">
                                                            <span class="hidden-xs-down">CDNR</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#cdnurTab" role="tab">
                                                            <span class="hidden-xs-down">CDNUR</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#expTab" role="tab">
                                                            <span class="hidden-xs-down">EXP</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#atTab" role="tab">
                                                            <span class="hidden-xs-down">AT</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#atadjTab" role="tab">
                                                            <span class="hidden-xs-down">ATADJ</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#exempTab" role="tab">
                                                            <span class="hidden-xs-down">EXEMP</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#hsnTab" role="tab">
                                                            <span class="hidden-xs-down">HSN</span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" data-toggle="tab" href="#documentTab" role="tab">
                                                            <span class="hidden-xs-down">Document</span>
                                                        </a>
                                                    </li>
                                                </ul>
                                                <!-- Tab panes -->
                                                <div class="panel-body">
                                                    <div class="tab-content">
                                                        <!-- B2B Start Here -->
                                                        <div class="tab-pane active" id="b2bTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of B2B</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>No. of Invoices</th>
                                                                                <th>Total CGST</th>
                                                                                <th>Total SGST</th>
                                                                                <th>Total IGST</th>
                                                                                <th>Total CESS</th>
                                                                                <th>Total Taxable Amount</th>
                                                                                <th>Total Amount</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-b2b">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>GSTIN/UIN of Recipient</th>
                                                                                        <th>Invoice Number</th>
                                                                                        <th>Invoice date</th>
                                                                                        <th>Invoice Value</th>
                                                                                        <th>Place Of Supply</th>
                                                                                        <th>Reverse Charge</th>
                                                                                        <th>Invoice Type</th>
                                                                                        <th>E-Commerce GSTIN</th>
                                                                                        <th>Rate</th>
                                                                                        <th>Taxable Value</th>
                                                                                        <th>Cess Amount</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>27AUYPK8066C1ZS</td>
                                                                                        <td>123</td>
                                                                                        <td>01-Sep-2017</td>
                                                                                        <td></td>
                                                                                        <td>27-Maharashtra</td>
                                                                                        <td>N</td>
                                                                                        <td>Regular</td>
                                                                                        <td></td>
                                                                                        <td>0</td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- B2B End Here -->
                                                        <!-- B2CL Start Here -->
                                                        <div class="tab-pane" id="b2clTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of B2CL</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>No. of Invoices</th>
                                                                                <th>Total CGST</th>
                                                                                <th>Total SGST</th>
                                                                                <th>Total IGST</th>
                                                                                <th>Total CESS</th>
                                                                                <th>Total Taxable Amount</th>
                                                                                <th>Total Amount</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-b2cl">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Invoice Number</th>
                                                                                        <th>Invoice date</th>
                                                                                        <th>Invoice Value</th>
                                                                                        <th>Place Of Supply</th>
                                                                                        <th>Rate</th>
                                                                                        <th>Taxable Value</th>
                                                                                        <th>Cess Amount</th>
                                                                                        <th>E-Commerce GSTIN</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody></tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- B2CL End Here -->
                                                        <!-- B2CS Start Here -->
                                                        <div class="tab-pane" id="b2csTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of B2CS</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>No. of Invoices</th>
                                                                                <th>Total CGST</th>
                                                                                <th>Total SGST</th>
                                                                                <th>Total IGST</th>
                                                                                <th>Total CESS</th>
                                                                                <th>Total Taxable Amount</th>
                                                                                <th>Total Amount</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-b2cs">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <!--<th>Invoice NO</th>-->
                                                                                        <th>Type</th>
                                                                                        <th>Place Of Supply</th>
                                                                                        <th>Rate</th>
                                                                                        <th>Taxable Value</th>
                                                                                        <th>Cess Amount</th>
                                                                                        <th>E-Commerce GSTIN</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody></tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- B2CS End Here -->
                                                        <!-- CDNR Start Here -->
                                                        <div class="tab-pane" id="cdnrTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of CDNR</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>No. of Recipients</th>
                                                                                <th>No. of Invoices</th>
                                                                                <th>No. of Notes/Vouchers</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td> <span>100</span></td>
                                                                                <td> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-cdnr">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>GSTIN/UIN of Recipient</th>
                                                                                        <th>Invoice/Advance Receipt Number</th>
                                                                                        <th>Invoice/Advance Receipt date</th>
                                                                                        <th>Note/Refund Voucher Number</th>
                                                                                        <th>Note/Refund Voucher date</th>
                                                                                        <th>Document Type</th>
                                                                                        <th>Reason For Issuing document</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>27AUYPK8066C1ZS</td>
                                                                                        <td></td>
                                                                                        <td>01-Sep-2017</td>
                                                                                        <td>123</td>
                                                                                        <td>2017-09-01</td>
                                                                                        <td>c</td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- CDNR End Here -->
                                                        <!-- CDNUR Start Here -->
                                                        <div class="tab-pane" id="cdnurTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of CDNUR</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>No. of Notes/Vouchers</th>
                                                                                <th>No. of Invoices</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-cdnur">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>UR Type</th>
                                                                                        <th>Note/Refund Voucher Number</th>
                                                                                        <th>Note/Refund Voucher date</th>
                                                                                        <th>Document Type</th>
                                                                                        <th>Invoice/Advance Receipt Number</th>
                                                                                        <th>Invoice/Advance Receipt date</th>
                                                                                        <th>Reason For Issueing document</th>
                                                                                        <th>Place of Supply</th>
                                                                                        <th>Note/Refund Voucher Value</th>
                                                                                        <th>Rate</th>
                                                                                        <th>Taxable Value</th>
                                                                                        <th>Cess Amount</th>
                                                                                        <th>Pre GST</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody></tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- CDNUR End Here -->
                                                        <!-- EXP Start Here -->
                                                        <div class="tab-pane" id="expTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of EXP</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>No. of Invoices</th>
                                                                                <th>Total Invoice Value</th>
                                                                                <th>No. of Shipping Bill</th>
                                                                                <th>Total Taxable Amount</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span>10</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-exp">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Export Type</th>
                                                                                        <th>Invoice Number</th>
                                                                                        <th>Invoice date</th>
                                                                                        <th>Invoice Value</th>
                                                                                        <th>Port Code</th>
                                                                                        <th>Shipping Bill Number</th>
                                                                                        <th>Shipping Bill Date</th>
                                                                                        <th>Rate</th>
                                                                                        <th>Taxable Value</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>WPAY</td>
                                                                                        <td></td>
                                                                                        <td>01-Sep-2017</td>
                                                                                        <td>10600.00</td>
                                                                                        <td>Pending</td>
                                                                                        <td></td>
                                                                                        <td>2017-09-02</td>
                                                                                        <td>0.00</td>
                                                                                        <td>10000.00</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>WPAY</td>
                                                                                        <td>00121</td>
                                                                                        <td>01-Sep-2017</td>
                                                                                        <td>5000.00</td>
                                                                                        <td>Pending</td>
                                                                                        <td></td>
                                                                                        <td>2017-09-02</td>
                                                                                        <td>0.00</td>
                                                                                        <td>5000.00</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- EXP End Here -->
                                                        <!-- AT Start Here -->
                                                        <div class="tab-pane" id="atTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of AT</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>Total Advance Received</th>
                                                                                <th>Total CGST</th>
                                                                                <th>Total SGST</th>
                                                                                <th>Total IGST</th>
                                                                                <th>Total CESS</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-at">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Place Of Supply</th>
                                                                                        <th>Rate</th>
                                                                                        <th>Gross Advance Received</th>
                                                                                        <th>Cess Amount</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>0</td>
                                                                                        <td>0</td>
                                                                                        <td>20000</td>
                                                                                        <td>0.00</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- AT End Here -->
                                                        <!-- ATADJ Start Here -->
                                                        <div class="tab-pane" id="atadjTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of ATADJ</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>otal Advance Adjusted</th>
                                                                                <th>Total CGST</th>
                                                                                <th>Total SGST</th>
                                                                                <th>Total IGST</th>
                                                                                <th>Total CESS</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-atadj">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Place Of Supply</th>
                                                                                        <th>Rate</th>
                                                                                        <th>Gross Advance Received</th>
                                                                                        <th>Cess Amount</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody></tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- ATADJ End Here -->
                                                        <!-- EXEMP Start Here -->
                                                        <div class="tab-pane" id="exempTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of EXEMP</label>
                                                                        <table class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>Total Nil Rated Supplies</th>
                                                                                <th>Total Exempted Supplies</th>
                                                                                <th>Total Non-GST Supplies</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span>100</span></td>
                                                                                <td><span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Description</th>
                                                                                        <th>Nil Rated Supplies</th>
                                                                                        <th>Exempted (other than nil rated/non GST supply )</th>
                                                                                        <th>Non-GST supplies</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>Inter-State supplies to registered person</td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>Intra-State supplies to registered person</td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>Inter-State supplies to unregistered person</td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>Intra-State supplies to unregistered person</td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- EXEMP End Here -->
                                                        <!-- HSN Start Here -->
                                                        <div class="tab-pane" id="hsnTab" role="tabpanel">
                                                            <div class="invoice-type">
                                                                <div class="row">
                                                                    <!-- Summary Bar -->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 summary-bar">
                                                                        <label>Summary of B2CL</label>
                                                                        <table id="ltz-table3" class="table table-bordered table-striped ltz-table">
                                                                            <tr>
                                                                                <th>No. of HSN</th>
                                                                                <th>Total CGST</th>
                                                                                <th>Total SGST</th>
                                                                                <th>Total IGST</th>
                                                                                <th>Total CESS</th>
                                                                                <th>Total Taxable Amount</th>
                                                                                <th>Total Amount</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                                <td><span class="icon ico-rupees ico-3x"></span> <span>100</span></td>
                                                                            </tr>
                                                                        </table>

                                                                        <hr>
                                                                    </div>
                                                                    <!-- /Summary Bar -->
                                                                    <!-- Table View-->
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table">
                                                                        <div class="table-responsive">
                                                                            <table class="table table-bordered table-striped dt-responsive dataTable no-footer ltz-table" id="gstr1-hsn">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>HSN</th>
                                                                                        <th>Description</th>
                                                                                        <th>UQC</th>
                                                                                        <th>Total Quantity</th>
                                                                                        <th>Total Value</th>
                                                                                        <th>Taxable Value</th>
                                                                                        <th>Integrated Tax Amount</th>
                                                                                        <th>Central Tax Amount</th>
                                                                                        <th>State/UT Tax Amount</th>
                                                                                        <th>Cess Amount</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td></td>
                                                                                        <td>live fish</td>
                                                                                        <td></td>
                                                                                        <td>9</td>
                                                                                        <td>45000</td>
                                                                                        <td>45000.00</td>
                                                                                        <td>0.00</td>
                                                                                        <td>600.00</td>
                                                                                        <td>600.00</td>
                                                                                        <td>0.00</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /Table View-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- HSN End Here -->
                                                        <!-- Document Start Here -->
                                                        <div class="tab-pane" id="documentTab" role="tabpanel">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 view-table doc-right">
                                                                <form id="table_document" action="" method="post">
                                                                    <table id="table_doc" class="table table-bordered ltz-table">
                                                                        <thead>
                                                                            <tr>
                                                                                <th class="w-6">Nature of Document</th>
                                                                                <th>Sr. No. From</th>
                                                                                <th>Sr. No. To</th>
                                                                                <th>Total Number</th>
                                                                                <th>Cancelled</th>
                                                                                <th>Actions</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <select id="natureofdoc" data-placeholder="Select nature of document" name="natureofdoc" class="form-control  chosen-select-deselect" required="required">
                                                                                                <option value=""></option>
                                                                                                <option value="1">Invoice for outward supply</option>
                                                                                                <option value="2">Invoice for inward supply from unregistered person</option>
                                                                                                <option value="3">Revised Invoice</option>
                                                                                                <option value="4">Debit Note</option>
                                                                                                <option value="5">Credit Note</option>
                                                                                                <option value="6">Receipt Voucher</option>
                                                                                                <option value="7">Payment Voucher</option>
                                                                                                <option value="8">Refund Voucher</option>
                                                                                                <option value="9">Delivery Challan for job work</option>
                                                                                                <option value="10">Delivery Challan for supply on approval</option>
                                                                                                <option value="11">Delivery Challan in case of liquid gas</option>
                                                                                                <option value="12">Delivery Challan in cases other than by way of supply (excluding at S no. 9 to 11)</option>
                                                                                            </select>
                                                                                </td>
                                                                                <td>
                                                                                    <input type="text" name="data[1][from]" class="form-control">
                                                                                </td>
                                                                                <td>
                                                                                    <input type="text" name="data[1][to]" class="form-control">
                                                                                </td>
                                                                                <td>
                                                                                    <input type="text" name="data[1][total]" class="form-control">
                                                                                </td>
                                                                                <td>
                                                                                    <input type="text" name="data[1][cancel]" class="form-control">
                                                                                </td>
                                                                                <td><input type="button" class="add tbl-btn" id="add_doc" value="" title="Add More Items"></td>
                                                                            </tr>
                                                                            
                                                                        </tbody>
                                                                        <tfoot>
                                                                            <tr>
                                                                                <td colspan="6">                                                                                    
                                                                                    <a class="btn letz-btn btn-ltz save-invoice pull-right"><span class="icon ico-save ico-2x"></span> Save</a>
                                                                                </td>
                                                                            </tr>
                                                                        </tfoot>
                                                                    </table>
                                                                </form>
                                                            </div>
                                                        </div>
                                                        <!-- Document End Here -->
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /View My Invoices -->
                                    <!-- GSTR-1 -->
                                    <div class="tab-pane" id="tab3" role="tabpanel" aria-expanded="false">
                                        
                                       
                                        <!-- /GSTR-1 Filing Summary -->
                                    </div>
                                    <!--/GSTR-1  -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



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


    <!----plugins----->
    <script type="text/javascript" src="../js/chosen.jquery.js"></script>
    <script type="text/javascript" src="../js/charts.js"></script>
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../js/pdfobject.min.js"></script>
    <script type="text/javascript" src="../js/sweetalert.min.js"></script>
    <script type="text/javascript" src="../js/gstr1.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>
</asp:Content>
