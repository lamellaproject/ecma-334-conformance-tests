/*
Rules: E23-3-pointer-type-inference-fails
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: Item.Echo(p);
Into: Item.Echo((long)p);
*/
using System;
class Item { public static void Echo<T>(T value) { } }
class Program
{
    static void Main()
    {
        unsafe
        {
            int* p = null;
            Item.Echo(p);
        }
    }
}
