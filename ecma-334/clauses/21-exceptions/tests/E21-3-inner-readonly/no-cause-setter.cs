/*
Rules: E21-3-inner-readonly
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: reject
Mutate: fault.InnerException = new Exception()
Into: Exception cause = fault.InnerException
*/
using System;
class Program
{
    static void Main()
    {
        Exception fault = new Exception();
        fault.InnerException = new Exception();
    }
}
