/*
Rules: E14-2-joint-processing; E14-2-circular-unit-dependency
Authority: ECMA-334 7th ed 14.2
Version: 7.3
Expected: run
Stdout: OK 3
Fixture: {"program":{"units":[{"source":"self"},{"source":"tests/E14-2-joint-processing/south.cs.part"}]}}
Mutate: public South Peer;
Into: public int Peer;
*/
using System;
class North { public South Peer; public int Code = 29; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        North north = new North();
        South south = new South();
        north.Peer = south;
        south.Peer = north;
        Check(object.ReferenceEquals(north.Peer, south), "first-unit-sees-second");
        Check(object.ReferenceEquals(south.Peer, north), "second-unit-sees-first");
        Check(north.Peer.Code + south.Peer.Code == 60, "cross-unit-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
