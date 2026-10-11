/*
Rules: E15-3-5-unnecessary-new-warning
Authority: ECMA-334 7th ed 15.3.5
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: public new int Read() { return 431; }
Into: public int Read() { return 431; }
*/
// The declaration requires an unnecessary-new warning.
class Meter { public new int Read() { return 431; } }
class Program { static void Main() { new Meter().Read(); System.Console.WriteLine("OK 0"); } }
