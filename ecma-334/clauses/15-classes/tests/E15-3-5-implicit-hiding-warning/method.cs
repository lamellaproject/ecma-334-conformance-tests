/*
Rules: E15-3-5-implicit-hiding-warning
Authority: ECMA-334 7th ed 15.3.5
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: public int Read() { return 409; }
Into: public new int Read() { return 409; }
*/
// The declaration requires a hiding warning.
class Parent { public int Read() { return 401; } }
class Child : Parent { public int Read() { return 409; } }
class Program { static void Main() { new Child().Read(); System.Console.WriteLine("OK 0"); } }
