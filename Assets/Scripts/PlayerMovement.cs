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

    //zmienna u�ywana w kodzie (nie widoczna w Inspektorze)
    private Vector3 tempRot;

    //metoda kt�ra si� powtarza co klatk� (FPS - Frames Per Second)
    void Update()
    {
        //poruszanie do przodu
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * movementSpeed;
        }

        //poruszanie do ty�u
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.forward * -1 * movementSpeed;
        }

        //skr�t w lewo
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            tempRot = transform.localEulerAngles;
            tempRot.y -= turnSpeed;
            transform.localEulerAngles = tempRot;
        }

        //skr�t w prawo
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            tempRot = transform.localEulerAngles;
            tempRot.y += turnSpeed;
            transform.localEulerAngles = tempRot;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("Interact", transform, SendMessageOptions.DontRequireReceiver);
    }
}
