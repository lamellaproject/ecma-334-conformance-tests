/*
Rules: E7-3-statement-local-spaces; E7-3-nested-local-name-conflict
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: catch (Exception caught)
Into: catch (Exception renamed)
*/
using System;
class Program
{
    static void Main()
    {
        int caught = 0;
        try { throw new Exception(); }
        catch (Exception caught) { }
    }
}
