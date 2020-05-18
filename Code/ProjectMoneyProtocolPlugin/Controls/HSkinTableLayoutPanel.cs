using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ProjectMoneyProtocolPlugin.Controls
{
	public class HSkinTableLayoutPanel : TableLayoutPanel
	{
		private Color borderColor = Color.Black;

		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				this.borderColor = value;
			}
		}

		public HSkinTableLayoutPanel()
		{
			base.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
		}

		protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
		{
			base.OnCellPaint(e);
			Pen pen = new Pen(this.BorderColor);
			int num = 0;
			int num2 = 0;
			if (e.CellBounds.X + e.CellBounds.Width == base.Width)
			{
				num = 1;
			}
			if (e.CellBounds.Y + e.CellBounds.Height == base.Height)
			{
				num2 = 1;
			}
			e.Graphics.DrawRectangle(pen, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - num, e.CellBounds.Height - num2);
		}
	}
}
