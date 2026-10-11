/*
Rules: E15-3-5-available-inherited-member
Authority: ECMA-334 7th ed 15.3.5
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: private int Read() { return 389; }
Into: public int Read() { return 389; }
*/
// An inaccessible inherited method does not suppress the unnecessary-new warning.
class Parent { private int Read() { return 389; } }
class Child : Parent { public new int Read() { return 397; } }
class Program { static void Main() { new Child().Read(); System.Console.WriteLine("OK 0"); } }
