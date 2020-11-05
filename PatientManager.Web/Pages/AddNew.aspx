<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="PatientManager.Web.Pages.AddNew" %>
<asp:Content ID="AddNewContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-margin-top">
        <div class="row">
            <asp:Label ID="lblRegisterMessage" runat="server" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="form-group col-xs-3">
                <asp:Label for="txtFirstName" ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                <asp:TextBox class="form-control" ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtFirstName" Display="Static" ErrorMessage="First name is required" runat="server" />
            </div>
            <div class="form-group col-xs-3">
                <asp:Label for="txtLastName" ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtLastName" Display="Static" ErrorMessage="Last name is required" runat="server" />
            </div>
            <div class="form-group col-xs-3">
                <asp:Label for="txtPhone" ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtPhone" Display="Static" ErrorMessage="Phone is required" runat="server" />
            </div>
            <div class="form-group col-xs-3">
                <asp:Label for="ddlGender" ID="lblGender" runat="server" Text="Phone"></asp:Label>
                <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                    <asp:ListItem Enabled="true" Text="Select..." Value="" />
                    <asp:ListItem Text="Female" Value="F" />
                    <asp:ListItem Text="Male" Value="M" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="ddlGender" Display="Static" ErrorMessage="Gender is required" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="form-group col-xs-6">
                <asp:Label for="txtEmail" ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                <asp:TextBox class="form-control" ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Static" ErrorMessage="Email is required" runat="server" />
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group col-xs-6">
                <asp:Label for="txtConfirmEmail" ID="lblConfirmEmail" runat="server" Text="Confirm e-mail"></asp:Label>
                <asp:TextBox class="form-control" ID="txtConfirmEmail" runat="server"></asp:TextBox>
                <asp:CompareValidator ControlToValidate="txtConfirmEmail" ControlToCompare="txtEmail" Display="Static" Operator="Equal" Type="String" ErrorMessage="Email should be equal" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="form-group col-xs-12">
                <asp:Label for="txaNote" ID="lblNotes" runat="server" Text="Notes"></asp:Label>
                <asp:TextBox ID="txaNote" CssClass="form-control" runat="server" Rows="10" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>

        <div class="row col-xs-12">
            <asp:Button CssClass="btn btn-primary" Text="Submit" OnClick="BtnSubmit_Click" runat="server" ID="btnSubmit" />
        </div>
    </div>
</asp:Content>