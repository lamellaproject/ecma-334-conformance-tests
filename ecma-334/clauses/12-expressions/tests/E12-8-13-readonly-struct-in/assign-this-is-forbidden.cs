/*
Rules: E12-8-13-readonly-struct-in
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: this = new Cell(9);
Into: Cell copy = new Cell(9);
*/
readonly struct Cell
{
    public readonly int Value;
    public Cell(int value) { Value = value; }
    public Cell Changed() { this = new Cell(9); return this; }
}
class Program { static void Main() { new Cell(3).Changed(); } }
