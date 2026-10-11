/*
Rules: E15-2-5-partial-equivalent-constraints
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : ILeft, IRight
Into: where T : ILeft
*/
interface ILeft { }
interface IRight { }
partial class Box<T> where T : ILeft { }
partial class Box<T> where T : ILeft, IRight { }
class Program { static void Main() { } }
