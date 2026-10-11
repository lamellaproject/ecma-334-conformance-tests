/*
Rules: E15-2-5-constraint-order
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : new(), IReading
Into: where T : IReading, new()
*/
interface IReading { }
class Box<T> where T : new(), IReading { }
class Program { static void Main() { } }
