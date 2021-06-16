using System;

namespace MgMvvmTools
{
    public class Command : Command<object>
    {
        public Command(Action execute) : base(execute) { }

        public Command(Action<object> execute) : base(execute) { }

        public Command(Action execute, Func<bool> canExecute) : base(execute, canExecute) { }

        public Command(Action<object> execute, Func<object, bool> canExecute) : base(execute, canExecute) { }
    }
}