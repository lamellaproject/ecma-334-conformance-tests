/*
Rules: E12-6-3-2-no-first-phase-inference
Authority: ECMA-334 7th ed 12.6.3.2
Version: 7.3
Expected: reject
Mutate: Identity(null)
Into: Identity((object)null)
*/
class Program
{
    static T Identity<T>(T value) { return value; }
    static void Main() { object result = Identity(null); }
}
