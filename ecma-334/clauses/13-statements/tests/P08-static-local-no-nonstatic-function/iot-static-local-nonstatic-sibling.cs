/*
Rules: P08-static-local-no-nonstatic-function
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: int Helper() { return 31; }
Into: static int Helper() { return 31; }
*/
class Program
{
    static int Main()
    {
        int Helper() { return 31; }
        static int Read() { return Helper(); }
        return Read() == 31 ? 0 : 1;
    }
}
