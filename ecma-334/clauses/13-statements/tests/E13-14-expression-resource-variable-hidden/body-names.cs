/*
Rules: E13-14-expression-resource-variable-hidden; E13-14-disposal-temporary-hidden
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using (new Resource())
Into: using (Resource resource = new Resource())
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Resource : IDisposable { public void Dispose() { } }
    static void Main()
    {
        using (new Resource())
        {
            int resource = 23, d = 29;
            Check(resource == 23 && d == 29, "hidden-expansion-variables-do-not-conflict");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
