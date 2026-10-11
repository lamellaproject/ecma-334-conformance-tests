/*
Rules: E13-8-3-break-switch-end-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 3: break;
Into: case 3: return 4;
*/
class Program
{
    static int Read() { switch (3) { case 3: break; default: return 5; } }
    static void Main() { }
}
