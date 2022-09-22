using UnityEngine;
using System.Collections;

public class agac : MonoBehaviour {

    public GameObject odun,tree;
    public Transform oyunucuönü;
    private float xp, yp, zp;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "yokedici")
        {
            Instantiate(odun, oyunucuönü.transform.position, oyunucuönü.transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
