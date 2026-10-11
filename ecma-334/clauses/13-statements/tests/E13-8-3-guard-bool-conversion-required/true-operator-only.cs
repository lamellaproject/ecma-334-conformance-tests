/*
Rules: E13-8-3-guard-bool-conversion-required
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/true-operator-only-d8e369b4eb.cs.part
Mutate: case 1 when new Truth():
Into: case 1 when true:
*/
struct Truth
{
    public static bool operator true(Truth value) { return true; }
    public static bool operator false(Truth value) { return false; }
}
class Program
{
    static void Main()
    {
        int value = 1;
        // operator true satisfies a boolean_expression, but supplies no implicit conversion to bool.
        switch (value) { case 1 when new Truth(): break; }
    }
}
