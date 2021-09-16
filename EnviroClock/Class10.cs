

// EnviroClock.ServiceCommunication
using EnviroClock;
using log4net;
using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

public class ServiceCommunication
{
	public enum ReturnValues
	{
		TimeOut = -3,
		BadResponse,
		NetworkError,
		Success,
		Failed,
		Duplicate,
		DatabaseError
	}

	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	private Socket client;

	public ServiceCommunication(string IPAddress, string PortNo)
	{
		Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		IAsyncResult asyncResult = socket.BeginConnect(IPAddress, Convert.ToInt32(PortNo), null, null);
		bool flag = asyncResult.AsyncWaitHandle.WaitOne(1500, true);
		this.client = socket;
	}

	public ReturnValues SendResetCommand(byte slaveno, string commandText, out string returnResponse, int flag, string time, out string error)
	{
		try
		{
			returnResponse = "";
			string empty = string.Empty;
			string empty2 = string.Empty;
			byte[] array = new byte[2048];
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			byte[] array2 = new byte[2];
			byte[] bytes = Encoding.Default.GetBytes(commandText);
			byte[] array3 = new byte[bytes.Length + 2 + 2 + 2];
			array3[0] = 0;
			array3[1] = slaveno;
			for (int i = 0; i < bytes.Length; i++)
			{
				array3[i + 2] = bytes[i];
			}
			ServiceCommunication.GetCRCByByte(array3, bytes.Length + 2, ref array2);
			array3[0] = 36;
			int num = array2[0];
			num &= 0xFF;
			array3[array3.Length - 4] = this.IntToHexByte(num / 16);
			array3[array3.Length - 3] = this.IntToHexByte(num % 16);
			array3[array3.Length - 2] = 44;
			array3[array3.Length - 1] = 13;
			string @string = Encoding.Default.GetString(array3);
			int receiveTimeout = 1000;
			this.client.SendTimeout = 3000;
			int num2 = this.client.Send(array3, 0, array3.Length, SocketFlags.None);
			byte[] array4 = new byte[10000];
			this.client.ReceiveTimeout = receiveTimeout;
			int num3 = this.client.Receive(array4);
			empty2 = Encoding.Default.GetString(array4);
			returnResponse = empty2.Replace("\0", string.Empty);
			error = "";
			this.client.Close();
			return ReturnValues.Success;
		}
		catch (Exception)
		{
			string text = error = "";
			returnResponse = "";
			return ReturnValues.Success;
		}
	}

	public ReturnValues SendCommand(byte slaveno, string commandText, out string returnResponse, int flag, string time, out string error)
	{
		try
		{
			returnResponse = "";
			string empty = string.Empty;
			string empty2 = string.Empty;
			byte[] array = new byte[2048];
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			byte[] array2 = new byte[2];
			byte[] bytes = Encoding.Default.GetBytes(commandText);
			byte[] array3 = new byte[bytes.Length + 2 + 2 + 2];
			array3[0] = 0;
			array3[1] = slaveno;
			for (int i = 0; i < bytes.Length; i++)
			{
				array3[i + 2] = bytes[i];
			}
			ServiceCommunication.GetCRCByByte(array3, bytes.Length + 2, ref array2);
			array3[0] = 36;
			int num = array2[0];
			num &= 0xFF;
			array3[array3.Length - 4] = this.IntToHexByte(num / 16);
			array3[array3.Length - 3] = this.IntToHexByte(num % 16);
			array3[array3.Length - 2] = 44;
			array3[array3.Length - 1] = 13;
			string @string = Encoding.Default.GetString(array3);
			int receiveTimeout = 1000;
			this.client.SendTimeout = 3000;
			int num2 = this.client.Send(array3, 0, array3.Length, SocketFlags.None);
			byte[] array4 = new byte[10000];
			this.client.ReceiveTimeout = receiveTimeout;
			int num3 = this.client.Receive(array4);
			empty2 = Encoding.Default.GetString(array4);
			returnResponse = empty2.Replace("\0", string.Empty);
			error = "";
			this.client.Close();
			return ReturnValues.Success;
		}
		catch (Exception ex)
		{
			ServiceCommunication.log.Error(ex.ToString());
			string text = error = "";
			returnResponse = "";
			return ReturnValues.Failed;
		}
	}

	public static string GetCRCByByte(byte[] message, int len, ref byte[] CRC)
	{
		string empty = string.Empty;
		try
		{
			CRC[0] = 0;
			for (int i = 0; i < len; i++)
			{
				CRC[0] = (byte)(CRC[0] ^ message[i]);
			}
			int num = CRC[0];
			num &= 0xFF;
			return num.ToString("X2");
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	private byte IntToHexByte(int data1)
	{
		if (data1 >= 0 && data1 <= 9)
		{
			return (byte)(data1 + 48);
		}
		int num = data1 - 10 + 65;
		return (byte)num;
	}
}
