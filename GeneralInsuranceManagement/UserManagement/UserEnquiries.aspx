﻿<%@ Page Title="User Enquiries" Language="C#" MasterPageFile="~/DEfaultUIS.Master" AutoEventWireup="true" CodeBehind="UserEnquiries.aspx.cs" Inherits="GeneralInsuranceManagement.UserManagement.UserEnquiries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">User Management</div>
        <div class="ps-3">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 p-0">
                    <li class="breadcrumb-item"><a href="javascript:;"><i class="bx bx-home-alt"></i></a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">User Approval</li>
                </ol>
            </nav>
        </div>
        <div class="ms-auto">
            <div class="btn-group">
                <button type="button" class="btn btn-primary">Settings</button>
                <button type="button" class="btn btn-primary split-bg-primary dropdown-toggle dropdown-toggle-split" data-bs-toggle="dropdown">
                    <span class="visually-hidden">Toggle Dropdown</span>
                </button>
                <div class="dropdown-menu dropdown-menu-right dropdown-menu-lg-end">
                    <a class="dropdown-item" href="javascript:;">Action</a>
                    <a class="dropdown-item" href="javascript:;">Another action</a>
                    <a class="dropdown-item" href="javascript:;">Something else here</a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item" href="javascript:;">Separated link</a>
                </div>
            </div>
        </div>
    </div>
    <!--end breadcrumb-->

    <h5 class="mb-0 text-uppercase">User Enquiries</h5>
    <hr />

    <div class="card ">
        <div class="card-body">
            <div class="table-responsive">
                <%--<div class="col-sm-12 align-content-center">--%>
                <asp:GridView ID="grdUsers" Width="100%" runat="server"
                    AutoGenerateColumns="False" AutoGenerateSelectButton="False"
                    DataKeyNames="ID" OnRowCommand="grdUsers_RowCommand"
                    CssClass="table table-striped table-bordered example" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                    Style="border-collapse: collapse !important; width=100%"
                    AllowPaging="True" AllowSorting="True" PageSize="10">
                    <Columns>
                        <asp:BoundField Visible="false" DataField="ID" HeaderText="ID"></asp:BoundField>
                        <asp:BoundField DataField="Firstnames" HeaderText="First Name(s)"></asp:BoundField>
                        <asp:BoundField DataField="Surname" HeaderText="Surname"></asp:BoundField>
                        <asp:BoundField DataField="DepartmentName" HeaderText="Department"></asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="User Type"></asp:BoundField>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton ID="Edit" runat="server" ForeColor="blue" CssClass="bx bxs-edit" CommandArgument='<%#Eval("ID")%>'
                                    CommandName="selectRecord"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--</div>--%>
            </div>
        </div>
    </div>
</asp:Content>
