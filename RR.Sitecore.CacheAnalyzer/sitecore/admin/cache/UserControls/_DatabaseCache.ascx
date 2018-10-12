<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_DatabaseCache.ascx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls._DatabaseCache" %>
<%@ Register Src="~/sitecore/admin/cache/UserControls/_CacheInfo.ascx" TagPrefix="uc1" TagName="_CacheInfo" %>
<%@ Register Src="~/sitecore/admin/cache/UserControls/_CacheCountsByTemplateIdTable.ascx" TagPrefix="uc1" TagName="_CacheCountsByTemplateIdTable" %>


<asp:PlaceHolder runat="server" ID="plcTableOfContent">
	<a name="top"></a>
	<asp:Repeater runat="server" ID="rptTableOfContent" ItemType="System.String">
		<ItemTemplate>
			<a href="#<%# Item%>"><%# Item %></a>
		</ItemTemplate>
	</asp:Repeater>
</asp:PlaceHolder>

<asp:Repeater runat="server" ID="rptDatabaseCachesInfo" ItemType="RR.Sitecore.AdvancedCache.Models.DatabaseCacheInfo">
	<ItemTemplate>
		<h1><a name="<%#Item.DatabaseName %>"><%#Item.DatabaseName %></a></h1><a href="#top">back to top</a>
		<table border="1">
			<tr>
				<td valign="top">Data Caches
				</td>
				<td>
					<uc1:_CacheInfo runat="server" ID="_CacheInfo" CacheInfo="<%# Item.DataCacheInfo %>" />
					<uc1:_CacheCountsByTemplateIdTable runat="server" id="_CacheCountsByTemplateIdTable" CacheCountsByTemplateIds="<%# Item.DataCacheInfo.CacheCountsByTemplateIds %>"/>					
				</td>
			</tr>
			<tr>
				<td valign="top">Item Caches
				</td>
				<td>
					<uc1:_CacheInfo runat="server" ID="_CacheInfo1" CacheInfo="<%# Item.ItemCacheInfo %>" />
					<uc1:_CacheCountsByTemplateIdTable runat="server" id="_CacheCountsByTemplateIdTable1" CacheCountsByTemplateIds="<%# Item.ItemCacheInfo.CacheCountsByTemplateIds %>"/>					
				</td>
			</tr>
		</table>
	</ItemTemplate>
</asp:Repeater>

