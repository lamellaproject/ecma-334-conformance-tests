/*
Rules: E12-6-3-11-upper-constructed-shape
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: reject
Mutate: Observe(new Consumer<Output<Box<int>>>())
Into: Observe<int>(new Consumer<Output<Box<int>>>())
*/
interface Input<in T> { }
interface Output<out T> { }
class Box<T> { }
class Packet<T> { }
class Dual<T> : Output<Box<T>>, Output<Packet<T>> { }
class Consumer<T> : Input<T> { }
class Program
{
    static void Observe<T>(Input<Dual<T>> value) { }
    static void Main() { Observe(new Consumer<Output<Box<int>>>()); }
}
