/*
Rules: P09-native-compound-once
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: Receiver()[Key()] += Right()
Into: Receiver()[Key()] -= Right()
*/
using System;
class Store
{
    public nint value = 37;
    public nint this[int key]
    {
        get { Program.trace = Program.trace * 10 + 3; return value; }
        set { Program.trace = Program.trace * 10 + 5; this.value = value; }
    }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static readonly Store store = new Store();
    static Store Receiver() { trace = trace * 10 + 1; return store; }
    static int Key() { trace = trace * 10 + 2; return 0; }
    static nint Right() { trace = trace * 10 + 4; return 15; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        nint result = Receiver()[Key()] += Right();
        Check(trace == 12345, "native-compound-location-get-right-set-once");
        Check(result == 52, "compound-expression-result");
        Check(store.value == 52, "compound-stored-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
