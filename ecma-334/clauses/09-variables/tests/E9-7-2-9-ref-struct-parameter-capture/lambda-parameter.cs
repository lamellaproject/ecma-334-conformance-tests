/*
Rules: E9-7-2-9-ref-struct-parameter-capture
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: ref struct Cell
Into: struct Cell
Csc: CS9108
*/
ref struct Cell { public int Value; }
class Program
{
    static System.Func<int> Capture(Cell cell) { return () => cell.Value; }
    static void Main() { }
}
