using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public Text interactableText;
    public float yOffset;
    public string objectName;

    private bool interacting = false;

    private void Start()
    {
        interactableText.text = "Press E to use the " + objectName + ".";

        interactableText.transform.position = GetComponent<Transform>().position - new Vector3(0f, yOffset, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            interactableText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactableText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            interacting = true;
        }
    }
}
