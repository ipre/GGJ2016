using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Bullet : MonoBehaviour {

    public Vector3 direction;
    public ParticleSystem endExplosion;
	
	// Update is called once per frame
	void Update () {

        transform.Translate(direction);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            return;
        }

        BulletReceiver receiver = other.gameObject.GetComponent<BulletReceiver>();

        if (receiver != null)
        {
            receiver.Receive();
        }

        Debug.Log(other.gameObject.name);

        if (other.GetComponent<FirstPersonController>() != null)
        {
            Sense sense = Root.Instance.SenseManager.GetBossSense();
            if (sense == null)
            {
                Application.LoadLevel("title");
            }
            else
            {
                sense.Off(null);
            }
        }

        if (endExplosion != null)
        {
            endExplosion = Instantiate(endExplosion);
            endExplosion.transform.position = transform.position;
            endExplosion.Play();
        }
        Destroy(gameObject);
    }
}
