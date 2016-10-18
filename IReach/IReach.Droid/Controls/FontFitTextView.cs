using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace IReach.Droid.Controls
{
    public class FontFitTextView : TextView
    {

        public FontFitTextView(Context context) : base(context)
        {
            Initialize();
        }

        public FontFitTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        public FontFitTextView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public FontFitTextView(IntPtr pointer, JniHandleOwnership handle) : base(pointer, handle)
        {
        }

        Android.Graphics.Paint mTestPaint
        {
            get;
            set;
        }

        private void Initialize()
        {

            mTestPaint = new Paint();
            mTestPaint.Set(this.Paint);
            //max size defaults to the initially specified text size unless it is too small
        }

        private void RefitText(String text, int textWidth)
        {
            if (textWidth <= 0)
                return;
            int targetWidth = textWidth - this.PaddingLeft - this.PaddingRight;
            float hi = (float)MeasuredHeight * .8f;
            float lo = 2;
            float threshold = 0.5f; // How close we have to be

            mTestPaint.Set(this.Paint);

            while ((hi - lo) > threshold)
            {
                float size = (hi + lo) / 2;
                mTestPaint.TextSize = (size);
                if (mTestPaint.MeasureText(text) >= targetWidth)
                    hi = size; // too big
                else
                    lo = size; // too small
            }
            // Use lo so that we undershoot rather than overshoot
            this.SetTextSize(ComplexUnitType.Px, lo);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            int parentWidth = MeasureSpec.GetSize(widthMeasureSpec);
            int height = MeasuredHeight;
            RefitText(Text.ToString(), parentWidth);
            this.SetMeasuredDimension(parentWidth, height);
        }

        protected override void OnTextChanged(Java.Lang.ICharSequence text, int start, int before, int after)
        {
            RefitText(text.ToString(), Width);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            if (w != oldw)
            {
                RefitText(Text, w);
            }
        }
    }
}