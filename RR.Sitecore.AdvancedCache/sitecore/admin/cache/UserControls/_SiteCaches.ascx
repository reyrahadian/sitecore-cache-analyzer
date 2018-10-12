<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_SiteCaches.ascx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls._SiteCaches" %>
<table border="1" cellspacing="1" cellpadding="1">
	<tr>
		<td>Sites</td>
		<td>
			<asp:Repeater runat="server" ID="rptSites" ItemType="System.String">
				<HeaderTemplate>
					<ul>
				</HeaderTemplate>
				<ItemTemplate>
					<li>
						<%# Item %>
					</li>
				</ItemTemplate>
				<FooterTemplate></ul></FooterTemplate>
			</asp:Repeater>
		</td>
	</tr>
	<tr>
		<td>Filtered Items Cache</td>
		<td>
			<asp:Label runat="server" ID="lblFilteredItemsCacheInfo"></asp:Label>
			<asp:Repeater runat="server" ID="rptFilteredItemCaches" ItemType="System.String">
				<HeaderTemplate>
					<ul>
				</HeaderTemplate>
				<ItemTemplate>
					<li>
						<%# Item %>
					</li>
				</ItemTemplate>
				<FooterTemplate></ul></FooterTemplate>
			</asp:Repeater>
		</td>
	</tr>
	<tr>
		<td>HTML Cache</td>
		<td>
			<asp:Label runat="server" ID="lblHtmlCache"></asp:Label>
			<asp:Repeater runat="server" ID="rptHtmlCache" ItemType="System.String">
				<HeaderTemplate>
					<ul>
				</HeaderTemplate>
				<ItemTemplate>
					<li>
						<%# Item %>
					</li>
				</ItemTemplate>
				<FooterTemplate></ul></FooterTemplate>
			</asp:Repeater>
		</td>
	</tr>
</table>
