using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    [SerializeField] private GameObject weight; // Vật nặng của con lắc
    [SerializeField] private GameObject mount; // Điểm treo của con lắc
    [SerializeField] private GameObject chains; // Điểm giữa xích của con lắc
    private Transform transformChains;
    private Pendulum pendulum;

    // Start is called before the first frame update
    void Start()
    {
        chains.transform.position = (weight.transform.position + mount.transform.position) / 2f;
        transformChains = chains.transform;
        GameObject spikedBall = transform.parent.Find("Spiked Ball").gameObject;
        pendulum = spikedBall.GetComponent<Pendulum>();
    }

    // Update is called once per frame
    void Update()
    {
        transformChains.position = (weight.transform.position + mount.transform.position) / 2f;
        transformChains.rotation = Quaternion.Euler(transformChains.rotation.eulerAngles.x, transformChains.rotation.eulerAngles.y, pendulum.GetAngle());
    }
}
