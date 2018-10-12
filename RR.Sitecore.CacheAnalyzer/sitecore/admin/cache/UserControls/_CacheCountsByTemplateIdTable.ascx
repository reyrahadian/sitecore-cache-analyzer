<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_CacheCountsByTemplateIdTable.ascx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls.CacheCountsByTemplateIdTable" %>
<asp:Repeater runat="server" ID="rptCacheCounts" ItemType="RR.Sitecore.AdvancedCache.Models.CacheCountByTemplateId">
	<HeaderTemplate>
		<table border="1" cellspacing="1" cellpadding="1">
		<thead style="font-weight: bold">
		<td>Template ID</td>
		<td>Template Name</td>
		<td>Count</td>
		</thead>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td><%# Item.TemplateId %></td>
			<td><%# Item.TemplateName %></td>
			<td><%# Item.Count%></td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
	</table>
	</FooterTemplate>
</asp:Repeater>