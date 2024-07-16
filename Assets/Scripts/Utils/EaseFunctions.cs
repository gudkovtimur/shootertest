using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//функции плавности, используются для более красивой анимации
public class EaseFunctions 
{

    public static float InQuad(float t)
    {
        return t * t;
    }

    public static float OutQuad(float t)
    {
        return 1 - InQuad(1 - t);
    }
    public static float InOutQuad(float t)
    {
        return t < 0.5f ? InQuad(t * 2) / 2 : 1 - InQuad((1 - t) * 2) / 2;
    }

    public static float InSine(float t)
    {
       return 1 - Mathf.Cos(t * Mathf.PI / 2f);
    }

    public static float OutSine(float t)
    {
        return Mathf.Sin(t * Mathf.PI / 2f);
    }

    public static float InOutSine(float t)
    {
       return -(Mathf.Cos(t * Mathf.PI) - 1) / 2;
    }

    public static float InCubic(float t)
    {
        return t * t * t;
    }

    public static float OutCubic(float t)
    {
        return 1 - Mathf.Pow(1 - t, 3);
    }

    public static float InOutCubic(float t)
    {
        return t < 0.5f ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
    }
    
    public static float InQuart(float t)
    {
        return t * t * t * t;
    }

    public static float OutQuart(float t)
    {
        return 1 - Mathf.Pow(1 - t, 4);
    }

    public static float InOutQuart(float t)
    {
        return t < 0.5f ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
    }
    
    public static float InQuint(float t)
    {
        return t * t * t * t * t;
    }

    public static float OutQuint(float t)
    {
        return 1 - Mathf.Pow(1 - t, 5);
    }

    public static float InOutQuint(float t)
    {
        return t < 0.5f ? 16 * t * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
    }
    
    public static float InExpo(float t)
    {
        return t == 0 ? 0 : Mathf.Pow(2, 10 * t - 10);
    }

    public static float OutExpo(float t)
    {
        return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
    }

    public static float InOutExpo(float t)
    {
        if (t == 0 || t == 1)
            return t;
        return t < 0.5f ? Mathf.Pow(2, 20 * t - 10) / 2 : (2 - Mathf.Pow(2, -20 * t + 10)) / 2; 
    }
    
    public static float InCirc(float t)
    {
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
    }

    public static float OutCirc(float t)
    {
        return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
    }

    public static float InOutCirc(float t)
    {
        return t < 0.5f ? 
            (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2 : 
            (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;
    }

    private const float c1 = 1.70158f;
    private const float c2 = 2.59491f;
    private const float c3 = 2.70158f;
    private const float c4 = (2f * Mathf.PI) / 3f;
    private const float c5 = (2 * Mathf.PI) / 4.5f;
    
    public static float InBack(float t)
    {
        return c3 * t * t * t - c1 * t * t;
    }

    public static float OutBack(float t)
    {
        return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
    }

    public static float InOutBack(float t)
    {
        return t < 0.5f
            ? (Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2
            : (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;
    }
    
    public static float InElastic(float t)
    {
        if (t == 0 || t == 1)
            return t;
        return t == 1 ? 1 : -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
    }

    public static float OutElastic(float t)
    {
        if (t == 0 || t == 1)
            return t;
        return t == 1 ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
    }

    public static float InOutElastic(float t)
    {
        if (t == 0 || t == 1)
            return t;
        return  t < 0.5f
                    ? -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2
                    : (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2 + 1;
    }

    private const float n1 = 7.5625f;
    private const float d1 = 2.75f;
    
    public static float InBounce(float t)
    {
        return 1 - OutBounce(1 - t);
    }

    public static float OutBounce(float t)
    {
        if (t < 1 / d1)
        {
            return n1 * t * t;
        }
        else if (t < 2 / d1)
        {
            t -= 1.5f / d1;
            return n1 * t * t + 0.75f;
        }
        else if (t < 2.5 / d1)
        {
            t -= 2.25f / d1;
            return n1 * t * t + 0.9375f;
        }
        else
        {
            t -= 2.625f / d1;
            return n1 * t * t + 0.984375f;
        }
    }

    public static float InOutBounce(float t)
    {
        return t < 0.5f
            ? (1 - OutBounce(1 - 2 * t)) / 2f
            : (1 + OutBounce(2 * t - 1)) / 2f;
    }
}
