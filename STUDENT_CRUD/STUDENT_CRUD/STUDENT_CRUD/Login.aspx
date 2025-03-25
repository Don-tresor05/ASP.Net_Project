<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="STUDENT_CRUD.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
  
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center align-items-center min-vh-100 bg-light">
            <div class="card p-4" style="width: 400px; border-radius: 30px; box-shadow: 0 0 30px rgba(0, 0, 0, 0.2);">
                <h1 class="text-center mb-4">Login</h1>
                <div class="mb-3">
                    <div class="input-group">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" required="required"></asp:TextBox>
                        <span class="input-group-text"><i class="bx bxs-user"></i></span>
                    </div>
                </div>
                <div class="mb-3">
                    <div class="input-group">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" required="required"></asp:TextBox>
                        <span class="input-group-text"><i class="bx bxs-lock-alt"></i></span>
                    </div>
                </div>
                <div class="mb-3">
                    <asp:HyperLink ID="lnkForgotPassword" runat="server" NavigateUrl="#" CssClass="text-decoration-none">Forgot Password?</asp:HyperLink>
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100 mb-3" OnClick="btnLogin_Click" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <p class="text-muted text-center">
                    Don't have an account? <asp:HyperLink ID="lnkSignup" runat="server" NavigateUrl="~/Signup.aspx">Signup here</asp:HyperLink>
                </p>
            </div>
        </div>
    </form>

 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
