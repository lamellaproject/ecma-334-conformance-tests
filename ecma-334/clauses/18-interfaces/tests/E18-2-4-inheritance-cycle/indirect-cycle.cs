/*
Rules: E18-2-4-inheritance-cycle
Authority: ECMA-334 7th ed 18.2.4
Version: 7.3
Expected: reject
Mutate: interface ILast : IFirst
Into: interface ILast
Csc: CS0529
*/
interface IFirst : IMiddle { }
interface IMiddle : ILast { }
interface ILast : IFirst { }
class Program { static void Main() { } }
