/*
Rules: E12-6-4-2-instance-this
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Main() { Read(3); }
Into: Main() { new Program().Read(3); }
*/
class Program
{
    int Read(int x) { return x; }
    static void Main() { Read(3); }
}
