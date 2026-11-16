/*
Rules: E13-8-3-nonconstant-case-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: switch (selector)
Into: switch (8)
*/
class Program
{
    static int Read(int selector) { int amount; switch (selector) { case 7: return amount; default: return 3; } }
    static void Main() { }
}
