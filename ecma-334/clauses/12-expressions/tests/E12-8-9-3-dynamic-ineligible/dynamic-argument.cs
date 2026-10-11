/*
Rules: E12-8-9-3-dynamic-ineligible
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: reject
Mutate: receiver.Read(argument)
Into: receiver.Read((int)argument)
*/
class Cell { }
static class Extensions { public static int Read(this Cell receiver, int value) { return value; } }
class Program
{
    static void Main() { Cell receiver = new Cell(); dynamic argument = 5; receiver.Read(argument); }
}
