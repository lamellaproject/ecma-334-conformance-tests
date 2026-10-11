/*
Rules: E12-8-16-2-argument-list-type
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new Mode(1)
Into: new Mode()
Csc: CS1729
*/
using System;
enum Mode { Idle, Active }
class Program
{
    static void Main() { Mode mode = new Mode(1); Console.WriteLine(mode == Mode.Idle); }
}
