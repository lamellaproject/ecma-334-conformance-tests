/*
Rules: E23-8-3-fixed-receiver-value
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/buffer-pointer-is-value-8ca556c91d.cs.part
Mutate: short** pointer = &value.Values;
Into: short** pointer = &copy;
*/
using System;
unsafe struct Item { public fixed short Values[2]; }
class Program
{
    static unsafe void Main()
    {
        Item value = new Item();
        short* copy = value.Values;
        short** pointer = &value.Values;
        // Supplemental observation only: compare addresses without dereferencing short**.
        Console.WriteLine((void*)pointer == (void*)&copy ? "copy" : "temporary");
    }
}
