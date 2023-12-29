using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallDemos.Records
{
    public record Todo(string Name, string Description);

    //internal record Todo
    //{
    //    public string Name { get; set; } = "";
    //}
}
