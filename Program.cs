using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        const uint MONITOR_DEFAULTTONEAREST = 2;
        Console.WriteLine("Program Started");

        IntPtr handle = GetForegroundWindow();
        IntPtr monitorHandle = MonitorFromWindow(handle, MONITOR_DEFAULTTONEAREST);

        bool ok = EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MyMonitorEnumCallback, IntPtr.Zero);

        Console.WriteLine($"Foreground Window Handle: {handle}");
        Console.WriteLine($"Monitor: {monitorHandle}");
        Console.WriteLine($"Monitors Connected: {ok}");
    }

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

    [DllImport("user32.dll")]
    static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumProc lpfnEnum, IntPtr dwData);

    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdc, ref RECT rect, IntPtr dwData);

    static bool MyMonitorEnumCallback(IntPtr hMonitor, IntPtr hdc, ref RECT rect, IntPtr dwData)
    {
        Console.WriteLine($"Monitor found: {hMonitor}  RECT=({rect.left},{rect.top})-({rect.right},{rect.bottom})");
        return true;
    }
}
