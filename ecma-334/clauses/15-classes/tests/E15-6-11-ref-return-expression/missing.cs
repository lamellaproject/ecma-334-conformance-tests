/*
Rules: E15-6-11-ref-return-expression
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: return;
Into: return ref slot;
*/
class Program { static int slot; static ref int Read() { return; } static void Main() { } }
