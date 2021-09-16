using EnviroClock;
using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;

public static class Access
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	public static void GrantAccess(string fullPath)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
			WindowsIdentity current = WindowsIdentity.GetCurrent();
			DirectorySecurity accessControl = directoryInfo.GetAccessControl();
			accessControl.AddAccessRule(new FileSystemAccessRule(current.Name, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
		}
		catch (Exception ex)
		{
			Access.log.Error(ex.ToString());
		}
	}
}
