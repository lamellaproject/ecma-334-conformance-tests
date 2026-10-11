/*
Rules: E7-4-1-instance-constructor-not-inherited
Authority: ECMA-334 7th ed 7.4.1
Version: 7.3
Expected: reject
Mutate: new Derived(17)
Into: new Derived()
*/
class Base { public Base(int value) { } }
class Derived : Base { public Derived() : base(17) { } }
class Program { static void Main() { new Derived(17); } }
