/*
Rules: E12-8-13-context
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: return this;
Into: return new Box();
*/
class Box { public static Box Get() { return this; } }
class Program { static void Main() { Box.Get(); } }
