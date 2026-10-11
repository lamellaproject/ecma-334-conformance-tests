/*
Rules: E23-8-2-element-byte; E23-8-1-inline-struct-buffer; E23-8-2-buffer-storage; E23-8-2-form-declaration; E23-8-2-form-modifier-public; E23-8-2-buffer-accessibility; E23-8-2-element-type; E23-8-2-declarator-member; E23-8-2-length-meaning; E23-8-2-sequential-layout
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public fixed byte Values[3];
Into: public fixed short Values[3];
*/
using System;
unsafe struct Item { public fixed byte Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        byte* pointer = value.Values;
        pointer[0] = (byte)11; pointer[1] = (byte)19; pointer[2] = (byte)29;
        Check(value.Values[0] == (byte)11 && value.Values[1] == (byte)19 && value.Values[2] == (byte)29, "typed-buffer-element-values");
        Check((byte*)&pointer[2] - (byte*)&pointer[0] == 2 * sizeof(byte), "buffer-element-byte-stride");
        Check(sizeof(Item) >= 3 * sizeof(byte), "buffer-storage-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
