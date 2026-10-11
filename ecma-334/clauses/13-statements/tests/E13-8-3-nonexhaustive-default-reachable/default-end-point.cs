/*
Rules: E13-8-3-nonexhaustive-default-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 3:
Into: case int any:
*/
class Program
{
    static int Read(int selector) { switch (selector) { case 3: return 4; default: break; } }
    static void Main() { }
}
