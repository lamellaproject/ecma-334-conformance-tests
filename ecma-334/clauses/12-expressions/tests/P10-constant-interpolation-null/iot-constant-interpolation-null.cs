/*
Rules: P10-constant-interpolation-null
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: $"[{Missing}]"
Into: $"[{""}]"
*/
class Program
{
    // Proposal L64 and alpha-v13 expressions L1783 permit string constants.
    // Registered csc nevertheless rejects a typed null-valued hole as nonconstant.
    const string Missing = null;
    const string Value = $"[{Missing}]";
    static void Main() { System.Console.WriteLine(Value); }
}
