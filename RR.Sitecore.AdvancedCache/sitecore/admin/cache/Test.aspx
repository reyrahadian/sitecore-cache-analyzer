<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.cache.cache_advanced_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advanced Cached Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<asp:Label runat="server" ID="lbl"></asp:Label>
			<asp:Repeater runat="server" ID="rpt" ItemType="Sitecore.Data.Items.Item">
				<HeaderTemplate>
					<ul>
				</HeaderTemplate>
				<ItemTemplate>
					<li><%# Item.ID %><%# Item.Language.Name %><%# Item.Version.Number %><%#Item.Paths.FullPath %></li>
				</ItemTemplate>
				<FooterTemplate>
					</ul>
				</FooterTemplate>
			</asp:Repeater>
        </div>
    </form>
</body>
</html>
