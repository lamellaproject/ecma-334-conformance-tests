/*
Rules: E21-3-arbitrary-chain; E21-3-constructor-inner
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Exception("wrapper", current)
Into: new Exception("wrapper", null)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception root = new Exception("root"); Exception current = root;
        // 21.3, p. 525: "The value of these properties can be specified in calls to the
        // instance constructor for System.Exception."
        for (int index = 0; index < 12; index++) current = new Exception("wrapper", current);
        int links = 0; Exception last = null;
        while (current != null) { links++; last = current; current = current.InnerException; }
        Check(links == 13, "all-cause-links-retained");
        Check(last == root, "last-cause-identity");
        Check(root.InnerException == null, "chain-terminates-at-root");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
