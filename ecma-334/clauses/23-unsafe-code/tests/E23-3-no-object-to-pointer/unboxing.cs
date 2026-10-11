/*
Rules: E23-3-no-object-to-pointer; E23-3-no-pointer-unboxing
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: int* p = (int*)value;
Into: int* p = (int*)(int)value;
*/
using System;
class Program
{
    static void Main()
    {
        unsafe
        {
            object value = 0;
            int* p = (int*)value;
        }
    }
}
