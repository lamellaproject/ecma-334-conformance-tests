/*
Rules: E12-8-13-struct-constructor-assignment
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: if (finish) this = default(Cell);
Into: this = default(Cell);
*/
struct Cell
{
    public int Value;
    public Cell(bool finish) { if (finish) this = default(Cell); }
}
class Program { static void Main() { new Cell(false); } }
