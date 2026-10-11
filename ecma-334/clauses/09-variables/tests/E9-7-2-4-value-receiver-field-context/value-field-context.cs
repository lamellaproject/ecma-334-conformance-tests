/*
Rules: E9-7-2-4-value-receiver-field-context
Authority: ECMA-334 7th ed 9.7.2.4
Version: 7.3
Expected: reject
Mutate: Select(Cell cell)
Into: Select(ref Cell cell)
Csc: CS8167
*/
struct Cell { public int Value; }
class Program
{
    static ref int Select(Cell cell) { return ref cell.Value; }
    static void Main() { }
}
