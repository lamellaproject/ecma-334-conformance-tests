/*
Rules: E9-4-4-8-false-state-body-transfer
Authority: ECMA-334 7th ed 9.4.4.8
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 0;
Csc: CS0165
*/
class Program
{
    static void Read(bool gate)
    {
        int cell;
        while (gate || (cell = 14) < 0) { System.Console.WriteLine(cell); gate = false; }
    }
    static void Main() { Read(true); }
}
