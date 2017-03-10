using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DispositionHelper {
    public static Color Orange = new Color32(255, 140, 0, 255);

    /// <summary>
    /// Get the colour from a disposition amount between 0 and 100.
    /// </summary>
    /// <param name="disposition"></param>
    /// <returns></returns>
    public static Color getColor(int disposition)
    {
        if(disposition >= 60)
        {
            return Color.blue;
        } else if(disposition >=40)
        {
            return Color.gray;
        } else
        {
            return Orange;
        }
    }
}