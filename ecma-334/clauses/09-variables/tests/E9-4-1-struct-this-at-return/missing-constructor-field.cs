/*
Rules: E9-4-1-struct-this-at-return
Authority: ECMA-334 7th ed 9.4.1
Version: 7.3
Expected: reject
Mutate: public Cell(int value) { Left = value; }
Into: public Cell(int value) { Left = value; Right = 0; }
Csc: CS0171
*/
struct Cell
{
    public int Left, Right;
    public Cell(int value) { Left = value; }
}
class Program { static void Main() { new Cell(31); } }
