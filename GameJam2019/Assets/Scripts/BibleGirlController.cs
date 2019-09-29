using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleGirlController : MonoBehaviour
{

    public Collider2D bibleGirlCollider;
    public PlayerController playerController;
    public GameObject bibleGirl;

    private float travelSpeed = 25f;
    private float step;

    private float maxTime = 1f;
    private float time = 0f;

    private bool countDownStart = false;
    private bool playerStopped = false;

    private void Start()
    {
        step = travelSpeed * Time.deltaTime;
    }

    private void Update()
    {
        if(playerStopped)
        {
            bibleGirl.transform.position = Vector3.MoveTowards(bibleGirl.transform.position, playerController.GetComponent<Transform>().position, step);

            if (Vector3.Distance(bibleGirl.transform.position, playerController.GetComponent<Transform>().position) < 1.5f)
            {
                playerStopped = false;
                countDownStart = true;
            }
        }

        if(countDownStart)
        {
            if(time > maxTime)
            {
                playerController.enabled = true;
                countDownStart = false;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerController.enabled = false;
            playerStopped = true;
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
