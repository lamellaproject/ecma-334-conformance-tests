/*
Rules: E12-6-3-15-common-type-failure; E12-6-3-12-fixing-candidates; E12-6-3-12-fixing-failure
Authority: ECMA-334 7th ed 12.6.3.15
Version: 7.3
Expected: reject
Mutate: new Left(), new Right()
Into: (Base)new Left(), new Right()
*/
class Base { }
class Left : Base { }
class Right : Base { }
class Program
{
    static void Main() { var array = new[] { new Left(), new Right() }; }
}
