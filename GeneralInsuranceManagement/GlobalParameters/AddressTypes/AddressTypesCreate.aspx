<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="AddressTypesCreate.aspx.cs" Inherits="GeneralInsuranceManagement.GlobalParameters.AddressTypes.AddressTypesCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Address Types Management</div>
        <div class="ps-3">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 p-0">
                    <li class="breadcrumb-item"><a href="~/Default"><i class="bx bx-home-alt"></i></a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">Creation</li>
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

    <asp:HiddenField ID="SchemeId" runat="server" />

    <div class="row">
        <div class="col-xl-8 mx-auto">
            <div class="card ">
                <div class="card-body p-4">
                    <h5 class="mb-4">
                        <span><i class="bx bx-current-location" style="font-size: larger"></i></span>
                        Address Types
                    </h5>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="AddressTypes" class="col-sm-3 col-form-label">Address Type </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-current-location" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="AddressTypes" CssClass="form-control" placeholder="Enter Address Type" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AddressTypes"
                                CssClass="text-danger" ErrorMessage="The Address Type field is required." />
                        </div>
                    </div>
                        <%-- <div class="col-md-6">
                       
                        <asp:Label runat="server" class="form-label">Description</asp:Label>
                        <asp:TextBox runat="server" ID="RegNo" CssClass="form-control" placeholder="Enter Time Group Description" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                            CssClass="text-danger" ErrorMessage="The Time Groups field is required." />
                    </div>--%>
                        <!-- row -->
                        <asp:Panel ID="pnlSave" runat="server">
                            <div class="row">
                                <label class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-9">
                                    <asp:Button runat="server" ID="btnCreate" OnClick="btnCreate_Click" Text="Create" CssClass="btn btn-primary px-4 " />
                                </div>
                            </div>
                        </asp:Panel>
                        <!-- row -->
                    </div>
                    <!-- form-layout-footer -->
                <!-- card -->
            </div>
        </div>
    </div>
</asp:Content>
