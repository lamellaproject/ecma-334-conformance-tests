/*
Rules: P10-struct-constructor-public
Authority: csc 5.12.0-1.26529.118 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: private Secret() { }
Into: public Secret() { }
*/
readonly record struct Secret
{
    private Secret() { }
}
class Program { static void Main() { } }
