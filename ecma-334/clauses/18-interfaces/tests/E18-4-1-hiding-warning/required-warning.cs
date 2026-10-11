/*
Rules: E18-4-1-hiding-warning
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: interface IDerived : IBase { void Read(); }
Into: interface IDerived : IBase { new void Read(); }
*/
// 18.4.1, pp. 491-492 prints a blanket modifier ban that conflicts with its grammar
// and hiding rules. This test follows those rules, which permit new.
interface IBase { void Read(); }
interface IDerived : IBase { void Read(); }
class Program { static void Main() { System.Console.WriteLine("OK 0"); } }
