using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour
{

    public Camera mainCam;
    public GameObject player;

    public float travelSpeed = 1f;

    private Vector3[] camLocations = new[] { new Vector3(0f, 0f, -10f), new Vector3(16f, 0f, -10f), new Vector3(32f, 0f, -10f), new Vector3(48f, 0f, -10f) };
    private int currentCam = 0;

    private float step;
    private bool camMoving = false;

    private void Start()
    {
        mainCam.transform.position = camLocations[0];

        step = travelSpeed * Time.deltaTime;
    }

    private void Update()
    {
        moveToNextCam();

        if(currentCam >= 3)
        {
            mainCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f, -10f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CamPanCollider")
        {
            collision.collider.enabled = false;
            camMoving = true;
        }

    }

    private void moveToNextCam()
    {
        if (camMoving)
        {
            mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, camLocations[currentCam + 1], step);
            Debug.Log("MOVING CAM");

            if(Vector3.Distance(mainCam.transform.position, camLocations[currentCam + 1]) < 0.01f)
            {
                camMoving = false;
                currentCam++;
            }
        }
    }



}
