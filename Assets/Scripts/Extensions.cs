using UnityEngine;

public static class Extensions {
    /// <summary>
    /// Transfer Vector3 to Vector2
    /// </summary>
    /// <returns>The Vector2.</returns>
    public static Vector2 To2d(this Vector3 v3){
        return new Vector2(v3.x, v3.y);
    }

    /// <summary>
    /// Rotate the Vector2 with degrees.
    /// </summary>
    /// <returns>The new Vector2.</returns>
    /// <param name="degrees">The angle in degrees.</param>
    public static Vector2 Rotate(this Vector2 v, float degrees) {
        float sin = Mathf.Sin(-degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(-degrees * Mathf.Deg2Rad);

        //sin(a+b) = sina * cosb + cosa * sinb
        //cos(a+b) = cosa * cosb - sina * sinb
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    /// <summary>
    /// Get the component of the Vector2 in that direction
    /// </summary>
    /// <returns>The component direction.</returns>
    /// <param name="direction">The direction.</param>
    public static Vector2 ComponentOn(this Vector2 v, Vector2 direction){
        return direction.normalized * v.magnitude * Mathf.Cos(Vector2.Angle(v, direction)*Mathf.PI/180);
    }

    /// <summary>
    /// Change the magnitude of the Vector2
    /// </summary>
    /// <returns>The new Vector2.</returns>
    /// <param name="magnitude">Magnitude.</param>
    public static Vector2 SetMagnitude(this Vector2 v, float magnitude) {
        return v.normalized * magnitude;
    }

    /// <summary>
    /// Transfer the Vector2 to Vector3 by adding z value(0 by default).
    /// </summary>
    /// <returns>The Vector3.</returns>
    /// <param name="z">The z coordinate.</param>
    public static Vector3 To3d(this Vector2 v2, float z = 0){
        return new Vector3(v2.x, v2.y, z);
    }

    /// <summary>
    /// Sets the alpha of the color.
    /// </summary>
    /// <returns>The new color.</returns>
    /// <param name="a">The alpha component.</param>
    public static Color SetAlpha(this Color color, float a){
        return new Color(color.r, color.g, color.b, a);
    }
}