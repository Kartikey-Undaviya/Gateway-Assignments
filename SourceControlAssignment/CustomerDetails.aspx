<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerDetails.aspx.vb" Inherits="SourceControlAssignment.StudentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .auto-style1 {
            width: 113%;
            margin-left: 200px;
        }
        .auto-style3 {
            width: 1200px;
            text-align: center;
            height: 16px;
        }
        .auto-style4 {
            width: 1200px;
            height: 31px;
            text-align: right;
        }
        .auto-style5 {
            height: 31px;
            width: 2741px;
        }
        .auto-style6 {
            text-align: center;
        }
        .auto-style7 {
            width: 1200px;
            text-align: right;
            font-size: large;
        }
        .auto-style8 {
            text-align: left;
            width: 2741px;
        }
        .auto-style9 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style10 {
            font-size: large;
        }
        .auto-style11 {
            height: 16px;
            width: 2741px;
        }
        .auto-style12 {
            width: 1200px;
            text-align: right;
            font-size: large;
            height: 49px;
        }
        .auto-style13 {
            text-align: left;
            width: 2741px;
            height: 49px;
        }
        .auto-style14 {
            font-size: large;
            margin-left: 0px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style9">
            Customer Details<br />
            <br />
        </div>
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style7">&nbsp;Name</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_name" runat="server" CssClass="auto-style10" Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name" CssClass="auto-style10" ErrorMessage="Name is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Email</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_email" runat="server" CssClass="auto-style10" Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_email" CssClass="auto-style10" ErrorMessage="Email is required" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email" CssClass="auto-style10" ErrorMessage="Invalid Email ID" ForeColor="#FF9933" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Password</td>
                <td class="auto-style13">
                    <asp:TextBox ID="txt_password" runat="server" CssClass="auto-style10" TextMode="Password" Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_password" CssClass="auto-style10" ErrorMessage="Enter Password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Confirm Password</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_cpassword" runat="server" CssClass="auto-style10" TextMode="Password" Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_cpassword" CssClass="auto-style10" ErrorMessage="Re-Enter Password" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_password" ControlToValidate="txt_cpassword" CssClass="auto-style10" ErrorMessage="Password is not matching" ForeColor="#FF9933" Display="Dynamic"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Age</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_age" runat="server" CssClass="auto-style10" Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_age" CssClass="auto-style10" ErrorMessage="Age is required" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_age" CssClass="auto-style10" ErrorMessage="Invalid age" ForeColor="#FF9933" MaximumValue="130" MinimumValue="5" Type="Integer" Display="Dynamic"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Mobile Number</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_mn" runat="server" CssClass="auto-style10" Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_mn" CssClass="auto-style10" ErrorMessage="Mobile Number is required" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_mn" CssClass="auto-style10" ErrorMessage="Invalid Mobile Number" ForeColor="#FF9933" ValidationExpression="\d{10}" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style11">
                    <asp:Button ID="btn" runat="server" CssClass="auto-style14" Text="Save Customer Details" Width="219px" />
                </td>
            </tr>
        </table>
    </form>
    <p class="auto-style6">
        &nbsp;</p>
</body>
</html>
