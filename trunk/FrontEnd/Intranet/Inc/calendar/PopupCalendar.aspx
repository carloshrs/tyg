<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Inc.PopupCalendar" CodeFile="PopupCalendar.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Advocatus Web Client - Calendario</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<asp:Calendar ID="calDate" OnSelectionChanged="Change_Date" Runat="server" BorderWidth="1px" BackColor="#F3F9F9"
				Width="220px" DayNameFormat="FirstLetter" ForeColor="#3D3A35" Height="200px" Font-Size="8pt"
				Font-Names="Verdana" BorderColor="#C2DCDB" ShowGridLines="True">
				<TodayDayStyle ForeColor="White" BackColor="#FCAC15"></TodayDayStyle>
				<SelectorStyle BackColor="#FCAC15"></SelectorStyle>
				<NextPrevStyle Font-Size="9pt" ForeColor="#F3F9F9"></NextPrevStyle>
				<DayHeaderStyle Height="1px" BackColor="#A5CCCC"></DayHeaderStyle>
				<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
				<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#F3F9F9" BackColor="#8BBBBB"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#838383"></OtherMonthDayStyle>
			</asp:Calendar>
			<input type="hidden" id="control" runat="server" NAME="control">
		</form>
	</body>
</HTML>
