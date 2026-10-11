/*
Rules: E9-4-4-15-finally-entry
Authority: ECMA-334 7th ed 9.4.4.15
Version: 7.3
Expected: reject
Mutate: System.Console.WriteLine(cell);
Into: System.Console.WriteLine(0);
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int cell;
        try { cell = 24; }
        finally { System.Console.WriteLine(cell); }
    }
}
