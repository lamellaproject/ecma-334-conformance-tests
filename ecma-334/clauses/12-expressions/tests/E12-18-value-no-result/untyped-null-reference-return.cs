/*
Rules: E12-18-value-no-result
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: return flag ? null : null;
Into: return flag ? (object)null : null;
*/
class Program
{
    static object Pick(bool flag)
    {
        return flag ? null : null;
    }
    static void Main() { }
}
