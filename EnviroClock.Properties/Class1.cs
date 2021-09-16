

// EnviroClock.Properties.Settings
using EnviroClock.Properties;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
[CompilerGenerated]
public class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

	public static Settings Default
	{
		get
		{
			return Settings.defaultInstance;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("True")]
	public bool SYSTEM_LOG
	{
		get
		{
			return (bool)((SettingsBase)this)["SYSTEM_LOG"];
		}
		set
		{
			((SettingsBase)this)["SYSTEM_LOG"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	[UserScopedSetting]
	public bool TRANSACTION_LOG
	{
		get
		{
			return (bool)((SettingsBase)this)["TRANSACTION_LOG"];
		}
		set
		{
			((SettingsBase)this)["TRANSACTION_LOG"] = value;
		}
	}

	[DefaultSettingValue("True")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public bool COMMAND_LOG
	{
		get
		{
			return (bool)((SettingsBase)this)["COMMAND_LOG"];
		}
		set
		{
			((SettingsBase)this)["COMMAND_LOG"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("True")]
	public bool EXCEPTION_LOG
	{
		get
		{
			return (bool)((SettingsBase)this)["EXCEPTION_LOG"];
		}
		set
		{
			((SettingsBase)this)["EXCEPTION_LOG"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ERROR_LOG
	{
		get
		{
			return (bool)((SettingsBase)this)["ERROR_LOG"];
		}
		set
		{
			((SettingsBase)this)["ERROR_LOG"] = value;
		}
	}

	[DefaultSettingValue("1000")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public string Interval
	{
		get
		{
			return (string)((SettingsBase)this)["Interval"];
		}
		set
		{
			((SettingsBase)this)["Interval"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("2001")]
	public string PortNo
	{
		get
		{
			return (string)((SettingsBase)this)["PortNo"];
		}
		set
		{
			((SettingsBase)this)["PortNo"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	[UserScopedSetting]
	public int connected
	{
		get
		{
			return (int)((SettingsBase)this)["connected"];
		}
		set
		{
			((SettingsBase)this)["connected"] = value;
		}
	}

	[DefaultSettingValue("CLK")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public string ClockVersion
	{
		get
		{
			return (string)((SettingsBase)this)["ClockVersion"];
		}
		set
		{
			((SettingsBase)this)["ClockVersion"] = value;
		}
	}

	[DefaultSettingValue("12345")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public string MasterPassword
	{
		get
		{
			return (string)((SettingsBase)this)["MasterPassword"];
		}
		set
		{
			((SettingsBase)this)["MasterPassword"] = value;
		}
	}
}
