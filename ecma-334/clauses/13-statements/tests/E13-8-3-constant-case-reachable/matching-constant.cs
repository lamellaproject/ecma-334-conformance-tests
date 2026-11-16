/*
Rules: E13-8-3-constant-case-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: switch (7)
Into: switch (8)
*/
class Program
{
    static int Read() { int amount; switch (7) { case 7: return amount; default: return 3; } }
    static void Main() { }
}
