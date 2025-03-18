<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="StudentCRUD.StudentForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Form</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h1>
            <hr />
            
            <asp:ValidationSummary ID="vsStudentForm" runat="server" CssClass="alert alert-danger" />
            
            <div class="row mb-3">
                <label for="txtFirstName" class="col-sm-2 col-form-label">First Name:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                        ControlToValidate="txtFirstName" ErrorMessage="First Name is required."
                        Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="row mb-3">
                <label for="txtLastName" class="col-sm-2 col-form-label">Last Name:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                        ControlToValidate="txtLastName" ErrorMessage="Last Name is required."
                        Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="row mb-3">
                <label for="txtDateOfBirth" class="col-sm-2 col-form-label">Date of Birth:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" 
                        ControlToValidate="txtDateOfBirth" ErrorMessage="Date of Birth is required."
                        Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvDateOfBirth" runat="server" 
                        ControlToValidate="txtDateOfBirth" ErrorMessage="Date of Birth must be between 01/01/1990 and today."
                        Type="Date" MinimumValue="1990-01-01" Display="None" SetFocusOnError="true"></asp:RangeValidator>
                </div>
            </div>
            
            <div class="row mb-3">
                <label for="txtEmail" class="col-sm-2 col-form-label">Email:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Email is required."
                        Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Invalid email format."
                        ValidationExpression="\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*"
                        Display="None" SetFocusOnError="true"></asp:RegularExpressionValidator>
                </div>
            </div>
            
            <div class="row mb-3">
                <label for="ddlCourse" class="col-sm-2 col-form-label">Course:</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-select">
                        <asp:ListItem Text="-- Select Course --" Value=""></asp:ListItem>
                        <asp:ListItem Text="Computer Science" Value="Computer Science"></asp:ListItem>
                        <asp:ListItem Text="Mathematics" Value="Mathematics"></asp:ListItem>
                        <asp:ListItem Text="Physics" Value="Physics"></asp:ListItem>
                        <asp:ListItem Text="Chemistry" Value="Chemistry"></asp:ListItem>
                        <asp:ListItem Text="Biology" Value="Biology"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCourse" runat="server" 
                        ControlToValidate="ddlCourse" ErrorMessage="Course is required."
                        Display="None" SetFocusOnError="true" InitialValue=""></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="row mb-3">
                <label for="txtGPA" class="col-sm-2 col-form-label">GPA:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtGPA" runat="server" CssClass="form-control" TextMode="Number" Step="0.1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvGPA" runat="server" 
                        ControlToValidate="txtGPA" ErrorMessage="GPA is required."
                        Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvGPA" runat="server" 
                        ControlToValidate="txtGPA" ErrorMessage="GPA must be between 0.0 and 4.0."
                        Type="Double" MinimumValue="0.0" MaximumValue="4.0"
                        Display="None" SetFocusOnError="true"></asp:RangeValidator>
                </div>
            </div>
            
            <div class="row mb-3">
                <div class="col-sm-10 offset-sm-2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false" />
                    <asp:HiddenField ID="hfStudentID" runat="server" />
                </div>
            </div>
        </div>
    </form>
    
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>