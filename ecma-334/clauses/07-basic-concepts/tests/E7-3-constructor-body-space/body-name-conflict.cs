/*
Rules: E7-3-constructor-body-space; E7-3-nested-local-name-conflict
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: int initialized = 7;
Into: int local = 7;
*/
class Base { public Base(int value) { } }
class Derived : Base
{
    public Derived() : base(Produce(out int initialized)) { int initialized = 7; }
    static int Produce(out int value) { value = 31; return 37; }
}
class Program { static void Main() { new Derived(); } }
