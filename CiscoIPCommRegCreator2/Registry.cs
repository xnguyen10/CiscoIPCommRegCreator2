using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoIPCommRegCreator2
{
    public class Registry
    {
        public string HostName { get; set; }

        public Registry(string hostname)
        {
            HostName = hostname;
        }

        public override string ToString()
        {
            return (@"Windows Registry Editor Version 5.00" + Environment.NewLine +
                        @"[HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Cisco Systems, Inc.\Communicator]" + Environment.NewLine +
                        "\"SoftPhoneData\"=\"C:\\\\Program Files (x86)\\\\Cisco Systems\\\\Cisco IP Communicator\\\\\"" + Environment.NewLine +
                        "\"Version\"=\"8.6.5.0\"" + Environment.NewLine +
                        "\"JVMGCPeriod\"=dword:0000ea60" + Environment.NewLine +
                        "\"ClassPath\"=\"win32sccp.jar\"" + Environment.NewLine +
                        "@=\"\"" + Environment.NewLine +
                        "\"InstalledLoadInformation\"=\"8.6.5.0\"" + Environment.NewLine +
                        "\"CmdLine\"=\"cip/sys/SystemManager.class\"" + Environment.NewLine +
                        "\"JVMPath\"=\"\"" + Environment.NewLine +
                        "\"JVMClassLoading\"=dword:00000000" + Environment.NewLine +
                        "\"JVMExecution\"=dword:00000000" + Environment.NewLine +
                        "\"JVMCall\"=dword:00000000" + Environment.NewLine +
                        "\"JVMBase\"=dword:00000000" + Environment.NewLine +
                        "\"JVMGarbageCollection\"=dword:00000000" + Environment.NewLine +
                        "\"JVMJNI\"=dword:00000000" + Environment.NewLine +
                        "\"JVMEnableDebugThread\"=dword:00000000" + Environment.NewLine +
                        "\"JVMDebugPort\"=dword:00001f41" + Environment.NewLine +
                        "\"JVMEnableMonitorThread\"=dword:00000000" + Environment.NewLine +
                        "\"JVMVerifier\"=dword:00000000" + Environment.NewLine +
                        "\"JVMUseSunJvm\"=dword:00000001" + Environment.NewLine +
                        "\"JVMTraceWait\"=dword:00000000" + Environment.NewLine +
                        "\"JVMPurpleMemory\"=dword:00895440" + Environment.NewLine +
                        "\"JVMTraceDynamicClasses\"=dword:00000000" + Environment.NewLine +
                        "\"JVMGCEnable\"=dword:00000000" + Environment.NewLine +
                        "\"JVMGCThreadPriority\"=dword:00000001" + Environment.NewLine +
                        "\"JVMHeapMemory\"=dword:00895440" + Environment.NewLine +
                        "\"LoadInformation\"=\".LOADS\"" + Environment.NewLine +
                        "\"SoftPhoneFileName\"=\"communicatork9.exe\"" + Environment.NewLine +
                        "\"NetworkCurrentAdapter\"=\"Intel(R) Ethernet Connection I219-LM\"" + Environment.NewLine +
                        "\"AlternateDeviceName\"=dword:00000001" + Environment.NewLine +
                        "\"NetworkTabUI\"=dword:00000002" + Environment.NewLine +
                        "\"CIPCProductCode\"=\"{7873926B-CE29-43A5-A811-17E39241AD7E}\"" + Environment.NewLine +
                        "\"UseSetVolume\"=dword:00000001" + Environment.NewLine +
                        "\"EnableHttpDownload\"=dword:00000001" + Environment.NewLine +
                        "\"UseDefaultDevices\"" +
                        "=dword:00000000" + Environment.NewLine +
                        "\"TftpServer1\"=dword:2abc4981" + Environment.NewLine +
                        "\"TftpServer2\"=dword:25bc4981" + Environment.NewLine +
                        "\"AlternateTftp\"=dword:00000001" + Environment.NewLine +
                        "\"HostName\"=\"" + HostName + "\"" + Environment.NewLine +
                        @"[HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Cisco Systems, Inc.\Communicator\Registered Handsets]" + Environment.NewLine +
                        @"[HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Cisco Systems, Inc.\Communicator\Registered Handsets\Clarisys]" + Environment.NewLine +
                        "\"Prog Id\"=\"ClarisysHandset.ClarisysHidHandset\"" + Environment.NewLine +
                        @"[HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Cisco Systems, Inc.\Communicator\Registered Handsets\GN Netcom]" + Environment.NewLine +
                        "\"Prog Id\"=\"GNNetcomHandset.GNNetcomHidHandset\"" + Environment.NewLine +
                        @"[HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Cisco Systems, Inc.\Communicator\Registered Handsets\PlantronicsHandler]" + Environment.NewLine +
                        "\"Prog Id\"=\"PlantronicsHandler.HidHandset\"" + Environment.NewLine);
        }
    }
}
