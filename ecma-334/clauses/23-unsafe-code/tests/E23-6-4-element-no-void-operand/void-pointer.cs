/*
Rules: E23-6-4-element-no-void-operand
Authority: ECMA-334 7th ed 23.6.4
Version: 7.3
Expected: reject
Mutate: int result = pointer[0];
Into: int result = ((int*)pointer)[0];
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int value = 13;
        void* pointer = &value;
        int result = pointer[0];
    }
}
