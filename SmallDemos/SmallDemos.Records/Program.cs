// See https://aka.ms/new-console-template for more information
using SmallDemos.Records;

Console.WriteLine("Hello, World!");


var todo1 = new Todo("name");

var todo2 = new Todo()
{
    Name = "2",
};

Console.WriteLine(todo1 == todo2);

todo1.Name = "2";
