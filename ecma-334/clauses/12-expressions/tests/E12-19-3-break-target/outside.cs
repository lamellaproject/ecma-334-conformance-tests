/*
Rules: E12-19-3-break-target
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: () => { break; }
Into: () => { return; }
*/
delegate void Invoke();
class Program
{
    static void Main()
    {
        bool condition = true;
        while (condition) { Invoke function = () => { break; }; break; }
    }
}
