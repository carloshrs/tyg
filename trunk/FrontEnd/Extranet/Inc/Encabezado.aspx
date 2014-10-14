<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Inc.Encabezado" CodeFile="Encabezado.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Encabezado</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
    <script>
        function cargarBanner() {
            setTimeout('try {top.Main.MostrarAviso();} catch(err){}', 3000); 
        }
    </script>
	<body onload="cargarBanner();">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%" class="text" bgcolor="#32528e"><IMG src="/img/logo.gif"></TD>
					<TD width="100%" class="text" bgcolor="#32528e" align="right"><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="334" height="87" >
<param name="movie" value="/img/top.swf"><param name="quality" value="high">
<embed src="/img/top.swf" pluginspage="http://www.macromedia.com/go/getflashplayer" width="334" height="87"></embed>
</object></TD>
				</TR>
				<TR>
					<TD width="100%" class="text" colspan="2"><BR>
						<BR>
						<BR>
					</TD>
				</TR>
				<TR>
					<TD width="100%" class="text" colspan="2">&nbsp;
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="30%">&nbsp;</TD>
								<TD width="70%" class="text" colspan="4">&nbsp;
									<asp:Literal id="litGrupos" runat="server"></asp:Literal></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
