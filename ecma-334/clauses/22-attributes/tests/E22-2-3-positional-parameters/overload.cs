/*
Rules: E22-2-3-positional-parameters; E22-2-3-constructor-parameter-sequence; E22-4-2-constructor-binding; E22-4-2-metadata-constructor
Authority: ECMA-334 7th ed 22.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [Code((byte)9)]
Into: [Code(9)]
*/
using System;
class CodeAttribute : Attribute
{
    public int Choice;
    public CodeAttribute(byte x) { Choice = 1; }
    public CodeAttribute(int x) { Choice = 2; }
}
[Code((byte)9)] class Tiny { }
[Code(9)] class Normal { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((CodeAttribute)Attribute.GetCustomAttribute(typeof(Tiny), typeof(CodeAttribute))).Choice == 1, "byte-constructor");
        Check(((CodeAttribute)Attribute.GetCustomAttribute(typeof(Normal), typeof(CodeAttribute))).Choice == 2, "int-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
