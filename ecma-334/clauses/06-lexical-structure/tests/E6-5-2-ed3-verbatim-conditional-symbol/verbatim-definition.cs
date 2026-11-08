/*
Rules: E6-5-2-ed3-verbatim-conditional-symbol
Authority: ECMA-334 3rd ed 9.5.1
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E6-5-2-ed3-verbatim-conditional-symbol/verbatim-definition.cs.part
Mutate: #define @CINDER
Into: #undef @CINDER
*/
// ECMA-334 3rd ed 9.5.1, p. 78 (PDF p. 98).
#define @CINDER
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        #if CINDER
        Check(true, "verbatim-defined");
        #else
        Check(false, "verbatim-defined");
        #endif
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
