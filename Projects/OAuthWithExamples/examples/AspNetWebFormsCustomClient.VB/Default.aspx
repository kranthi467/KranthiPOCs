﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AspNetWebFormsCustomClient.VB._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
		<div>
			<asp:Repeater ID="Repeater1" runat="server">
				<ItemTemplate>
					<div style="border: 1px solid silver;padding:4px;margin-bottom:12px;">
						<pre>
Client name:    <%#Eval("Key")%>
Provider name:  <%#Eval("ProviderName")%>
Type:           <%#Nemiro.OAuth.OAuthManager.RegisteredClients(GetDataItem()).GetType()%>
						</pre>
						<asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" data-provider='<%#GetDataItem()%>' />
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
  </form>
</body>
</html>
