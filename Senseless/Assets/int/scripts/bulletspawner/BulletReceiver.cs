using UnityEngine;
using System.Collections;

public class BulletReceiver : MonoBehaviour {

    public void Receive()
    {
        Animator anim = GetComponent<Animator>();

        if (anim != null)
        {
            anim.SetTrigger("Break");
        }
    }
}
