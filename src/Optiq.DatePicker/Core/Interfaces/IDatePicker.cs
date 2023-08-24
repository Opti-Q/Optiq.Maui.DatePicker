namespace Optiq.DatePicker.Core.Interfaces;

public interface IDatePicker : IView, ITextStyle
{
    string Format { get; set; }
    DateTime? Date { get; set; }
    DateTime MinimumDate { get; }
    DateTime MaximumDate { get; }
}