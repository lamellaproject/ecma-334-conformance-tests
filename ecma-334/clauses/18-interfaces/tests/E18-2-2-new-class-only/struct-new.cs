/*
Rules: E18-2-2-new-class-only
Authority: ECMA-334 7th ed 18.2.2
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: new interface IMarker
Into: interface IMarker
*/
// 18.2.2, p. 488 restricts new to an interface defined within a class.
// Clause 5, p. 9 requires a diagnostic, not necessarily an error.
struct Container { new interface IMarker { } }
class Program { static void Main() { System.Console.WriteLine("OK 0"); } }
