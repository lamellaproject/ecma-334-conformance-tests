/*
Rules: E12-6-3-11-no-upper-inference
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: reject
Mutate: new Consumer<string>()
Into: new Consumer<Box<string>>()
*/
interface Input<in T> { }
class Consumer<T> : Input<T> { }
class Box<T> { }
class Program
{
    static void Observe<T>(Input<Box<T>> x) { }
    static void Main() { Observe(new Consumer<string>()); }
}
