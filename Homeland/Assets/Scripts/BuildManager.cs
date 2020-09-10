using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for building selecting turrets to build. 
/// </summary>
public class BuildManager : MonoBehaviour
{
    public GameObject standardTurretPrefab;
    private GameObject turretToBuild;

    // Singleton pattern: we only need 1 BuildManager for the entire game
    public static BuildManager instance = null;

    private void Awake()
    {
        if (instance != null)
            throw new Exception("There are more than 1 BuildManage instances!");

        instance = this;
    }

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    
    /// <summary>
    /// Return the type of the turret to build to the caller
    /// </summary>
    /// <returns>Turret</returns>
    public GameObject GetTurretType()
    {
        return turretToBuild;
    }
}
