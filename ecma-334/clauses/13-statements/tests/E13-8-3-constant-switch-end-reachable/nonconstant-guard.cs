/*
Rules: E13-8-3-constant-switch-end-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 3 when flag:
Into: case 3 when true:
*/
class Program
{
    static int Read(bool flag) { switch (3) { case 3 when flag: return 4; } }
    static void Main() { }
}
