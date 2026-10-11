/*
Rules: E15-2-5-known-reference
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: return null;
Into: return default(T);
*/
class Program
{
    static T Null<T>() where T : struct { return null; }
    static void Main() { }
}
