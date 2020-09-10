using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for keeping track of if the player can build on the node, handle user's input,
/// and build turret on the node.
/// </summary>
public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Renderer rend;
    private Color initalColor;
    public Vector3 positionOffset;

    private GameObject turret;

    public Transform parent;
    private bool isAvailable = true;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        initalColor = rend.material.color;
        parent = GameObject.Find("Turrets").transform;
    }

    /// <summary>
    /// Build a turret on this node.
    /// </summary>
    private void OnMouseDown()
    {
        if (!isAvailable)
        {
            Debug.Log("This node is not available!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretType();
        turret = Instantiate(turretToBuild, this.transform.position + positionOffset, this.transform.rotation);
        turret.transform.SetParent(parent);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = initalColor;
    }
}
