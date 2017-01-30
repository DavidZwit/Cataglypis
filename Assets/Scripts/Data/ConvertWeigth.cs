using UnityEngine;

public enum metricSize
{
    mili = 0,
    centi = 1,
    deci = 2,
    unit = 3,
    deca = 4,
    hecto = 5,
    kilo = 6
}

public class ConvertUnit
{

    static string toMili(float val) { return val * 1000 + "m"; }
    static string toCenti(float val) { return val * 100 + "c"; }
    static string toDeci(float val) { return val * 10 + "d"; }
    static string toUnit(float val) { return val + ""; }
    static string toDeca(float val) { return val * .1f + "da"; }
    static string toHecto(float val) { return val * .01f + "h"; }
    static string toKilo(float val) { return val * .001f + "k"; }

    public delegate string conFunc(float val);
    static conFunc[] convertFuncs = new conFunc[] {
        toMili,
        toCenti,
        toDeci,
        toUnit,
        toDeca,
        toHecto,
        toKilo
    };

    public static metricSize GetRandomMetricSize()
    {
        return (metricSize)Mathf.Round(Random.Range(0, convertFuncs.Length));
    }
    public static metricSize GetPseudoRandomMetricSize()
    {
        int i = Random.Range(0, convertFuncs.Length);
        if (i < 2)
            i = 0;
        else if (i > 4)
            i = convertFuncs.Length-1;
        else
            i = 3;
        return (metricSize)i;

    }

    public static string GetConverted(float val, metricSize metricsize, string unit = "g")
    {
        return convertFuncs[(int)metricsize](val) + unit;
    }
}
