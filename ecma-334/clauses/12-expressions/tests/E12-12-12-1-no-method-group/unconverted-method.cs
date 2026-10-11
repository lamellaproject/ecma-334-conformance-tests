/*
Rules: E12-12-12-1-no-method-group
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: reject
Mutate: Make is D
Into: ((D)Make) is D
*/
delegate int D();
class Program { static int Make() { return 3; } static void Main() { bool b = Make is D; } }
