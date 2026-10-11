/*
Rules: E12-6-3-11-upper-unknown-reference
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: reject
Mutate: new Consumer<long[]>()
Into: new Consumer<int[]>()
*/
interface Input<in T> { }
class Consumer<T> : Input<T> { }
class Program
{
    static void Common<T>(Input<T[]> left, Input<T[]> right) { }
    static void Main() { Common(new Consumer<int[]>(), new Consumer<long[]>()); }
}
