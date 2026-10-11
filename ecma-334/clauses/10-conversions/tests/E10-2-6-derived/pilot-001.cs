/*
Rules: E10-2-6-derived; E10-3-4-derived; E10-6-1-nullable-nullable; E10-6-1-value-nullable; E10-6-1-nullable-value; E10-6-1-classification; E10-6-1-standard; E10-6-1-null; E10-6-1-nonnull; E10-6-1-wrap; E10-6-1-unwrap; E8-3-12-unwrap-null; E8-3-12-unwrap-value; E8-3-12-wrap; E10-2-1-categories; E10-3-1-categories
Authority: ECMA-334 7th ed 10.2.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: long? wide=present, absent=missing;
Into: long? wide=null, absent=missing;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? present=317, missing=null; long? wide=present, absent=missing;
        long? wrapped=317; byte? narrowed=unchecked((byte?)present);
        long bare=(long)present;
        Check(wide.HasValue && wide.Value==317 && !absent.HasValue && wrapped.Value==317 && narrowed.Value==61 && bare==317, "E10-2-6-derived-pilot-001-check-01");
        try { long fail=(long)missing; Check(false, "E10-2-6-derived-pilot-001-check-02"); } catch (InvalidOperationException) { Check(true, "E10-2-6-derived-pilot-001-check-02"); } catch (Exception error) { Check(false, "E10-2-6-derived-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        try { byte? fail=checked((byte?)present); Check(false, "E10-2-6-derived-pilot-001-check-03"); } catch (OverflowException) { Check(true, "E10-2-6-derived-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-2-6-derived-unexpected-exception-2"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
