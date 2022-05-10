using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TestAutomation.Core.Utilities.Helpers
{
    public static class WinAPIHelper
    {
        #region Enternal Libs Use

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        private const int MIN_ALL = 419;
        private const int WM_COMMAND = 0x111;

        #endregion Enternal Libs Use

        #region Public Methods

        public static void LeftMouseClick(int x, int y)
        {
            MoveCursorToPosition(x, y);
            PerformOneLeftMouseButtonClick(x, y);
        }

        public static void LeftMouseDoubleClick(int x, int y)
        {
            LeftMouseClick(x, y);
            Thread.Sleep(100);
            PerformOneLeftMouseButtonClick(x, y);
        }

        public static void GetCenterOfScreen(ref int x, ref int y)
        {
            x = Screen.PrimaryScreen.Bounds.Width / 2;
            y = Screen.PrimaryScreen.Bounds.Height / 2;
        }

        public static void GetScreenSize(ref int x, ref int y)
        {
            x = Screen.PrimaryScreen.Bounds.Width;
            y = Screen.PrimaryScreen.Bounds.Height;
        }

        public static void MinimizeAllWindows()
        {
            var window = FindWindow("Shell_TrayWnd", null);
            SendMessage(window, WM_COMMAND, MIN_ALL, 0);
        }

        public static void SendKey(string key)
        {
            SendKeys.Send(key);
        }

        public static void ClickAndHold(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            Thread.Sleep(100);
        }

        public static void MoveCursorToPosition(int x, int y)
        {
            SetCursorPos(x, y);
            Thread.Sleep(500);
        }

        public static void SendKeyWait(string key)
        {
            SendKeys.SendWait(key);
        }

        public static void PerformOneLeftMouseButtonUp(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            Thread.Sleep(100);
        }

        #endregion Public Methods

        #region Private Methods

        private static void PerformOneLeftMouseButtonClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        #endregion Private Methods

    }
}