/*
Rules: E23-4-static-field-moveable
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: reject
Mutate: int* p = &Value;
Into: fixed (int* p = &Value) { }
Csc: CS0212
*/
using System;
class Program
{
    static int Value;
    static unsafe void Main()
    {
        int* p = &Value;
    }
}
