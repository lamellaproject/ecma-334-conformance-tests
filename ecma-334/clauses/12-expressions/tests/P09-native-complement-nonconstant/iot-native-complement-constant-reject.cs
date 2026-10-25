/*
Rules: P09-native-complement-nonconstant
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: const nint complement = ~(nint)13;
Into: const nint complement = (nint)(~13);
*/
class Program
{
    // Proposal L37-L39 lists native complement as foldable. The registered csc
    // rejects this native operand; the test follows that post-edition authority.
    const nint complement = ~(nint)13;
    static int Main() { return complement == -14 ? 0 : 1; }
}
