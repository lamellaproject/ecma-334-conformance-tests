/*
Rules: E12-8-8-projection-form
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: reject
Mutate: new { receiver?.Read() }
Into: new { Number = receiver?.Read() }
*/
class Cell { public int Read() { return 3; } }
class Program
{
    static void Main()
    {
        Cell receiver = null;
        var projection = new { receiver?.Read() };
    }
}
