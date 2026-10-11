/*
Rules: E23-3-no-void-arithmetic
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: void* next = p + 1;
Into: void* next = (byte*)p + 1;
*/
using System;
class Program
{
    static void Main()
    {
        unsafe
        {
            void* p = null;
            void* next = p + 1;
        }
    }
}
