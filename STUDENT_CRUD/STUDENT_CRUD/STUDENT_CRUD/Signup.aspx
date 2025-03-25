<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="STUDENT_CRUD.Signup" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Signup</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

 <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center align-items-center min-vh-100 bg-light">
            <div class="card p-4" style="width: 400px; border-radius: 30px; box-shadow: 0 0 30px rgba(0, 0, 0, 0.2);">
                <h2 class="text-center mb-4">Signup</h2>
                <div class="mb-3">
                    <div class="input-group">
                        <asp:TextBox ID="txtRegUsername" runat="server" CssClass="form-control" placeholder="Username" required="required"></asp:TextBox>
                        <span class="input-group-text"><i class="bx bxs-user"></i></span>
                    </div>
                </div>
                <div class="mb-3">
                    <div class="input-group">
                        <asp:TextBox ID="txtRegEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email" required="required"></asp:TextBox>
                        <span class="input-group-text"><i class="bx bxs-envelope"></i></span>
                    </div>
                </div>
                <div class="mb-3">
                    <div class="input-group">
                        <asp:TextBox ID="txtRegPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" required="required"></asp:TextBox>
                        <span class="input-group-text"><i class="bx bxs-lock-alt"></i></span>
                    </div>
                </div>
                <div class="mb-3">
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Select Role" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                        <asp:ListItem Text="Lecturer" Value="Lecturer"></asp:ListItem>
                        <asp:ListItem Text="HOD" Value="HOD"></asp:ListItem>
                        <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                        <asp:ListItem Text="Registrar" Value="Registrar"></asp:ListItem>
                    </asp:DropDownList><br />
                </div>
               <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary w-100 mb-3" OnClick="btnRegister_Click" /><br />

                 <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <p class="text-muted text-center">
                    Already have an account? <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Login here</asp:HyperLink>
                </p>
            </div>
        </div>
    </form>

   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
