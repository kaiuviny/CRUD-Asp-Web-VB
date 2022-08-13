<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CRUD_ASP_WEB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="background-color: blueviolet; font-size: xx-large;" align="center">
        CRUD Operation In Asp.Net VB
    </div>
    <br />
    <div align="left" style="padding: 15px">

        <table class="nav-justified">
            <tr>
                <td style="width: 210px; height: 22px">
                    <asp:Label ID="lblProductID" runat="server" Font-Bold="True" Font-Size="Medium" Text="PRODUCT ID"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtProductID" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" BackColor="#6600CC" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="38px" Text="Search" Width="106px" />
                </td>
            </tr>
            <tr>
                <td style="width: 210px">
                    <asp:Label ID="lblItemName" runat="server" Font-Bold="True" Font-Size="Medium" Text="ITEM NAME"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtItemName" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 210px">
                    <asp:Label ID="lblSpecification" runat="server" Font-Bold="True" Font-Size="Medium" Text="SPECIFICATION"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSpeficitation" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 210px">
                    <asp:Label ID="lblUnit" runat="server" Font-Bold="True" Font-Size="Medium" Text="UNIT"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlUnit" runat="server" Font-Size="Medium" Width="200px">
                        <asp:ListItem Value="KG"></asp:ListItem>
                        <asp:ListItem Value="PCS"></asp:ListItem>
                        <asp:ListItem Value="DZN"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 210px">
                    <asp:Label ID="lblColor" runat="server" Font-Bold="True" Font-Size="Medium" Text="COLOR"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblColor" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>GREEN</asp:ListItem>
                        <asp:ListItem>BLACK</asp:ListItem>
                        <asp:ListItem>RED</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 210px">
                    <asp:Label ID="lblInsertDate" runat="server" Font-Bold="True" Font-Size="Medium" Text="INSERT DATE"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInserDate" runat="server" Font-Size="Medium" TextMode="Date" Width="106px"></asp:TextBox>
                    <asp:TextBox ID="txtInsertTime" runat="server" Font-Size="Medium" TextMode="Time"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 210px; height: 24px;">
                    <asp:Label ID="lblOpeningQuantity" runat="server" Font-Bold="True" Font-Size="Medium" Text="OPENING QUANTITY"></asp:Label>
                </td>
                <td style="height: 24px">
                    <asp:TextBox ID="txtOpeningQuantity" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 210px">
                    <asp:Label ID="lblProductStatus" runat="server" Font-Bold="True" Font-Size="Medium" Text="PRODUCT STATUS"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbRegular" runat="server" Text="Regular" />
                    <asp:CheckBox ID="cbIrregular" runat="server" Text="Irregular" />
                </td>
            </tr>
        </table>

        <div>
            <table class="nav-justified" style="width: 103%">
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnInsertProduct" runat="server" BackColor="#6600CC" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="38px" Text="Insert" Width="106px" />
                        <asp:Button ID="btnUpdateProduct" runat="server" BackColor="#6600CC" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="38px" Text="Update" Width="106px" />
                        <asp:Button ID="btnDeleteProduct" runat="server" BackColor="#6600CC" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="38px" Text="Delete" Width="106px" OnClientClick="return  confirm(&quot;Are you sure to delete?&quot;)" />
                    </td>
                </tr>
            </table>
        </div>

        <div align="left" style="width: 953px">

        <hr />

            <asp:GridView ID="gvProducts" runat="server" Width="80%">
                <HeaderStyle BackColor="#6600FF" ForeColor="White" />
            </asp:GridView>

        </div>

    </div>

    
</asp:Content>
