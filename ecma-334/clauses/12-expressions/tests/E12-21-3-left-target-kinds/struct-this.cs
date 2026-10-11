/*
Rules: E12-21-3-left-target-kinds
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: reject
Mutate: this = ref other
Into: this = other
Csc: CS8373
*/
struct Cell
{
    public int Value;
    public void Move(ref Cell other) { this = ref other; }
}
class Program
{
    static void Main() { Cell first = new Cell(), second = new Cell(); first.Move(ref second); }
}
