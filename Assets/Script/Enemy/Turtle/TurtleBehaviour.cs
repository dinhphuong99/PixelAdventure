using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    [SerializeField] private float spikeOutTime = 6f;
    [SerializeField] private float spikeInTime = 3f;
    [SerializeField] private GameObject head;
    private float spikeTimer = 0f;
    private bool isSpikeOut = false;
    private bool isSpikeIn = true;
    private bool isSpikeInDone = true;
    private bool isSpikeOutDone = false;

    [SerializeField] private GameObject spikes;

    public bool GetIsSpikeOut()
    {
        return this.isSpikeOut;
    }

    public bool GetIsSpikeIn()
    {
        return this.isSpikeIn;
    }

    public bool GetIsSpikeInDone()
    {
        return this.isSpikeInDone;
    }

    public bool GetIsSpikeOutDone()
    {
        return this.isSpikeOutDone;
    }

    // Update is called once per frame
    void Update()
    {
        spikeTimer += Time.deltaTime;

        if (spikeTimer <= spikeInTime)
        {
            isSpikeIn = true;
            isSpikeOut = false;
            isSpikeOutDone = false;
            head.GetComponent<EdgeCollider2D>().enabled = true;
        }

        if (spikeTimer >= spikeInTime && spikeTimer <= spikeInTime + spikeOutTime)
        {
            isSpikeIn = false;
            isSpikeOut = true;
            isSpikeInDone = false;
            head.GetComponent<EdgeCollider2D>().enabled = false;
        }

        if (spikeTimer >= spikeInTime + spikeOutTime)
        {
            spikeTimer = 0f;
        }
    }

    private void SpikeOut()
    {
        spikes.SetActive(true);
    }

    private void SpikeIn()
    {
        spikes.SetActive(false);
    }

    private void SpikeInDone()
    {
        isSpikeInDone = true;
        isSpikeOutDone = false;
    }

    private void SpikeOutDone()
    {
        isSpikeInDone = false;
        isSpikeOutDone = true;
    }
}