namespace Optiq.DatePicker.Core;

public interface IDatePicker : IView, ITextStyle
{
    string Format { get; set; }
    DateTime? Date { get; set; }
    DateTime MinimumDate { get; }
    DateTime MaximumDate { get; }
}