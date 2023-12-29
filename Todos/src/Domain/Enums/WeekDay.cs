using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;

internal enum WeekDay
{
    Tuesday,
    Monday,
    Wednesday, 
    Thursday,
    Friday
}

public class Test()
{
    public void test()
    {
         if (WeekDay.Monday == WeekDay.Tuesday);
    }
}
