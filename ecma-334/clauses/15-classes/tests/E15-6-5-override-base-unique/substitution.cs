/*
Rules: E15-6-5-override-base-unique
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: class Leaf : Root<int>
Into: class Leaf : Root<long>
Csc: CS0462
*/
class Root<T>
{
    public virtual int Read(T value) { return 89; }
    public virtual int Read(int value) { return 97; }
}
class Leaf : Root<int> { public override int Read(int value) { return 101; } }
class Program { static void Main() { } }
