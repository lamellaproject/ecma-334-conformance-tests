/*
Rules: E12-6-3-1-initial-state; E12-6-3-1-fixed-or-bounded
Authority: ECMA-334 7th ed 12.6.3.1
Version: 7.3
Expected: reject
Mutate: Create()
Into: Create<int>()
*/
class Program
{
    static T Create<T>() { return default(T); }
    static void Main() { int result = Create(); }
}
