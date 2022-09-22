using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Düşman : MonoBehaviour {
    public Text zamanText;
    public GameObject oyuncuObj;

    void Start()
    {

    }

        void Update () {
        if (zamanText.text == "Gündüz")
        {
            Destroy(this.gameObject);
        }

        oyuncuObj = GameObject.Find("Oyuncu");
        zamanText = GameObject.Find("Zaman").GetComponent<Text>();
        transform.LookAt(oyuncuObj.transform);
        transform.Translate(0, 0, 7 * Time.deltaTime);
    }
}
