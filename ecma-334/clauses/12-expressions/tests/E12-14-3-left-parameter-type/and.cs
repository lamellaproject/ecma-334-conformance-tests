/*
Rules: E12-14-3-left-parameter-type
Authority: ECMA-334 7th ed 12.14.3
Version: 7.3
Expected: reject
Mutate: x && y
Into: x & y
*/
class Flag
{
    public static bool operator true(Flag x) { return true; }
    public static bool operator false(Flag x) { return false; }
    public static Flag operator &(int x, Flag y) { return y; }
}
class Program { static void Main() { int x = 3; Flag y = new Flag(); var result = x && y; } }
