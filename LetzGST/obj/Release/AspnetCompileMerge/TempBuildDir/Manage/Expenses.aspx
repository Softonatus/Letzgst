<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="Expenses.aspx.cs" Inherits="LetzGST.Manage.Expenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div id="page-content-wrapper">--%>

                <div class="box clearfix">

                    <div class="box-header with-border">
                        <h3 class="box-title">Expenses Management</h3>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-2 col-md-offset-2">
                                <a href="PurchaseOrder.aspx">
                                    <div class="box-container">
                                        Purchase Order
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a href="Bills.aspx">
                                    <div class="box-container">
                                        Purchase Order bIlls
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a href="#">
                                    <div class="box-container">
                                        Recurring Bills
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a href="#">
                                    <div class="box-container">
                                        Internal Expenses
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

        <%--    </div>--%>
    
    <script src="https://npmcdn.com/tether@1.2.4/dist/js/tether.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var $target = $('#sidebar-wrapper'); viewuser_
            $target.find("ul li ul").each(function () {
                $(this).removeClass("show");
            });
            $target.find("ul li a").each(function () {
                if ($(this).hasClass("active")) {
                    $(this).removeClass("active");
                }
                $("#managemenus").addClass("show");
                $("#expense").addClass("active");
            });
        });
    </script>
</asp:Content>
