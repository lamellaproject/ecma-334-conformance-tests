/*
Rules: E12-6-3-13-no-effective-return; E12-6-3-13-no-inferred-return; E12-6-3-7-no-output-inference
Authority: ECMA-334 7th ed 12.6.3.13
Version: 7.3
Expected: reject
Mutate: Make(() => { throw new Exception(); })
Into: Make<int>(() => { throw new Exception(); })
*/
using System;
class Program
{
    static Func<T> Make<T>(Func<T> f) { return f; }
    static void Main() { Make(() => { throw new Exception(); }); }
}
