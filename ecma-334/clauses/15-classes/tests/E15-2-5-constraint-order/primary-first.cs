/*
Rules: E15-2-5-constraint-order
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : IReading, Root
Into: where T : Root, IReading
*/
interface IReading { }
class Root { }
class Box<T> where T : IReading, Root { }
class Program { static void Main() { } }
