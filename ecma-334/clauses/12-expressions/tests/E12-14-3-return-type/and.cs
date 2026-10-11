/*
Rules: E12-14-3-return-type
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
    public static int operator &(Flag x, Flag y) { return 3; }
}
class Program { static void Main() { Flag x = new Flag(), y = new Flag(); var result = x && y; } }
