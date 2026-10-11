/*
Rules: E15-6-11-ref-return-safe-context
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: return ref local;
Into: return ref slot;
*/
class Program { static int slot; static ref int Read() { int local = 22; return ref local; } static void Main() { } }
