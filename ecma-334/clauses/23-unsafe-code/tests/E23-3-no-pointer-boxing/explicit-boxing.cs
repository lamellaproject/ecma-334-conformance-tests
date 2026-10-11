/*
Rules: E23-3-no-pointer-boxing
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: object value = (object)p;
Into: object value = (object)(long)p;
*/
using System;
class Program
{
    static void Main()
    {
        unsafe
        {
            int* p = null;
            object value = (object)p;
        }
    }
}
