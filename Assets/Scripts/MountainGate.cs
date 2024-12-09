using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MountainGate : MonoBehaviour
{
    public bool isToOpenGate = false;
    [SerializeField] private Animator _animator;


    private void OnTriggerEnter(Collider other)
    {
        // TODO: check if it's XR rig 
        // TODO: test animation
        OpenMountainGate();
        // TODO: loan WhereIsHammer scene
    }

    private void OpenMountainGate()
    {
        if (isToOpenGate)
        {
            _animator.SetBool("isToOpenGate", true);
        }
    }
}
