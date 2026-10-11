/*
Rules: E20-2-new-nested-only
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: public new delegate void Notice();
Into: public delegate void Notice();
*/
public new delegate void Notice();
class Program { static void Main() { } }
