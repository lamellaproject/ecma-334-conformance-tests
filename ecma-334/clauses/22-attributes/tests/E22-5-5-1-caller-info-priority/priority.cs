/*
Rules: E22-5-5-1-caller-info-priority; E22-5-5-1-caller-info-order-irrelevant
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: CallerLineNumber, System.Runtime.CompilerServices.CallerFilePath, System.Runtime.CompilerServices.CallerMemberName
Into: CallerFilePath, System.Runtime.CompilerServices.CallerMemberName
*/
using System;
class Caller
{
    public static object First([System.Runtime.CompilerServices.CallerLineNumber, System.Runtime.CompilerServices.CallerFilePath, System.Runtime.CompilerServices.CallerMemberName] object value = null) { return value; }
    public static object Reverse([System.Runtime.CompilerServices.CallerMemberName, System.Runtime.CompilerServices.CallerFilePath, System.Runtime.CompilerServices.CallerLineNumber] object value = null) { return value; }
    public static string FileFirst([System.Runtime.CompilerServices.CallerMemberName, System.Runtime.CompilerServices.CallerFilePath] string value = null) { return value; }
    public static string FileOnly([System.Runtime.CompilerServices.CallerFilePath] string value = null) { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#line 707 "priority-source.cs"
        object a = Caller.First(); object b = Caller.Reverse(); string path = Caller.FileFirst(); string file = Caller.FileOnly();
#line default
        Check(a is int && (int)a == 707, "line-priority");
        Check(b is int && (int)b == 707, "lexical-order-irrelevant");
        Check(path != null && path == file, "file-before-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
