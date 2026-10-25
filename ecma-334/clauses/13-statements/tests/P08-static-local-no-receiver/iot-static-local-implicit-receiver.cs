/*
Rules: P08-static-local-no-receiver
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: static int Read() { return Code; }
Into: int Read() { return Code; }
*/
class Program
{
    int Code = 47;
    int Compute()
    {
        static int Read() { return Code; }
        return Read();
    }
    static int Main() { return new Program().Compute() == 47 ? 0 : 1; }
}
