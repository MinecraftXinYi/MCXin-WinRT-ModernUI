// See https://aka.ms/new-console-template for more information
using MinecraftXinYi.Windows.ModernUI.Core;
using System.Runtime.InteropServices;

[DllImport("shell32.dll", EntryPoint = "#61")]
[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
static extern int RunFileDlg(nint hwndParent, nint hIcon, string lpszDestDirectory, string lpszCaption, string lpszText, uint dwFlags);

Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.WriteLine($"Enable DPI Scaling: {HighDPISupport.EnableModernHighDPIScalingForThread()}");
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
RunFileDlg(0, 0, null!, null!, null!, 0);
