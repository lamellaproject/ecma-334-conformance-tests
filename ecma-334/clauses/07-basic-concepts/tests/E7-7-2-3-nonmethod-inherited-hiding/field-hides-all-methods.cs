/*
Rules: E7-7-2-3-nonmethod-inherited-hiding
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: reject
Mutate: public new int Read = 29;
Into: public new int Renamed = 29;
*/
delegate int NoArg();
delegate int OneArg(int value);
class Root { public int Read() { return 17; } public int Read(int value) { return 23; } }
class Branch : Root
{
    public new int Read = 29;
    public int Probe() { NoArg first = Read; OneArg second = Read; return first() + second(5); }
}
class Program { static void Main() { } }
