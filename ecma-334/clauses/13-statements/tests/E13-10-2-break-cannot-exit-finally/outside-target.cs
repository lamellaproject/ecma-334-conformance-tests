/*
Rules: E13-10-2-break-cannot-exit-finally; E13-11-finally-break-target-inside
Authority: ECMA-334 7th ed 13.10.2
Version: 7.3
Expected: reject
Mutate: finally { break; }
Into: finally { while (true) { break; } }
*/
class Program
{
    static void Main() { while (true) { try { } finally { break; } } }
}
