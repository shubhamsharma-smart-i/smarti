

// EnviroClock.ServiceResponse
using EnviroClock;
using log4net;
using System;
using System.Reflection;

public class ServiceResponse
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	public static string GetFormattedIP(string Ipaddress)
	{
		string[] array = Ipaddress.Split('.');
		if (array[3].StartsWith("0"))
		{
			return array[0] + "." + array[1] + "." + array[2] + "." + array[3].Remove(0, 1);
		}
		return Ipaddress;
	}

	public static bool SetResponse(string Command, string IPAddress, string Port)
	{
		try
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			ServiceCommunication serviceCommunication = new ServiceCommunication(ServiceResponse.GetFormattedIP(IPAddress), Port);
			int num = 0;
            //try
            //{
            //    num = Convert.ToInt16(ServiceResponse.GetResponse("lu,100,", 2, IPAddress, Port));
            //}
            //catch
            //{
            //    return false;
            //}
            DateTime now;
			ServiceCommunication.ReturnValues returnValues;
			if (Command == "lM,10,123,")
			{
				ServiceCommunication serviceCommunication2 = serviceCommunication;
				byte commandPrefix = ServiceResponse.GetCommandPrefix(num);
				now = DateTime.Now;
				returnValues = serviceCommunication2.SendResetCommand(commandPrefix, Command, out empty2, 0, now.ToString(), out empty);
			}
			else
			{
				ServiceCommunication serviceCommunication3 = serviceCommunication;
				byte commandPrefix2 = ServiceResponse.GetCommandPrefix(num);
				now = DateTime.Now;
				returnValues = serviceCommunication3.SendCommand(commandPrefix2, Command, out empty2, 0, now.ToString(), out empty);
			}
			if (returnValues == ServiceCommunication.ReturnValues.Success)
			{
				ServiceResponse.log.Debug("\n command is  " + Command + " Receive Data " + empty2);
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ServiceResponse.log.Error(ex.ToString());
			ServiceResponse.log.Error("Command Not Responded.");
			return false;
		}
	}

	public static string GetResponse(string Command, int para, string IPAddress, string Port)
	{
		try
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			ServiceCommunication serviceCommunication = new ServiceCommunication(ServiceResponse.GetFormattedIP(IPAddress), Port);
			if (serviceCommunication.SendCommand(ServiceResponse.GetCommandPrefix(0), Command, out empty2, 0, DateTime.Now.ToString(), out empty) == ServiceCommunication.ReturnValues.Success)
			{
				ServiceResponse.log.Debug("\n command is " + Command + " Receive Data  " + empty2);
				return empty2.Split(',')[Convert.ToInt32(para)].ToString();
			}
			ServiceResponse.log.Debug("\n command is " + Command + " Receive Data  " + empty2);
			return "";
		}
		catch (Exception ex)
		{
			ServiceResponse.log.Error(ex.ToString());
			ServiceResponse.log.Error("Command Not Responded.");
			return "";
		}
	}

	public static byte GetCommandPrefix(int Slaveid)
	{
		byte result = 0;
		try
		{
			result = (byte)(Slaveid + 48);
		}
		catch (Exception ex)
		{
			ServiceResponse.log.Error(ex.ToString());
		}
		return result;
	}
}
