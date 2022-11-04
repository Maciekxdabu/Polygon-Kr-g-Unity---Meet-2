using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private Light targetLight;

    private void Start()
    {
        if (targetLight == null)
        {
            Debug.LogWarning("Light is not attatched to the Script!");
            throw new System.NullReferenceException();
        }

        Debug.Log("LightTrigger Started");
        targetLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        targetLight.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        targetLight.enabled = false;
    }
}
