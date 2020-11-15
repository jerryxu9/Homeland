using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        // Ensure that the turret doesn't build on the node under the turret buttons
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.instance.GetTurretType() == null)
            return;

        if (!isAvailable)
        {
            Debug.Log("This node is not available!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretType();
        turret = Instantiate(turretToBuild, this.transform.position + positionOffset, this.transform.rotation);
        turret.transform.SetParent(parent);
        isAvailable = false;
    }

    private void OnMouseEnter()
    {
        // The color of the node under the turret buttons will not be changed
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.instance.GetTurretType() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = initalColor;
    }
}
