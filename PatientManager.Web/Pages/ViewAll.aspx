<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="PatientManager.Web.Pages.ViewAll" %>
<asp:Content ID="AllContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-margin-top">
        <asp:GridView ID="grvPatients" runat="server" CssClass="table table-striped" ItemType="PatientManager.Domain.Dto.PatientDto" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="FirstName" >
                    <ItemTemplate>
                        <%# Item.FirstName %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName">
                    <ItemTemplate>
                        <%# Item.LastName %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <%# Item.Phone %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <%# Item.Gender %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%# Item.Email %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Notes">
                    <ItemTemplate>
                        <%# Item.Notes %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" CssClass="btn btn-primary" NavigateUrl='<%# string.Format("~/Pages/EditPatient.aspx?id={0}", Item.Id.ToString()) %>' Text="Edit" /> | 
                        <asp:Button CssClass="btn btn-danger" Text="Delete" runat="server" ID="btnDelete" CommandArgument='<%# Item.Id.ToString() %>'
                            OnClick="btnDelete_Click" OnClientClick="showModalConfirm('Are you sure delete this patient?');"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>    
    <script type="text/javascript">
        function showModalConfirm(msg) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(msg)) {
                confirm_value.value = "Yes";
            }
            else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
