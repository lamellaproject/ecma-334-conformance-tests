/*
Rules: E15-7-6-sealed-property-no-further-override; E15-7-6-sealed-property-accessors
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: sealed override int Item
Into: override int Item
*/
class Base { int slot; public virtual int Item { get { return slot; } set { slot = value; } } }
class Middle : Base { public sealed override int Item { get { return 18; } set { } } }
class Derived : Middle { public override int Item { get { return 29; } } }
class Program { static void Main() { } }
