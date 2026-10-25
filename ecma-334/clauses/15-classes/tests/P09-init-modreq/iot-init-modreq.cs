/*
Rules: P09-init-modreq
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"InitLibrary","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"InitLibrary"}]}}
Mutate: public int Code { get; init; }
Into: public int Code { get; set; }
*/
#if LIBRARY
namespace Codes { public class Packet { public int Code { get; init; } } }
#else
using System;
using System.Reflection;
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
        // Required metadata modifiers are the predicate's observable output.
        MethodInfo setter = typeof(Codes.Packet).GetProperty("Code").SetMethod;
        Type[] modifiers = setter.ReturnParameter.GetRequiredCustomModifiers();
        Check(modifiers.Length == 1 && modifiers[0] == typeof(System.Runtime.CompilerServices.IsExternalInit), "init-return-required-modifier");
        Check(setter.GetParameters()[0].GetRequiredCustomModifiers().Length == 0, "modifier-on-return-not-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
#endif
