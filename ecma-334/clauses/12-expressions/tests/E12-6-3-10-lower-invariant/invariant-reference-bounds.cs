/*
Rules: E12-6-3-10-lower-invariant
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: reject
Mutate: new Box<object>()
Into: new Box<string>()
*/
class Box<T> { }
class Program
{
    static void Common<T>(Box<T> left, Box<T> right) { }
    static void Main() { Common(new Box<string>(), new Box<object>()); }
}
