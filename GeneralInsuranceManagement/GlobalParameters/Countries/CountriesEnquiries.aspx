﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="CountriesEnquiries.aspx.cs" Inherits="GeneralInsuranceManagement.GlobalParameters.Countries.Countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Countries</div>
        <div class="ps-3">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 p-0">
                    <li class="breadcrumb-item"><a href="javascript:;"><i class="bx bx-home-alt"></i></a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">Enquiries</li>
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

    <asp:Panel runat="server" ID="usersCard">
        <h5 class="mb-0 text-uppercase">
            <span><i class="bx bx-flag" style="font-size: larger"></i></span>
            Countries
        </h5>
        <hr />
        <div class="row; col-sm-3">
            <a runat="server" href="~/GlobalParameters/Countries/CountriesCreate" class="btn btn-primary">Create
            </a>
        </div>
        <br />

        <div class="card ">
            <div class="card-body">
                <div class="table-responsive">
                    <%--<div class="col-sm-12 align-content-center">--%>
                    <asp:GridView ID="grdAcctypes" ClientIDMode="Static" Width="100%" runat="server"
                        AutoGenerateColumns="False" OnRowCommand="grdAcctypes_RowCommand" AutoGenerateSelectButton="False"
                        DataKeyNames="ID"
                        CssClass="table table-striped table-bordered example" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                        Style="border-collapse: collapse !important; width=100%"
                        AllowPaging="True" AllowSorting="True" PageSize="10">
                        <Columns>
                            <asp:BoundField Visible="false" DataField="ID" HeaderText="ID"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Country Name"></asp:BoundField>
                            <asp:BoundField DataField="Code" HeaderText="Country Code"></asp:BoundField>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit" runat="server" ForeColor="blue" CssClass="bx bxs-edit" CommandArgument='<%#Eval("ID")%>'
                                        CommandName="selectRecord"></asp:LinkButton>
                                    <asp:LinkButton ID="delete" runat="server" ForeColor="red" CssClass="bx bxs-trash" CommandArgument='<%#Eval("ID")%>'
                                        CommandName="deleteRecord"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%--</div>--%>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="txtuserid" runat="server" />

</asp:Content>
