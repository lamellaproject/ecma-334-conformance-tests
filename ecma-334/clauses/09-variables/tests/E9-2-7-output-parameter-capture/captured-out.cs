/*
Rules: E9-2-7-output-parameter-capture; E9-7-2-9-output-parameter-capture
Authority: ECMA-334 7th ed 9.2.7
Version: 7.3
Expected: reject
Mutate: () => value
Into: () => 25
Csc: CS1628
*/
class Program
{
    static System.Func<int> Capture(out int value) { value = 25; return () => value; }
    static void Main() { int cell; Capture(out cell); }
}
