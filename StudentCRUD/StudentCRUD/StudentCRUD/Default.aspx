<%-- Default.aspx - Homepage --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentCRUD.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Management System</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .jumbotron {
            padding: 2rem;
            margin-bottom: 2rem;
            background-color: #e9ecef;
            border-radius: 0.3rem;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron mt-4">
                <h1 class="display-4">Student Management System</h1>
                <p class="lead">A simple ASP.NET Web Forms application for managing student records.</p>
                <hr class="my-4" />
                <p>This system allows you to track student information including personal details, courses, and academic performance.</p>
                <p class="lead">
                    <asp:Button ID="btnGetStarted" runat="server" Text="Get Started" CssClass="btn btn-primary btn-lg" OnClick="btnGetStarted_Click" />
                </p>
            </div>
            
            <div class="row">
                <div class="col-md-4">
                    <div class="card mb-4">
                        <div class="card-header">
                            <h4>Student Management</h4>
                        </div>
                        <div class="card-body">
                            <p>View, add, edit, and delete student records in the system.</p>
                            <asp:Button ID="btnStudents" runat="server" Text="Manage Students" CssClass="btn btn-outline-primary" OnClick="btnStudents_Click" />
                        </div>
                    </div>
                </div>
                
                <div class="col-md-4">
                    <div class="card mb-4">
                        <div class="card-header">
                            <h4>Course Information</h4>
                        </div>
                        <div class="card-body">
                            <p>View and manage available courses in the system.</p>
                            <asp:Button ID="btnCourses" runat="server" Text="View Courses" CssClass="btn btn-outline-primary" OnClick="btnCourses_Click" />
                        </div>
                    </div>
                </div>
                
                <div class="col-md-4">
                    <div class="card mb-4">
                        <div class="card-header">
                            <h4>Statistics</h4>
                        </div>
                        <div class="card-body">
                            <p>View statistics and reports about student performance.</p>
                            <asp:Button ID="btnStats" runat="server" Text="View Statistics" CssClass="btn btn-outline-primary" OnClick="btnStats_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>