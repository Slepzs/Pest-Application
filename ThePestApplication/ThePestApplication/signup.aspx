<%@ Page Title="" Language="C#" MasterPageFile="~/masterone.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="ThePestApplication.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="wrapper">
        <div class="container">
            <div class="loginform">
                <h1>Create an account</h1>
    <p>
        <br />
    </p>
    <asp:Label ID="label" runat="server" Text="First Name" CssClass="formlabel"></asp:Label>
    <asp:TextBox ID="TextBoxFN" runat="server"></asp:TextBox>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Last Name" CssClass="formlabel"></asp:Label>
        <asp:TextBox ID="TextBoxLN" runat="server"></asp:TextBox>
        
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Street" CssClass="formlabel"></asp:Label>
        <asp:TextBox ID="TextBoxStreet" runat="server"></asp:TextBox>
    </p>
    <p>
          <asp:Label ID="Label4" runat="server" Text="Zip" CssClass="formlabel"></asp:Label>
        <asp:TextBox ID="TextBoxZip" runat="server"></asp:TextBox>
      
    </p>
    <p aria-atomic="False">
          <asp:Label ID="Label5" runat="server" Text="E-Mail" CssClass="formlabel"></asp:Label>
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
      
    </p>
    <p>
           <asp:Label ID="Label6" runat="server" Text="Password" CssClass="formlabel"></asp:Label>
 
        <asp:TextBox ID="TextBoxPassword" runat="server" Type="password"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="RpdPassword" ControlToValidate="TextBoxPassword" ErrorMessage="Your passwords do not match" EnableClientScript="False"></asp:CompareValidator>    
    </p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Repeat Password" CssClass="formlabel"></asp:Label>
        <asp:TextBox ID="RpdPassword" runat="server" Type="password"></asp:TextBox>
        
    </p>
    <p>
        <asp:Label ID="LabelMessage" runat="server" Text="Message"></asp:Label>
                </p>
    <asp:Button ID="BtnCreate" runat="server" Text="Create Account" CssClass="submitbtn" OnClick="BtnCreate_Click" />
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>        
                </div>
            </div>
        </div>
</asp:Content>
