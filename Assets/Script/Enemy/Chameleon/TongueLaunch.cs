using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueLaunch : MonoBehaviour
{
    private GameObject tongue;

    private void Start()
    {
        tongue = this.transform.GetChild(3).gameObject;
    }

    public void Launch()
    {
        tongue.SetActive(true);
    }

    public void StopLaunch()
    {
        tongue.SetActive(false);
    }
}