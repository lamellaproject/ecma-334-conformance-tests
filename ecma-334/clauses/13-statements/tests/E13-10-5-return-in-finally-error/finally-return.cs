/*
Rules: E13-10-5-return-in-finally-error; E13-11-finally-return-error
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return;
Into: ;
*/

class Program
{
    static void Finish() { try { } finally { return; } }
    static void Main() { }
}
