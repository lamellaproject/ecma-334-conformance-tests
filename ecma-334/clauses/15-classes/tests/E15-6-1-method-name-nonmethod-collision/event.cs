/*
Rules: E15-6-1-method-name-nonmethod-collision
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public event System.Action Read;
Into: public event System.Action Changed;
Csc: CS0102
*/
class Holder
{
    public event System.Action Read;
    public int Read() { return 1; }
}
class Program { static void Main() { } }
