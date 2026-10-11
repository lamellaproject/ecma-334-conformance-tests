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
    static int Probe(Cell cell) { int Read() { return cell.Value; } return Read(); }
    static void Main() { }
}
