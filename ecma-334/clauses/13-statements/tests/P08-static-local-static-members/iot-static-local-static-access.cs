/*
Rules: P08-static-local-static-members
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: static int Read() { return hidden + Step(); }
Into: static int Read() { return other + Step(); }
*/
using System;
class Vault
{
    private static int hidden = 73;
    private static int other = 19;
    private static int calls;
    private static int Step() { calls++; return 7; }
    public int Compute()
    {
        static int Read() { return hidden + Step(); }
        return Read();
    }
    public static int Calls { get { return calls; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(new Vault().Compute() == 80, "static-local-private-member-binding");
        Check(Vault.Calls == 1, "static-local-method-invoked-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
