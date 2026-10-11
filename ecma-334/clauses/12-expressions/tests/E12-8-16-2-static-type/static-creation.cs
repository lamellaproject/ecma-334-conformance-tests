/*
Rules: E12-8-16-2-static-type
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new Utility()
Into: new object()
Csc: CS0712
*/
using System;
static class Utility { }
class Program
{
    static void Main() { object value = new Utility(); Console.WriteLine(value != null); }
}
