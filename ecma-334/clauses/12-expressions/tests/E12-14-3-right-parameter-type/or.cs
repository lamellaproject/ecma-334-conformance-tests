/*
Rules: E12-14-3-right-parameter-type
Authority: ECMA-334 7th ed 12.14.3
Version: 7.3
Expected: reject
Mutate: x || y
Into: x | y
*/
class Flag
{
    public static bool operator true(Flag x) { return true; }
    public static bool operator false(Flag x) { return false; }
    public static Flag operator |(Flag x, int y) { return x; }
}
class Program { static void Main() { Flag x = new Flag(); int y = 3; var result = x || y; } }
