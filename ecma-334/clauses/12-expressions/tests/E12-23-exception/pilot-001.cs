/*
Rules: E12-23-exception
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: int destination=(int)79228162514264337593543950335m;
Into: int destination=default(int);
Csc: CS0031
*/
using System;


class Program
{
    static void Main()
    {
        const int destination=(int)79228162514264337593543950335m;
    }
}
