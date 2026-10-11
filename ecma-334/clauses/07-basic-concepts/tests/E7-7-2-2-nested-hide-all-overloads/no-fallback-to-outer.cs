/*
Rules: E7-7-2-2-nested-hide-all-overloads
Authority: ECMA-334 7th ed 7.7.2.2
Version: 7.3
Expected: reject
Mutate: return Read("ash");
Into: return Container.Read("ash");
*/
class Container
{
    public static int Read(int value) { return 43; }
    public static int Read(string value) { return 47; }
    class Inner
    {
        static int Read(long value) { return 53; }
        static int Probe() { return Read("ash"); }
    }
}
class Program { static void Main() { } }
