/*
Rules: E12-19-2-declaration-space
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: int value = 7;
Into: int local = 7;
*/
delegate int Transform(int value);
class Program { static void Main() { Transform function = (int value) => { int value = 7; return value; }; } }
