using System.Drawing;
using Color = Microsoft.Maui.Graphics.Color;
using Font = Microsoft.Maui.Font;

namespace Optiq.DatePicker.Tests;

public class DatePickerStub
{
    public string Format { get; set; }

    public DateTime? Date { get; set; }

    public DateTime MinimumDate { get; set; }

    public DateTime MaximumDate { get; set; }

    public double CharacterSpacing { get; set; }

    public Font Font { get; set; }

    public Color TextColor { get; set; }
}