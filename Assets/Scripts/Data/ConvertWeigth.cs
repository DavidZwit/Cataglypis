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

    static string toMili(float val) { return val * 100 + "m"; }
    static string toCenti(float val) { return val * 10 + "c"; }
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

    public static string GetConverted(float val, metricSize metricsize, string unit = "g")
    {
        return convertFuncs[(int)metricsize](val) + unit;
    }
}
