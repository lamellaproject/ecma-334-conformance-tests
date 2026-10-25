/*
Rules: P08-static-local-nameof
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 1
Mutate: return nameof(input) + ":" + nameof(near) + ":" + nameof(this.Value) + ":" + nameof(base.Code);
Into: return nameof(near) + ":" + nameof(near) + ":" + nameof(this.Value) + ":" + nameof(base.Code);
*/
using System;
class Parent { protected int Code { get { return 0; } } }
class Child : Parent
{
    public int Value { get { return 0; } }
    public string Names(int input)
    {
        int near = input + 1;
        static string Read()
        {
            return nameof(input) + ":" + nameof(near) + ":" + nameof(this.Value) + ":" + nameof(base.Code);
        }
        return Read() + ":" + near;
    }
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
        Check(new Child().Names(23) == "input:near:Value:Code:24", "static-local-nameof-without-capture");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
