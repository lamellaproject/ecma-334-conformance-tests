/*
Rules: P08-static-local-no-enclosing-state
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: static int Read() { return outside; }
Into: int Read() { return outside; }
*/
class Program
{
    static int Main()
    {
        int outside = 37;
        static int Read() { return outside; }
        return Read() == 37 ? 0 : 1;
    }
}
