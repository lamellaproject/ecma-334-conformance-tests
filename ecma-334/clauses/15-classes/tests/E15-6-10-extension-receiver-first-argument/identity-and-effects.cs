/*
Rules: E15-6-10-extension-receiver-first-argument
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Receive().Return(Argument())
Into: Extensions.Return(null, Argument())
*/
using System;
class Parcel { }
static class Extensions
{
    public static Parcel Return(this Parcel receiver, int marker)
    {
        Program.trace = Program.trace * 10 + 3;
        Program.received = marker;
        return receiver;
    }
}
class Program
{
    internal static int trace, received;
    static Parcel expected = new Parcel();
    static Parcel Receive() { trace = trace * 10 + 1; return expected; }
    static int Argument() { trace = trace * 10 + 2; return 29; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parcel result = Receive().Return(Argument());
        Check(object.ReferenceEquals(result, expected), "extension-receives-original-receiver-as-first-argument");
        Check(received == 29, "explicit-argument-follows-the-receiver-argument");
        Check(trace == 123, "receiver-and-explicit-argument-evaluate-once-before-method-body");
        Parcel missing = null;
        Check(missing.Return(11) == null, "null-receiver-is-passed-as-a-static-method-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
