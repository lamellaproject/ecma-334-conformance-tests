/*
Rules: E12-12-9-ed3-anonymous-method-group-entries
Authority: ECMA-334 3rd ed 14.9.8
Version: ISO-2
Expected: run
Stdout: OK 3
Mutate: delegate { return ReadNumber(); }
Into: new ReadValue(ReadNumber)
*/
// ECMA-334 3rd ed 14.9.8, p. 209 (PDF p. 229).
using System;
delegate int ReadValue();
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
        ReadValue anonymous = delegate { return ReadNumber(); };
        Check(named() == 47, "named-value");
        Check(anonymous() == 47, "anonymous-value");
        Check(named != anonymous, "different-entry-origins");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
