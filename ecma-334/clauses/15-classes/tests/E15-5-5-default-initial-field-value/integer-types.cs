/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: public ulong UnsignedLong;
Into: public ulong UnsignedLong = 1UL;
*/
using System;
class Holder
{
    public sbyte SignedByte;
    public byte UnsignedByte;
    public short SignedShort;
    public ushort UnsignedShort;
    public uint UnsignedInt;
    public long SignedLong;
    public ulong UnsignedLong;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.SignedByte == 0, "sbyte-field-default");
        Check(value.UnsignedByte == 0, "byte-field-default");
        Check(value.SignedShort == 0, "short-field-default");
        Check(value.UnsignedShort == 0, "ushort-field-default");
        Check(value.UnsignedInt == 0u, "uint-field-default");
        Check(value.SignedLong == 0L, "long-field-default");
        Check(value.UnsignedLong == 0UL, "ulong-field-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
