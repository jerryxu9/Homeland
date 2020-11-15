using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 70f;
    public float explosionRadius = 0f;
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
            this.transform.LookAt(target);
        }
    }

    /// <summary>
    /// Instantiate bullet impact effect, do damage to the target and destroy the bullet
    /// </summary>
    private void HitTarget()
    {
        // do damge
        GameObject impactEffect = Instantiate(bulletImapctEffect, this.transform.position, this.transform.rotation);
        Destroy(impactEffect, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
        return;
    }

    /// <summary>
    /// Do damage to every enmey in the explosion radius
    /// </summary>
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    /// <summary>
    /// Do damage to the a single enmey
    /// </summary>
    private void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    /// <summary>
    /// Display the explosion range
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
    }
}
