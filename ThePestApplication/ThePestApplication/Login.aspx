<%@ Page Title="" Language="C#" MasterPageFile="~/masterone.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ThePestApplication.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="wrapper">
        <div class="container">
            <div class="login">
            <h2>Log-in</h2>
                <p>You personal pest request site. </p>
 
    
    <span class="loginfo">E-mail</span>
    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
    <span class="loginfo">Password</span>
    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
    <asp:Button ID="Btnlogin" runat="server" OnClick="Btnlogin_Click" Text="Login " CssClass="loginbtn" />

                <br />
                <br />
                <asp:Label ID="LabelMessage" runat="server"></asp:Label>

                </div>
                   </div>
    </div>
</asp:Content>
