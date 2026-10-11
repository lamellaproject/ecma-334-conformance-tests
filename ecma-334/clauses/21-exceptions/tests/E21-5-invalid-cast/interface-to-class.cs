/*
Rules: E21-5-invalid-cast
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: IMarker source = new Other()
Into: IMarker source = new Desired()
*/
using System;
interface IMarker { }
class Other : IMarker { }
class Desired : IMarker { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IMarker source = new Other(); bool caught = false;
        try { Desired result = (Desired)source; }
        catch (InvalidCastException) { caught = true; }
        catch (Exception) { }
        Check(caught, "failed-interface-to-class-cast-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
