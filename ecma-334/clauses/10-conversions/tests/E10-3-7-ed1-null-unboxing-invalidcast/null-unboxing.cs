/*
Rules: E10-3-7-ed1-null-unboxing-invalidcast
Authority: ECMA-334 1st ed 11.3.2
Version: ISO-1
Expected: run
Stdout: OK 4
Version-Witness: tests/E10-3-7-ed1-null-unboxing-invalidcast/null-unboxing.witness.cs.part
Mutate: IStamp empty = null;
Into: IStamp empty = new Parcel();
*/
// ECMA-334 1st ed 11.3.2, p. 97 (PDF p. 111), lines 40-43. Unboxing a null object or
// implemented-interface reference to a value type throws System.InvalidCastException, as
// does unboxing an incompatible boxed value.
using System;

interface IStamp { }
struct Parcel : IStamp { }
struct Spare : IStamp { }

class Entry
{
    static int checks;
    static int failures;

    static bool ObjectFailure(object source)
    {
        try { Parcel value = (Parcel)source; return false; }
        catch (InvalidCastException) { return true; }
        catch (Exception) { return false; }
    }

    static bool InterfaceFailure(IStamp source)
    {
        try { Parcel value = (Parcel)source; return false; }
        catch (InvalidCastException) { return true; }
        catch (Exception) { return false; }
    }

    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }

    static int Main()
    {
        IStamp empty = null;
        IStamp other = new Spare();
        Check(ObjectFailure(empty), "object-null");
        Check(InterfaceFailure(empty), "interface-null");
        Check(ObjectFailure(other), "object-wrong-box");
        Check(InterfaceFailure(other), "interface-wrong-box");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
