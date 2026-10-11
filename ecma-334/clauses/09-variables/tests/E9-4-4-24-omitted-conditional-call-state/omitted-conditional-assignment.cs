/*
Rules: E9-4-4-24-omitted-conditional-call-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 0;
Csc: CS0165
*/
class Program
{
    [System.Diagnostics.Conditional("SUITE_NEVER_DEFINED")]
    static void Omit(int value) { }
    static void Main() { int cell; Omit(cell = 33); System.Console.WriteLine(cell); }
}
