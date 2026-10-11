/*
Rules: E12-5-2-object-dynamic-base
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: reject
Mutate: object root = new object();
Into: Derived root = new Derived();
*/
class Base { public void Touch() { } }
class Derived : Base { }
class Program
{
    static void Main()
    {
        new Derived().Touch();
        object root = new object();
        root.Touch();
    }
}
