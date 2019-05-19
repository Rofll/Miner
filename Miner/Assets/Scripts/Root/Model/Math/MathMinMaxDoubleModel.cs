using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathMinMaxDoubleModel
{
    public MathMinMaxDoubleModel(double min, double max)
    {
        this.min = min;
        this.max = max;
    }

    private readonly double min;
    private readonly double max;

    public double Min
    {
        get { return min; }
    }

    public double Max
    {
        get { return max; }
    }

}
