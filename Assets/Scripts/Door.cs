using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public void Interact(Transform toMove)
    {
        toMove.position = target.position;
    }
}
