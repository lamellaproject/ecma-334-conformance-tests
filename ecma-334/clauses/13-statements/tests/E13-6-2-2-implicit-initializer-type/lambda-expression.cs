/*
Rules: E13-6-2-2-implicit-initializer-type
Authority: ECMA-334 7th ed 13.6.2.2
Version: 7.3
Expected: reject
Mutate: var item = () => 6;
Into: Compute item = () => 6;
*/
delegate int Compute();
class Program { static void Main() { var item = () => 6; } }
