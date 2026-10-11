/*
Rules: E20-4-ref-return
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: ReadRef converted=Bridge.Read;
Into: ReadRef converted=default(ReadRef);
Csc: CS8189
*/
using System;


delegate ref int ReadRef(); static class Bridge {public static int Number;public static ref readonly int Read(){return ref Number;}}

class Program
{
    static void Main()
    {
        ReadRef converted=Bridge.Read;
    }
}
