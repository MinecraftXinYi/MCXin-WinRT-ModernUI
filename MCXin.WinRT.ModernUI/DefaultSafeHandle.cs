using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI;

internal partial class DefaultSafeHandle(nint invalidHandleValue, bool ownsHandle) : SafeHandle(invalidHandleValue, ownsHandle)
{
    public DefaultSafeHandle(nint handle) : this(handle, true) => SetHandle(handle);

    public override bool IsInvalid => handle != IntPtr.Zero;

    protected override bool ReleaseHandle() => true;
}
