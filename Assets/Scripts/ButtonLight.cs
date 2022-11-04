using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLight : MonoBehaviour
{
    [SerializeField] private Light lightTarget;

    public void InteractButton()
    {
        lightTarget.enabled = !lightTarget.enabled;
    }
}
