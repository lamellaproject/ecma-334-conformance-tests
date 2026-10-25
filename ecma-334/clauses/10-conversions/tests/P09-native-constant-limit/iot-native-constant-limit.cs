/*
Rules: P09-native-constant-limit
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: const nint wide = (nint)2147483701L;
Into: static readonly nint wide = unchecked((nint)2147483701L);
*/
class Program
{
    const nint wide = (nint)2147483701L;
    static int Main() { return wide == 0 ? 1 : 0; }
}
