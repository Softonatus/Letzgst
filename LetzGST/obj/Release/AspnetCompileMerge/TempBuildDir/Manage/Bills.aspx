<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="Bills.aspx.cs" Inherits="LetzGST.Manage.Bills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div id="page-content-wrapper">--%>

                <div class="box clearfix">

                    <div class="box-header with-border">
                        <h3 class="box-title">Expenditure Management : Expenditure Bills</h3>
                    </div>
                    <div class="box-body">
                        <div id="horizontalTab">
                            <div id="expensetable" style="display: block;">
                                <div class="row">
                                    <div class="upcoming-container">
                                        <div class="col-md-6 col-sm-12 col-xs-12">
                                          <%--  Future Bills
                                            <table class="table">
                                                <tr>
                                                    <th>Bill</th>
                                                    <th>Amount</th>
                                                    <th>Date</th>
                                                </tr>
                                                <tr>
                                                    <td>Tes</td>
                                                    <td><span class="icon ico-rupees ico-3x"></span> 10,000</td>
                                                    <td>13/09/2017</td>
                                                </tr>
                                            </table>--%>
                                        </div>
                                        <div class="col-md-6 col-sm-12 col-xs-12">
                                            <%--<a class="btn btn-primary" id="addpobtn">Add purchase bill</a>--%>
                                            <a class="btn btn-ltz m-t-30 pull-right" id="addpobtn"><span class="icon ico-add ico-2x"></span> Add Expenditure  Bill</a>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div class="table-container">
                                    <div class="col-md-12">
                                        <table id="pobills" class="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline" width="100%" cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th>Sr.no</th>
                                                    <th>Vendor Name</th>
                                                    <th>Bill / Ref No</th>
                                                    <th>Bill Date</th>
                                                    <th>Amount</th>
                                                    <th>Expense</th>
                                                    <th>Payment type</th>
                                                    <th>Status</th>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody id="billDetail">
                                                <tr>
                                                   <td colspan="9">
                                                       Loading....
                                                   </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>


                                </div>

                            </div>
                            <div id="addexpense" style="display: none;">
                                <form id="addBillDetails" runat="server">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="btns-container">
                                                <div class="pull-left">
                                                    <%--<a class="btn btn-danger letz-btn" id="backtopo"><span class="glyphicon glyphicon-remove"></span></a>--%>
                                                     <a class="btn letz-btn btn-ltz" id="backtopo"><span class="icon ico-back ico-2x"></span> Back</a>
                                                </div>
                                                <div class="pull-right">
                                                    <%--<a href="recurringbills.html" class="btn btn-primary letz-btn"><span class="icon ico-return"></span> Make Reuccrung bill</a>--%>
                                                    <%--<a class="btn letz-btn btn-ltz" type="submit" id="btn_SubmitPO"><span class="icon ico-save ico-2x"></span> Save</a>--%>
                                                    <button class="btn letz-btn btn-ltz" type="button" id="btn_SubmitBill"><span class="icon ico-save ico-2x"></span>Save</button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Biller Name</label> &nbsp; <span id="err_purchaseorderto"></span>
                                                <select id="purchaseorderto" data-placeholder="Biller Name" name="purchaseorderto" class="form-control chosen-select-deselect" required="required"> 
                                                    <option selected> </option>
                                                    <option value="addnewpoto" class="addnewtxt">Add new vendor</option>
                                                </select>
                                                <div class="edits" style="display: none;"><a href="javascript:void(0);"><span class="icon ico-edit ico-2x"></span></a></div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">Bill No</label> 
                                                <input type="text" id="billno" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">Bill Date</label>  &nbsp;<span id="err_podate"></span>
                                                <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="icon ico-calendar"></i>
                                                    </div>
                                                    <input type="text" class="form-control pull-right" id="podate" name="podate" required="required">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">Bill Due Date</label>  &nbsp;<span id="err_duedate"></span>
                                                <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="icon ico-calendar"></i>
                                                    </div>
                                                    <input type="text" class="form-control pull-right" id="duedate">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Expense Type</label>  &nbsp;<span id="err_addnewexp"></span>
                                                <select id="addnewexp" data-placeholder="Expense Type" name="addnewexp" class="form-control  chosen-select-deselect" required="required">
                                                    <option selected></option>
                                                    <option value="newexpense"  class="addnewtxt"> Add new expense</option>
                                                    <option value="1"> Marketing </option>
                                                    <option value="2"> Traveling </option>
                                                    <option value="3"> Rent</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">Ref No</label>   &nbsp;<span id="err_refno"></span>
                                                <input type="text" id="refno" class="form-control" name="refno">
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Payment Method</label>  &nbsp;<span id="err_paymentmethod"></span>
                                                <select id="paymentmethod" data-placeholder="Payment Terms" name="paymentmethod" class="form-control chosen-select-deselect" required="required">
                                                    <option selected> </option>
                                                    <option value="cash"> Cash </option>
                                                    <option value="cheque"> Cheque</option>
                                                    <option value="banktransfer"> Bank Transfer</option>
                                                    <option value="creditcard">Credit Card</option>
                                                    <option value="debitcard">Debit Card</option>
                                                    <option value="online">Online</option>
                                                    <option value="others">Others</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">Bill End Date</label>
                                                <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="icon ico-calendar"></i>
                                                    </div>
                                                    <input type="text" class="form-control pull-right" id="poenddate">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Place Of supply</label>
                                                <select id="placeodsupply" data-placeholder="Select Place of Supply " name="placeodsupply" class="form-control  chosen-select-deselect" required="required">
                                                    <option></option>
                                                    <option value="1"> Maharashtra </option>
                                                    <option value="2"> Gujrat </option>
                                                    <option value="3"> Punjab</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Port Code</label>
                                                <select id="portCode" data-placeholder="Select Port Code" class="form-control chosen-select-deselect" required="required">
                                                        <option></option>
                                                        <option value="INCNB1">INCNB1</option>
                                                        <option value="INCRN1">INCRN1</option>
                                                        <option value="INMYB1">INMYB1</option>
                                                        <option value="INESH1">INESH1</option>
                                                        <option value="INRGT1">INRGT1</option>
                                                        <option value="INMDW1">INMDW1</option>
                                                        <option value="INNAN1">INNAN1</option>
                                                        <option value="INIXZ1">INIXZ1</option>
                                                        <option value="INIXZ4">INIXZ4</option>
                                                        <option value="INHYD4">INHYD4</option>
                                                        <option value="INBNP1">INBNP1</option>
                                                        <option value="INNVP1">INNVP1</option>
                                                        <option value="INVTZ1">INVTZ1</option>
                                                        <option value="INSRV1">INSRV1</option>
                                                        <option value="INVTZ6">INVTZ6</option>
                                                        <option value="INVRU1">INVRU1</option>
                                                        <option value="INKAK1">INKAK1</option>
                                                        <option value="INRPL6">INRPL6</option>
                                                        <option value="INKDD6">INKDD6</option>
                                                        <option value="INVTZ4">INVTZ4</option>
                                                        <option value="INAPT6">INAPT6</option>
                                                        <option value="INCLX6">INCLX6</option>
                                                        <option value="INSNF6">INSNF6</option>
                                                        <option value="INCOI6">INCOI6</option>
                                                        <option value="INMAP1">INMAP1</option>
                                                        <option value="INKRI1">INKRI1</option>
                                                        <option value="INAKP6">INAKP6</option>
                                                        <option value="INTNI6">INTNI6</option>
                                                        <option value="INAKR6">INAKR6</option>
                                                        <option value="INVZM6">INVZM6</option>
                                                        <option value="INAKB6">INAKB6</option>
                                                        <option value="INNRP6">INNRP6</option>
                                                        <option value="INMOV6">INMOV6</option>
                                                        <option value="INKVR6">INKVR6</option>
                                                        <option value="INFMA6">INFMA6</option>
                                                        <option value="INFMH6">INFMH6</option>
                                                        <option value="INCOA6">INCOA6</option>
                                                        <option value="INGLY6">INGLY6</option>
                                                        <option value="INSPE6">INSPE6</option>
                                                        <option value="INCOP6">INCOP6</option>
                                                        <option value="INMDE6">INMDE6</option>
                                                        <option value="INKOH6">INKOH6</option>
                                                        <option value="INURF 6">INURF 6</option>
                                                        <option value="INMEA 6">INMEA 6</option>
                                                        <option value="IN DBS 6">IN DBS 6</option>
                                                        <option value="IN URG 6">IN URG 6</option>
                                                        <option value="IN TAS 6">IN TAS 6</option>
                                                        <option value="IN GNR 6">IN GNR 6</option>
                                                        <option value="IN FMS 6">IN FMS 6</option>
                                                        <option value="IN FMJ 6">IN FMJ 6</option>
                                                        <option value="IN LPI 6">IN LPI 6</option>
                                                        <option value="IN LPD 6">IN LPD 6</option>
                                                        <option value="IN TMI 6">IN TMI 6</option>
                                                        <option value="IN HUR 6">IN HUR 6</option>
                                                        <option value="IN VZR 6">IN VZR 6</option>
                                                        <option value="IN CDP 6">IN CDP 6</option>
                                                        <option value="INTMX6">INTMX6</option>
                                                        <option value="INNPGB">INNPGB</option>
                                                        <option value="INDRGB">INDRGB</option>
                                                        <option value="INGAU4">INGAU4</option>
                                                        <option value="INGHWB">INGHWB</option>
                                                        <option value="INDHBB">INDHBB</option>
                                                        <option value="INGTGB">INGTGB</option>
                                                        <option value="INGKJ2">INGKJ2</option>
                                                        <option value="INHTSB">INHTSB</option>
                                                        <option value="INKGJB">INKGJB</option>
                                                        <option value="INSTRB">INSTRB</option>
                                                        <option value="INSLRB">INSLRB</option>
                                                        <option value="INSLR2">INSLR2</option>
                                                        <option value="INPHBB">INPHBB</option>
                                                        <option value="INNMTB">INNMTB</option>
                                                        <option value="INMNUB">INMNUB</option>
                                                        <option value="INMKCB">INMKCB</option>
                                                        <option value="INMHN2">INMHN2</option>
                                                        <option value="INLTBB">INLTBB</option>
                                                        <option value="INULPB">INULPB</option>
                                                        <option value="INTJPB">INTJPB</option>
                                                        <option value="INKXJ2">INKXJ2</option>
                                                        <option value="INHLD2">INHLD2</option>
                                                        <option value="INGKJB">INGKJB</option>
                                                        <option value="INAMG6">INAMG6</option>
                                                        <option value="INRXL8">INRXL8</option>
                                                        <option value="INGALB">INGALB</option>
                                                        <option value="INJBNB">INJBNB</option>
                                                        <option value="INSNBB">INSNBB</option>
                                                        <option value="INRXLB">INRXLB</option>
                                                        <option value="INKNLB">INKNLB</option>
                                                        <option value="INKTRB">INKTRB</option>
                                                        <option value="INJAYB">INJAYB</option>
                                                        <option value="INBTMB">INBTMB</option>
                                                        <option value="INBGUB">INBGUB</option>
                                                        <option value="INBNRB">INBNRB</option>
                                                        <option value="INGAY4">INGAY4</option>
                                                        <option value="INPAT4">INPAT4</option>
                                                        <option value="INRAI6">INRAI6</option>
                                                        <option value="INRJN6">INRJN6</option>
                                                        <option value="INDAM1">INDAM1</option>
                                                        <option value="INSHP1">INSHP1</option>
                                                        <option value="INDEL4">INDEL4</option>
                                                        <option value="INDLI2">INDLI2</option>
                                                        <option value="INTKD6">INTKD6</option>
                                                        <option value="INPPG6">INPPG6</option>
                                                        <option value="INMRM1">INMRM1</option>
                                                        <option value="INTPN1">INTPN1</option>
                                                        <option value="INPPJ1">INPPJ1</option>
                                                        <option value="INPNJ1">INPNJ1</option>
                                                        <option value="INCHR1">INCHR1</option>
                                                        <option value="INBET1">INBET1</option>
                                                        <option value="INMDG6">INMDG6</option>
                                                        <option value="INGOI4">INGOI4</option>
                                                        <option value="INPAN1">INPAN1</option>
                                                        <option value="INSBI6">INSBI6</option>
                                                        <option value="INPAV1">INPAV1</option>
                                                        <option value="INBED1">INBED1</option>
                                                        <option value="INBGW1">INBGW1</option>
                                                        <option value="INKDN1">INKDN1</option>
                                                        <option value="INKVI1">INKVI1</option>
                                                        <option value="INGHA1">INGHA1</option>
                                                        <option value="INGIN6">INGIN6</option>
                                                        <option value="INDRK1">INDRK1</option>
                                                        <option value="INDHR1">INDHR1</option>
                                                        <option value="INCMB1">INCMB1</option>
                                                        <option value="INBSR1">INBSR1</option>
                                                        <option value="INBLM1">INBLM1</option>
                                                        <option value="INHZA6">INHZA6</option>
                                                        <option value="INBHD6">INBHD6</option>
                                                        <option value="INLPJ6">INLPJ6</option>
                                                        <option value="INBCO6">INBCO6</option>
                                                        <option value="INAJE6">INAJE6</option>
                                                        <option value="INJBL6">INJBL6</option>
                                                        <option value="INKDL6">INKDL6</option>
                                                        <option value="INVAL6">INVAL6</option>
                                                        <option value="INSBH1">INSBH1</option>
                                                        <option value="INSMR1">INSMR1</option>
                                                        <option value="INRJP1">INRJP1</option>
                                                        <option value="INONJ1">INONJ1</option>
                                                        <option value="INOMU1">INOMU1</option>
                                                        <option value="INNVB1">INNVB1</option>
                                                        <option value="INMTW1">INMTW1</option>
                                                        <option value="INKTW1">INKTW1</option>
                                                        <option value="INKTD1">INKTD1</option>
                                                        <option value="INUMR1">INUMR1</option>
                                                        <option value="INTNK1">INTNK1</option>
                                                        <option value="INBYT1">INBYT1</option>
                                                        <option value="INADA6">INADA6</option>
                                                        <option value="INBHU1">INBHU1</option>
                                                        <option value="INDIV1">INDIV1</option>
                                                        <option value="INIXY1">INIXY1</option>
                                                        <option value="INJBD1">INJBD1</option>
                                                        <option value="INUMB1">INUMB1</option>
                                                        <option value="INTUN1">INTUN1</option>
                                                        <option value="INTJA1">INTJA1</option>
                                                        <option value="INSIK1">INSIK1</option>
                                                        <option value="INSAL1">INSAL1</option>
                                                        <option value="INPIN1">INPIN1</option>
                                                        <option value="INPBD1">INPBD1</option>
                                                        <option value="INOKH1">INOKH1</option>
                                                        <option value="INNAV1">INNAV1</option>
                                                        <option value="INRAJ6">INRAJ6</option>
                                                        <option value="INVPI6">INVPI6</option>
                                                        <option value="INSTV6">INSTV6</option>
                                                        <option value="INIXY6">INIXY6</option>
                                                        <option value="INSAC6">INSAC6</option>
                                                        <option value="INKAP6">INKAP6</option>
                                                        <option value="INBRC6">INBRC6</option>
                                                        <option value="INAMD5">INAMD5</option>
                                                        <option value="INAMD4">INAMD4</option>
                                                        <option value="INALA1">INALA1</option>
                                                        <option value="INMDV1">INMDV1</option>
                                                        <option value="INVVA1">INVVA1</option>
                                                        <option value="INVSI1">INVSI1</option>
                                                        <option value="INVAD1">INVAD1</option>
                                                        <option value="INMUN1">INMUN1</option>
                                                        <option value="INMLI1">INMLI1</option>
                                                        <option value="INMHA1">INMHA1</option>
                                                        <option value="INMGR1">INMGR1</option>
                                                        <option value="INMDK1">INMDK1</option>
                                                        <option value="INMDA1">INMDA1</option>
                                                        <option value="INKOK1">INKOK1</option>
                                                        <option value="INJDA1">INJDA1</option>
                                                        <option value="INJAK1">INJAK1</option>
                                                        <option value="INGGA1">INGGA1</option>
                                                        <option value="INDAH1">INDAH1</option>
                                                        <option value="INBRH1">INBRH1</option>
                                                        <option value="INAKV6">INAKV6</option>
                                                        <option value="INCHN6">INCHN6</option>
                                                        <option value="INSAU6">INSAU6</option>
                                                        <option value="INUDN6">INUDN6</option>
                                                        <option value="INAJM6">INAJM6</option>
                                                        <option value="INSCH6">INSCH6</option>
                                                        <option value="INAPI6">INAPI6</option>
                                                        <option value="INGNG6">INGNG6</option>
                                                        <option value="INADG6">INADG6</option>
                                                        <option value="INADC6">INADC6</option>
                                                        <option value="INZIP6">INZIP6</option>
                                                        <option value="INGNS6">INGNS6</option>
                                                        <option value="INADM6">INADM6</option>
                                                        <option value="INADR6">INADR6</option>
                                                        <option value="INGNT6">INGNT6</option>
                                                        <option value="INBHS6">INBHS6</option>
                                                        <option value="IN VLN 6">IN VLN 6</option>
                                                        <option value="INBRS6">INBRS6</option>
                                                        <option value="IN BHC 6">IN BHC 6</option>
                                                        <option value="IN VLD 6">IN VLD 6</option>
                                                        <option value="IN HZR 6">IN HZR 6</option>
                                                        <option value="IN BRL 6">IN BRL 6</option>
                                                        <option value="IN KBC6">IN KBC6</option>
                                                        <option value="IN HZA1">IN HZA1</option>
                                                        <option value="INGNA6">INGNA6</option>
                                                        <option value="INGNC6">INGNC6</option>
                                                        <option value="INKBC6">INKBC6</option>
                                                        <option value="INGAO6">INGAO6</option>
                                                        <option value="INBDM6">INBDM6</option>
                                                        <option value="INGHR6">INGHR6</option>
                                                        <option value="INREA6">INREA6</option>
                                                        <option value="INPTL6">INPTL6</option>
                                                        <option value="INNUR6">INNUR6</option>
                                                        <option value="INPNP6">INPNP6</option>
                                                        <option value="INFBD6">INFBD6</option>
                                                        <option value="INBVC6">INBVC6</option>
                                                        <option value="IN BFR 6">IN BFR 6</option>
                                                        <option value="INCDD6">INCDD6</option>
                                                        <option value="INCDC6">INCDC6</option>
                                                        <option value="INPKR6">INPKR6</option>
                                                        <option value="INNGSB">INNGSB</option>
                                                        <option value="INSXR4">INSXR4</option>
                                                        <option value="INBBM6">INBBM6</option>
                                                        <option value="INIXW6">INIXW6</option>
                                                        <option value="INTAT6">INTAT6</option>
                                                        <option value="INBLR4">INBLR4</option>
                                                        <option value="INBLR5">INBLR5</option>
                                                        <option value="INDRU6">INDRU6</option>
                                                        <option value="INCDP1">INCDP1</option>
                                                        <option value="INPDD1">INPDD1</option>
                                                        <option value="INKRW1">INKRW1</option>
                                                        <option value="INHWR1">INHWR1</option>
                                                        <option value="INHGT1">INHGT1</option>
                                                        <option value="INBTK1">INBTK1</option>
                                                        <option value="INBKR1">INBKR1</option>
                                                        <option value="INBDR1">INBDR1</option>
                                                        <option value="INNML1">INNML1</option>
                                                        <option value="INBGQ6">INBGQ6</option>
                                                        <option value="INMAQ6">INMAQ6</option>
                                                        <option value="INUDI6">INUDI6</option>
                                                        <option value="INBNC6">INBNC6</option>
                                                        <option value="INHSP6">INHSP6</option>
                                                        <option value="INHSF6">INHSF6</option>
                                                        <option value="INHST6">INHST6</option>
                                                        <option value="INSBC6">INSBC6</option>
                                                        <option value="INBLK1">INBLK1</option>
                                                        <option value="INCOO1">INCOO1</option>
                                                        <option value="INMAL1">INMAL1</option>
                                                        <option value="INHAS6">INHAS6</option>
                                                        <option value="INWFD6">INWFD6</option>
                                                        <option value="INTRI1">INTRI1</option>
                                                        <option value="INIXE1">INIXE1</option>
                                                        <option value="INTRV4">INTRV4</option>
                                                        <option value="INANG1">INANG1</option>
                                                        <option value="INBDG1">INBDG1</option>
                                                        <option value="INKAL1">INKAL1</option>
                                                        <option value="INKSG1">INKSG1</option>
                                                        <option value="INKVL1">INKVL1</option>
                                                        <option value="INMHE1">INMHE1</option>
                                                        <option value="INPNN1">INPNN1</option>
                                                        <option value="INCCT6">INCCT6</option>
                                                        <option value="INTVC6">INTVC6</option>
                                                        <option value="INERV6">INERV6</option>
                                                        <option value="INERP6">INERP6</option>
                                                        <option value="INRKG1">INRKG1</option>
                                                        <option value="INMLP1">INMLP1</option>
                                                        <option value="INLPR1">INLPR1</option>
                                                        <option value="INKDP1">INKDP1</option>
                                                        <option value="INKND1">INKND1</option>
                                                        <option value="INCNN1">INCNN1</option>
                                                        <option value="INCOK1">INCOK1</option>
                                                        <option value="INALF1">INALF1</option>
                                                        <option value="INCOK6">INCOK6</option>
                                                        <option value="INARR6">INARR6</option>
                                                        <option value="INCCJ4">INCCJ4</option>
                                                        <option value="INMCI1">INMCI1</option>
                                                        <option value="INTEL1">INTEL1</option>
                                                        <option value="INVZJ1">INVZJ1</option>
                                                        <option value="INCOK4">INCOK4</option>
                                                        <option value="INNEE1">INNEE1</option>
                                                        <option value="INCCJ1">INCCJ1</option>
                                                        <option value="INAZK1">INAZK1</option>
                                                        <option value="INKYM6">INKYM6</option>
                                                        <option value="IN TCR 6">IN TCR 6</option>
                                                        <option value="INAGI1">INAGI1</option>
                                                        <option value="INKTI1">INKTI1</option>
                                                        <option value="INADI1">INADI1</option>
                                                        <option value="INBTR1">INBTR1</option>
                                                        <option value="INCTI1">INCTI1</option>
                                                        <option value="INKVT1">INKVT1</option>
                                                        <option value="INKDI1">INKDI1</option>
                                                        <option value="INAMI1">INAMI1</option>
                                                        <option value="INMPR6">INMPR6</option>
                                                        <option value="INKHD6">INKHD6</option>
                                                        <option value="INDHA6">INDHA6</option>
                                                        <option value="INMDD6">INMDD6</option>
                                                        <option value="INIDR4">INIDR4</option>
                                                        <option value="INGWL6">INGWL6</option>
                                                        <option value="ININD6">ININD6</option>
                                                        <option value="INIDR6">INIDR6</option>
                                                        <option value="INRTM6">INRTM6</option>
                                                        <option value="ININB6">ININB6</option>
                                                        <option value="ININI6">ININI6</option>
                                                        <option value="ININN6">ININN6</option>
                                                        <option value="ININT6">ININT6</option>
                                                        <option value="INACH1">INACH1</option>
                                                        <option value="INBOM4">INBOM4</option>
                                                        <option value="INNSA1">INNSA1</option>
                                                        <option value="INVYD1">INVYD1</option>
                                                        <option value="INVNG1">INVNG1</option>
                                                        <option value="INVSV1">INVSV1</option>
                                                        <option value="INVRD1">INVRD1</option>
                                                        <option value="INUTN1">INUTN1</option>
                                                        <option value="INULW1">INULW1</option>
                                                        <option value="INTMP1">INTMP1</option>
                                                        <option value="INTNA1">INTNA1</option>
                                                        <option value="INTHL1">INTHL1</option>
                                                        <option value="INTRP1">INTRP1</option>
                                                        <option value="INDEG1">INDEG1</option>
                                                        <option value="INDLB6">INDLB6</option>
                                                        <option value="INDTW1">INDTW1</option>
                                                        <option value="INDHN1">INDHN1</option>
                                                        <option value="INBRY1">INBRY1</option>
                                                        <option value="INBRM1">INBRM1</option>
                                                        <option value="INBSL6">INBSL6</option>
                                                        <option value="INBWN1">INBWN1</option>
                                                        <option value="INBLP1">INBLP1</option>
                                                        <option value="INKRP1">INKRP1</option>
                                                        <option value="INKIW1">INKIW1</option>
                                                        <option value="INKSH1">INKSH1</option>
                                                        <option value="INKRN1">INKRN1</option>
                                                        <option value="INKLY1">INKLY1</option>
                                                        <option value="INJTP1">INJTP1</option>
                                                        <option value="INJGD1">INJGD1</option>
                                                        <option value="INHRN1">INHRN1</option>
                                                        <option value="INDIG1">INDIG1</option>
                                                        <option value="INJNR4">INJNR4</option>
                                                        <option value="INJNR6">INJNR6</option>
                                                        <option value="INTLG6">INTLG6</option>
                                                        <option value="INMWA6">INMWA6</option>
                                                        <option value="INPVL6">INPVL6</option>
                                                        <option value="INSWD1">INSWD1</option>
                                                        <option value="INSTP1">INSTP1</option>
                                                        <option value="INRJR1">INRJR1</option>
                                                        <option value="INPRG1">INPRG1</option>
                                                        <option value="INPSH1">INPSH1</option>
                                                        <option value="INNVT1">INNVT1</option>
                                                        <option value="INNWP1">INNWP1</option>
                                                        <option value="INNDG1">INNDG1</option>
                                                        <option value="INMRD1">INMRD1</option>
                                                        <option value="INGRD6">INGRD6</option>
                                                        <option value="INGRR6">INGRR6</option>
                                                        <option value="INMRA1">INMRA1</option>
                                                        <option value="INMRJ6">INMRJ6</option>
                                                        <option value="INMNR1">INMNR1</option>
                                                        <option value="INMNW1">INMNW1</option>
                                                        <option value="INMLW1">INMLW1</option>
                                                        <option value="INKMB1">INKMB1</option>
                                                        <option value="INBSN1">INBSN1</option>
                                                        <option value="INBKT1">INBKT1</option>
                                                        <option value="INBND1">INBND1</option>
                                                        <option value="INANL1">INANL1</option>
                                                        <option value="INABG1">INABG1</option>
                                                        <option value="INBOM1">INBOM1</option>
                                                        <option value="INDHP1">INDHP1</option>
                                                        <option value="INRED1">INRED1</option>
                                                        <option value="INKHP6">INKHP6</option>
                                                        <option value="INBOM6">INBOM6</option>
                                                        <option value="INCCH6">INCCH6</option>
                                                        <option value="INWAL6">INWAL6</option>
                                                        <option value="INPMP6">INPMP6</option>
                                                        <option value="INNSK6">INNSK6</option>
                                                        <option value="INNGP6">INNGP6</option>
                                                        <option value="INMUL6">INMUL6</option>
                                                        <option value="INJAL6">INJAL6</option>
                                                        <option value="INDIG6">INDIG6</option>
                                                        <option value="INNAG4">INNAG4</option>
                                                        <option value="INPNQ4">INPNQ4</option>
                                                        <option value="INDHU1">INDHU1</option>
                                                        <option value="INRVD1">INRVD1</option>
                                                        <option value="INRTC1">INRTC1</option>
                                                        <option value="INRNR1">INRNR1</option>
                                                        <option value="INPNV6">INPNV6</option>
                                                        <option value="INDMT1">INDMT1</option>
                                                        <option value="INBAP6">INBAP6</option>
                                                        <option value="INKLM6">INKLM6</option>
                                                        <option value="INBAU6">INBAU6</option>
                                                        <option value="INBAI6">INBAI6</option>
                                                        <option value="INBAG6">INBAG6</option>
                                                        <option value="INBAM6">INBAM6</option>
                                                        <option value="IN BAT 6">IN BAT 6</option>
                                                        <option value="AIN PNQ 6">AIN PNQ 6</option>
                                                        <option value="INMUC6">INMUC6</option>
                                                        <option value="INPSI6">INPSI6</option>
                                                        <option value="INPMT6">INPMT6</option>
                                                        <option value="INPIT6">INPIT6</option>
                                                        <option value="INPEK6">INPEK6</option>
                                                        <option value="INKRM6">INKRM6</option>
                                                        <option value="INAIR6">INAIR6</option>
                                                        <option value="INVKH6">INVKH6</option>
                                                        <option value="INCHJ6">INCHJ6</option>
                                                        <option value="INDPC4">INDPC4</option>
                                                        <option value="INBNG6">INBNG6</option>
                                                        <option value="INAIG6">INAIG6</option>
                                                        <option value="INAWM6">INAWM6</option>
                                                        <option value="INDID6">INDID6</option>
                                                        <option value="INPUM6">INPUM6</option>
                                                        <option value="INKLE6">INKLE6</option>
                                                        <option value="INSTU6">INSTU6</option>
                                                        <option value="INNKI6">INNKI6</option>
                                                        <option value="INSTM6">INSTM6</option>
                                                        <option value="INPNU6">INPNU6</option>
                                                        <option value="INAWW6">INAWW6</option>
                                                        <option value="INWRR6">INWRR6</option>
                                                        <option value="INCCW6">INCCW6</option>
                                                        <option value="INTGN6">INTGN6</option>
                                                        <option value="INPUN6">INPUN6</option>
                                                        <option value="INPNE6">INPNE6</option>
                                                        <option value="INCCQ6">INCCQ6</option>
                                                        <option value="INMREB">INMREB</option>
                                                        <option value="INIMF4">INIMF4</option>
                                                        <option value="INBGMB">INBGMB</option>
                                                        <option value="INBRAB">INBRAB</option>
                                                        <option value="INSBZB">INSBZB</option>
                                                        <option value="INRGUB">INRGUB</option>
                                                        <option value="INMGHB">INMGHB</option>
                                                        <option value="INGHPB">INGHPB</option>
                                                        <option value="INDWKB">INDWKB</option>
                                                        <option value="INDLUB">INDLUB</option>
                                                        <option value="INBOLB">INBOLB</option>
                                                        <option value="INBLTB">INBLTB</option>
                                                        <option value="INCHPB">INCHPB</option>
                                                        <option value="INDMRB">INDMRB</option>
                                                        <option value="INBBP1">INBBP1</option>
                                                        <option value="INPRT1">INPRT1</option>
                                                        <option value="INBBI4">INBBI4</option>
                                                        <option value="INGPR1">INGPR1</option>
                                                        <option value="INSKD6">INSKD6</option>
                                                        <option value="INBBS6">INBBS6</option>
                                                        <option value="INCAS6">INCAS6</option>
                                                        <option value="INKRK1">INKRK1</option>
                                                        <option value="INPNY1">INPNY1</option>
                                                        <option value="INPNY6">INPNY6</option>
                                                        <option value="INLUD6">INLUD6</option>
                                                        <option value="INASR2">INASR2</option>
                                                        <option value="INATT2">INATT2</option>
                                                        <option value="INATRB">INATRB</option>
                                                        <option value="INDPR6">INDPR6</option>
                                                        <option value="INATQ4">INATQ4</option>
                                                        <option value="INJUC6">INJUC6</option>
                                                        <option value="INLDH6">INLDH6</option>
                                                        <option value="INASR6">INASR6</option>
                                                        <option value="INBTI6">INBTI6</option>
                                                        <option value="INJAI6">INJAI6</option>
                                                        <option value="INTHA6">INTHA6</option>
                                                        <option value="INMNB2">INMNB2</option>
                                                        <option value="INKKU6">INKKU6</option>
                                                        <option value="INBRN6">INBRN6</option>
                                                        <option value="INJAI5">INJAI5</option>
                                                        <option value="INJSZ6">INJSZ6</option>
                                                        <option value="INBGK6">INBGK6</option>
                                                        <option value="INBMR2">INBMR2</option>
                                                        <option value="INJAI4">INJAI4</option>
                                                        <option value="INBHL6">INBHL6</option>
                                                        <option value="INJUX6">INJUX6</option>
                                                        <option value="INUDZ6">INUDZ6</option>
                                                        <option value="INKTT6">INKTT6</option>
                                                        <option value="INBWD6">INBWD6</option>
                                                        <option value="INCHMB">INCHMB</option>
                                                        <option value="INAJJ6">INAJJ6</option>
                                                        <option value="INIXM6">INIXM6</option>
                                                        <option value="INCHE6">INCHE6</option>
                                                        <option value="INKAR6">INKAR6</option>
                                                        <option value="INIGU6">INIGU6</option>
                                                        <option value="INMAA6">INMAA6</option>
                                                        <option value="INMAA4">INMAA4</option>
                                                        <option value="INTUT1">INTUT1</option>
                                                        <option value="INTUT6">INTUT6</option>
                                                        <option value="INMAA1">INMAA1</option>
                                                        <option value="INDSK1">INDSK1</option>
                                                        <option value="INKSP1">INKSP1</option>
                                                        <option value="INPTN1">INPTN1</option>
                                                        <option value="INTPH1">INTPH1</option>
                                                        <option value="INTDE6">INTDE6</option>
                                                        <option value="INTND1">INTND1</option>
                                                        <option value="INTHO6">INTHO6</option>
                                                        <option value="INRWR1">INRWR1</option>
                                                        <option value="INPMB1">INPMB1</option>
                                                        <option value="INKKR1">INKKR1</option>
                                                        <option value="INCHL1">INCHL1</option>
                                                        <option value="INTRL6">INTRL6</option>
                                                        <option value="INILP6">INILP6</option>
                                                        <option value="INCDL1">INCDL1</option>
                                                        <option value="INNPT1">INNPT1</option>
                                                        <option value="INTYR1">INTYR1</option>
                                                        <option value="INVKM1">INVKM1</option>
                                                        <option value="INSLL6">INSLL6</option>
                                                        <option value="INTUP6">INTUP6</option>
                                                        <option value="INSXT6">INSXT6</option>
                                                        <option value="INCBE6">INCBE6</option>
                                                        <option value="INTRZ4">INTRZ4</option>
                                                        <option value="INCJB4">INCJB4</option>
                                                        <option value="INVEP1">INVEP1</option>
                                                        <option value="INRAM1">INRAM1</option>
                                                        <option value="INMDP1">INMDP1</option>
                                                        <option value="INCGI6">INCGI6</option>
                                                        <option value="INCGA6">INCGA6</option>
                                                        <option value="INCGL6">INCGL6</option>
                                                        <option value="INCJN6">INCJN6</option>
                                                        <option value="INCJS6">INCJS6</option>
                                                        <option value="INCJO6">INCJO6</option>
                                                        <option value="INCJF6">INCJF6</option>
                                                        <option value="INCBS6">INCBS6</option>
                                                        <option value="INVTC6">INVTC6</option>
                                                        <option value="INTEN6">INTEN6</option>
                                                        <option value="INTNC6">INTNC6</option>
                                                        <option value="INNNN6">INNNN6</option>
                                                        <option value="INTBM6">INTBM6</option>
                                                        <option value="INUKL6">INUKL6</option>
                                                        <option value="INPYS6">INPYS6</option>
                                                        <option value="INGDP6">INGDP6</option>
                                                        <option value="INENR1">INENR1</option>
                                                        <option value="INTVT6">INTVT6</option>
                                                        <option value="INKAT1">INKAT1</option>
                                                        <option value="INTBT6">INTBT6</option>
                                                        <option value="INCSP6">INCSP6</option>
                                                        <option value="INCJI6">INCJI6</option>
                                                        <option value="INCJD6">INCJD6</option>
                                                        <option value="INCEC6">INCEC6</option>
                                                        <option value="INCJE6">INCJE6</option>
                                                        <option value="INCJA6">INCJA6</option>
                                                        <option value="INCSV6">INCSV6</option>
                                                        <option value="INCGE6">INCGE6</option>
                                                        <option value="INCNC6">INCNC6</option>
                                                        <option value="INTBC6">INTBC6</option>
                                                        <option value="INMAS6">INMAS6</option>
                                                        <option value="INTLT6">INTLT6</option>
                                                        <option value="INTBH6">INTBH6</option>
                                                        <option value="INCBT6">INCBT6</option>
                                                        <option value="INVLR6">INVLR6</option>
                                                        <option value="INCJV6">INCJV6</option>
                                                        <option value="INMEC6">INMEC6</option>
                                                        <option value="INMDC6">INMDC6</option>
                                                        <option value="INSXE6">INSXE6</option>
                                                        <option value="INMDR6">INMDR6</option>
                                                        <option value="INCFI6">INCFI6</option>
                                                        <option value="INHSI6">INHSI6</option>
                                                        <option value="INMAE6">INMAE6</option>
                                                        <option value="INTBS6">INTBS6</option>
                                                        <option value="INAGTB">INAGTB</option>
                                                        <option value="INMHGB">INMHGB</option>
                                                        <option value="INSABB">INSABB</option>
                                                        <option value="INSMPB">INSMPB</option>
                                                        <option value="INRGBB">INRGBB</option>
                                                        <option value="INKWGB">INKWGB</option>
                                                        <option value="INDHLB">INDHLB</option>
                                                        <option value="INKELB">INKELB</option>
                                                        <option value="INBSAB">INBSAB</option>
                                                        <option value="INGAIB">INGAIB</option>
                                                        <option value="INRDT6">INRDT6</option>
                                                        <option value="INGJIB">INGJIB</option>
                                                        <option value="INJHOB">INJHOB</option>
                                                        <option value="INKTGB">INKTGB</option>
                                                        <option value="INNGRB">INNGRB</option>
                                                        <option value="INMBS6">INMBS6</option>
                                                        <option value="INLON6">INLON6</option>
                                                        <option value="INCPL6">INCPL6</option>
                                                        <option value="INBDH6">INBDH6</option>
                                                        <option value="INTTP6">INTTP6</option>
                                                        <option value="INAPL6">INAPL6</option>
                                                        <option value="INTKNB">INTKNB</option>
                                                        <option value="INSNLB">INSNLB</option>
                                                        <option value="INKWAB">INKWAB</option>
                                                        <option value="INKNU6">INKNU6</option>
                                                        <option value="INJWAB">INJWAB</option>
                                                        <option value="INSJR6">INSJR6</option>
                                                        <option value="INDLAB">INDLAB</option>
                                                        <option value="INBNYB">INBNYB</option>
                                                        <option value="INSTT6">INSTT6</option>
                                                        <option value="INAGR4">INAGR4</option>
                                                        <option value="INDER6">INDER6</option>
                                                        <option value="INMBC6">INMBC6</option>
                                                        <option value="INNDA6">INNDA6</option>
                                                        <option value="INSRE6">INSRE6</option>
                                                        <option value="INMTC6">INMTC6</option>
                                                        <option value="INMBD6">INMBD6</option>
                                                        <option value="INCPC6">INCPC6</option>
                                                        <option value="INBSB6">INBSB6</option>
                                                        <option value="INBLJ6">INBLJ6</option>
                                                        <option value="INVNS4">INVNS4</option>
                                                        <option value="INPNK6">INPNK6</option>
                                                        <option value="INBEK4">INBEK4</option>
                                                        <option value="INLKO4">INLKO4</option>
                                                        <option value="INKNU4">INKNU4</option>
                                                        <option value="IN BUL 6">IN BUL 6</option>
                                                        <option value="IN ALP 6">IN ALP 6</option>
                                                        <option value="IN NOI6">IN NOI6</option>
                                                        <option value="INCCU4">INCCU4</option>
                                                        <option value="INGTZB">INGTZB</option>
                                                        <option value="INHLIB">INHLIB</option>
                                                        <option value="INJIGB">INJIGB</option>
                                                        <option value="INSNG2">INSNG2</option>
                                                        <option value="INRNG2">INRNG2</option>
                                                        <option value="INRDP2">INRDP2</option>
                                                        <option value="INPTPB">INPTPB</option>
                                                        <option value="INPNTB">INPNTB</option>
                                                        <option value="INNKNB">INNKNB</option>
                                                        <option value="INLGLB">INLGLB</option>
                                                        <option value="INMHDB">INMHDB</option>
                                                        <option value="INJPGB">INJPGB</option>
                                                        <option value="INDUR6">INDUR6</option>
                                                        <option value="INTNGB">INTNGB</option>
                                                        <option value="INTTSB">INTTSB</option>
                                                        <option value="INSKPB">INSKPB</option>
                                                        <option value="INSTIB">INSTIB</option>
                                                        <option value="INHGLB">INHGLB</option>
                                                        <option value="INGJXB">INGJXB</option>
                                                        <option value="INGED2">INGED2</option>
                                                        <option value="INPTP8">INPTP8</option>
                                                        <option value="INCBDB">INCBDB</option>
                                                        <option value="INFBRB">INFBRB</option>
                                                        <option value="INCCU1">INCCU1</option>
                                                        <option value="INHAL1">INHAL1</option>
                                                        <option value="INSLT6">INSLT6</option>
                                                        <option value="INFLT6">INFLT6</option>
                                                        <option value="INIXB4">INIXB4</option>
                                                        <option value="INBNT6">INBNT6</option>
                                                        <option value="INBXR6">INBXR6</option>
                                                        <option value="INBNX6">INBNX6</option>
                                                        <option value="INBNK6">INBNK6</option>
                                                        <option value="INBNW6">INBNW6</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Supply Type</label>
                                                <select id="supplytype" data-placeholder="Select Supply Type" name="supplytype" class="form-control  chosen-select-deselect" required="required">
                                                    <option></option>
                                                    <option value="1"> Inter State </option>
                                                    <option value="2"> Intra State </option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Expense Bill Type</label>
                                                <select id="billtype" data-placeholder="Expense Bill Type" name="billtype" class="form-control chosen-select-deselect" required="required">
                                                    <option> </option>                                                   
                                                    <option value="1"> Regular B2B </option>
                                                    <option value=""> Deemed Export</option>
                                                    <option value=""> Special Economic Zone (SEZ) Supply With Pay</option>
                                                    <option value=""> Special Economic Zone (SEZ) Supply Without  Pay</option>
                                                    <option value="">Exempt</option>
                                                    <option value="">Nill rated</option>
                                                    <option value="">Non Gst</option>
                                                     <option value="">Bill of entry (Emport)</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Expense Bill Head</label>
                                                <select id="expensebillhead" data-placeholder="Select Bill Head" name="expensebillhead" class="form-control  chosen-select-deselect" required="required">
                                                    <option></option>
                                                    <option value="1"> Input Goods </option>
                                                    <option value="2"> Input Services </option>
                                                    <option value="3">Capital Goods</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 text-center">
                                            <div class="form-group">
                                                <div class="form-group p-t-25">
                                                    <input type="checkbox" id="reversecharge">
                                                    <label class="control-label">Reversed Charge</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="p-t-20">
                                        <div class="ltzgst-table-container">


                                        </div>

                                        <table id="potable" class="table table-bordered dt-responsive dataTable no-footer dtr-inline ltz-table" width="100%" cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th class="w-1">Sr.no</th>
                                                    <th class="w-2">Items</th>
                                                    <th class="w-2">Description</th>
                                                    <th class="w-3">Price</th>
                                                    <th class="w-4">Qty / Unit</th>
                                                    <th class="w-4">Amount</th>
                                                    <th class="w-4">Tax</th>
                                                    <th class="w-4">GST</th>
                                                    <th class="w-3">Purchase Type</th>
                                                    <th class="w-1"></th>


                                                </tr>
                                            </thead>
                                            <tbody  id="tblItemDetails">
                                                <tr  class="data-wrapper">
                                                    <td>1</td>
                                                    <td>

                                                        <select id="additems_1" name="additems_1" data-placeholder="Select items" class="form-control additems chosen-select-deselect userItemDetails" required="required">                                               
                                                                <option></option>
                                                                <option value="addnewitem" class="addnewtxt">Add new item</option>
                                                         </select>


                                                    </td>
                                                    <td><textarea class="form-control" id="desc_1"></textarea></td>
                                                    <td><input type="text" class="form-control calculate ignore" id="price_1" data-rule-required="true" name="price_1" onkeypress="return isNumberKey(event)"  /></td>
                                                    <td><input type="text" class="form-control product-qty calculate ignore" id="unt_1"  data-rule-required="true" name="unt_1" onkeypress="return isNumberKey(event)" /><span id="unit_1">Kg</span></td>
                                                   

                                                    <td><input type="text" class="form-control amtdetails calculate" disabled id="Amount_1"></td>
                                                    <td>
                                                        <select id="tax_1" name="tax" data-placeholder="Select tax" class="form-control chosen-select-deselect calculate ignore" required="required">                                                
                                                                <option></option>
                                                                <option>NA</option>
                                                                <option value="0"> 0 </option>
                                                                <option value="3"> 3% </option>
                                                                <option value="5">5%</option>
                                                                <option value="12">12%</option>
                                                                <option value="18">18%</option>
                                                                <option value="28">28%</option>
                                                            </select>
                                                    </td>
                                                    <td>
                                                        <div id="taxseperation_1">
                                                            <div class="gsttax-txt cgst-sep" style="display:none;"><span>CGST@</span><span class="cgst">0</span>%<span> : <i>&#8377;</i><span class="cgstAmt"> 0</span></span></div>
                                                            <div class="gsttax-txt sgst-sep" style="display:none;"><span>SGST@</span><span class="sgst">0</span>%<span> : <i>&#8377;</i><span class="sgstAmt"> 0</span></span></div>
                                                            <div class="gsttax-txt igst-sep" style="display:none;"><span>IGST@</span><span class="igst">0</span>%<span> : <i>&#8377;</i><span class="igstAmt"> 0</span></span></div>
                                                            <div class="gsttax-txt utgst-sep" style="display:none;"><span>UTGST@</span><span class="utgst">0</span>%<span> : <i>&#8377;</i><span class="utgstAmt"> 0</span></span></div>
                                                        </div>

                                                    </td>
                                                    <td>
                                                        <select data-placeholder="Purchase type & tax" class="form-control chosen-select-deselect" required="required" id="purchase_1">
                                                                  <option></option>
                                                            <optgroup label="Input Good">
                                                                <option> Business Purpose (T4) </option>
                                                                <option> Non-Business Purpose (T1) </option>
                                                                <option>Sale of Exempted supply (T2)</option>
                                                                <option>Restricted Products (T3)</option>
                                                                <option>Common/Other (C2)</option>
                                                            </optgroup>
                                                            <optgroup label="Input Service">
                                                                <option> Business Purpose (T4) </option>
                                                                <option> Non-Business Purpose (T1) </option>
                                                                <option>Sale of Exempted supply (T2)</option>
                                                                <option>Restricted Products (T3)</option>
                                                                <option>Common/Other (C2)</option>
                                                            </optgroup>
                                                            <optgroup label="Capital Good">
                                                                <option> Business Purpose (T4) </option>
                                                                <option> Non-Business Purpose (T1) </option>
                                                                <option>Sale of Exempted supply (T2)</option>
                                                                <option>Restricted Products (T3)</option>
                                                                <option>Common/Other (C2)</option>
                                                            </optgroup>                                                                
                                                            </select>
                                                    </td>
                                                    <td>
                                                        <input type='button' class='add' value='' title="Add More Items" id="add_1" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="p-t15">
                                        <div class="row">
                                            <div class="col-md-4 col-sm-12 col-xs-12">
                                                <label class="control-label">Notes</label>
                                                <textarea class="form-control" id="TA_notes">                                                        
                                                    </textarea>
                                            </div>
                                            <div class="col-md-4 col-sm-12 col-xs-12" style="visibility:hidden">
                                                <div class="form-group">
                                                    <label class="control-label">Attachment</label>
                                                    <input type="file" class="filestyle" data-icon="false" id="companylogo" name="companylogo">
                                                </div>
                                            </div>

                                            <div class="col-md-4 col-sm-12 col-xs-12">
                                                <div class="total-container">
                                                    <div class="col-md-5 col-sm-4 col-xs-4 net-total">
                                                        <p class="control-label">Sub Total :</p>
                                                        <p class="control-label">Total CGST:</p>
                                                        <p class="control-label">Total SGST:</p>
                                                        <p class="control-label">Total IGST:</p>
                                                        <p class="control-label">Total UTGST:</p>
                                                        <p class="control-label p-t-5">Freight &amp; Packaging:</p>
                                                        <p class="control-label p-t-5">Labour Charge:</p>
                                                        <p class="control-label p-t-5"> Insurance Amt:</p>
                                                        <p class="control-label p-t-5"> Other Charges:</p>
                                                        <p class="control-label p-t-10">Discount :</p>
                                                        <%--<p class="control-label p-t-5">CESS :</p>--%>
                                                        <p class="control-label p-t-5">Round of &nbsp;
                                                            <input type="checkbox"> :</p>
                                                        <p class="control-label payable-text">Gross Total : </p>
                                                        <p class="control-label payable-text">Amount In Word : </p>
                                                    </div>
                                                    <div class="col-md-7 col-sm-4 col-xs-4 net-total no-gutter">
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalamt">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalcgst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalsgst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totaligst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalugst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="freight" value="0" class="discount-txt"></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="labourCharge" value="0" class="discount-txt"></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="InsuranceAmt" value="0" class="discount-txt"></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="otherCharges" value="0" class="discount-txt"></p>
                                                        <p>
                                                            &nbsp;&nbsp;&nbsp; <input type="text" id="disount" value="0" class="discount-txt"><label>%</label>
                                                        </p>
                                                       <%-- <p>&nbsp;&nbsp;&nbsp; <input type="text" id="cess" value="" class="discount-txt"></p>--%>
                                                        <%-- <p>
                                                            <select id="invoicetds" data-placeholder="Select TDS" name="invoicetds" class="chosen-select select-tds">
                                                                    <option></option>                                                               
                                                                </select>
                                                            <span id="tds-description" class="tdstxt">Interest other than Interest on Securities</span>
                                                        </p>--%>

                                                        <p>
                                                            <span class="icon ico-rupees ico-3x"></span> <span id="roundamt">0</span>
                                                        </p>
                                                        <p class="payable-text"><span class="icon ico-rupees ico-3x"></span> <span id="nettotal">0</span></p>
                                                        <p class="payable-text"><span ></span> <span id="AmtWords"></span></p>
                                                    </div>
                                                </div>
                                            </div>

                                            <%--<div class="col-md-4 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div class="col-md-4 col-sm-4 col-xs-4 net-total">
                                                        <p class="control-label">Total :</p>

                                                        <p class="control-label">Discount :</p>
                                                        <p class="control-label">TDS :</p>
                                                        <p>&nbsp;</p>
                                                        <p class="control-label">Round of &nbsp;<input type="checkbox" id="chkRound"> :</p>
                                                        <p class="control-label payable-text">Net Total : </p>
                                                    </div>
                                                    <div class="col-md-8 col-sm-4 col-xs-4 net-total">
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalamt"> </span></p>

                                                        <p><input type="text" id="disount" value="0"> <span> %</span></p>
                                                        <p>
                                                            <select id="TdsOption" data-placeholder="Select TDS" name="purchaseorderto" class="chosen-select-deselect select-tds calculate">
                                                                <option></option>                                                             
                                                            </select>
                                                            <span id="tds-description" class="tdstxt">Interest other than Interest on Securities</span>
                                                        </p>
                                                        <p class="m-t-28">
                                                            <span class="icon ico-rupees ico-3x"></span> <span id="roundamt"> </span>
                                                        </p>
                                                        <p class="payable-text"><span class="icon ico-rupees ico-3x"></span> <span id="nettotal"> 199.50</span></p>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uCountry" runat="server" Value="0" />         
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
                                </form>
                            </div>

                        </div>
                    </div>
                </div>
           <%-- </div>--%>
        <input type="hidden" id="hdnRowId" value="1" />
        <input type="hidden" id="hdnPurchaseId" value="" />
        <input type="hidden" id="hdnVendorId" value="" />

        <!-------------all modals starts here-------------->
    <!--add new vendor start-->
    <div class="modal fade " id="poorderto" tabindex="-1" role="dialog" style="display: none;">
        <form id="vendordetails">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="addVendor">Add Vendor</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-12">

                                <div class="form-group">
                                    <label class="control-label">Vendor / Company Name</label> &nbsp;  <span id="err_companyname"></span>
                                    <input type="text" class="form-control" id="companyname" name="companyname" placeholder="Vendor / Company Name">
                                </div>
                                <div class="form-group">
                                    <label class="control-label required">Contact Number</label>  &nbsp;  <span id="err_contactno"></span>
                                    <input type="text" class="form-control" id="contactno" name="contactno" placeholder="Contact Numbar" required="required">
                                </div>
                                <div class="form-group">
                                    <label class="control-label required">Email</label> &nbsp;  <span id="err_profileemail"></span>
                                    <input type="email" class="form-control" id="profileemail" name="profileemail" placeholder="Email" required="required">
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <label class="control-label">City</label> &nbsp;  <span id="err_city"></span>
                                        <input type="text" class="form-control" id="city" name="city" placeholder="City">
                                    </div>
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <label class="control-label">State</label> &nbsp;  <span id="stateErr"></span>
                                        <select id="state" name="state"  data-placeholder="Select State" class="form-control chosen-select-deselect" required="required">                                                
                                                    <option></option>
                                                    <option value="Andaman and Nicobar Islands">Andaman and Nicobar Islands</option>
                                                    <option value="Andhra Pradesh">Andhra Pradesh</option>
                                                    <option value="Arunachal Pradesh">Arunachal Pradesh</option>
                                                    <option value="Assam">Assam</option>
                                                    <option value="Bihar">Bihar</option>
                                                    <option value="Chandigarh">Chandigarh</option>
                                                    <option value="Chhattisgarh">Chhattisgarh</option>
                                                    <option value="Dadra and Nagar Haveli">Dadra and Nagar Haveli</option>
                                                    <option value="Daman and Diu">Daman and Diu</option>
                                                    <option value="Delhi">Delhi</option>
                                                    <option value="Goa">Goa</option>
                                                    <option value="Gujarat">Gujarat</option>
                                                    <option value="Haryana">Haryana</option>
                                                    <option value="Himachal Pradesh">Himachal Pradesh</option>
                                                    <option value="Jammu and Kashmir">Jammu and Kashmir</option>
                                                    <option value="Jharkhand">Jharkhand</option>
                                                    <option value="Karnataka">Karnataka</option>
                                                    <option value="Kerala">Kerala</option>
                                                    <option value="Lakshadweep">Lakshadweep</option>
                                                    <option value="Madhya Pradesh">Madhya Pradesh</option>
                                                    <option value="Maharashtra">Maharashtra</option>
                                                    <option value="Manipur">Manipur</option>
                                                    <option value="Meghalaya">Meghalaya</option>
                                                    <option value="Mizoram">Mizoram</option>
                                                    <option value="Nagaland">Nagaland</option>
                                                    <option value="Orissa">Orissa</option>
                                                    <option value="Puducherry">Puducherry</option>
                                                    <option value="Punjab">Punjab</option>
                                                    <option value="Rajasthan">Rajasthan</option>
                                                    <option value="Sikkim">Sikkim</option>
                                                    <option value="Tamil Nadu">Tamil Nadu</option>
                                                    <option value="Tripura">Tripura</option>
                                                    <option value="Uttaranchal">Uttaranchal</option>
                                                    <option value="Uttar Pradesh">Uttar Pradesh</option>
                                                    <option value="West Bengal">West Bengal</option>
                                                </select>
                                    </div>
                                </div>


                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label">Contact Person</label> &nbsp; <span id="err_ContactPerson"></span>
                                    <input type="text" class="form-control" id="ContactPerson" name="ContactPerson" placeholder="Contact Person">
                                </div>
                                <div class="form-group address-group">
                                    <label class="control-label">Address</label> &nbsp;  <span id="err_address1"></span>
                                    <input type="text" class="form-control" id="address1" name="address1" placeholder="Address line 1">
                                    <input type="text" class="form-control" id="address2" name="address2" placeholder="Address line 2">
                                    <input type="text" class="form-control" id="address3" name="address3" placeholder="Address line 3">
                                </div>
                                <div class="row">

                                </div>
                                <div class="row">
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <label class="control-label required">Pin</label> &nbsp;  <span id="err_pin"></span>
                                        <input type="text" class="form-control" id="pin" name="pin" placeholder="Pin" required="required">
                                    </div>
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <label class="control-label">Country</label>
                                        <input type="text" class="form-control" id="country" name="country"  value="India" readonly="readonly" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label required">PAN Number</label>
                                    <input type="text" class="form-control" id="panno" name="panno" placeholder="Pan Number" required="required">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">TAN</label>
                                    <input type="text" class="form-control" id="tan" name="tan" placeholder="Tan Number">
                                </div>
                                <div class="form-group hidemember" style="display:none">
                                    <label class="control-label required">CA Membership ID</label>
                                    <input type="text" class="form-control" id="camembership" name="camembership" placeholder="CA Membership Number" required="required">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">Service Tax</label>
                                    <input type="text" class="form-control" id="servicetax" name="servicetax" placeholder="Service Number">
                                </div>

                                <div class="form-group hideme">
                                    <label class="control-label">Bank  Account Number </label>
                                    <input type="text" class="form-control" id="acctNumber" name="bankacno" placeholder="Bank Account Number">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">Bank  Account Name </label>
                                    <input type="text" class="form-control" id="bankacname" name="bankacname" placeholder="Bank  Account Name">
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12 col-xs-12">

                                <div class="form-group">
                                    <label class="control-label required">GSTN</label>
                                    <input type="text" class="form-control" id="gstnno" name="gstnno" placeholder="Gst Number" required="required">
                                </div>
                                <div class="form-group hideadhaar" style="display:none">
                                    <label class="control-label required">Adhaar Number</label>
                                    <input type="text" class="form-control" id="adhaar" name="adhaar" placeholder="Adhaar Number" required="required">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">CIN</label>
                                    <input type="text" class="form-control" id="cin" name="cin" placeholder="Cin Number">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">VAT / TIN </label>
                                    <input type="text" class="form-control" id="vattin" name="vattin" placeholder="Vat / Tin Number">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">IFSC</label>
                                    <input type="text" class="form-control" id="ifsc" name="ifsc" placeholder="IFSC">
                                </div>
                                <div class="form-group hideme">
                                    <input type="checkbox"> Reverse Charge
                                    <input type="checkbox"> Composition Vendor
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="saveVendor">Save changes</button>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <!--add new vendor end -->
    <!-----add new expense type start -->
    <div class="modal fade " id="newexpenses" tabindex="-1" role="dialog" style="display: none;">
        <form id="expenseDetails">
            <div class="modal-dialog bs-example-modal-md" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="addExpense">Add Expense</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Expense Name</label>&nbsp; <span id="err_newexpense"></span>
                                    <input type="text" class="form-control" id="newexpense" name="newexpense" placeholder="Expense Name"  required="required" >
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary"  id="saveExpense">Save changes</button>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <!-----add new expense type end-->

    <!-----add new payment terms start -->
    <div class="modal fade itemsadd" id="" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog bs-example-modal-md" role="document">
            <form id="frm_additem">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="addItem">Add Item</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Item Name</label>&nbsp; <span id="err_txtItemName"></span>
                                    <input type="text" class="form-control" id="txtItemName" name="txtItemName" placeholder="Item Name" required="required">
                                </div>
                                <div class="form-group">
                                    <label class="control-label">HSN / SAC Code</label> &nbsp;<span id="err_txt_hsnhsc"></span>
                                    <input type="text" class="form-control" id="txt_hsnhsc" name="txt_hsnhsc" placeholder="HSN / SAC Code">

                                    <button class="btn link-btn" data-toggle="modal" href="#codesmodal">Find HSN / SAC Codes</button>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Price</label> &nbsp;<span id="err_txtprice"></span>
                                    <input type="text" class="form-control" id="txtprice" name="txtprice" placeholder="Price" required="required">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Tax</label>  &nbsp;<span id="err_taxdetails"></span>
                                    <select id="taxdetails" data-placeholder="Select Tax" name="taxdetails" class="form-control chosen-select-deselect" required="required">                                                
                                        <option></option>
                                        <option>NA</option>
                                        <option value="0"> 0 </option>
                                        <option value="3"> 3% </option>
                                        <option value="5">5%</option>
                                        <option value="12">12%</option>
                                        <option value="18">18%</option>
                                        <option value="28">28%</option>
                                    </select>
                                </div>

                                <div class="form-group">
                                    <label class="control-label">Measure units</label> &nbsp;<span id="err_dd_Unit"></span>
                                    <select id="dd_Unit" name="dd_Unit" data-placeholder="Select Unit"  class="form-control chosen-select-deselect" required="required">                                                
                                        <option></option>
                                        <option>NA</option>
                                        <option value="KG"> KG </option>
                                        <option value="Box"> Box</option>
                                        <option value="Bundle">Bundle</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Description</label>
                                    <textarea class="form-control"></textarea>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="btnSaveItem">Save changes</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-----add new payment terms end-->
    <!-----add new payment terms start -->
    <!--<div class="modal fade itemsadd" id="codesmodal" tabindex="-1" role="dialog" style="display: none;">-->
    <div id="codesmodal" class="modal fade" tabindex="-1" data-focus-on="input:first" style="display: none;">
        <div class="modal-dialog bs-example-modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="HsnHsc">Find HSN / SAC Codes</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
                </div>
                <div class="modal-body">
                    <form id="sethsncode">
                        <div class="row">
                            <div class=" col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label">Select </label>
                                    <select id="crrole" name="crrole" class="form-control" required="required">                                                
                                                <option value="-1">--Select--</option>
                                                <option value="hsn"> Goods </option>
                                                <option value="hsc"> Services</option>
                                            </select>
                                </div>
                            </div>
                            <div class="col-md-8 col-sm-12 col-xs-12">
                                <label>Search HSN / SAC code</label>
                                <div id="imaginary_container">
                                    <div class="input-group stylish-input-group">
                                        <input type="text" class="form-control" placeholder="HSN Code (e.g. 1011090) or keywords (e.g. Manufactures )" id="txtSearch">
                                        <span class="input-group-addon">
                                            <button type="button" id="search">
                                                <span class="glyphicon glyphicon-search"></span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="codes-container">
                                    <div class="codes" id="userCodes">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="btnSaveHsnCode">Save changes</button>
                </div>
            </div>
        </div>        
    </div>
    <!-----add new payment terms end-->
    
    <script type="text/javascript" src="../../js/jsrender.js"></script>  
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/charts.js"></script>
    <script type="text/javascript" src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../js/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/pobills.js"></script>
    <script type="text/javascript" src="../js/custom.js"></script>

    <script id="tblBilldetailsList" type="text/x-jsrender">
        <tr id="{{:BillId}}">
            <td></td>
            <td>{{:VendorName}}</td>
            <td>{{:RefId}}</td>
            <td>{{:BillDate}}</td>
            <td><span class="icon ico-rupees ico-3x"></span> {{:TotalAmount}}</td>
            <td>{{:ExpenseType}}</td>
            <td>{{:PaymentMethod}}</td>
            <td>{{:Status}}</td>
            <td>
               <%-- <a class="actions-btn" id="viewuser_{{:BillId}}" title="View"><span class="icon ico-view ico-2x"></span></a>--%>
                <a class="actions-btn edit" id="edituser_{{:BillId}}" title="Edit"><span class="icon ico-edit ico-2x"></span></a>
                <a class="actions-btn delete" id="deleteuser_{{:BillId}}" title="Delete"><span class="icon ico-delete ico-2x"></span></a>


            </td>
        </tr>
    </script>
    <script id="tblVendorDropdown" type="text/x-jsrender">
        <option value="{{:Id}}" state="{{:State}}"> {{:VendorName}} </option>
    </script>
    <script id="tblTdsDropdown" type="text/x-jsrender">
        <option value="{{:TdsRate}}" desc="{{:TdsDescription}}"> {{:TdsRate}}%  ({{:TdsSection}}) </option>
    </script>
    <script id="tblexpenseDropdown" type="text/x-jsrender">
        <option value="{{:Id}}"> {{:ExpenseType}} </option>
    </script>
    <script id="tblItemsDropdown" type="text/x-jsrender">
        <option value="{{:Id}}" HsnCodeId="{{:HsnCodeId}}" ItemDescription="{{:ItemDescription}}" Price="{{:Price}}" Tax="{{:Tax}}" UnitOfMeasures="{{:UnitOfMeasures}}"> {{:ItemName}} </option>
    </script>
    <script id="userHsn" type="text/x-jsrender">
        <div class="checkbox">
            <label><input type="radio" id="hsn_{{:HsnCodeId}}" rate="{{:HsnRate}}" name="rd_HSNHSC" code="{{:HsnCode}}"><span>{{:HsnCode}}</span></label>
            <label><span>{{:HsnDetail}}</span></label>
        </div>
    </script>
    <script id="userHsc" type="text/x-jsrender">
        <div class="checkbox">
            <label><input type="radio" id="hsc_{{:HsnCodeId}}" rate="{{:HsnRate}}" name="rd_HSNHSC" code="{{:HsnCode}}"><span>{{:HsnCode}}</span></label>
            <label><span>{{:HsnDetail}}</span></label>
        </div>
    </script>

</asp:Content>
