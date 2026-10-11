/*
Rules: E12-19-2-parameter-name-conflict
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: (int value) => value + 13
Into: (int inner) => inner + 13
*/
delegate int Transform(int item);
class Program { static void Main() { int value = 7; Transform function = (int value) => value + 13; } }
