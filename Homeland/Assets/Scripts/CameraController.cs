using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool shouldMove = true;
    [Header("Attributes")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;                        // For scrolling
    public float maxY = 80f;                        // For scrolling

    /// <summary>
    /// Check for player's input and move the camera accordingly
    /// </summary>
    private void Update()
    {
        // if the player presses the Escape key, disable camera movement
        if (Input.GetKeyDown(KeyCode.Escape))
            shouldMove = !shouldMove;

        if (!shouldMove)
            return;

        //if ((Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness) && Camera.main.transform.position.z < -45f)
        //{
        //    this.transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        //}
        //if ((Input.GetKey(KeyCode.S) || Input.mousePosition.y <= Screen.height - panBorderThickness) && Camera.main.transform.position.z > -65f)
        //{
        //    this.transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        //}
        //if ((Input.GetKey(KeyCode.A) || Input.mousePosition.x <= Screen.width - panBorderThickness) && Camera.main.transform.position.x > 30f)
        //{
        //    this.transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        //}
        //if ((Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness) && Camera.main.transform.position.x < 50f)
        //{
        //    this.transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        //}

        if ((Input.GetKey(KeyCode.W)) && Camera.main.transform.position.z < -15f)
        {
            this.transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey(KeyCode.S)) && Camera.main.transform.position.z > -80f)
        {
            this.transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey(KeyCode.A)) && Camera.main.transform.position.x > 15f)
        {
            this.transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey(KeyCode.D)) && Camera.main.transform.position.x < 65f)
        {
            this.transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // zoom in and out if the player scrolls 
        float scrollMagnitude = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = this.transform.position;
        pos.y -= scrollMagnitude * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        this.transform.position = pos;
    }
}
