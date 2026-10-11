/*
Rules: E23-7-no-local-out-argument; E23-7-local-readonly
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: Touch(out pointer);
Into: Touch(out copy);
*/
using System;
unsafe class Program
{
    static void Touch(out int* value) { value = null; }
    static void Main()
    {
        int[] items = { 11 };
        fixed (int* pointer = items)
        {
            int* copy = pointer;
            Touch(out pointer);
        }
    }
}
