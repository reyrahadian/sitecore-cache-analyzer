<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.cache.AdvancedCacheAdmin" %>

<%@ Register Src="~/sitecore/admin/cache-advanced/_GeneralCache.ascx" TagPrefix="uc1" TagName="_GeneralCache" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Advanced Cache Admin</title>
</head>
<body>
	<form id="mainForm" runat="server">
		<asp:LinkButton runat="server" OnClick="ChangeTab" CommandArgument="0">General</asp:LinkButton>
		<asp:LinkButton runat="server" OnClick="ChangeTab" CommandArgument="1">Site Caches</asp:LinkButton>
		<asp:LinkButton runat="server" OnClick="ChangeTab" CommandArgument="2">Database Caches</asp:LinkButton>
		<asp:LinkButton runat="server" OnClick="ChangeTab" CommandArgument="3">Access Result Caches</asp:LinkButton>
		<asp:LinkButton runat="server" OnClick="ChangeTab" CommandArgument="4">Data Provider Caches</asp:LinkButton>
		<asp:LinkButton runat="server" OnClick="ChangeTab" CommandArgument="5">Miscellaneous Caches</asp:LinkButton>

		<asp:MultiView runat="server" ID="cacheTabs">
			<asp:View runat="server">
				<h1>General</h1>
				<uc1:_GeneralCache runat="server" id="_GeneralCache" />
			</asp:View>
			<asp:View runat="server" ID="viewSiteCaches">
				<h1>Site Caches</h1>
			</asp:View>
			<asp:View runat="server" ID="viewDatabaseCaches">
				<h1>Database Caches</h1>
			</asp:View>
			<asp:View runat="server" ID="viewAccessResultCaches">
				<h1>Access Result Caches</h1>
			</asp:View>			
			<asp:View runat="server" ID="viewDataProviderCaches">
				<h1>Data Provider Caches</h1>
			</asp:View>			
			<asp:View runat="server" ID="viewMiscCaches">
				<h1>Miscellaneous Caches</h1>
			</asp:View>			
		</asp:MultiView>
	</form>
</body>
</html>
