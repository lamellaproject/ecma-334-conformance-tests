/*
Rules: E14-7-top-level-default-access
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: reject
Mutate: class Hidden { }
Into: public class Hidden { }
*/
class Hidden { }
public class Exposed : Hidden { }
class Program
{
    static void Main() {  }
}
