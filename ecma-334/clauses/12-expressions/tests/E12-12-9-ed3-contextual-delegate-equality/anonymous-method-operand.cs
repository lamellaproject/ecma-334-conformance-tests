/*
Rules: E12-12-9-ed3-contextual-delegate-equality
Authority: ECMA-334 3rd ed 14.9.8
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E12-12-9-ed3-contextual-delegate-equality/anonymous-method-operand.cs.part
Mutate: named != delegate { return ReadNumber(); }
Into: named != new ReadValue(delegate { return ReadNumber(); })
*/
// ECMA-334 3rd ed 14.9.8, p. 208 (PDF p. 228).
using System;
delegate int ReadValue();
delegate int OtherRead();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int ReadNumber() { return 47; }
    static int Main()
    {
        ReadValue named = new ReadValue(ReadNumber);
        Check(named != delegate { return ReadNumber(); }, "contextual-anonymous-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
