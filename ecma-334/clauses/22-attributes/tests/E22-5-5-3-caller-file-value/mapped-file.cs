/*
Rules: E22-5-5-3-caller-file-value; E22-5-5-3-caller-file-eligible; E22-5-5-3-caller-file-format; E22-5-5-3-caller-file-directives
Authority: ECMA-334 7th ed 22.5.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [System.Runtime.CompilerServices.CallerFilePath] string path
Into: string path
*/
using System;
class Caller { public static string File([System.Runtime.CompilerServices.CallerFilePath] string path = null) { return path; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#line 17 "caller-file-source.cs"
        string value = Caller.File();
#line default
        // The path format is implementation-dependent, and #line may affect the path.
        // Accept every string representation; substitution must replace the null default.
        Check(value != null, "mapped-caller-file");
        Check(Caller.File("explicit") == "explicit", "explicit-file-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
