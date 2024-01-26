<%@ Page Title="User Enquiries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserEnquiries.aspx.cs" Inherits="GeneralInsuranceManagement.UserManagement.UserEnquiries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="sl-mainpanel">--%>
        <nav class="breadcrumb sl-breadcrumb">
            <a class="breadcrumb-item" href="index.html">Short Term</a>
            <a class="breadcrumb-item" href="index.html">Users</a>
            <span class="breadcrumb-item active">Enquiries</span>
        </nav>

        <div class="sl-pagebody">
          <div class="sl-page-title">
          <h5>User Enquiries</h5>
        </div><!-- sl-page-title -->
        </div>

        <div class="card pd-20 pd-sm-40">
            <div class="table-wrapper">
                <%--<div class="form-group row gutters">--%>
                    <%--<div class="form-group row gutters col-12">--%>
                        <div class="col-sm-12 align-content-center">
                            <asp:GridView ID="grdUsers" Width="100%" runat="server"
                                AutoGenerateColumns="False" AutoGenerateSelectButton="False" 
                                DataKeyNames="ID"
                                CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                Style="border-collapse: collapse !important"
                                AllowPaging="True" AllowSorting="True" PageSize="10" >
                                <Columns>
                                    <asp:BoundField Visible="false" DataField="ID" HeaderText="ID"></asp:BoundField>
                                    <asp:BoundField DataField="Firstnames" HeaderText="First Name(s)"></asp:BoundField>
                                    <asp:BoundField DataField="Surname" HeaderText="Surname"></asp:BoundField>
                                    <asp:BoundField DataField="DepartmentName" HeaderText="Department"></asp:BoundField>
                                    <asp:BoundField DataField="UserRole" HeaderText="User Type"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Edit" runat="server" ForeColor="blue" CssClass="fa fa-check" CommandArgument='<%#Eval("ID")%>' CommandName="selectRecord"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    <%--</div>--%>
                <%--</div>--%>
            </div>
        </div>
    <%--</div>--%>
</asp:Content>
