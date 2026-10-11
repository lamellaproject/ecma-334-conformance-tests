/*
Rules: E15-6-2-1-explicit-interface-optional-warning
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: int IReader.Read(int value = 41)
Into: int IReader.Read(int value)
*/
interface IReader { int Read(int value); }
class Holder : IReader { int IReader.Read(int value = 41) { return value; } }
class Program { static void Main() { System.Console.WriteLine("OK 0"); } }
