<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cache-advanced.aspx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.AdvancedCacheAdmin" %>
<%@ Import Namespace="Sitecore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Advanced Cache Admin</title>
</head>
<body>
	<form id="mainForm" runat="server">
		<table id="Table1" style="height: 154px; width: 594px;" cellspacing="1" cellpadding="1"
			width="594" border="1">
			<tr>
				<td>
					<asp:Label ID="Caches" runat="server" DESIGNTIMEDRAGDROP="79">Actions</asp:Label>
				</td>
				<td></td>
				<td>
					<asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_OnClick"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="c_clearAll" runat="server" Text="Clear all"></asp:Button>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label1" runat="server">Totals</asp:Label>
				</td>
				<td></td>
				<td>
					<asp:Label ID="labelTotals" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="height: 36px"></td>
				<td style="height: 36px"></td>
				<td style="height: 36px"></td>
			</tr>
			<tr>
				<td valign="top">
					<asp:Label ID="labelCacheTitle" runat="server">Caches</asp:Label>
				</td>
				<td></td>
				<td>
					<asp:PlaceHolder ID="c_caches" runat="server"></asp:PlaceHolder>
					<asp:Repeater runat="server" ID="rptCaches" ItemType="RR.Sitecore.AdvancedCache.CacheInfo">
						<HeaderTemplate>
							<table border="1">
								<thead>
									<td></td>
									<td>Name</td>
									<td>Count</td>
									<td>Size</td>
									<td>Delta</td>
									<td>Max Size</td>
								</thead>
						</HeaderTemplate>
						<ItemTemplate>
							<tr>
								<td></td>
								<td><%# Item.Name%></td>
								<td><%# Item.Count%></td>
								<td><%# MainUtil.FormatSize(Item.Size)%></td>
								<td><%# MainUtil.FormatSize(Item.DeltaSize)%></td>
								<td><%# MainUtil.FormatSize(Item.MaxSize) %></td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:Repeater>
				</td>
			</tr>
		</table>
	</form>
</body>
</html>
