using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

public static partial class WRTUITextInputNative
{
    [DllImport(WRTUINativeLibraryName.WUCTI, EntryPoint = WRTUINativeLibraryEntryPoint.DefaultEntryPoint)]
    public static extern int CreateTextInputProducer(nint consumer, out nint pProducer);
}
