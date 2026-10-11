/*
Rules: E12-23-no-user
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: (int)(Token)4
Into: (int)4
Csc: CS0133
*/
struct Token
{
    public int Number;
    public static implicit operator Token(int value) { return new Token { Number = value }; }
    public static explicit operator int(Token value) { return value.Number; }
}
class Program
{
    const int Value = (int)(Token)4;
    static void Main() { }
}
