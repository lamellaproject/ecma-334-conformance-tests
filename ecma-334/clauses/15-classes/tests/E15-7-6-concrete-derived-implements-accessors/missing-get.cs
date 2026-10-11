/*
Rules: E15-7-6-concrete-derived-implements-accessors
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: set { }
Into: get { return 36; } set { }
*/
abstract class Base { public abstract int Item { get; set; } }
class Derived : Base { public override int Item { set { } } }
class Program { static void Main() { } }
