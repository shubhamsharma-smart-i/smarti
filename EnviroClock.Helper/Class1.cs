

// EnviroClock.Helper.CommonHelper
using EnviroClock.Entity;
using EnviroClock.Helper;
using log4net;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

public static class CommonHelper
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	public static SettingParam ReaderXML()
	{
		SettingParam result = new SettingParam();
		try
		{
			string inputUri = Application.StartupPath + "/Usercredentials.xml";
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingParam));
			using (XmlReader xmlReader = XmlReader.Create(inputUri))
			{
				result = (SettingParam)xmlSerializer.Deserialize(xmlReader);
				xmlReader.Close();
				xmlReader.Dispose();
			}
		}
		catch (Exception message)
		{
			CommonHelper.log.Error(message);
		}
		return result;
	}

	public static bool WriteXML(SettingParam obj)
	{
		bool result = false;
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load("Usercredentials.xml");
			xmlDocument.SelectSingleNode("SettingParam/Password").InnerText = obj.Password;
			xmlDocument.SelectSingleNode("SettingParam/SceduleParam1").InnerText = obj.SceduleParam1;
			xmlDocument.SelectSingleNode("SettingParam/SceduleParam2").InnerText = obj.SceduleParam2;
			xmlDocument.Save("Usercredentials.xml");
			return true;
		}
		catch (Exception message)
		{
			CommonHelper.log.Error(message);
		}
		return result;
	}

	public static string Encrypt(string text)
	{
		try
		{
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			byte[] inArray = uTF8Encoding.GetBytes(text).ToArray();
			return Convert.ToBase64String(inArray);
		}
		catch (Exception message)
		{
			CommonHelper.log.Error(message);
			return "";
		}
	}

	public static string Decrypt(string text)
	{
		try
		{
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			byte[] bytes = Convert.FromBase64String(text);
			return uTF8Encoding.GetString(bytes);
		}
		catch (Exception message)
		{
			CommonHelper.log.Error(message);
			return "";
		}
	}
}
