using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Xunit;

namespace Optiq.DatePicker.Tests;
public class TimePickerUnitTest
{

    [Fact]
    public void TestConstructor()
    {
        TimePicker picker = new TimePicker();

        Assert.Null(picker.Time);
    }

    [Fact]
    public void TestTimeOutOfRange()
    {
        var picker = new TimePicker
        {
            Time = new TimeSpan(0, 0, 0)
        };

        picker.Time = new TimeSpan(8, 30, 0);
        
        Assert.Throws<ArgumentException>(() => picker.Time = new TimeSpan(-1, 0, 0));
    }
}
