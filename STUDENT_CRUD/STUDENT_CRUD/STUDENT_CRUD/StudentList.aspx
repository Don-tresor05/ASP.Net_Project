<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="STUDENT_CRUD.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>STUDENT LIST</h1>
            <br />
             <div class="row mb-3">
                <div class="col">
                    <asp:Button ID="btnAddNew" runat="server" Text="New Student" CssClass="btn btn-primary" OnClick="btnAddNew_Click" />
                </div>
            </div>

            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False"
                CssClass ="table table-striped table-hover " DataKeyNames="ID"
                OnRowCommand="gvStudents_RowCommand" Height="131px">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"  ReadOnly="true"/>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name"  ReadOnly="true"/>
                    <asp:BoundField DataField="Age" HeaderText="Age"  ReadOnly="true"/>
                    <asp:BoundField DataField="Course" HeaderText="Course"  ReadOnly="true"/>
                    <asp:BoundField DataField="GPA" HeaderText="GPA"  ReadOnly="true"/>
                   <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnView" runat="server" Text="View" 
                                CommandName="ViewStudent" 
                                CommandArgument='<%# Eval("ID") %>' 
                                CssClass="btn btn-info btn-sm" />
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                                CommandName="EditStudent" 
                                CommandArgument='<%# Eval("ID") %>' 
                                CssClass="btn btn-warning btn-sm" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
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
    <script src="scripts/jquery-3.7.0.min.js"></script>
     <script src="scripts/bootstrap.bundle.min.js"></script>

</body>
</html>
