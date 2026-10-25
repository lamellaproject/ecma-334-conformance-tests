/*
Rules: E10-3-7-ed1-unboxing-sources
Authority: ECMA-334 1st ed 11.3.2
Version: ISO-1
Expected: reject
Version-Witness: tests/E10-3-7-ed1-unboxing-sources/unbox-struct-valuetype.witness.cs.part
Mutate: (Parcel)storage
Into: (Parcel)(object)storage
*/
// ECMA-334 1st ed 11.3.2, p. 97 (PDF p. 111), lines 27-28. Unboxing permits conversion
// from object or from an interface implemented by the target value type; it does not
// permit direct unboxing from System.ValueType or System.Enum.
struct Parcel
{
    public int Number;
    public Parcel(int number) { Number = number; }
}
class Entry
{
    static void Main()
    {
        System.ValueType storage = (System.ValueType)(object)new Parcel(53);
        Parcel result = (Parcel)storage;
        System.Console.WriteLine(result.Number == 53 ? "OK" : "FAIL");
    }
}
