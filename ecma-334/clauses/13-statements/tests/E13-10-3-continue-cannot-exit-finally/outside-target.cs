/*
Rules: E13-10-3-continue-cannot-exit-finally; E13-11-finally-continue-target-inside
Authority: ECMA-334 7th ed 13.10.3
Version: 7.3
Expected: reject
Mutate: finally { continue; }
Into: finally { for (int inner = 0; inner < 1; inner++) { continue; } }
*/
class Program
{
    static void Main() { for (int outer = 0; outer < 1; outer++) { try { } finally { continue; } } }
}
