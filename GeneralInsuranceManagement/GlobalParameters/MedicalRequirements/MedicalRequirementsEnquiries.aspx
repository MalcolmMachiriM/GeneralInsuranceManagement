<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="MedicalRequirementsEnquiries.aspx.cs" Inherits="GeneralInsuranceManagement.GlobalParameters.MedicalRequirements.MedicalRequirementsEnquiries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Medical Requirements</div>
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
            <span><i class="bx bx-plus-medical" style="font-size: larger"></i></span>
            MEdical Requirements
        </h5>
        <hr />

        <div class="card ">
            <div class="card-body">
                <div class="table-responsive">
                    <%--<div class="col-sm-12 align-content-center">--%>
                    <asp:GridView ID="grdAcctypes" ClientIDMode="Static" Width="100%" runat="server"
                        AutoGenerateColumns="False" AutoGenerateSelectButton="False"
                        DataKeyNames="ID"
                        CssClass="table table-striped table-bordered example" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                        Style="border-collapse: collapse !important; width=100%"
                        AllowPaging="True" AllowSorting="True" PageSize="10">
                        <Columns>
                            <asp:BoundField Visible="false" DataField="ID" HeaderText="ID"></asp:BoundField>
                            <asp:BoundField DataField="Code" HeaderText="Medical Requirements Code"></asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Medical Requirements"></asp:BoundField>
                            <asp:BoundField DataField="Tariff" HeaderText="Tariff"></asp:BoundField>
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
    </asp:Panel>
    <asp:HiddenField ID="txtuserid" runat="server" />

</asp:Content>
