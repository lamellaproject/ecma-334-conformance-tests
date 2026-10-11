/*
Rules: E16-4-8-no-instance-initializer
Authority: ECMA-334 7th ed 16.4.8
Version: 7.3
Expected: reject
Mutate: public int Value = 5;
Into: public int Value;
*/
struct Entry { public int Value = 5; public Entry(int value) { Value = value; } }
class Program { static void Main() { } }
