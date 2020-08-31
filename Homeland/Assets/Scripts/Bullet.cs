using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 70f;
    public GameObject bulletImapctEffect;

    /// <summary>
    /// Get the target from Turret.cs 
    /// </summary>
    /// <param name="_target">Enemy transform</param>
    public void ChaseTarget(Transform _target)
    {
        target = _target;
    }

    /// <summary>
    /// Shoot the bullet at target game object. Destory this bullet if the target is null or when it hits the target
    /// </summary>
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - this.transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        else
        {
            // Normalized as it ensures the speed is constant and irrelevant how close it is to the object
            this.transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }

    /// <summary>
    /// Instantiate bullet impact effect, do damage to the target and destroy the bullet
    /// </summary>
    private void HitTarget()
    {
        // do damge
        GameObject impactEffect = Instantiate(bulletImapctEffect, this.transform.position, this.transform.rotation);
        Destroy(impactEffect, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
        return;
    }
}
