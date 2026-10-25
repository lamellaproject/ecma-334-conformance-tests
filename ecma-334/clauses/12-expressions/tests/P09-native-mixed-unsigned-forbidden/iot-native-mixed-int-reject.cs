/*
Rules: P09-native-mixed-unsigned-forbidden
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: u + signed
Into: u + (nuint)signed
*/
class Program
{
    static int Main()
    {
        nuint u = 40;
        int signed = 6;
        var result = u + signed;
        return result == 46 ? 0 : 1;
    }
}
