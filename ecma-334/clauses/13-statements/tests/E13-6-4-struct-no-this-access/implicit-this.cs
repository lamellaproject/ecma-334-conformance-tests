/*
Rules: E13-6-4-struct-no-this-access
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: => Value;
Into: => copy.Value;
*/
struct Token
{
    public int Value;
    public int Read() { Token copy = this; int Local() => Value; return Local(); }
}
class Program { static void Main() { } }
