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
    private static object Receiver;
    static Register() { Receiver = this; }
}
class Program { static void Main() { } }
