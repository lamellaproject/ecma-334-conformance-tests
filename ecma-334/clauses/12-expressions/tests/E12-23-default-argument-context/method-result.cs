/*
Rules: E12-23-default-argument-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: int number = Compute()
Into: int number = 7
Csc: CS1736
*/
class Program
{
    static int Compute() { return 7; }
    static void Use(int number = Compute()) { }
    static void Main() { Use(); }
}
