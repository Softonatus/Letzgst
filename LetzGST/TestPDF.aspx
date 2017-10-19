<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPDF.aspx.cs" Inherits="LetzGST.TestPDF" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/pdf.css" rel="stylesheet" />
</head>
<body style="width: 210mm; height: 296mm;">
    <form id="form1" runat="server">
    <section style="padding:6mm">
        <div style="border: solid 1px #666; height: auto; overflow: hidden;">
            <div style="text-align: center;border-bottom: solid 1px #666;background-color: #dadada;height: 30px;font-size: 16px;">
                Tax Invoice
            </div>
            <div style="height: 124px; border-bottom:solid 1px #666;">
                <div style="width: 50%; padding: 10px 10px 10px 10px; float: left;">
                    <p>Softonauts Infotech Pvt.Ltd</p>
                    <p>Nathyog Plot no 2/3, Yashdeep Chs,</p>
                    <p>Nr Thackery Garden, Beliwali, Badlapur(w)</p>
                    <p>Pin:421503, Maharashtra, India</p>
                </div>
                <div style="width: 44%; padding: 10px 10px 10px 10px;float: left; border-left:solid 1px #666;">
                    <p><strong>GSTN:</strong></p>
                    <p><strong>PAN:</strong></p>
                    <p><strong>Contact Name & No:</strong></p>
                    <p><strong>Email:</strong></p>
                    <p><strong>Web:</strong></p>
                </div>
            </div>
            <div style="height: auto; border-bottom:solid 1px #666; overflow: hidden;">
                <div style="width: 50%; padding: 10px 10px 10px 10px; float: left;">
                    <p><strong>Invoice No:</strong><span></span></p>
                    <p><strong>Invoice Date:</strong><span></span></p>
                    <p><strong>Due Date:</strong><span></span></p>
                    <p><strong>Tax Is payable On reverse Charge:(Yes/No):</strong><span></span></p>

                </div>
                <div style="width: 44%; padding: 10px 10px 10px 10px; float: left; border-left:solid 1px #666;">
                    <p><strong>Transpotation Mode:</strong><span></span></p>
                    <p><strong>Veh No :</strong><span></span></p>
                    <p><strong>Date & Time of Supply :</strong><span></span></p>
                    <p><strong>Place of Supply :</strong><span></span></p>
                </div>
            </div>
            <div style="height: auto; border-bottom:solid 1px #666; overflow: hidden;">
                <div style="width: 50%; padding: 10px 10px 10px 10px; float: left;">
                    <strong>Details of Receiver (Billed to)</strong>
                    <p><strong>Name:</strong><span></span></p>
                    <p><strong>Address:</strong><span></span></p>
                    <p><strong>GSTN:</strong><span></span></p>
                </div>
                <div style="width: 44%; padding: 10px 10px 10px 10px; float: left; border-left:solid 1px #666;">
                    <strong>Details of Receiver (Billed to)</strong>
                    <p><strong>Name:</strong><span></span></p>
                    <p><strong>Address:</strong><span></span></p>
                    <p><strong>GSTN:</strong><span></span></p>
                </div>
            </div>
            <div style="height: auto;padding: 6px 2px 0 2px; overflow: hidden;">
                <table width="100%" cellpadding='0' cellspacing='0' border='0' class='pdftbl'>
                    <tr>
                        <th colspan="1" rowspan="2">#</th>
                        <th colspan="1" rowspan="2" class="text-left">Items (HSN /SAC) </th>
                        <th colspan="1" rowspan="2" class="text-left">Qty</th>
                        <th colspan="1" rowspan="2">Unit</th>
                        <th colspan="1" rowspan="2">Rate</th>
                        <th colspan="1" rowspan="2">Discount</th>
                        <th colspan="2" rowspan="1">CGST</th>
                        <th colspan="2" rowspan="1">SGST</th>
                        <th colspan="2" rowspan="1">IGST</th>
                        <th colspan="2" rowspan="1">UTGST</th>
                        <th colspan="2" rowspan="1">CESS</th>
                        <th colspan="1" rowspan="2">Amout</th>
                    </tr>
                    <tr>
                        <th colspan="1" rowspan="1">Rate (%)</th>
                        <th colspan="1" rowspan="1">Amt (Rs)</th>
                        <th colspan="1" rowspan="1">Rate (%)</th>
                        <th colspan="1" rowspan="1">Amt (Rs)</th>
                        <th colspan="1" rowspan="1">Rate (%)</th>
                        <th colspan="1" rowspan="1">Amt (Rs)</th>
                        <th colspan="1" rowspan="1">Rate (%)</th>
                        <th colspan="1" rowspan="1">Amt (Rs)</th>
                        <th colspan="1" rowspan="1">Rate (%)</th>
                        <th colspan="1" rowspan="1">Amt (Rs)</th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Live Fish (10256)</td>
                        <td>100</td>
                        <td>2</td>
                        <td>500</td>
                        <td>NA</td>
                        <td>3%</td>
                        <td>30</td>
                        <td>3%</td>
                        <td>30</td>
                        <td>3%</td>
                        <td>30</td>
                        <td>3%</td>
                        <td>30</td>
                        <td>3%</td>
                        <td>30</td>
                        <td>1000</td>
                    </tr>
                    <tr class="footer">
                        <td colspan="5"></td>
                        <td>Total</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>

                </table>
            </div>
            <div style="height: auto; border-bottom:solid 1px #666; overflow: hidden;">
                <div style="width: 50%; padding: 10px 10px 10px 5px; float: right; border-left:solid 1px #666;">
                    <p><strong>Freight & Packaging:</strong><span></span></p>
                    <p><strong>Labour Charges:</strong><span></span></p>
                    <p><strong>Insurance Amt:</strong><span></span></p>
                    <p><strong>Other Charges:</strong><span></span></p>
                    <p><strong>Discount :</strong><span></span></p>
                    <p><strong>Net Total:</strong><span></span></p>
                </div>
            </div>
            <div style="height: auto; border-bottom:solid 1px #666; overflow: hidden; padding: 10px 10px 10px 10px;">
                <strong>Net Total (in words) : </strong><span></span>
            </div>
            <div style="height: auto; border-bottom:solid 1px #666; overflow: hidden;">
                <div style="width: 50%; padding: 10px 10px 10px 10px; float: left;">                  
                    <p><strong>Particulars given above are true or correct</strong></p>
                    <p><span></span></p>
                </div>
                <div style="width: 44%; padding: 10px 10px 10px 10px; float: left; border-left:solid 1px #666;">                   
                    <p><strong>Electronic Referance Number</strong></p>
                    <p><span></span></p>
                </div>
            </div>
            <div style="height: 100px; border-bottom:solid 1px #666; overflow: hidden;">
                <div style="width: 50%; min-height: 100px; padding: 10px 10px 10px 10px; float: left;">                  
                    <p><strong>Terms & Conditions</strong></p>
                    <p><span></span></p>
                </div>
                <div style="width: 44%; min-height: 100px; padding: 10px 10px 10px 10px; float: left; border-left:solid 1px #666;">                   
                    <p><strong>Bank details</strong></p>
                    <p><span></span></p>
                </div>
            </div>
            <div style="height: auto; overflow: hidden;">
                <div style="width: 50%; padding: 10px 10px 10px 10px; float: left;">                  
                    <p><strong>Receiver's Sign</strong></p>
                    <p><span></span></p>
                </div>
                <div style="width: 44%; padding: 10px 10px 10px 10px; float: left; border-left:solid 1px #666;">                   
                    <p><strong>Authorised Signatory</strong></p>
                    <p>Name:</p>
                    <p>Designation:</p>
                </div>
            </div>
        </div>
    </section>
        <asp:Button ID="btnExport" runat="server" Text="Export" onclick="btnExport_Click" />
       <%-- <asp:Button ID="btn_PDFEmail" runat="server" Text="Convert HTML to PDF and Send Email with Attachment" OnClick="btn_PDFEmail_Click" />--%>
    
    </form>
</body>
</html>
