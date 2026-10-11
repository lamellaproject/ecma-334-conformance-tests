/*
Rules: E23-3-no-void-indirection
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: byte value = *p;
Into: byte value = *(byte*)p;
*/
using System;
class Program
{
    static void Main()
    {
        unsafe
        {
            void* p = null;
            byte value = *p;
        }
    }
}
