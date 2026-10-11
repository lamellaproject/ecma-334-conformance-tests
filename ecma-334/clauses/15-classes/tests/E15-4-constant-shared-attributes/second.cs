/*
Rules: E15-4-constant-shared-attributes; E15-4-constant-attributes
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: [System.Obsolete("Retired", true)]
Into: [System.Obsolete("Retired", false)]
Csc: CS0619
*/
class Limits
{
    [System.Obsolete("Retired", true)]
    public const int First = 31, Second = 47;
}
class Program { static void Main() { int value = Limits.Second; } }
