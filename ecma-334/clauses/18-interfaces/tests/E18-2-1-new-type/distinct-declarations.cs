/*
Rules: E18-2-1-new-type; E18-2-1-declared-name; E18-2-4-zero-base-interfaces; E18-3-body-form
Authority: ECMA-334 7th ed 18.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Parcel : IParcel { }
Into: class Parcel : IParcel, IReceipt { }
*/
using System;
interface IParcel { }
interface IReceipt { }
class Parcel : IParcel { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IParcel item = new Parcel();
        Check(item is IParcel, "declared-name");
        Check(!(item is IReceipt), "different-interface-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
