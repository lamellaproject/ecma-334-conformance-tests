/*
Rules: E12-8-16-5-best-common-element-type
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: reject
Mutate: new Left(), new Right()
Into: (object)new Left(), new Right()
*/
class Left { }
class Right { }
class Program
{
    static void Main() { var cells = new[] { new Left(), new Right() }; }
}
