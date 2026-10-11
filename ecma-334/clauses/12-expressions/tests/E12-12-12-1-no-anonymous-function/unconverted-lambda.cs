/*
Rules: E12-12-12-1-no-anonymous-function
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: reject
Mutate: (() => 1) is D
Into: ((D)(() => 1)) is D
*/
delegate int D();
class Program { static void Main() { bool b = (() => 1) is D; } }
