<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="STUDENT_CRUD.UserDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 10px;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
        }
        .form-section {
            margin-bottom: 20px;
        }
        .form-section label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-section select, .form-section input[type="text"] {
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-left: 74px;
        }
        .form-section button {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .form-section button:hover {
            background-color: #45a049;
        }
        .search-bar {
            float: right;
            margin-bottom: 20px;
        }
        .search-bar input[type="text"] {
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .search-bar button {
            padding: 8px 12px;
            background-color: #008CBA;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .search-bar button:hover {
            background-color: #007B9E;
        }
        .table-section {
            clear: both;
            margin-top: 20px;
        }
        .table-section table {
            width: 100%;
            border-collapse: collapse;
        }
        .table-section th, .table-section td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .table-section th {
            background-color: #f2f2f2;
        }
        .print-button {
            margin-top: 10px;
        }
        .print-button button {
            padding: 10px 20px;
            background-color: #f44336;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .print-button button:hover {
            background-color: #e53935;
        }
        
    </style>
    <script>
        
        function showTimeDropdown() {
            var groupCourse = document.getElementById("ddlGroupCourse").value;
            var timeDropdown = document.getElementById("timeDropdown");

            if (groupCourse !== "") {
                timeDropdown.style.display = "block";
            } else {
                timeDropdown.style.display = "none";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="search-bar">
                <input type="text" id="txtSearch" placeholder="Search..." runat="server" />
                <button type="button">Search</button>
            </div>


            <div class="form-section">
                <h2>Course Registration</h2>
                <label for="ddlCourseName">Course Name:</label>
                <asp:DropDownList ID="ddlCourseName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseName_SelectedIndexChanged"></asp:DropDownList>

                <label for="ddlGroupCourse">Group Course:</label>
                <asp:DropDownList ID="ddlGroupCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupCourse_SelectedIndexChanged" Width="257px"></asp:DropDownList>

            
                <asp:TextBox ID="txtStudyTime" runat="server" ReadOnly="true" placeholder="Study Time" Width="317px"></asp:TextBox>

                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />

                <asp:Label ID="lblMessage" runat="server"></asp:Label>

            </div>
       <asp:GridView ID="gvRegisteredCourses" runat="server" AutoGenerateColumns="false"
    CssClass="table table-bordered table-striped table-hover"
    HeaderStyle-CssClass="thead-dark"
    RowStyle-CssClass="text-center"
    AlternatingRowStyle-CssClass="text-center"
    GridLines="None"
    ShowFooter="true"
    OnRowDataBound="gvRegisteredCourses_RowDataBound"
    OnRowCommand="gvRegisteredCourses_RowCommand">
    <Columns>
        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
        <asp:BoundField DataField="GroupName" HeaderText="Group" />
        <asp:BoundField DataField="StudyTime" HeaderText="Time" />
        <asp:BoundField DataField="TuitionFee" HeaderText="Tuition Fee" DataFormatString="{0:N2}" />

        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm"
                    CommandName="Edit" CommandArgument='<%# Eval("CourseName") %>' />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
                    CommandName="Delete" CommandArgument='<%# Eval("CourseName") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
            <asp:Button ID="btnPrint" runat="server" Text="Print" 
    CssClass="btn btn-primary" OnClick="btnPrint_Click" />
        </div>
    </form>
</body>
</html>