/*
Rules: E23-3-no-pointer-to-object; E23-3-pointer-type-category; E23-3-no-object-inheritance
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: object value = p;
Into: object value = (long)p;
*/
using System;
class Program
{
    static void Main()
    {
        unsafe
        {
            int* p = null;
            object value = p;
        }
    }
}
