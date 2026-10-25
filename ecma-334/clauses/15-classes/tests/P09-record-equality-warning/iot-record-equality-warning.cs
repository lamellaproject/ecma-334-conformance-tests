/*
Rules: P09-record-equality-warning
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: public virtual bool Equals(Seal other) { return !object.ReferenceEquals(other, null); }
Into: public virtual bool Equals(Seal other) { return !object.ReferenceEquals(other, null); } public override int GetHashCode() { return 0; }
*/
record Seal
{
    public virtual bool Equals(Seal other) { return !object.ReferenceEquals(other, null); }
}
class Program { static void Main() { System.Console.WriteLine("OK 0"); } }
