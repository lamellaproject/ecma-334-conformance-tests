/*
Rules: E15-2-5-known-reference
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: static T Null<T>()
Into: static T Null<T>() where T : class
*/
class Program
{
    static T Null<T>() { return null; }
    static void Main() { }
}
