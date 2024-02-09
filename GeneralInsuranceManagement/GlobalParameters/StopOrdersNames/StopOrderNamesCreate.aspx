<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="StopOrderNamesCreate.aspx.cs" Inherits="GeneralInsuranceManagement.GlobalParameters.StopOrdersNames.StopOrderNamesCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Stop Orders Management</div>
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

    <asp:HiddenField ID="Id" runat="server" />

    <div class="row">
        <div class="col-xl-8 mx-auto">
            <div class="card ">
                <div class="card-body p-4">
                    <h5 class="mb-4">
                        <span><i class='bx bx-building-house' style="font-size: x-large"></i></span>
                        Stop Orders
                    </h5>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="StopOrderName" class="col-sm-3 col-form-label">Stop Order Name </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-building-house" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="StopOrderName" CssClass="form-control" placeholder="Enter Stop Order Name" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="StopOrderName"
                                CssClass="text-danger" ErrorMessage="The Stop Order Name field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="EmployerName" class="col-sm-3 col-form-label">Employer Name </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-user" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="EmployerName" CssClass="form-control" placeholder="Enter Employer Name" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="EmployerName"
                                CssClass="text-danger" ErrorMessage="The Employer Name field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="EmployeeNumber" class="col-sm-3 col-form-label">Employee Number </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-barcode" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="EmployeeNumber" CssClass="form-control" placeholder="Enter Employee Number" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="EmployeeNumber"
                                CssClass="text-danger" ErrorMessage="The Employee Number field is required." />
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
                <!-- card -->
            </div>
        </div>
    </div>
</asp:Content>
