/*
Rules: E12-19-3-goto-target
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: goto Outside;
Into: return;
*/
delegate void Invoke();
class Program
{
    static void Main()
    {
        Invoke function = () => { goto Outside; };
        Outside: return;
    }
}
