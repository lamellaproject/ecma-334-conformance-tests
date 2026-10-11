/*
Rules: E15-7-6-private-accessor-nonvirtual; E15-7-6-overridden-accessor-accessible
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: set { copy = value; }
Into: 
*/
class Base { int slot; public virtual int Item { get { return slot; } private set { slot = value; } } }
class Derived : Base { int copy; public override int Item { get { return copy; } set { copy = value; } } }
class Program { static void Main() { } }
