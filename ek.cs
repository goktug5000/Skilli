using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ek : MonoBehaviour {

	public float a;
    public int tohum,neekecem,neekili;//1-odun , 2-......
    public bool basladı,girildi;
    public GameObject ekili, aagac,oyunucuönü;
    public Text neekecemm,tohumumuz;
    private string neekecemstr,adim,ekiliadim;//adim a değişkeninin isimi için , ekiliadim da neekili için

	void Start () {
        basladı = false;
        aagac.SetActive(false);
        ekili.SetActive(false);
        adim = this.gameObject.name.ToString();
	}

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            girildi = true;
        }
        if (col.gameObject.tag == "yokedici"&&basladı==true)
        {
            basladı = false;
            aagac.SetActive(false);
        }
    }
    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            girildi = false;
        }
    }
    public void savee()
    {
        ekiliadim = adim + neekili;
        PlayerPrefs.SetFloat(adim, a);
        PlayerPrefs.SetInt(ekiliadim, neekili);
    }
    public void loadd()
    {
        a = PlayerPrefs.GetFloat(adim);
        neekili = PlayerPrefs.GetInt(ekiliadim);
        if (neekili != 0)
        {
            basladı = true;
        }
    }
	void Update () {
        neekecemstr = neekecemm.text.ToString();
        switch (neekecemstr)
        {
            case "bos":
                neekecem = 0;
                break;
            case "oduntohum":
                neekecem = 1;
                break;
            //böyle devam et item seçmeye
        }
        if (girildi == true&&basladı==false)
        {
            //tüm ekilebilecekleri buraya yaz
            switch (neekecem)
            {
                case 1:
                    tohum =int.Parse(tohumumuz.text);
                    tohum = tohum - 1;
                    tohumumuz.text = tohum.ToString();
                    a = 600;
                    neekecem = 0;
                    neekili = 1;
                    neekecemm.text = "bos";
                    basladı = true;
                    break;
            }
        }
        if (a > 0)
        {
            a -= 1 * Time.deltaTime;
            ekili.SetActive(true);
        }
        if (a <= 0)
        {
            switch (neekili)
            {
                case 1:
                    aagac.SetActive(true);
                    neekili = 0;
                    break;
            }
            ekili.SetActive(false);
        }
	}
}
