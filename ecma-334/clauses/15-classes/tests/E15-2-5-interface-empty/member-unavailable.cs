/*
Rules: E15-2-5-interface-empty
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : class
Into: where T : class, IReading
*/
interface IReading { int Read(); }
class Box<T> where T : class { public static int Read(T value) { return value.Read(); } }
class Program { static void Main() { } }
