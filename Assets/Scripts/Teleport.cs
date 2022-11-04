using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public void Interact(Transform toMove)
    {
        Debug.Log("Door Interaction", gameObject);

        toMove.position = target.position;
    }
}
