using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    /// <summary>
    /// Set the type of the turret to build to standard turret.
    /// </summary>
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret selected");
        BuildManager.instance.SetTurretToBuild(BuildManager.instance.StandardTurretPrefab);
    }

    /// <summary>
    /// Set the type of the turret to build to turret 2.
    /// </summary>
    public void PurchaseLongRangeTurret()
    {
        Debug.Log("Long range turret selected");
        BuildManager.instance.SetTurretToBuild(BuildManager.instance.LongRangeTurretPrefab);
    }

    /// <summary>
    /// Set the type of the turret to build to turret 3.
    /// </summary>
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile launcher selected");
        BuildManager.instance.SetTurretToBuild(BuildManager.instance.MissileLauncherPrefab);
    }
}
