/*
Rules: E9-2-6-reference-parameter-capture; E9-7-2-9-reference-parameter-capture
Authority: ECMA-334 7th ed 9.2.6
Version: 7.3
Expected: reject
Mutate: () => value
Into: () => 17
Csc: CS1628
*/
class Program
{
    static System.Func<int> Capture(ref int value) { return () => value; }
    static void Main() { int cell = 17; Capture(ref cell); }
}
