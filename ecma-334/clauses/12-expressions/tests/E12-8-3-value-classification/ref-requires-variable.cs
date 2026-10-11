/*
Rules: E12-8-3-value-classification
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: reject
Mutate: Touch(ref $"v{3}");
Into: Touch(ref value);
Csc: CS1510
*/
class Program
{
    static void Touch(ref string value) { value = "changed"; }
    static void Main()
    {
        string value = "v3";
        Touch(ref $"v{3}");
    }
}
