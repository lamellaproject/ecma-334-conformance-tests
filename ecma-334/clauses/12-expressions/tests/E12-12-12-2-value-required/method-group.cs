/*
Rules: E12-12-12-2-value-required
Authority: ECMA-334 7th ed 12.12.12.2
Version: 7.3
Expected: reject
Mutate: Make is var value
Into: ((D)Make) is var value
*/
delegate int D();
class Program { static int Make() { return 3; } static void Main() { bool b = Make is var value; } }
