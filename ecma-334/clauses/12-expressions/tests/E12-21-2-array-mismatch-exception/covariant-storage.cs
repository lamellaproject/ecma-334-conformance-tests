/*
Rules: E12-21-2-array-mismatch-exception; E12-21-2-array-compatibility-check; E12-21-2-array-null-compatible; E12-21-2-array-reference-compatible
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Base rejected = new Other();
Into: Base rejected = new Leaf();
*/
using System;
class Base { }
class Leaf : Base { }
class Other : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Base[] array = new Leaf[1];
        Base accepted = new Leaf();
        Base result = (array[0] = accepted);
        Check(object.ReferenceEquals(result, accepted) && object.ReferenceEquals(array[0], accepted), "actual-element-reference-conversion");
        result = (array[0] = null);
        Check(result == null && array[0] == null, "null-compatible-with-actual-element-type");
        array[0] = accepted;
        Base rejected = new Other();
        bool mismatch = false;
        try { array[0] = rejected; }
        catch (ArrayTypeMismatchException) { mismatch = true; }
        catch (Exception) { }
        Check(mismatch && object.ReferenceEquals(array[0], accepted), "mismatch-type-and-no-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
