using CoreFoundation;
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace Optiq.DatePicker.Platforms;

public class IOSDatePicker : NoCaretField
{
    public IOSDatePicker()
    {
        BorderStyle = UITextBorderStyle.RoundedRect;
        var picker = new UIDatePicker { Mode = UIDatePickerMode.Date, TimeZone = new NSTimeZone("UTC") };

        if (OperatingSystem.IsIOSVersionAtLeast(13, 4))
        {
            picker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
        }

        this.InputView = picker;
        var accessoryView = new DoneAccessoryView();
        this.InputAccessoryView = accessoryView;

        accessoryView.SetDataContext(this);
        accessoryView.SetDoneClicked(OnDoneClicked);

        this.InputView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
        this.InputAccessoryView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

        this.InputAssistantItem.LeadingBarButtonGroups = null;
        this.InputAssistantItem.TrailingBarButtonGroups = null;

        this.AccessibilityTraits = UIAccessibilityTrait.Button;

        this.EditingDidBegin += OnStarted;
        this.EditingDidEnd += OnEnded;
        picker.ValueChanged += OnValueChanged;
    }


    static void OnDoneClicked(object obj)
    {
        if (obj is IOSDatePicker mdp)
            mdp.MauiDatePickerDelegate?.DoneClicked();
    }

    void OnValueChanged(object? sender, EventArgs e) =>
        MauiDatePickerDelegate?.DatePickerValueChanged();

    void OnEnded(object? sender, EventArgs e) =>
        MauiDatePickerDelegate?.DatePickerEditingDidEnd();

    void OnStarted(object? sender, EventArgs e) =>
        MauiDatePickerDelegate?.DatePickerEditingDidBegin();

    internal MauiDatePickerDelegate? MauiDatePickerDelegate
    {
        get;
        set;
    }
}
   