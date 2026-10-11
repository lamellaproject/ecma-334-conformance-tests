/*
Rules: E15-7-3-property-hides-read
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: int seen = box.Item;
Into: int seen = ((Base)box).Item;
*/
class Base { public int Item { get { return 15; } } }
class Derived : Base { public new int Item { set { } } }
class Program { static void Main() { Derived box = new Derived(); int seen = box.Item; } }
