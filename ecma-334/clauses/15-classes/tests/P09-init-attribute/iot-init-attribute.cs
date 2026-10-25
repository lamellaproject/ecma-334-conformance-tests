/*
Rules: P09-init-attribute
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: [Code(Code = 47)]
Into: [Code(Code = 48)]
*/
using System;
class CodeAttribute : Attribute { public int Code { get; init; } }
[Code(Code = 47)]
class Tagged { }
class Program
{
    static int checks, failures;
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        // Metadata inspection is needed to observe the named attribute argument.
        CodeAttribute code = (CodeAttribute)Attribute.GetCustomAttribute(typeof(Tagged), typeof(CodeAttribute));
        Check(code.Code == 47, "attribute-named-init-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
