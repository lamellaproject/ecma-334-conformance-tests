/*
Rules: P09-record-equality-warning
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: public bool Equals(Warn other) { return true; }
Into: public bool Equals(Warn other) { return true; } public override int GetHashCode() { return 0; }
*/
using System;
readonly record struct Warn
{
    public bool Equals(Warn other) { return true; }
}
class Program
{
    static int Main() { Console.WriteLine("OK 0"); return 0; }
}
