using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class oyuncu : MonoBehaviour {

    private float hız,xr,yr,zr,alıcıcd,baltacd,yenialindi,baltavurcd,neekecemcd,newloadcd;//newload yeni yüklenince 2 sn
    private int silah,odun,tohumm ,sahipmal,odunlvl,sahiplvl,item,ekilecekitem,mal,maxmal;
    //itemde 0-boş , 1-odun ...
    //ekilecek item 0-boş 1-oduntohum ...

    private int tarlasayisi;
    //Build sekmesi için sayaçlar

    private bool kosuyor,yürüyor,genelb,envanterb,yeteneklerb,odunalb,tohumcub,tarlacıb,escb, vuruyor,tohumpb,buildsekmeb;
    private bool activedtarlahayaletb;//hayalet tarlanın açık olup olmadığına bakar
    public bool tarladab;//Nerede olduğumuzu gösterenler

    private Animator anim;


    public GameObject kol,nitro,genel,envanter,yetenek,alıcı,tohumpanel,tohumbuton,esc,tarlabutton,tarlapanel,tohumumuzpanel,chestbut;
    public GameObject balta, cekic;

    //canvas
    public GameObject buildsekme, hayaletTarla, hayaletİPTALTarla, tarlaObj;


    private Rigidbody rb3d;
    public Text odunumuz,tohumumuz, malımız, lvlımız, onunlvlımız,neekecem,newload,tarlaEnv;//tarlaEnv envanterdeki inşa edilebilir tarla sayısı

    public Transform tarlakurmayeri;

    public bool deneme=false;

	void Start () {
        try
        {
            hız = 10;
            odun = 10;
            odunlvl = 1;
            alıcıcd = 0;
            yenialindi = 0;
            tohumm = 0;
            tohumumuz.text = tohumm.ToString();
            silah = 0;
            mal = 0;
            maxmal = 20;
            tarlasayisi = 0;
        }
        catch
        {
            Debug.Log("Değişken");
        }

        anim = gameObject.GetComponent<Animator>();
        rb3d = gameObject.GetComponent<Rigidbody>();

        try
        {
            alıcı.SetActive(false);
            tohumpanel.SetActive(false);
            tohumbuton.SetActive(false);
            esc.SetActive(false);
            tarlapanel.SetActive(false);
            tarlabutton.SetActive(false);
            tohumumuzpanel.SetActive(false);

            buildsekme.SetActive(false);
            hayaletTarla.SetActive(false);
            hayaletİPTALTarla.SetActive(false);

            nitro.SetActive(false);
            balta.SetActive(false);
            cekic.SetActive(false);
        }
        catch
        {
            Debug.Log("Aktiveler");
        }

        try
        {
            genelb = false;
            envanterb = false;
            yeteneklerb = false;
            odunalb = false;
            escb = false;
            kosuyor = false;
            tohumcub = false;
            vuruyor = false;
            tohumpb = false;
            buildsekmeb = false;

            activedtarlahayaletb = false;

            //Nerede olduğumuzu gösterenler
            tarladab = false;
        }
        catch
        {
            Debug.Log("true_false");
        }

	}
	public void env()
    {
        envanterb = !envanterb;
    }
    public void skil()
    {
        yeteneklerb = !yeteneklerb;
    }
    public void devam()
    {
        escb = false;
    }
    public void save()
    {
        //konum save
        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.SetFloat("posZ", transform.position.z);
        //yön save
        PlayerPrefs.SetFloat("rotX", transform.eulerAngles.x);
        PlayerPrefs.SetFloat("rotY", transform.eulerAngles.y);
        PlayerPrefs.SetFloat("rotZ", transform.eulerAngles.z);

        //ıvır zıvır save
        PlayerPrefs.SetInt("odunS", odun);
        PlayerPrefs.SetInt("tohumS", tohumm);

        //materyal toplama yerleri save


        escb = false;
    }
    public void load()
    {
        //yön save
        float px,py,pz;
        px = PlayerPrefs.GetFloat("posX");
        py = PlayerPrefs.GetFloat("posY");
        pz = PlayerPrefs.GetFloat("posZ");
        transform.position = new Vector3(px, py, pz);
        //yön load
        float rrx, rry, rrz;
        rrx = PlayerPrefs.GetFloat("rotX");
        rry = PlayerPrefs.GetFloat("rotY");
        rrz = PlayerPrefs.GetFloat("rotZ");
        transform.rotation = Quaternion.Euler(rrx, rry, rrz);

        //ıvır zıvır load
        odun = PlayerPrefs.GetInt("odunS");
        odunumuz.text = odun.ToString();
        tohumm = PlayerPrefs.GetInt("tohumS");
        tohumumuz.text = tohumm.ToString();

        //materyal toplama yerleri load

        newloadcd = 2;
        escb = false;
    }
    public void justquit()
    {
        Application.Quit();
    }

    public void oduntohumsec()
    {
        if (tohumm >= 1)
        {
        neekecem.text = "oduntohum";
        neekecemcd = 5;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "odun"&&alıcıcd<=0)
        {
            if (yenialindi<=0)
            {
                odunalb = true;
            }
            item = 1;
        }
        if (col.gameObject.tag == "tohumcu")
        {
            tohumbuton.SetActive(true);
        }
        if (col.gameObject.tag == "tarlacı")
        {
            tarlabutton.SetActive(true);
        }
        if (col.gameObject.tag == "chest")
        {
            chestbut.SetActive(true);
        }

    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "tarla")
        {
            tarladab = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "odun")
        {
            odunalb = false;
            item = 0;
        }
        if (col.gameObject.tag == "tohumcu")
        {
            tohumbuton.SetActive(false);
            tohumcub = false;
            tohumpanel.SetActive(false);
        }
        if (col.gameObject.tag == "tarlacı")
        {
            tarlabutton.SetActive(false);
            tarlacıb = false;
            tarlapanel.SetActive(false);
        }
        if (col.gameObject.tag == "chest")
        {
            chestbut.SetActive(false);
        }
        if (col.gameObject.tag == "tarla")
        {
            tarladab = false;
        }
    }

    public void tohumpanell()
    {
        tohumpanel.SetActive(tohumcub = !tohumcub);
        envanterb = true;
    }
    public void tarlapanell()
    {
        tarlapanel.SetActive(tarlacıb = !tarlacıb);
        envanterb = true;
    }
    public void alsana()
    {
        if (item == 1 && alıcıcd<=0)
        {
            odun=odun+1;
            alıcıcd = 1f;
            odunumuz.text = odun.ToString();
        }
        yenialindi = 3;
        odunalb = false;
    }
    public void tohumdönüstür()
    {
        if (odun >= 1)
        {
            odun = odun - 1;
            tohumm = tohumm + 2;
            odunumuz.text = odun.ToString();
            tohumumuz.text = tohumm.ToString();
        }
    }
    public void BUYtarla()
    {
        if (odun >= 4)
        {
            tarlasayisi += 1;
            odun -= 4;
            odunumuz.text = odun.ToString();
        }
    }
    public void tohumekpanel()
    {
        tohumpb = !tohumpb;
    }

    public void BuildTarla()
    {
        if (tarlasayisi > 0)
        {
            silah = 0;
            if (activedtarlahayaletb==true)
            {
                if (tarladab == false)
                {
                    activedtarlahayaletb = false;
                    hayaletTarla.SetActive(false);
                    Instantiate(tarlaObj, tarlakurmayeri.transform.position, tarlakurmayeri.transform.rotation);
                    tarlasayisi -= 1;
                }
            }
            else
            {
                activedtarlahayaletb = true;
                hayaletTarla.SetActive(true);
            }
        }
    }

	void Update () {
        tarlaEnv.text = tarlasayisi.ToString();

//Taşıdığım yükü hesaplayıp hızımı düşürüyor
        mal = (odun * 3) + (tohumm);
        malımız.text = mal.ToString();
        if (mal > maxmal)
        {
            hız = 5;
        }
        else
        {
            //hızlandırma etkisi eklersen burayı unutma
            hız = 10;
        }

//yürü
        if (Input.GetKey(KeyCode.W) && kosuyor == false&&vuruyor==false)
        {
            transform.Translate(0, 0, hız * Time.deltaTime);
            yürüyor = true;
        }
        if (Input.GetKey(KeyCode.D) && vuruyor == false)
        {
            transform.Rotate(Vector3.up, 115 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && vuruyor == false)
        {
            transform.Rotate(Vector3.up, -115 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)&& kosuyor== false&&vuruyor == false)
        {
            transform.Translate(0, 0, -hız/2 * Time.deltaTime);
            yürüyor = true;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
        {
            yürüyor = false;
        }
        if (vuruyor == false)
        {
            anim.SetBool("yürü", yürüyor);
        }

//Dik dur
        xr = transform.eulerAngles.x;
        zr = transform.eulerAngles.z;
        if(xr<= -5 || xr>=5)
        {
            yr = transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yr, 0);
        }
        if (zr <= -5 || zr >= 5)
        {
            yr = transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yr, 0);
        }


//Topla
        if (Input.GetKeyDown(KeyCode.E))
        {
            alsana();
            item = 0;
        }

//Nitro
        if (Input.GetKey(KeyCode.LeftShift)&& vuruyor == false)
        {
            transform.Translate(0, 0, hız * 3 * Time.deltaTime);
            kosuyor = true;
            nitro.SetActive(true);
            yürüyor = true;
        }
        else
        {
            kosuyor = false;
            nitro.SetActive(false);
        }

//Genel aç
//Envanter aç
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (genelb == true)
            {
                envanterb = false;
                tohumpb = false;
                buildsekmeb = false;
            }
            genelb = !genelb;
            yeteneklerb = false;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            envanterb = !envanterb;
            buildsekmeb = false;
        }


