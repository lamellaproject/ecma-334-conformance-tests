/*
Rules: P09-native-mixed-unsigned-forbidden
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: u + n
Into: u + (nuint)n
*/
class Program
{
    static int Main()
    {
        nuint u = 20;
        nint n = 3;
        var result = u + n;
        return result == 23 ? 0 : 1;
    }
}
