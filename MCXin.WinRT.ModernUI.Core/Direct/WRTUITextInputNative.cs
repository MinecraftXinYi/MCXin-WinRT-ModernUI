using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

public static partial class WRTUITextInputNative
{
#if NET8_0_OR_GREATER
    [LibraryImport
#else
    [DllImport
#endif
        (WRTUINativeLibraryName.WUCTI, EntryPoint = WRTUINativeLibraryEntryPoint.DefaultEntryPoint, SetLastError = true), PreserveSig]
    public static
#if NET8_0_OR_GREATER
        partial
#else
        extern
#endif
        int CreateTextInputProducer(nint consumer, out nint pProducer);
}
