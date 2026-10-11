/*
Rules: E9-4-4-31-anonymous-parameter-state
Authority: ECMA-334 7th ed 9.4.4.31
Version: 7.3
Expected: reject
Mutate: System.Console.WriteLine(value);
Into: System.Console.WriteLine(0);
Csc: CS0269
*/
delegate void Output(out int value);
class Program
{
    static void Main()
    {
        Output output = (out int value) => { System.Console.WriteLine(value); value = 3; };
        int cell;
        output(out cell);
    }
}
