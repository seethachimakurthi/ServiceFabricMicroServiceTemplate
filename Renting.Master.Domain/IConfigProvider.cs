using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Master.Domain
{
    public interface IConfigProvider
    {
        string GetVal(string key);
    }
}
