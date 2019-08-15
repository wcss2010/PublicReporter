using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjectReporter.Utility
{
	public class WatermarkUtility
	{
		private const int EM_SETCUEBANNER = 5377;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		public static void SetWatermark(TextBox textBox, string watermark)
		{
			WatermarkUtility.SendMessage(textBox.Handle, 5377, 0, watermark);
		}

		public static void ClearWatermark(TextBox textBox)
		{
			WatermarkUtility.SendMessage(textBox.Handle, 5377, 0, string.Empty);
		}
	}
}
