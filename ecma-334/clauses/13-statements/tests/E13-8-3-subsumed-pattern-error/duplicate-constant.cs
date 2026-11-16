/*
Rules: E13-8-3-subsumed-pattern-error
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 7: ; break;
Into: case 8: ; break;
*/
class Program
{
    static void Read(int value) { switch (value) { case 7: break; case 7: ; break; } }
    static void Main() { }
}
