/*
Rules: P09-native-dependent-shift-nonconstant
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: const nint shifted = (nint)13 >> 33;
Into: const nint shifted = (nint)13 >> 1;
*/
class Program
{
    // Proposal L38's fixed Int32 operation would mask the count and give six.
    // The registered csc refuses a constant whose native-width results differ.
    const nint shifted = (nint)13 >> 33;
    static int Main() { return shifted == 6 ? 0 : 1; }
}
