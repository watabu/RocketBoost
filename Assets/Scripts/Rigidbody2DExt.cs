//https://stackoverflow.com/questions/34250868/unity-addexplosionforce-to-2d
using UnityEngine;

public static class Rigidbody2DExt
{

    /// <summary>
    /// 指定した爆発半径でちょうど力が0になる
    /// </summary>
    /// <param name="rb"></param>
    /// <param name="explosionForce"></param>
    /// <param name="explosionPosition"></param>
    /// <param name="explosionRadius"></param>
    /// <param name="upwardsModifier"></param>
    /// <param name="mode"></param>
    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else
        {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }
        //rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
        //爆発半径以上なら0, 爆心なら1
        float force = Mathf.Lerp(0, 1, (1 - explosionDistance / explosionRadius)) * explosionForce;
        rb.AddForce(force * explosionDir, mode);
    }
}