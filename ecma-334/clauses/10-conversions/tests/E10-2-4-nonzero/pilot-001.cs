/*
Rules: E10-2-4-nonzero
Authority: ECMA-334 7th ed 10.2.4
Version: 7.3
Expected: reject
Mutate: Label a=1;
Into: Label a=default(Label);
Csc: CS0266
*/
using System;

enum Label { Mark=1 }
class Program
{
    static void Main()
    {
        Label a=1;
    }
}
