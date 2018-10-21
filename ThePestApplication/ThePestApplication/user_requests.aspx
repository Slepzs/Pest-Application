<%@ Page Title="" Language="C#" MasterPageFile="~/masterone.Master" AutoEventWireup="true" CodeBehind="user_requests.aspx.cs" Inherits="ThePestApplication.user_requests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="container">
            <div class="user_requests">

    <h1>Requests</h1>
    <p>Must requests will be seen in 24 hours.</p>
    <p>It's not possible to do more than 4 requests :-)</p>
    <p>
        <asp:Label ID="swag" runat="server" CssClass="infomessage"></asp:Label>
    </p>
    
                               <p>
        <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update" CssClass="btnupdate" />
        <asp:Button ID="BtnGetHelp" runat="server" Text="Send Request" OnClick="BtnGetHelp_Click" CssClass="sendreq" />
                </p>
                <p>
                    <asp:Label ID="LabelSelect" runat="server"></asp:Label>
                </p>
                <p>
    <asp:DropDownList ID="DropDownListPests" runat="server" DataSourceID="SqlDataSource1" DataTextField="pestname" DataValueField="idpest" Height="42px" Width="102px">
    </asp:DropDownList>
    <asp:TextBox ID="TextBoxCalender" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownListHours" runat="server" AutoPostBack="True">
        <asp:ListItem Value="08:00:00.000">8:00 - 10:00 (2H)</asp:ListItem>
        <asp:ListItem Value="10:00:00.000">10:00-12:00 (2H)</asp:ListItem>
        <asp:ListItem Value="12:00:00.000">12:00-14:00 (2H)</asp:ListItem>
        <asp:ListItem Value="14:00:00.000">14:00-16:00 (2H)</asp:ListItem>
    </asp:DropDownList>
                </p>
                <p>&nbsp;</p>

<div class="gridcal">
        <asp:GridView ID="GridViewUser" runat="server" OnSelectedIndexChanged="GridViewUser_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" OnSelectionChanged="Calendar1_SelectionChanged" Width="350px" BorderWidth="1px" NextPrevFormat="FullMonth">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" Font-Bold="True" BorderWidth="4px" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>

</div>

                <p>
<asp:Label ID="LabelMessage" runat="server" CssClass="infomessage"></asp:Label>
    <asp:DropDownList ID="DropDownListDelete" runat="server" DataSourceID="SqlDataSource2" DataTextField="date" DataValueField="pestrequest" Height="21px" OnSelectedIndexChanged="DropDownListDelete_SelectedIndexChanged" Width="139px" CssClass="dateselect">
</asp:DropDownList>
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete Request" CssClass="btndelete" />
                </p>
 
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:pestupdateConnectionString %>" SelectCommand="SELECT [date], [idcustomer], [pestrequest] FROM [Help] WHERE ([idcustomer] = @idcustomer)">
    <SelectParameters>
        <asp:SessionParameter Name="idcustomer" SessionField="id" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
    <p>
        &nbsp;</p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pestupdateConnectionString %>" SelectCommand="SELECT [pestname], [idpest] FROM [Pests]"></asp:SqlDataSource>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>&nbsp;</p>


            </div>
        </div>
    </div>
</asp:Content>
