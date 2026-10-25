/*
Rules: E10-3-7-ed1-unboxing-sources
Authority: ECMA-334 1st ed 11.3.2
Version: ISO-1
Expected: reject
Version-Witness: tests/E10-3-7-ed1-unboxing-sources/unbox-enum-enum.witness.cs.part
Mutate: (Signal)storage
Into: (Signal)(object)storage
*/
// ECMA-334 1st ed 11.3.2, p. 97 (PDF p. 111), lines 27-28. Unboxing permits conversion
// from object or from an interface implemented by the target value type; it does not
// permit direct unboxing from System.ValueType or System.Enum.
enum Signal : short { Ready = 43 }
class Entry
{
    static void Main()
    {
        System.Enum storage = (System.Enum)(object)Signal.Ready;
        Signal result = (Signal)storage;
        System.Console.WriteLine(result == Signal.Ready ? "OK" : "FAIL");
    }
}
