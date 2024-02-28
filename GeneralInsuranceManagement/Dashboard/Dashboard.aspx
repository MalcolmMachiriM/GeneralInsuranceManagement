<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GeneralInsuranceManagement.Dashboard.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* Customize the appearance of the GridView */
.table {
    width: 100%;
    border-collapse: collapse;
}

/* Add stripes to alternate rows */
.table-striped tbody tr:nth-of-type(odd) {
    background-color: #f9f9f9;
}

/* Add borders to table cells */
.table-bordered {
    border: 1px solid #dee2e6;
}

/* Add hover effect to table rows */
.table-hover tbody tr:hover {
    background-color: #f5f5f5;
}

/* Center align text in table headers */
th {
    text-align: center;
}

/* Add padding to table cells */
td, th {
    padding: 8px;
}

    </style>

    <div class="row row-cols-1 row-cols-md-2 row-cols-xl-4">
        <div class="col">
            <div class="card radius-10 bg-gradient-deepblue">
                <div class="card-body">
                    <div class="d-flex align-items-center">
                        <h5 class="mb-0 text-white">
                            <asp:Label ID="lblMaleNet" runat="server" Text=""></asp:Label></h5>
                        <div class="ms-auto">
                            <i class='bx bx-cart fs-3 text-white'></i>
                        </div>
                    </div>
                    <div class="progress my-2 bg-opacity-25 bg-white" style="height: 4px;">
                        <div class="progress-bar bg-white" role="progressbar" style="width: 55%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <div class="d-flex align-items-center text-white">
                        <p class="mb-0">Male Net Salary</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card radius-10 bg-gradient-ohhappiness">
                <div class="card-body">
                    <div class="d-flex align-items-center">
                        <h5 class="mb-0 text-white">
                            <asp:Label ID="lblFemaleNet" runat="server" Text=""></asp:Label></h5>
                        <div class="ms-auto">
                            <i class='bx bx-dollar fs-3 text-white'></i>
                        </div>
                    </div>
                    <div class="progress my-2 bg-opacity-25 bg-white" style="height: 4px;">
                        <div class="progress-bar bg-white" role="progressbar" style="width: 55%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <div class="d-flex align-items-center text-white">
                        <p class="mb-0">Female Net Salary</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card radius-10 bg-gradient-ibiza">
                <div class="card-body">
                    <div class="d-flex align-items-center">
                        <h5 class="mb-0 text-white">
                            <asp:Label ID="lblMaleCount" runat="server" Text=""></asp:Label></h5>
                        <div class="ms-auto">
                            <i class='bx bx-group fs-3 text-white'></i>
                        </div>
                    </div>
                    <div class="progress my-2 bg-opacity-25 bg-white" style="height: 4px;">
                        <div class="progress-bar bg-white" role="progressbar" style="width: 55%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <div class="d-flex align-items-center text-white">
                        <p class="mb-0">Male Count</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card radius-10 bg-gradient-moonlit">
                <div class="card-body">
                    <div class="d-flex align-items-center">
                        <h5 class="mb-0 text-white">
                            <asp:Label ID="lblFemaleCount" runat="server" Text=""></asp:Label></h5>
                        <div class="ms-auto">
                            <i class='bx bx-envelope fs-3 text-white'></i>
                        </div>
                    </div>
                    <div class="progress my-2 bg-opacity-25 bg-white" style="height: 4px;">
                        <div class="progress-bar bg-white" role="progressbar" style="width: 55%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <div class="d-flex align-items-center text-white">
                        <p class="mb-0">Female Count</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--end row-->
    <div class="row">
        <div class="col-12 col-lg-8 col-xl-8 d-flex">
            <div class="card radius-10 w-100">
                <div class="card-body">
                    <div class="d-flex align-items-center">
                        <div>
                            <h5 class="mb-0">Site Traffic</h5>
                        </div>
                        <div class="dropdown options ms-auto">
                            <div class="dropdown-toggle dropdown-toggle-nocaret" data-bs-toggle="dropdown">
                                <i class='bx bx-dots-horizontal-rounded'></i>
                            </div>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                                <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                                <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="chartdiv4" style="width: 100%; height: 300px;"></div>
                </div>
                <div class="row row-cols-1 row-cols-md-3 row-cols-xl-3 g-0 row-group text-center border-top">
                    <div class="col">
                        <div class="p-3">
                            <h5 class="mb-0">45.87M</h5>
                            <small class="mb-0">Overall Visitor <span><i class="bx bx-up-arrow-alt align-middle"></i>2.43%</span></small>
                        </div>
                    </div>
                    <div class="col">
                        <div class="p-3">
                            <h5 class="mb-0">15:48</h5>
                            <small class="mb-0">Visitor Duration <span><i class="bx bx-up-arrow-alt align-middle"></i>12.65%</span></small>
                        </div>
                    </div>
                    <div class="col">
                        <div class="p-3">
                            <h5 class="mb-0">245.65</h5>
                            <small class="mb-0">Pages/Visit <span><i class="bx bx-up-arrow-alt align-middle"></i>5.62%</span></small>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-12 col-lg-4 col-xl-4 d-flex">
            <div class="card radius-10 overflow-hidden w-100">
                <div class="card-body">
                    <div class="d-flex align-items-center mb-3">
                        <h5 class="mb-0">Top Referral</h5>
                        <div class="dropdown options ms-auto">
                            <div class="dropdown-toggle dropdown-toggle-nocaret" data-bs-toggle="dropdown">
                                <i class='bx bx-dots-horizontal-rounded'></i>
                            </div>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                                <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                                <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="chartdiv5" style="width: 100%; height: 400px;"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="row ">
        <div class="col-12 col-lg-4 col-xl-4 d-flex" style="height: 300px">
            <div class="card radius-10 w-100">
                <div class="card-body" style="background-color: #fe7e8d">
                    <div class="d-flex align-items-center">
                        <div>
                            <h5 class="mb-0">Number of Members</h5>
                        </div>
                    </div>
                    <div id="chartdiv6" style="width: 100%; height: 150px;"></div>
                </div>
                <div class="row row-cols-1 row-cols-md-2 row-cols-xl-2 g-0 row-group text-center border-top">
                    <div class="col">
                        <div class="p-2">
                            <h5 class="mb-0">45.87M</h5>
                            <small class="mb-0">Overall Visitor </small>
                        </div>
                    </div>
                    <div class="col">
                        <div class="p-2">
                            <h5 class="mb-0">15:48</h5>
                            <small class="mb-0">Visitor Duration </small>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-12 col-lg-4 col-xl-4 d-flex" style="height: 300px">
            <div class="card radius-10 w-100">
                <div class="card-body" style="background-color: #0bd38e">
                    <div class="d-flex align-items-center">
                        <div>
                            <h5 class="mb-0">Basic Salary</h5>
                        </div>
                    </div>
                    <div id="chartdiv7" style="width: 100%; height: 150px;"></div>
                </div>
                <div class="row row-cols-1 row-cols-md-2 row-cols-xl-2 g-0 row-group text-center border-top">
                    <div class="col">
                        <div class="p-2">
                            <h5 class="mb-0">45.87M</h5>
                            <small class="mb-0">Overall Visitor </small>
                        </div>
                    </div>
                    <div class="col">
                        <div class="p-2">
                            <h5 class="mb-0">15:48</h5>
                            <small class="mb-0">Visitor Duration </small>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-12 col-lg-4 col-xl-4 d-flex" style="height: 300px">
            <div class="card radius-10 w-100">
                <div class="card-body" style="background-color: #01c1c5">
                    <div class="d-flex align-items-center">
                        <div>
                            <h5 class="mb-0">Net Salary</h5>
                        </div>
                    </div>
                    <div id="chartdiv8" style="width: 100%; height: 150px;"></div>
                </div>
                <div class="row row-cols-1 row-cols-md-2 row-cols-xl-2 g-0 row-group text-center border-top">
                    <div class="col">
                        <div class="p-2">
                            <h5 class="mb-0">45.87M</h5>
                            <small class="mb-0">Overall Visitor </small>
                        </div>
                    </div>
                    <div class="col">
                        <div class="p-2">
                            <h5 class="mb-0">15:48</h5>
                            <small class="mb-0">Visitor Duration</small>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="card radius-10">
            <div class="card-body">
                <div class="d-flex align-items-center">
                    <div>
                        <h5 class="mb-0">Policies</h5>
                    </div>
                    <div class="dropdown options ms-auto">
                        <div class="dropdown-toggle dropdown-toggle-nocaret" data-bs-toggle="dropdown">
                            <i class='bx bx-dots-horizontal-rounded'></i>
                        </div>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="javascript:;">Action</a></li>
                            <li><a class="dropdown-item" href="javascript:;">Another action</a></li>
                            <li><a class="dropdown-item" href="javascript:;">Something else here</a></li>
                        </ul>
                    </div>
                </div>
                <hr>
                <div class="table-responsive">
                    <asp:GridView ID="grdDashboard" OnPageIndexChanging="grdDashboard_PageIndexChanging" ClientIDMode="Static" Width="100%" runat="server"
                        AutoGenerateColumns="False" AutoGenerateSelectButton="False"
                        DataKeyNames="PensionNo"
                        CssClass="table table-striped table-bordered example" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                        Style="border-collapse: collapse !important; width: 100%;"
                        AllowPaging="True" AllowSorting="True">
                        <Columns>
                            <asp:BoundField Visible="false" DataField="PensionNo" HeaderText="ID"></asp:BoundField>
                            <asp:BoundField DataField="PensionBasis" HeaderText="Pension Basis"></asp:BoundField>
                            <asp:BoundField DataField="PensionType" HeaderText="Pension Type"></asp:BoundField>
                            <asp:BoundField DataField="LastName" HeaderText="Last Name"></asp:BoundField>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name"></asp:BoundField>
                            <asp:BoundField DataField="Gender" HeaderText="Gender"></asp:BoundField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name"></asp:BoundField>
                            <asp:BoundField DataField="BankBranchName" HeaderText="Bank Branch Name"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.24/css/jquery.dataTables.css">
    <script type="text/javascript" charset="utf8" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.js"></script>

    <%--<script>
        $(document).ready(function () {
            $('#grdDashboard').DataTable();
        });

    </script>--%>
</asp:Content>
