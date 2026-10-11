/*
Rules: E10-2-8-array; E10-2-8-array-list; E10-2-8-system-array
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: object[] objects=strings;
Into: object[] objects=default(object[]);
*/
using System;
using System.Collections.Generic;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] strings={"seed"}; object[] objects=strings; Array array=strings; ICloneable cloneable=strings;
        IList<object> list=strings; IReadOnlyList<object> read=strings; IEnumerable<object> values=strings;
        string[,] matrix=new string[1,1]; matrix[0,0]="grid"; object[,] wide=matrix;
        Check(ReferenceEquals(objects,strings) && ReferenceEquals(array,strings) && ReferenceEquals(cloneable,strings), "E10-2-8-array-pilot-001-check-01");
        Check(list[0].Equals("seed") && read[0].Equals("seed") && ReferenceEquals(values,strings) && wide[0,0].Equals("grid"), "E10-2-8-array-pilot-001-check-02");
        try { objects[0]=new object(); Check(false, "E10-2-8-array-pilot-001-check-03"); } catch (ArrayTypeMismatchException) { Check(true, "E10-2-8-array-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-2-8-array-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
