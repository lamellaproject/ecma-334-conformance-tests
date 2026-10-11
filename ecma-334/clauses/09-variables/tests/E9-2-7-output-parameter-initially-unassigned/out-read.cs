/*
Rules: E9-2-7-output-parameter-initially-unassigned; E9-4-3-output-parameter-unassigned; E9-4-4-2-function-entry-unassigned
Authority: ECMA-334 7th ed 9.2.7
Version: 7.3
Expected: reject
Mutate: System.Console.WriteLine(value);
Into: System.Console.WriteLine(0);
Csc: CS0269
*/
class Program
{
    static void Fill(out int value) { System.Console.WriteLine(value); value = 5; }
    static void Main() { int cell = 99; Fill(out cell); }
}
