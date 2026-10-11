/*
Rules: E23-7-no-local-ref-argument; E23-7-local-readonly
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: Touch(ref pointer);
Into: Touch(ref copy);
*/
using System;
unsafe class Program
{
    static void Touch(ref int* value) { }
    static void Main()
    {
        int[] items = { 11 };
        fixed (int* pointer = items)
        {
            int* copy = pointer;
            Touch(ref pointer);
        }
    }
}
