using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //poprawne, ale nie polecane
    public float movementSpeed = 0.01f;

    //poprawne i polecane
    [SerializeField]
    private float turnSpeed = 0.5f;

    //zmienna u¿ywana w kodzie (nie widoczna w Inspektorze)
    private Vector3 tempRot;

    private List<GameObject> interactable = new List<GameObject>();

    void Update()
    {
        //move forward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * movementSpeed;
        }

        //move backwards
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * movementSpeed;
        }

        //turn left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            tempRot = transform.localEulerAngles;
            tempRot.y -= turnSpeed;
            transform.localEulerAngles = tempRot;
        }

        //turn right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            tempRot = transform.localEulerAngles;
            tempRot.y += turnSpeed;
            transform.localEulerAngles = tempRot;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int n = 0; n < interactable.Count; n++)
            { 
                interactable[n].gameObject.SendMessage("InteractButton", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //interaction with the door
        collision.gameObject.SendMessage("Interact", transform, SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerEnter(Collider other)
    {
        interactable.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        interactable.Remove(other.gameObject);
    }
}
