using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxParent : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private int typeBox = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Out()
    {
        anim.Play("Idle_" + typeBox);
    }
}