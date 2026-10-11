/*
Rules: E23-3-no-anonymous-object-pointer-value
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: Address = p
Into: Address = (long)p
*/
using System;
class Program
{
    static void Main()
    {
        unsafe
        {
            int* p = null;
            var value = new { Address = p };
        }
    }
}
