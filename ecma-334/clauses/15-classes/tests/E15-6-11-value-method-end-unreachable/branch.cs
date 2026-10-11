/*
Rules: E15-6-11-value-method-end-unreachable
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: if (choose) return 12;
Into: return 12;
*/
class Program { static int Read(bool choose) { if (choose) return 12; } static void Main() { } }
