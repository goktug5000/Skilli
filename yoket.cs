using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class yoket : MonoBehaviour {
    public Text newload;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "alıcı")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        newload = GameObject.Find("newload").GetComponent<Text>();
        if (newload.text == "true")
        {
            Destroy(this.gameObject);
        }
    }
}
