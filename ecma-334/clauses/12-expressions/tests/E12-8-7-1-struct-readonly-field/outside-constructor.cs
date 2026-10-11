/*
Rules: E12-8-7-1-struct-readonly-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: public readonly int value;
Into: public int value;
Csc: CS0192
*/
struct Cell
{
    public readonly int value;
    public Cell(int value) { this.value = value; }
}
class Program
{
    static void Touch(ref int value) { value++; }
    static void Main() { Cell cell = new Cell(3); Touch(ref cell.value); }
}
