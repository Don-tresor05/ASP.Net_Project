<%-- StudentList.aspx - List all students --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="StudentCRUD.StudentList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student List</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="mt-4">Student Management</h1>
            <hr />
            
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Button ID="btnAddNew" runat="server" Text="Add New Student" CssClass="btn btn-primary" OnClick="btnAddNew_Click" />
                    <asp:Button ID="btnHome" runat="server" Text="Back to Home" CssClass="btn btn-secondary ml-2" OnClick="btnHome_Click" />
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search students..."></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-outline-secondary" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline-secondary" OnClick="btnClear_Click" />
                        </div>
                    </div>
                </div>
            </div>
            
            <asp:Panel ID="pnlNoRecords" runat="server" CssClass="alert alert-info" Visible="false">
                No student records found.
            </asp:Panel>
            
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" 
                CssClass="table table-striped table-hover" DataKeyNames="ID"
                OnRowCommand="gvStudents_RowCommand" EmptyDataText="No records found."
                BorderWidth="0px" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Course" HeaderText="Course" />
                    <asp:BoundField DataField="GPA" HeaderText="GPA" DataFormatString="{0:F1}" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" Text="View" 
                                CommandName="ViewStudent" 
                                CommandArgument='<%# Eval("ID") %>' 
                                CssClass="btn btn-info btn-sm" />
                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" 
                                CommandName="EditStudent" 
                                CommandArgument='<%# Eval("ID") %>' 
                                CssClass="btn btn-warning btn-sm" />
                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" 
                                CommandName="DeleteStudent" 
                                CommandArgument='<%# Eval("ID") %>' 
                                CssClass="btn btn-danger btn-sm"
                                OnClientClick="return confirm('Are you sure you want to delete this student?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>