/*
Rules: E12-19-2-parameter-name-conflict
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: (int value) => value + 17
Into: (int inner) => inner + 17
*/
delegate int Transform(int item);
class Program { static void Main() { const int value = 7; Transform function = (int value) => value + 17; } }
