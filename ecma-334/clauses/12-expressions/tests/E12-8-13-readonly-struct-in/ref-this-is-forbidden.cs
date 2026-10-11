/*
Rules: E12-8-13-readonly-struct-in
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: Touch(ref this)
Into: Touch(ref copy)
*/
readonly struct Cell
{
    public readonly int Value;
    public Cell(int value) { Value = value; }
    static void Touch(ref Cell cell) { cell = new Cell(7); }
    public void Act() { Cell copy = this; Touch(ref this); }
}
class Program { static void Main() { new Cell(3).Act(); } }
