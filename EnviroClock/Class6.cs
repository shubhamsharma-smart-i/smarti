

// EnviroClock.Common
using EnviroClock;
using log4net;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

public static class Common
{
	public static string ClockVersion = string.Empty;

	public static IPEndPoint udp_ep;

	public static UdpClient udp;

	public static StringBuilder sb = new StringBuilder();

	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	public static IPAddress ParseIPAddress(string ipaddr)
	{
		short num = Convert.ToInt16(ipaddr.Replace(",", ".").Split('.')[0]);
		string text = num.ToString();
		string str = text;
		num = Convert.ToInt16(ipaddr.Replace(",", ".").Split('.')[1]);
		text = str + "." + num.ToString();
		string str2 = text;
		num = Convert.ToInt16(ipaddr.Replace(",", ".").Split('.')[2]);
		text = str2 + "." + num.ToString();
		string str3 = text;
		num = Convert.ToInt16(ipaddr.Replace(",", ".").Split('.')[3]);
		text = str3 + "." + num.ToString();
		return IPAddress.Parse(text);
	}

	public static void UDP_IncomingData(IAsyncResult ar)
	{
		try
		{
			IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8000);
			byte[] bytes = Common.udp.EndReceive(ar, ref iPEndPoint);
			Common.sb.Append(Encoding.UTF8.GetString(bytes).ToString());
			Common.udp.BeginReceive(Common.UDP_IncomingData, null);
		}
		catch (Exception ex)
		{
			Common.log.Error(ex.ToString());
		}
	}
}
