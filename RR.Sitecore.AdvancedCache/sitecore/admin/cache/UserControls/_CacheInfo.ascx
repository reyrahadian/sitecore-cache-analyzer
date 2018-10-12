<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_CacheInfo.ascx.cs" Inherits="RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls._CacheInfo" %>
<%@ Import Namespace="Sitecore" %>

Name: <%= CacheInfo.Name %>
Count: <%= CacheInfo.Count %>
Size: <%= MainUtil.FormatSize(CacheInfo.Size) %>
MaxSize: <%= MainUtil.FormatSize(CacheInfo.MaxSize) %>