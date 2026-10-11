/*
Rules: E9-4-4-15-try-entry
Authority: ECMA-334 7th ed 9.4.4.15
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 4;
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int cell;
        try { System.Console.WriteLine(cell); }
        finally { }
    }
}
