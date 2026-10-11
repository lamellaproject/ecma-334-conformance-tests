/*
Rules: E15-6-11-ref-method-end-unreachable
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: if (choose) return ref slot;
Into: return ref slot;
*/
class Program { static int slot; static ref int Read(bool choose) { if (choose) return ref slot; } static void Main() { } }
