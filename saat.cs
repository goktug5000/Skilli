using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class saat : MonoBehaviour {
    private float saaat,gün;
    private int düsmansayısı;
    public Light gunes;
    public Text zamanText;
    public Transform spawnTrans;
    public GameObject düşman1;
    private int zaman;//zaman 0 gündüz 1 akşam 2 gece

    void Start()
    {
        gunes = GetComponent<Light>();
        zaman = 0;
        gün = 1;
        saaat = 0;
    }
    void Update () {
        saaat += 1 * Time.deltaTime;
        if (saaat >= 400)
        {
            saaat =  0;
            gün++;
        }
        if (saaat >= 0 && saaat <= 200)
        {
            gunes.intensity=1;
            zaman = 0;
            zamanText.text = "Gündüz";
        }
        if (saaat >= 200 && saaat <= 300)
        {
            gunes.intensity = 0.5f;
            zaman = 1;
            zamanText.text = "Akşam";
        }
        if (saaat >= 300 && saaat <= 400)
        {
            gunes.intensity = 0;
            zaman = 2;
            zamanText.text = "Gece";
        }
        if (zamanText.text == "Gece")
        {

            if (düsmansayısı < gün)
            {
                Instantiate(düşman1, spawnTrans.transform.position, spawnTrans.transform.rotation);
                düsmansayısı ++;
            }
            
        }
    }
}
