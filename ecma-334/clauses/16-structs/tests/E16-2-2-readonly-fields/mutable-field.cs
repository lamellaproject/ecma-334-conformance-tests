/*
Rules: E16-2-2-readonly-fields
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: reject
Mutate: public int Value;
Into: public readonly int Value;
*/
readonly struct Entry { public int Value; }
class Program { static void Main() { } }
