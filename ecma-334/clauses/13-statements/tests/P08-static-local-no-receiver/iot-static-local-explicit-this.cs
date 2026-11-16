/*
Rules: P08-static-local-no-receiver
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: static int Read() { return this.Code; }
Into: int Read() { return this.Code; }
*/
class Program
{
    int Code = 53;
    int Compute()
    {
        static int Read() { return this.Code; }
        return Read();
    }
    static int Main() { return new Program().Compute() == 53 ? 0 : 1; }
}
