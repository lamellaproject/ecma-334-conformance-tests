/*
Rules: E14-7-class-nested-default-access
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: reject
Mutate: class Hidden { }
Into: public class Hidden { }
*/
class Owner { class Hidden { } }
class Program
{
    static void Main() { Owner.Hidden value = null; }
}
