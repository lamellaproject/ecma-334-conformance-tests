/*
Rules: E15-6-10-extension-nonnested-class
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: public static int Read(this int receiver)
Into: public static int Read(int receiver)
Csc: CS1109
*/
class Outer
{
    public static class Extensions { public static int Read(this int receiver) { return receiver; } }
}
class Program { static void Main() { } }
