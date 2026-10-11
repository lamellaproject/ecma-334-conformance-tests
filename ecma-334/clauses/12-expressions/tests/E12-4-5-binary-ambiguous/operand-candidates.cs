/*
Rules: E12-4-5-binary-ambiguous
Authority: ECMA-334 7th ed 12.4.5
Version: 7.3
Expected: reject
Mutate: left + right
Into: left + (int)right
*/
struct Left
{
    public static implicit operator int(Left x) { return 3; }
    public static int operator +(Left x, int y) { return 1; }
}
struct Right
{
    public static implicit operator int(Right y) { return 5; }
    public static int operator +(int x, Right y) { return 2; }
}
class Program { static void Main() { Left left = new Left(); Right right = new Right(); int result = left + right; } }
