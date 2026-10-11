/*
Rules: E12-23-enum-declaration-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: Code = Program.Compute()
Into: Code = 7
Csc: CS0133
*/
enum Label { Code = Program.Compute() }
class Program
{
    public static int Compute() { return 7; }
    static void Main() { }
}
