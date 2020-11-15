using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for building selecting turrets to build. 
/// </summary>
public class BuildManager : MonoBehaviour
{
    public GameObject StandardTurretPrefab;
    public GameObject LongRangeTurretPrefab;
    public GameObject MissileLauncherPrefab;

    private GameObject turretToBuild;

    // Singleton pattern: we only need 1 BuildManager for the entire game
    public static BuildManager instance = null;

    private void Awake()
    {
        if (instance != null)
            throw new Exception("There are more than 1 BuildManage instances!");

        instance = this;
    }
    
    /// <summary>
    /// Return the type of the turret to build to the caller
    /// </summary>
    /// <returns>Turret</returns>
    public GameObject GetTurretType()
    {
        return turretToBuild;
    }

    /// <summary>
    /// Set the type of the turret to build
    /// </summary>
    /// <param name="turret">GameObject of turret to build</param>
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
