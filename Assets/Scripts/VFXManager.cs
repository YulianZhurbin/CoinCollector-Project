using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] ParticleSystem[] fireworks;
    [SerializeField] ParticleSystem playerBurst;

    private static VFXManager instance;

    public static VFXManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    public void PlayOffFireworks()
    {
        foreach (ParticleSystem salute in fireworks)
        {
            salute.Play();
        }
    }

    public void Burst(Vector3 burstPoint)
    {
        Instantiate(playerBurst, burstPoint, playerBurst.transform.rotation);
    }

}
