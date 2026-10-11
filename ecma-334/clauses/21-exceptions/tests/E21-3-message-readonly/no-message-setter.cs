/*
Rules: E21-3-message-readonly
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: reject
Mutate: fault.Message = "another reason"
Into: string message = fault.Message
*/
using System;
class Program
{
    static void Main()
    {
        Exception fault = new Exception("a reason");
        fault.Message = "another reason";
    }
}
