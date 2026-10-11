/*
Rules: E15-2-5-duplicate-interface-constraint
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : IReading, IReading
Into: where T : IReading
*/
interface IReading { }
class Box<T> where T : IReading, IReading { }
class Program { static void Main() { } }
