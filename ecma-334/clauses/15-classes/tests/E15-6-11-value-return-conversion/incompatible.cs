/*
Rules: E15-6-11-value-return-conversion
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: return "six";
Into: return 6;
*/
class Program { static int Read() { return "six"; } static void Main() { } }
