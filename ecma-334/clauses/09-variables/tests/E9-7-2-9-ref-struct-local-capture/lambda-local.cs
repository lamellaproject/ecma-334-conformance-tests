/*
Rules: E9-7-2-9-ref-struct-local-capture
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: ref struct Cell
Into: struct Cell
Csc: CS8175
*/
ref struct Cell { public int Value; }
class Program
{
    static void Main()
    {
        Cell cell = new Cell { Value = 42 };
        System.Func<int> read = () => cell.Value;
        read();
    }
}
