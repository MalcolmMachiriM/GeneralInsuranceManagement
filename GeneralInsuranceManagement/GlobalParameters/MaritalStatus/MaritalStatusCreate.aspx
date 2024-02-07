<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="MaritalStatusCreate.aspx.cs" Inherits="GeneralInsuranceManagement.GlobalParameters.MaritalStatus.MaritalStatusCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Institution Types Management</div>
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
                        <span><i class='bx bx-crown' style="font-size: x-large"></i></span>
                        Marital Status
                    </h5>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="row g-3">
                        <%--AssociatedControlID="Description"--%>
                        <asp:Label runat="server" class="col-sm-3 col-form-label">Marital Status </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class='bx bx-crown' style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="MaritalStatus" CssClass="form-control" placeholder="Enter Marital Status" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="MaritalStatus"
                                    CssClass="text-danger" ErrorMessage="The Marital Status field is required." />
                            </div>
                        </div>
                        <!-- row -->
                        <asp:Label runat="server" class="col-sm-3 col-form-label">Code </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class='bx bx-barcode' style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="MaritalStatusCode" CssClass="form-control" placeholder="Enter Marital Status Code" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="MaritalStatusCode"
                                    CssClass="text-danger" ErrorMessage="The Code field is required." />
                            </div>
                        </div>                        
                        <asp:Panel ID="pnlSave" runat="server">
                            <div class="row">
                                <label class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-9">
                                    <asp:Button runat="server" ID="btnCreate" Text="Create" CssClass="btn btn-primary px-4 " />
                                </div>
                            </div>
                        </asp:Panel>
                        <!-- row -->
                    </div>
                    <!-- form-layout-footer -->

                </div>
                <!-- card -->
            </div>
        </div>
    </div>
</asp:Content>
