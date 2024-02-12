<%@ Page Title="Product Creation" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="ProductCreation.aspx.cs" Inherits="GeneralInsuranceManagement.Products.ProductCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Products Management</div>
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

    <asp:HiddenField ID="ProductId" runat="server" />
    <asp:HiddenField ID="SchemeId" runat="server" />


    <div class="row">
        <div class="col-xl-8 mx-auto">
            <div class="card ">
                <div class="card-body p-4">
                    <h5 runat="server" class="mb-4">
                        <asp:Literal runat="server" ID="pagetitle" />

                    </h5>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="row g-3">
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="Name" class="form-label">Name</asp:Label>
                            <asp:TextBox runat="server" ID="Name" CssClass="form-control" placeholder="Enter Name" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                CssClass="text-danger" ErrorMessage="The Name field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="Description" class="form-label">Description</asp:Label>
                            <asp:TextBox runat="server" ID="Description" CssClass="form-control" placeholder="Enter Description" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                                CssClass="text-danger" ErrorMessage="The Description field is required." />
                        </div>
                        <!-- row -->
                        <asp:Panel ID="pnlSave" runat="server">
                            <div class="row">
                                <label class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-9">
                                    <asp:Button runat="server" OnClick="btnCreate_Click" ID="btnCreate" Text="Create" CssClass="btn btn-primary px-4 " />
                                    <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn btn-light px-4 " />
                                </div>
                            </div>
                        </asp:Panel>
                        <!-- row -->
                        <asp:Panel ID="pnlApprove" runat="server">
                            <div class="row">
                                <label class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-9">
                                    <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="btn btn-success px-4 " />
                                    <asp:Button runat="server" ID="btnReject" Text="Reject" CssClass="btn btn-danger px-4 " />
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                    <!-- form-layout-footer -->

                </div>
                <!-- card -->
            </div>
        </div>
    </div>

</asp:Content>
