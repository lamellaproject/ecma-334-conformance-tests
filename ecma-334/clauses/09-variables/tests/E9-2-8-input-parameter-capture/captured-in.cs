/*
Rules: E9-2-8-input-parameter-capture; E9-7-2-9-input-parameter-capture
Authority: ECMA-334 7th ed 9.2.8
Version: 7.3
Expected: reject
Mutate: () => value
Into: () => 31
Csc: CS1628
*/
class Program
{
    static System.Func<int> Capture(in int value) { return () => value; }
    static void Main() { int cell = 31; Capture(in cell); }
}
