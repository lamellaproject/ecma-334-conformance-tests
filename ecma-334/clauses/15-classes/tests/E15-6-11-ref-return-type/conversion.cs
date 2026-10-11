/*
Rules: E15-6-11-ref-return-type
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: ref narrow;
Into: ref slot;
*/
class Program { static short narrow; static int slot; static ref int Read() { return ref narrow; } static void Main() { } }
