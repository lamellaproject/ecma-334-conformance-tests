/*
Rules: E7-1-host-entry-access; E7-1-application-compilation; E7-1-startup-call; E7-2-void-exit-code; E7-2-termination-control
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: private static void Main()
Into: private void Main()
*/
using System;
class Envelope
{
    private class Entry
    {
        static int checks, failures;
        static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
        private static void Main()
        {
            if (failures == 0) Console.WriteLine("OK " + checks);
        }
    }
}
