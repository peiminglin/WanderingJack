using UnityEngine;

public static class Extensions {
    public static Vector2 to2d(this Vector3 v3){
        return new Vector2(v3.x, v3.y);
    }

    public static Vector3 to3d(this Vector2 v2, float z = 0){
        return new Vector3(v2.x, v2.y, z);
    }
}