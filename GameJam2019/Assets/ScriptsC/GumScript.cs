using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumScript : MonoBehaviour
{

    public GameObject player;
    public float timeStuck = 5f;
    bool stuck = false;
    float endtime;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (stuck)
        {
            if (time > endtime)
            {
                player.GetComponent<PlayerController>().enabled = true;
                stuck = false;
                Destroy(this.gameObject);
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().enabled = false;
            stuck = true;
            endtime = timeStuck;

        }
    }
}
