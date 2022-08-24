using System;
using System.Collections.Generic;
using System.Text;

namespace Azkar.Apps_Interface
{
    public interface ICustomNotification
    {
        void send(string title, string message);
    }
}
