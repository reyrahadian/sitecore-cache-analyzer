<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_GeneralCache.ascx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls._GeneralCache" %>
<%@ Import Namespace="Sitecore" %>
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
		<td style="height: 36px">
		</td>
	</tr>
	<tr>
		<td valign="top">
			<asp:Label ID="labelCacheTitle" runat="server">Caches</asp:Label>
		</td>
		<td></td>
		<td>
			<asp:PlaceHolder ID="c_caches" runat="server"></asp:PlaceHolder>
			<asp:Repeater runat="server" ID="rptCaches" ItemType="RR.Sitecore.AdvancedCache.Models.CacheInfo">
				<HeaderTemplate>
					<table border="1">
					<thead>
					<td>Name</td>
					<td>Count</td>
					<td>Size</td>
					<td>Max Size</td>
					</thead>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td><%# Item.Name %></td>
						<td><%# Item.Count %></td>
						<td><%# MainUtil.FormatSize(Item.Size) %></td>
						<td><%# MainUtil.FormatSize(Item.MaxSize) %></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
				</table>
				</FooterTemplate>
			</asp:Repeater>

			<asp:Label runat="server" ID="lblCacheInfo"></asp:Label>
			<asp:Repeater runat="server" ID="rptItems" ItemType="Sitecore.Data.Items.Item">
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
		</td>
	</tr>
</table>