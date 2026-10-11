/*
Rules: E12-23-constructs-only; E12-23-constant-context-required; E12-23-constant-declaration-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: const int Value = Compute();
Into: const int Value = 4;
Csc: CS0133
*/
class Program
{
    static int Compute() { return 4; }
    const int Value = Compute();
    static void Main() { }
}