//inşa özellikleri

        if (Input.GetKeyDown(KeyCode.B))
        {
            buildsekmeb = !buildsekmeb;
            envanterb = false;
        }

//KurAMAMA hayaleti

        if (tarladab == true && activedtarlahayaletb == true)
        {
            hayaletTarla.SetActive(false);
            hayaletİPTALTarla.SetActive(true);
        }
        if (activedtarlahayaletb == false)
        {
            hayaletİPTALTarla.SetActive(false);
        }
        if (tarladab == false && activedtarlahayaletb == true)
        {
            hayaletİPTALTarla.SetActive(false);
            hayaletTarla.SetActive(true);
        }

//silah seç

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            silah = 0;
            anim.SetInteger("silah", silah);
            //tüm silahlar.setactive(false);
            balta.SetActive(false);
            cekic.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            silah = 1;
            balta.SetActive(true);
            cekic.SetActive(false);
            anim.SetInteger("silah", silah);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            silah = 2;
            balta.SetActive(false);
            cekic.SetActive(true);
            anim.SetInteger("silah", silah);
        }


        //yok edici

        if (alıcıcd > 0)
        {
            alıcı.SetActive(true);
            alıcıcd -= 1 * Time.deltaTime;
        }
        else
        {
            alıcı.SetActive(false);
        }
        if (yenialindi >= 0)
        {
            yenialindi = yenialindi - 1 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            deneme = true;
            if (silah == 0)
            {

            }
            if (silah == 1&&vuruyor==false)
            {
                vuruyor = true;
                baltavurcd = 1;
                //anim.SetInteger("silah", silah);
                //yokedici.SetActive(true);
            }
            if (silah == 2 && vuruyor == false)
            {
                vuruyor = true;
                baltavurcd = 3;
                //anim.SetInteger("silah", silah);
                //yokedici.SetActive(true);
            }

        }
        if (baltavurcd > 0)
        {
            vuruyor = true;
            baltavurcd -= 1 * Time.deltaTime;
        }
        else
        {
            vuruyor = false;
        }
        anim.SetBool("vuruyor", vuruyor);
        if (!Input.GetKey(KeyCode.Space))
        {
            deneme = false;
        }
//Ne Ekecem cd

        if (neekecemcd > 0)
        {
            neekecemcd -= 1 * Time.deltaTime;
        }
        else
        {
            neekecemcd = 0;
            neekecem.text = "bos";
        }


//ESC

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escb = !escb;
            envanterb = false;
            tohumpb = false;
            genelb = false;
            yeteneklerb = false;
            buildsekmeb = false;

            //KURMA SEÇENEKLERİNİN İPTALLERİNİ EKLE
            activedtarlahayaletb = false;
            hayaletTarla.SetActive(false);
        }

//new load cd

        if (newloadcd > 0)
        {
            newloadcd -= 1 * Time.deltaTime;
            newload.text = "true";
        }
        else
        {
            newload.text = "false";
        }

        genel.SetActive(genelb);
        yetenek.SetActive(yeteneklerb);
        envanter.SetActive(envanterb);
        tohumumuzpanel.SetActive(tohumpb);
        buildsekme.SetActive(buildsekmeb);
        esc.SetActive(escb);
        tohumm = int.Parse(tohumumuz.text);
    }
}
