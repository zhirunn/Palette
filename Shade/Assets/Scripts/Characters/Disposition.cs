using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Disposition : System.Object
{
    public static Color Orange = new Color32(255, 140, 0, 255);

    [Range(0,100)]
    [SerializeField]
    public int disposition = 50;

    public Disposition(int disposition)
    {
        this.disposition = disposition;
    }

    /// <summary>
    /// Determine if a given disposition is similar to another disposition. 
    /// This equality checks for disposition similarity via the displayed colour.
    /// </summary>
    /// <param name="other">The other disposition to compare</param>
    /// <returns>true if similar; false otherwise.</returns>
    public bool isSimilar(Disposition other)
    {
        return other.getColor().Equals(getColor());
    }

    public Color getColor()
    {
        return Disposition.getColor(disposition);
    }

    /// <summary>
    /// Get the colour from a disposition amount between 0 and 100.
    /// </summary>
    /// <param name="disposition"></param>
    /// <returns></returns>
    public static Color getColor(int disposition)
    {
        if (disposition >= 50)
        {
            return Color.blue;
        }
        else
        {
            return Orange;
        }
    }

    public static Color POSITIVE = Color.blue;
    public static Color NEGATIVE = Orange;
}