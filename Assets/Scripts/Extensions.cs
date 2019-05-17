using UnityEngine;

public static class Extensions {
    public static Vector2 To2d(this Vector3 v3){
        return new Vector2(v3.x, v3.y);
    }

    public static Vector2 Rotate(this Vector2 v, float degrees) {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    public static Vector2 ComponentOn(this Vector2 v, Vector2 direction){
        return direction.normalized * v.magnitude * Mathf.Cos(Vector2.Angle(v, direction)*Mathf.PI/180);
    }

    public static Vector2 SetMagnitude(this Vector2 v, float magnitude) {
        return v.normalized * magnitude;
    }

    public static Vector3 To3d(this Vector2 v2, float z = 0){
        return new Vector3(v2.x, v2.y, z);
    }

    public static Color SetAlpha(this Color color, float a){
        return new Color(color.r, color.g, color.b, a);
    }
}