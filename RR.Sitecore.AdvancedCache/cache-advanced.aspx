<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cache-advanced.aspx.cs" Inherits="RR.Sitecore.AdvancedCache.AdvancedCacheAdmin" %>

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
				<asp:Button ID="c_refresh" runat="server" Text="Refresh"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="c_clearAll" runat="server" Text="Clear all"></asp:Button>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label1" runat="server">Totals</asp:Label>
			</td>
			<td></td>
			<td>
				<asp:Label ID="c_totals" runat="server">[totals]</asp:Label>
			</td>
		</tr>
		<tr>
			<td style="height: 36px"></td>
			<td style="height: 36px"></td>
			<td style="height: 36px"></td>
		</tr>
		<tr>
			<td valign="top">
				<asp:Label ID="c_cacheTitle" runat="server">Caches</asp:Label>
			</td>
			<td></td>
			<td>
				<asp:PlaceHolder ID="c_caches" runat="server"></asp:PlaceHolder>
			</td>
		</tr>
	</table>
</form>
</body>
</html>