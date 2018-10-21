<%@ Page Title="" Language="C#" MasterPageFile="~/masterone.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ThePestApplication.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="wrapper">
      <div class="container">
          <div class="defaultpage">
      <h1>Welcome to Pest Patrol</h1>
      <p>We can remove a lot of different animals! Take a look at our prices.</p>
      <p>Do you want to do a Request? <a href="user_requests.aspx">Go here!</a></p>
      <p>&nbsp;<asp:Label ID="LabelMessage" runat="server"></asp:Label>
      </p>

        <asp:Repeater ID="RepeaterTotal" runat="server" OnItemCommand="RepeaterTotal_ItemCommand">
        <HeaderTemplate>
            <table class="show-pest">
                <tr>
                    <td>Pest Type</td>
                    <td>Price</td>
                    <td>Pest Picture</td>
                </tr>
        </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("pestname") %></td>
                    <td><%# Eval("price") %> Kr</td>
                    <td><img src="Pictures/<%# Eval("pictureref") %>" /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    
    <p>
        &nbsp;</p>
          </div>
     </div>  
 </div> 

</asp:Content>
