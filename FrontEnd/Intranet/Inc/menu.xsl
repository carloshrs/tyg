<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
	<link rel="STYLESHEET" type="text/css" href="/inc/menuStyle.css" />
	<SCRIPT language="Javascript" src="/inc/XPMenu.js"></SCRIPT>
	<xsl:apply-templates select="menu"/>
	
</xsl:template>

 <xsl:template match="menu">
	<span id="menu1">
		<table width="100%" class="TopGroup" cellspacing="1" id="menu1_group_1" cellpadding="0" border="0" onMouseOut="aspnm_groupMsOut('menu1_group_1', null, null, 50);" style="Z-INDEX:999">
			<tr>
				<xsl:apply-templates select="menuPrincipal" mode="A"/>
				<td></td>
				<td width="100%" valign="middle" align="right" class="titlesmall"><img src="/img/ico_user.gif" />
					<img src="/img/shim.gif" width="5" /><xsl:value-of select="@Usuario"/>
						<img src="/img/shim.gif" width="5" /><img src="/img/divisor_ficha.gif" />
					<img src="/img/shim.gif" width="5" /><xsl:value-of select="@Fecha"/>
					<img src="/img/shim.gif" width="6" />
				</td><td><a href="/Login.aspx" target="_top"><IMG src="/img/cerrar.gif" border="0" width="16" height="16" id="Img3" alt="Cerrar Sesión"/></a></td>
			</tr>
		</table>
	</span>
	<xsl:apply-templates select="menuPrincipal" mode="B"/>
 </xsl:template>
 
 <xsl:template match="menuPrincipal" mode="A">
	<td width="20" class="TopMenuItem">
		<xsl:attribute name="onMouseOver">this.className='TopMenuItemOver';if (document.readyState == 'complete') aspnm_itemMsOver('<xsl:value-of select="@idMenuItem"/>', '<xsl:value-of select="@idMenuGroup"/>', 'belowleft', 0, 0, 50, null);</xsl:attribute>
		<xsl:attribute name="onMouseOut">this.className='TopMenuItem';aspnm_itemMsOut('<xsl:value-of select="@idMenuItem"/>', 'menu1_group_1', '<xsl:value-of select="@idMenuGroup"/>', 50, null);</xsl:attribute>
		<xsl:attribute name="id">
			<xsl:value-of select="@idMenuItem"/>
		</xsl:attribute>
		<xsl:value-of select="@text"/>
	</td>
 </xsl:template>

<xsl:template match="menuPrincipal" mode="B">
<span>
	<table class="MenuGroup" cellspacing="0" cellpadding="0" border="0"  style="Z-INDEX:999;VISIBILITY:hidden;POSITION:absolute">
	<xsl:attribute name="id"><xsl:value-of select="@idMenuGroup"/></xsl:attribute>
	<xsl:attribute name="onMouseOver">aspnm_groupMsOver('<xsl:value-of select="@idMenuGroup"/>')</xsl:attribute>
	<xsl:attribute name="onMouseOut">aspnm_groupMsOut('<xsl:value-of select="@idMenuGroup"/>', '<xsl:value-of select="@idMenuItem"/>', 'menu1_group_1', 50, null);</xsl:attribute>
	
		<xsl:apply-templates select="itemMenu"/>
	</table>
</span>
</xsl:template>

<xsl:template match="itemMenu">
	
	<xsl:if test="@separar='1'">
		<tr>
			<td height="1" bgcolor="#B4B5B8"><img src="/Img/menu/gray.gif" border="0" width="100%" height="1" class="MenuBreak" onMouseOver="this.className='MenuBreak';" onMouseOut="this.className='MenuBreak';" /></td>
		</tr>
	</xsl:if>

	<tr>
		<td>
			<table class="MenuItem" cellpadding="0" cellspacing="0" border="0" width="100%" height="100%" onMouseDown="" onMouseUp="" onClick="javascript: document.location.href='/adm/contenidos/abmcanal.asp?Modo=A&amp;Paso=1&amp;Padre=&amp;idCanal='; return false;">
			<xsl:attribute name="id"><xsl:value-of select="@idMenuItem"/></xsl:attribute>
			<xsl:attribute name="onMouseOver">if (document.readyState == 'complete') aspnm_updateCell('<xsl:value-of select="@idMenuItem"/>', 'MenuItemOver', '<xsl:value-of select="@idImagenItem"/>', '<xsl:value-of select="@imageOver"/>', null, '', 'over');</xsl:attribute>
			<xsl:attribute name="onMouseOut">if (document.readyState == 'complete') aspnm_updateCell('<xsl:value-of select="@idMenuItem"/>', 'MenuItem', '<xsl:value-of select="@idImagenItem"/>', '<xsl:value-of select="@imageOut"/>', null, '', 'out');</xsl:attribute>
			<xsl:attribute name="onClick">javascript: document.location.href='<xsl:value-of select="@onClick"/>'; return false;</xsl:attribute>
				<tr>
					<td style="PADDING-RIGHT:0px;PADDING-LEFT:0px;PADDING-BOTTOM:0px;PADDING-TOP:0px" width="20">
					<img border="0"><xsl:attribute name="id"><xsl:value-of select="@idImagenItem"/></xsl:attribute>
					<xsl:attribute name="src"><xsl:value-of select="@imageOut"/></xsl:attribute></img></td>
					<td><xsl:value-of select="@text"/></td>
					<td style="PADDING-RIGHT:0px;PADDING-LEFT:0px;PADDING-BOTTOM:0px;PADDING-TOP:0px" width="15"></td>
				</tr>
			</table>
		</td>
	</tr>
 </xsl:template>

</xsl:stylesheet>
