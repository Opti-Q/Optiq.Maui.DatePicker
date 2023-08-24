using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Util;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Graphics.Drawable;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Optiq.DatePicker.Platforms;

public class AndroidDatePicker : AppCompatEditText, Android.Views.View.IOnClickListener
{
    public AndroidDatePicker(Context context) : base(context)
    {
        Initialize();
    }

    public AndroidDatePicker(Context context, IAttributeSet? attrs) : base(context, attrs)
    {
        Initialize();
    }

    public AndroidDatePicker(Context context, IAttributeSet? attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
    {
        Initialize();
    }

    protected AndroidDatePicker(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
    }

    public Action? ShowPicker { get; set; }
    public Action? HidePicker { get; set; }


    void Initialize()
    {
        if (Background != null)
            DrawableCompat.Wrap(Background);

        Focusable = true;
        FocusableInTouchMode = false;
        Clickable = true;
        InputType = InputTypes.Null;

        SetOnClickListener(this);
    }

    public void OnClick(Android.Views.View? v)
    {
        ShowPicker?.Invoke();
    }
}