/*
Rules: P11-raw-interpolation-formattable
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 2
Mutate: FormattableString form=$$"""soil {{n}} and {{m}}""";
Into: FormattableString form=$$"""soil {{0}} and {{m}}""";
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int n=829; string m="shale";
        FormattableString form=$$"""soil {{n}} and {{m}}""";
        Check(form.Format=="soil {0} and {1}" && (int)form.GetArgument(0)==829 && (string)form.GetArgument(1)=="shale", "P11-raw-interpolation-formattable-pilot-200001-check-01");
        Check(form.ToString(null)=="soil 829 and shale", "P11-raw-interpolation-formattable-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
