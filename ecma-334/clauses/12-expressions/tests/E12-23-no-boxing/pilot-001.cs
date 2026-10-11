/*
Rules: E12-23-no-boxing
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: object destination=61;
Into: object destination=default(object);
Csc: CS0134
*/
using System;


class Program
{
    static void Main()
    {
        const object destination=61;
    }
}
