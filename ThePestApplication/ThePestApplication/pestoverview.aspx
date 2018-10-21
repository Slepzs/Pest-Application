<%@ Page Title="" Language="C#" MasterPageFile="~/masterone.Master" AutoEventWireup="true" CodeBehind="pestoverview.aspx.cs" Inherits="ThePestApplication.pestoverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper">
      <div class="container">

          <h2>Overview of current pests available to pick from.</h2>
        <asp:GridView ID="GridViewpests" runat="server" OnSelectedIndexChanged="GridViewpests_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    </p>
    <asp:Label ID="Label1" runat="server" Text="Pest"></asp:Label>
    <asp:TextBox ID="TextBoxPestName" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
          <asp:Label ID="Label3" runat="server" Text="Delete:"></asp:Label>
    <asp:DropDownList ID="DropDownListDelete" runat="server" OnSelectedIndexChanged="DropDownListDelete_SelectedIndexChanged">
    </asp:DropDownList>
    <p>
        <asp:Button ID="BtnCreate" runat="server" OnClick="BtnCreate_Click1" Text="Create Pest" CssClass="sendreq" />
        <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update Pest" CssClass="btnupdate" />
        <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete Pest" CssClass="btndelete" />
    </p>
          </div>
         </div>
</asp:Content>
