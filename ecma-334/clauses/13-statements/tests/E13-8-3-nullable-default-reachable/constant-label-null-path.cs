/*
Rules: E13-8-3-nullable-default-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: int amount;
Into: int amount = 3;
*/
class Program
{
    static int Read(bool? flag) { int amount; switch (flag) { case true: return 1; case false: return 2; default: return amount; } }
    static void Main() { }
}
