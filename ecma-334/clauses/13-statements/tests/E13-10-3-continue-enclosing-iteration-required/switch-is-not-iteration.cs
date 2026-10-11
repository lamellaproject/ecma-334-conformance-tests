/*
Rules: E13-10-3-continue-enclosing-iteration-required
Authority: ECMA-334 7th ed 13.10.3
Version: 7.3
Expected: reject
Mutate: continue;
Into: break;
*/
class Program
{
    static void Main() { int value = 1; switch (value) { default: continue; } }
}
