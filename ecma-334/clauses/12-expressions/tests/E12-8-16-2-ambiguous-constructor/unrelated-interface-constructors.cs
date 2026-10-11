/*
Rules: E12-8-16-2-ambiguous-constructor
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new Choice(null)
Into: new Choice((ILeft)null)
Csc: CS0121
*/
using System;
interface ILeft { }
interface IRight { }
class Choice
{
    public Choice(ILeft left) { }
    public Choice(IRight right) { }
}
class Program
{
    static void Main() { var value = new Choice(null); Console.WriteLine(value != null); }
}
