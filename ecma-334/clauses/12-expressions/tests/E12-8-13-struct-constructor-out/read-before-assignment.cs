/*
Rules: E12-8-13-struct-constructor-out
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: Observe(ref this);
Into: this = default(Cell); Observe(ref this);
*/
struct Cell
{
    public int Value;
    static void Observe(ref Cell value) { }
    public Cell(int value) { Observe(ref this); Value = value; }
}
class Program { static void Main() { new Cell(4); } }
