/*
Rules: E15-6-2-1-single-indexer-optional-warning
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: int index = 43
Into: int index
*/
class Holder { public int this[int index = 43] { get { return index; } } }
class Program { static void Main() { System.Console.WriteLine("OK 0"); } }
