<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="StudentCRUD.StudentDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Details</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Student Details</h1>
            <hr />
            
            <div class="card">
                <div class="card-header">
                    <h3><asp:Literal ID="ltlStudentName" runat="server"></asp:Literal></h3>
                </div>
                <div class="card-body">
                    <dl class="row">
                        <dt class="col-sm-3">ID:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlID" runat="server"></asp:Literal></dd>
                        
                        <dt class="col-sm-3">First Name:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlFirstName" runat="server"></asp:Literal></dd>
                        
                        <dt class="col-sm-3">Last Name:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlLastName" runat="server"></asp:Literal></dd>
                        
                        <dt class="col-sm-3">Date of Birth:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlDateOfBirth" runat="server"></asp:Literal></dd>
                        
                        <dt class="col-sm-3">Age:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlAge" runat="server"></asp:Literal></dd>
                        
                        <dt class="col-sm-3">Email:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlEmail" runat="server"></asp:Literal></dd>
                        
                        <dt class="col-sm-3">Course:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlCourse" runat="server"></asp:Literal></dd>
                        
                        <dt class="col-sm-3">GPA:</dt>
                        <dd class="col-sm-9"><asp:Literal ID="ltlGPA" runat="server"></asp:Literal></dd>
                    </dl>
                </div>
                <div class="card-footer">
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"
                        OnClientClick="return confirm('Are you sure you want to delete this student?');" />
                    <asp:Button ID="btnBack" runat="server" Text="Back to List" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
                    <asp:HiddenField ID="hfStudentID" runat="server" />
                </div>
            </div>
        </div>
    </form>
    
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>