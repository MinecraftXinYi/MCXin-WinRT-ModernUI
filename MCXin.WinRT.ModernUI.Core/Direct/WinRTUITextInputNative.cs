using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

public static partial class WinRTUITextInputNative
{
    [LibraryImport(WinRTUILibraryName.WUCTI, EntryPoint = "#1500")]
    public static partial int CreateTextInputProducer(nint consumer, out nint pProducer);
}
