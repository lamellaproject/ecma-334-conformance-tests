/*
Rules: E15-4-constant-expression-conversion
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const double Fraction = 1.25m;
Into: public const double Fraction = 1.25d;
Csc: CS0266
*/
class Limits { public const double Fraction = 1.25m; }
class Program { static void Main() { double value = Limits.Fraction; } }
