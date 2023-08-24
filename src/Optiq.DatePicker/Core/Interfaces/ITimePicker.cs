using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiq.DatePicker.Core.Interfaces
{
    public interface ITimePicker : IView, ITextStyle
    {
        string Format { get; }

        TimeSpan? Time { get; set; }
    }
}
