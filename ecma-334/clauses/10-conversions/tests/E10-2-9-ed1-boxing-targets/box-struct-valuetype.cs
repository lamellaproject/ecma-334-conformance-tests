/*
Rules: E10-2-9-ed1-boxing-targets
Authority: ECMA-334 1st ed 11.3.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E10-2-9-ed1-boxing-targets/box-struct-valuetype.witness.cs.part
Mutate: System.ValueType storage
Into: object storage
*/
// ECMA-334 1st ed 11.3.1, p. 96 (PDF p. 110), lines 20-21. Boxing permits conversion to
// object or an implemented interface, not a direct conversion from a value type to
// System.ValueType or from an enum to System.Enum.
struct Parcel
{
    public int Number;
    public Parcel(int number) { Number = number; }
}
class Entry
{
    static void Main()
    {
        System.ValueType storage = new Parcel(53);
        System.Console.WriteLine(storage != null ? "OK" : "FAIL");
    }
}
