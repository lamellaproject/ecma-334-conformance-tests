/*
Rules: E6-5-1-directive-start-form; E6-5-1-grammar-pp-directive-1; E6-5-1-grammar-pp-kind-1; E6-5-1-grammar-pp-kind-2; E6-5-1-grammar-pp-whitespace-1; E6-5-1-grammar-pp-new-line-1; E6-5-1-directive-trailing-comment; E6-3-1-grammar-input-section-part-2
Authority: ECMA-334 7th ed 6.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #  define ACTIVE
Into: #  undef ACTIVE
*/
   #  define ACTIVE   // declaration payload ends here
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        #   if ACTIVE    // conditional payload ends here
        int amount = 17;
        #  else
        int amount = 0;
        #   endif  // group ends here
        Check(amount == 17, "spaces-around-directive-start");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
