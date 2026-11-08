/*
Rules: E13-14-ed3-nullable-resource-interface-required
Authority: ECMA-334 3rd ed 15.13
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E13-14-ed3-nullable-resource-interface-required/nullable-disposable-payload.cs.part
Mutate: using (resource)
Into: using (resource.Value)
*/
// ECMA-334 3rd ed 15.13, p. 244 (PDF p. 264).
using System;
struct Ticket : IDisposable
{
    public static int calls;
    public void Dispose() { calls++; }
}
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
        Ticket? resource = new Ticket();
        using (resource) {}
        Check(Ticket.calls == 1, "disposable-payload");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
