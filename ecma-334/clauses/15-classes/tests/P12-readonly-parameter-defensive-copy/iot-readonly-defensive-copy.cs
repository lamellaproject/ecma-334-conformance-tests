/*
Rules: P12-readonly-parameter-defensive-copy
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 2
Mutate: int observed = Observe(in value);
Into: int observed = Observe(in different);
*/
using System;
struct Counter
{
    public int Value;
    public int Next() { return ++Value; }
}
class Test
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Observe(ref readonly Counter value)
    {
        int first = value.Next();
        int second = value.Next();
        return first * 100 + second;
    }
    static int Main()
    {
        Counter value = new Counter { Value = 7 };
        Counter different = new Counter { Value = 12 };
        int observed = Observe(in value);
        Check(observed == 808, "fresh-copy-for-each-mutating-method-call");
        Check(value.Value == 7, "caller-storage-unchanged");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
