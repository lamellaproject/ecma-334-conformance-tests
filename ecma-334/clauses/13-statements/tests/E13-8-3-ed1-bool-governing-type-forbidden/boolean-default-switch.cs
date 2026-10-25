/*
Rules: E13-8-3-ed1-bool-governing-type-forbidden
Authority: ECMA-334 1st ed 15.7.2
Version: ISO-1
Expected: reject
Mutate: switch (flag)
Into: switch (flag ? 1 : 0)
*/
// ECMA-334 1st ed 15.7.2, p. 186 (PDF p. 200), lines 3-8 has no bool governing type.
class Entry
{
    public static int Main()
    {
        bool flag = true;
        switch (flag) { default: return 0; }
    }
}
