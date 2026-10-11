/*
Rules: E15-3-1-type-nontype-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public class Token { }
Into: public class Other { }
*/
class Catalog
{
    public class Token { }
    public int Token;
}
class Program { static void Main() { } }
