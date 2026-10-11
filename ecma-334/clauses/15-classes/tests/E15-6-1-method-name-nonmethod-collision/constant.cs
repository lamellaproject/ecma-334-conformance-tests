/*
Rules: E15-6-1-method-name-nonmethod-collision
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public const int Read = 2;
Into: public const int Stored = 2;
Csc: CS0102
*/
class Holder
{
    public const int Read = 2;
    public int Read() { return 1; }
}
class Program { static void Main() { } }
