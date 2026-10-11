/*
Rules: E15-7-6-override-single-accessor
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: get { return 37; }
Into: 
*/
class Base { public virtual int Item { set { } } }
class Derived : Base { public override int Item { get { return 37; } set { } } }
class Program { static void Main() { } }
