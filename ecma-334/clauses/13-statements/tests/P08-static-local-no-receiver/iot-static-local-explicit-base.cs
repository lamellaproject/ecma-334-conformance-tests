/*
Rules: P08-static-local-no-receiver
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: static int Read() { return base.Code; }
Into: int Read() { return base.Code; }
*/
class Parent { protected int Code = 59; }
class Program : Parent
{
    int Compute()
    {
        static int Read() { return base.Code; }
        return Read();
    }
    static int Main() { return new Program().Compute() == 59 ? 0 : 1; }
}
