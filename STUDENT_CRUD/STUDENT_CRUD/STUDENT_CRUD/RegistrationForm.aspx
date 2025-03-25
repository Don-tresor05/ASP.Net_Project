<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="STUDENT_CRUD.RegistrationForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <link href="Content/styles.css" rel="stylesheet" />
    <style type="text/css" media="screen">
    .print-only { display: none; }
</style>
 <style>
        .header {
            position: relative;
            text-align: center;
            margin-bottom: 20px;
        }
        .logo {
            position: absolute;
            top: 0;
            left: 0;
        }
        .header-content {
            display: inline-block;
            text-align: center;
            margin-left: 30px;
         height: 75px;
     }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="registration-form">
            
            <div class="header">
                <div class="logo">
                    <img src="images/aucalogo.jpeg" alt="AUCA Logo" style="height: 117px; width: 118px;" />
                </div>
                <div class="header-content">
                    <h1>&nbsp;</h1>
                    <h1>Adventist University of Central Africa</h1>
                    <p>P.O. Box 2461 Kigali, Rwanda | www.auca.ac.rw | info@auca.ac.rw</p>
                </div>
            </div>

           
         <div class="header-container">
    <h2>&nbsp;</h2>
             <h2>REGISTRATION FORM</h2>
    <p class="generated-date"><strong>Generated on:</strong> <asp:Label ID="lblGeneratedDate" runat="server" Text="9/30/2024"></asp:Label></p>
</div>
<div class="student-container">
    
   <div class="student-info">
    <p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Student Number:</strong> 
        <asp:Label ID="lblStudentNumber" runat="server" Text=""></asp:Label>
    </p>
    <p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Student Names:</strong> 
        <asp:Label ID="lblStudentNames" runat="server" Text=""></asp:Label>
    </p>
</div>

   
   <div class="student-details">
    <div class="detail-row">
        <span class="detail-label"><strong>Faculty:</strong></span>
        <span class="detail-value">Information Technology</span>
    </div>
    <div class="detail-row">
        <span class="detail-label"><strong>Department:</strong></span>
        <span class="detail-value">Information Management</span>
    </div>
    <div class="detail-row">
        <span class="detail-label"><strong>Program:</strong></span>
        <span class="detail-value">Day</span>
    </div>
</div>
</div>



            
         <div class="registered-courses-section" style="margin-top: 30px;">
   
    
    <asp:GridView ID="gvRegisteredCourses" runat="server" AutoGenerateColumns="false" 
        CssClass="registered-courses-table" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="CourseName" HeaderText="COURSE NAME" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="GroupName" HeaderText="GROUP" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="StudyTime" HeaderText="TIME" HeaderStyle-Font-Bold="true" />
            <asp:BoundField DataField="TuitionFee" HeaderText="TUITION FEE" 
                DataFormatString="{0:N0}" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" />
        </Columns>
    </asp:GridView>

           
            <div class="total-credits">
                <p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Credits:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>&nbsp;<strong><asp:Label ID="lblTotalCredits" runat="server" Text="9"></asp:Label></strong></p>
            </div>

           <div class="fees-section">
    <table class="fee-table">
        <tr>
            <td>Registration Fee:</td>
            <td class="amount">25,000</td>
        </tr>
        <tr class="indented">
            <td>Late Fine:</td>
            <td class="amount">0</td>
        </tr>
        <tr>
            <td>Facility Fee:</td>
            <td class="amount">0</td>
        </tr>
        <tr>
    <td>Reasearch Manual:</td>
    <td class="amount">0</td>
</tr>
        <tr>
    <td>Centre Fee:</td>
    <td class="amount">0</td>
</tr>
        <tr>
    <td>Stdudent Card:</td>
    <td class="amount">0</td>
</tr>
                <tr>
    <td>Graduation Fee:</td>
    <td class="amount">0</td>
</tr>
                <tr>
    <td>Libarary Card:</td>
    <td class="amount">0</td>
</tr>
                <tr>
    <td>Life INsurance:</td>
    <td class="amount">0</td>
</tr>
                <tr>
    <td>Supervision:</td>
    <td class="amount">0</td>
</tr>
        
       <tr>
    <td>TUITION FEE:</td>
    <td class="amount">
        <asp:Label ID="lblTuitionFee" runat="server" Text="0"></asp:Label>
    </td>
</tr>
<tr class="total-row">
    <td><strong>TOTAL TO BE PAID:</strong></td>
    <td class="amount">
        <strong><asp:Label ID="lblTotalToPay" runat="server" Text="0"></asp:Label></strong>
    </td>
</tr>
    </table>
</div>
            <div style="margin-top: 30px; text-align: center; max-width: 350px; margin-left: auto; margin-right: auto;">

     <div class="signatures" style="text-align: center; font-size: 14px; max-width: 350px; margin: 10px auto;">
    <div style="display: flex; align-items: center; justify-content: center; margin: 5px 0;">
        <strong style="margin-right: 10px;">Student's Signature:</strong>
        <div style="border-bottom: 1px solid #000; flex-grow: 1; max-width: 200px;"></div>
    </div>
    
    <div style="display: flex; align-items: center; justify-content: center; margin: 5px 0;">
        <strong style="margin-right: 10px;">Faculty Office Signature:</strong>
        <div style="border-bottom: 1px solid #000; flex-grow: 1; max-width: 200px;"></div>
    </div>
    
    <div style="display: flex; align-items: center; justify-content: center; margin: 5px 0;">
        <strong style="margin-right: 10px;">Account's Signature:</strong>
        <div style="border-bottom: 1px solid #000; flex-grow: 1; max-width: 200px;"></div>
    </div>
    
    <div style="display: flex; align-items: center; justify-content: center; margin: 5px 0;">
        <strong style="margin-right: 10px;">Registrar's Office:</strong>
        <div style="border-bottom: 1px solid #000; flex-grow: 1; max-width: 200px;"></div>
    </div>
</div>
                </div>
            <div style="border-top: 2px solid #000; margin: 300px auto 15px; max-width: 900px;"></div>

           
            <div class="footer-notes">
                <p><strong>NOTE:</strong></p>
                <p>1. This is not official registration unless it bears the stamp of the BUSINESS OFFICE and the REGISTRAR OFFICE.</p>
                <p>2. This form loses its value if not submitted within 2 weeks.</p>
                <p>3. Payment shall be done via URIBUTO PAY, Dial *775*2# AUCA Code TH61132546, then follow instructions.</p>
                <p>Account No. 00040-00280275-75 BK</p>
            </div>
        </div>
    </form>
</body>
</html>