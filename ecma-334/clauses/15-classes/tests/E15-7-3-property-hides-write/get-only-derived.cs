/*
Rules: E15-7-3-property-hides-write
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: box.Item = 25;
Into: ((Base)box).Item = 25;
*/
class Base { int slot; public int Item { get { return slot; } set { slot = value; } } }
class Derived : Base { public new int Item { get { return 12; } } }
class Program { static void Main() { Derived box = new Derived(); box.Item = 25; } }
