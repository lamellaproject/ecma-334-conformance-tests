/*
Rules: E12-8-9-4-delegate-applicability
Authority: ECMA-334 7th ed 12.8.9.4
Version: 7.3
Expected: reject
Mutate: operation("pine")
Into: operation(5)
*/
delegate int Operation(int value);
class Program
{
    static int Read(int value) { return value; }
    static void Main() { Operation operation = Read; operation("pine"); }
}
