/*
Rules: E12-8-13-class-member-classification
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: Take(ref this)
Into: Take(ref local)
*/
class Box
{
    static void Take(ref Box value) { }
    public void Act() { Box local = this; Take(ref this); }
}
class Program { static void Main() { new Box().Act(); } }
