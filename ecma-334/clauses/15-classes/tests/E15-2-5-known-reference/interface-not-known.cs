/*
Rules: E15-2-5-known-reference
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : IReading
Into: where T : class, IReading
*/
interface IReading { }
class Program
{
    static T Null<T>() where T : IReading { return null; }
    static void Main() { }
}
