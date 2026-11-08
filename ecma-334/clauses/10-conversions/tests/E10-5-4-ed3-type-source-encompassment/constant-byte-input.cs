/*
Rules: E10-5-4-ed3-type-source-encompassment
Authority: ECMA-334 3rd ed 13.4.3
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-5-4-ed3-type-source-encompassment/constant-byte-input.cs.part
Mutate: Parcel result = 53;
Into: Parcel result = (byte)53;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Parcel
    {
        public int Number;
        public Parcel(int number) { Number = number; }
        public static implicit operator Parcel(byte value) { return new Parcel(value); }
    }
    static int Main()
    {
        Parcel result = 53;
        Check(result.Number == 53, "constant-byte-operator-input");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
