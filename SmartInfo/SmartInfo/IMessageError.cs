using System;
using System.Collections.Generic;
using System.Text;

namespace SmartInfo
{
  public  interface IMessageError
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
