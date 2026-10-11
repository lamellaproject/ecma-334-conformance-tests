/*
Rules: E13-8-3-constant-switch-end-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: switch (3)
Into: switch (4)
*/
class Program
{
    static int Read() { switch (3) { case 4: return 5; } }
    static void Main() { }
}
