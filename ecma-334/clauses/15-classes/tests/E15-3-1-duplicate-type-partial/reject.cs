/*
Rules: E15-3-1-duplicate-type-partial
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public class Entry { public int Second; }
Into: public partial class Entry { public int Second; }
*/
class Catalog
{
    public partial class Entry { public int First; }
    public class Entry { public int Second; }
}
class Program { static void Main() { } }
