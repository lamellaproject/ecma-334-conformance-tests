/*
Rules: P08-static-local-no-enclosing-state
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: static int Read() { return outside; }
Into: int Read() { return outside; }
*/
class Program
{
    static int Compute(int outside)
    {
        static int Read() { return outside; }
        return Read();
    }
    static int Main() { return Compute(43) == 43 ? 0 : 1; }
}
