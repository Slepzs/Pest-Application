<%@ Page Title="" Language="C#" MasterPageFile="~/masterone.Master" AutoEventWireup="true" CodeBehind="Requests.aspx.cs" Inherits="ThePestApplication.Requests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Search By Name:
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="firstname" DataValueField="firstname" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Refresh" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pestupdateConnectionString %>" SelectCommand="SELECT DISTINCT [firstname] FROM [Customer]"></asp:SqlDataSource>
    </p>


    <asp:Panel ID="Panel1" runat="server">
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Width="563px">
           <AlternatingRowStyle BackColor="#CCCCCC" />
           <Columns>
               <asp:BoundField DataField="firstname" HeaderText="firstname" SortExpression="firstname" />
               <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
               <asp:BoundField DataField="pestname" HeaderText="pestname" SortExpression="pestname" />
               <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
           </Columns>
           <FooterStyle BackColor="#CCCCCC" />
           <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
           <SortedAscendingCellStyle BackColor="#F1F1F1" />
           <SortedAscendingHeaderStyle BackColor="#808080" />
           <SortedDescendingCellStyle BackColor="#CAC9C9" />
           <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
                     
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:pestupdateConnectionString %>" SelectCommand="SELECT Customer.firstname, Customer.email, Pests.pestname, Help.date FROM Customer INNER JOIN Help ON Customer.id = Help.idcustomer INNER JOIN Pests ON Help.idpest = Pests.idpest"></asp:SqlDataSource>
    </asp:Panel>
   <asp:Panel ID="Panel2" runat="server"> 
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource3" ForeColor="Black" GridLines="Vertical" Width="559px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="firstname" HeaderText="firstname" SortExpression="firstname" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="pestname" HeaderText="pestname" SortExpression="pestname" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:pestupdateConnectionString %>" SelectCommand="SELECT Customer.firstname, Customer.email, Pests.pestname, Help.date FROM Customer INNER JOIN Help ON Customer.id = Help.idcustomer INNER JOIN Pests ON Help.idpest = Pests.idpest WHERE (Customer.firstname = @firstname)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="firstname" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
       <br />
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server">
        <br />
    </asp:Panel>
</asp:Content>
