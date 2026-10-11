/*
Rules: E16-2-2-readonly-no-setter
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: reject
Mutate: public int Value { get; set; }
Into: public int Value { get; }
*/
readonly struct Entry { public int Value { get; set; } }
class Program { static void Main() { } }
