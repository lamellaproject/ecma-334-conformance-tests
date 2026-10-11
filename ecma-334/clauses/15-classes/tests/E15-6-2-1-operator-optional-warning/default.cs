/*
Rules: E15-6-2-1-operator-optional-warning
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: int amount = 47
Into: int amount
*/
class Holder { public static Holder operator +(Holder left, int amount = 47) { return left; } }
class Program { static void Main() { System.Console.WriteLine("OK 0"); } }
