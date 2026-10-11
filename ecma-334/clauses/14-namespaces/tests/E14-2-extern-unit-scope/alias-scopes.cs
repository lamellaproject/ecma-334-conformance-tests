/*
Rules: E14-2-extern-unit-scope; E14-2-grammar-compilation-unit-1; E14-2-assembly-global-attributes; E14-2-module-global-attributes; E14-4-extern-namespace-alias; E14-4-extern-nested-namespaces; E14-4-grammar-extern-alias-directive-1; E14-4-extern-directive-scope; E14-4-extern-reference; E14-5-2-using-alias-global-attributes; E14-5-2-alias-target-extern-scope
Authority: ECMA-334 7th ed 14.2
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"references":[{"alias":"Outside","asset":"System.Runtime.dll"}]}}
Mutate: extern alias Outside;
Into: extern alias Missing;
*/
extern alias Outside;
using Flag = Outside::System.CLSCompliantAttribute;
using Value = Outside::System.Int32;
using System;
[assembly: Flag(true)]
[module: Flag(true)]
namespace Home { class Reader { public static Outside::System.Int32 Read() { return 29; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Value value = Home.Reader.Read();
        Check(value == 29, "alias-in-using-and-namespace-member");
        object attribute = new Outside::System.Runtime.CompilerServices.CompilerGeneratedAttribute();
        Check(attribute != null, "extern-nested-namespace");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
