/*
Rules: E15-3-8-static-no-this
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: Receiver = this;
Into: Receiver = null;
*/
class Register
{
    public delegate void Signal();
    private static object Receiver;
    public static event Signal Changed { add { Receiver = this; } remove { } }
}
class Program { static void Main() { } }
