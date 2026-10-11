/*
Rules: E12-6-3-11-upper-invariant
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: reject
Mutate: new Consumer<Box<object>>()
Into: new Consumer<Box<string>>()
*/
interface Input<in T> { }
class Consumer<T> : Input<T> { }
class Box<T> { }
class Program
{
    static void Common<T>(Input<Box<T>> a, Input<Box<T>> b) { }
    static void Main() { Common(new Consumer<Box<string>>(), new Consumer<Box<object>>()); }
}
