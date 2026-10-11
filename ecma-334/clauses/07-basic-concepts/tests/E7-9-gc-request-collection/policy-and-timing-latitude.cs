/*
Rules: E7-9-gc-request-collection; E7-9-gc-static-control; E7-9-collection-time-unspecified; E7-9-gc-policy-latitude
Authority: ECMA-334 7th ed 7.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: GC.Collect();
Into: GC.NoSuchCollectionRequest();
*/
using System;
class Token { public int Value = 163; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token live = new Token(), alias = live;
        GC.Collect();
        // No addresses, reclaimed-byte counts, generations, or elapsed times are prescribed.
        Check(live == alias, "any-allowed-collector-policy-preserves-live-object-identity");
        Check(live.Value == 163, "collection-request-preserves-live-data");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
