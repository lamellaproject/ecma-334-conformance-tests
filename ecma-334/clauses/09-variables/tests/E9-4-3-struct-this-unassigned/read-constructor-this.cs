/*
Rules: E9-4-3-struct-this-unassigned
Authority: ECMA-334 7th ed 9.4.3
Version: 7.3
Expected: reject
Mutate: Read(this);
Into: Read(new Cell());
Csc: CS0188
*/
struct Cell
{
    public int Value;
    public Cell(int value) { Read(this); Value = value; }
    static void Read(Cell value) { System.Console.WriteLine(value.Value); }
}
class Program { static void Main() { new Cell(42); } }
