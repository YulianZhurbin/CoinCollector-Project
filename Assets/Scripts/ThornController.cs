using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerController.Instance.gameObject)
        {
            VFXManager.Instance.Burst(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
            GameManager.Instance.StopGame();
            AudioManager.Instance.PlayBurst();
        }
    }
}
