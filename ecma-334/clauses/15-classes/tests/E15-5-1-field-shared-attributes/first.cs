/*
Rules: E15-5-1-field-shared-attributes; E15-5-1-field-attributes
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: [System.Obsolete("Retired", true)]
Into: [System.Obsolete("Retired", false)]
Csc: CS0619
*/
class Holder
{
    [System.Obsolete("Retired", true)]
    public int First = 41, Second = 61;
}
class Program { static void Main() { int value = new Holder().First; } }
