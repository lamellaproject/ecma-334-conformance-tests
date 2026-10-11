/*
Rules: E12-8-9-3-eligible-nonnested-class
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: reject
Mutate: this Cell receiver
Into: Cell receiver
*/
class Cell { }
class Container
{
    public static class Extensions { public static int Read(this Cell receiver) { return 3; } }
}
class Program { static void Main() { Container.Extensions.Read(new Cell()); } }
