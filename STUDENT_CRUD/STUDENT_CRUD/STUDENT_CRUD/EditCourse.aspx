<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCourse.aspx.cs" Inherits="STUDENT_CRUD.EditCourse" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Edit Course</h2>
        <asp:TextBox ID="txtCourseName" runat="server" placeholder="Course Name" /><br />
        <asp:TextBox ID="txtGroupName" runat="server" placeholder="Group Name" /><br />
        <asp:TextBox ID="txtStudyTime" runat="server" placeholder="Study Time" /><br />
        <asp:TextBox ID="txtTuitionFee" runat="server" placeholder="Tuition Fee" /><br />
        <asp:Button ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
    </form>
</body>
</html>