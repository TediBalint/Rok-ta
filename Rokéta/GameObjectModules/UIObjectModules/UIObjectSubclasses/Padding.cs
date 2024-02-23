using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses
{
	public class Padding
	{
		private int left;
		private int right;
		private int bottom;
		private int top;

		public int Left
		{
			get => left;
			set
			{
				if (left != value)
				{
					left = value;
					OnMarginChanged();
				}
			}
		}

		public int Right
		{
			get => right;
			set
			{
				if(right != value)
				{
					right = value;
					OnMarginChanged();
				}
			}
		}

		public int Top
		{
			get => top;
			set
			{
				if(top != value)
				{
					top = value;
					OnMarginChanged();
				}
			}
		}

		public int Bottom
		{
			get => bottom;
			set
			{
				if(bottom != value)
				{
					bottom = value;
					OnMarginChanged();
				}
			}
		}

		public int padX
		{
			set
			{
				left = right = value;
				OnMarginChanged();
			}
		}
		public int padY
		{
			set
			{
				top = bottom = value;
				OnMarginChanged();
			}
		}

		public event EventHandler PaddingChanged;
		public Padding(int padding) {
			left = bottom = top = right = padding;
		}
		public Padding(int padX, int padY) { 
			left = right = padX;
			top = bottom = padY;
		}
		public Padding(int _top, int _right, int _bottom,  int _left)
		{
			bottom = _bottom;
			top = _top;
			left = _left;
			right = _right;
		}
		protected void OnMarginChanged()
		{
			PaddingChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
