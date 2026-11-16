/*
Rules: E15-2-5-pointer-constraint-satisfaction; E15-2-5-pointer-type-argument
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Capsule<int*> value = null;
Into: Capsule<int> value = null;
*/
class Capsule<T> where T : struct { }
class Program
{
    static void Main()
    {
        unsafe
        {
            Capsule<int*> value = null;
        }
    }
}
