/*
Rules: E8-3-8-no-floating-implicit
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: reject
Mutate: double destination=value;
Into: double destination=default(double);
Csc: CS0266
*/
using System;


class Program
{
    static void Main()
    {
        decimal value=2.25m; double destination=value;
    }
}
