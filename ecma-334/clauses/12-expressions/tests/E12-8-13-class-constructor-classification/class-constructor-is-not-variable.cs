/*
Rules: E12-8-13-class-constructor-classification
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: Take(ref this)
Into: Take(ref local)
*/
class Box
{
    static void Take(ref Box value) { }
    public Box() { Box local = null; Take(ref this); }
}
class Program { static void Main() { new Box(); } }
