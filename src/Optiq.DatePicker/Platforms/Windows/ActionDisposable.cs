using System.Threading;
using System;

namespace Optiq.DatePicker.Platforms;

class ActionDisposable : IDisposable
{
    volatile Action? _action;

    public ActionDisposable(Action action)
    {
        _action = action;
    }

    public void Dispose()
    {
        Interlocked.Exchange(ref _action, null)?.Invoke();
    }
}