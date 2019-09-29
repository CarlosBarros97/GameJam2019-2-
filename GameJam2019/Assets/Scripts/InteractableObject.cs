using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public ChoiceScript choiceScript;
    public PlayerController playerController;

    public Text interactableText;
    public float yOffset;
    public string objectName;

    private bool inRange = false;

    private int interactID;

    private bool interacting = false;
    private bool interacted = false;

    private void Start()
    {
        interactableText.text = "Press E to use the " + objectName + ".";

        interactableText.transform.position = GetComponent<Transform>().position - new Vector3(0f, yOffset, 0f);

        if (this.gameObject.name == "ParkingMeter")
            interactID = 1;
        if (this.gameObject.name == "DeskInfoGuy")
            interactID = 2;


    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.enabled = false;
                choiceScript.choicePanel1.gameObject.SetActive(true);
                interactableText.gameObject.SetActive(false);
                interacting = true;
                interacted = true;
            }
        }

        if(interacting)
        {
            if(interactID == 1)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    choiceScript.choicePanel1.SetActive(false);
                    choiceScript.ChoiceOption1();
                    interacting = false;
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    choiceScript.choicePanel1.SetActive(false);
                    choiceScript.ChoiceOption2();
                    interacting = false;
                }
            }
            else if(interactID == 2)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    choiceScript.choicePanel1.SetActive(false);
                    choiceScript.ChoiceOption3();
                    interacting = false;
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    choiceScript.choicePanel1.SetActive(false);
                    choiceScript.ChoiceOption4();
                    interacting = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactableText.gameObject.SetActive(true);

            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactableText.gameObject.SetActive(false);

            inRange = false;

            if(interacting)
            {
                choiceScript.interactableCanvas.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        /*if(collision.gameObject.tag == "Player")
        {
            Debug.Log("IN INTERACTABLE");
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            playerController.enabled = false;
            choiceScript.choicePanel1.gameObject.SetActive(true);
            interactableText.gameObject.SetActive(false);
            interacting = true;
        }
    }*/
    }
}
