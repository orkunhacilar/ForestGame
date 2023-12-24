using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaraketController : MonoBehaviour
{
    [SerializeField]
    Transform zeminKontrolNoktasi;

    [SerializeField]
    GameObject normalPlayer;

    [SerializeField]
    Animator NormalAnim;

    public LayerMask zeminMaske; // Tag sectirir gibi 2 d oldugu icin layer sectiriyor bize public bir sekilde

    public Rigidbody2D rb;
    public float haraketHizi;
    bool kiliciVurdumu;
    bool yonSagdami;
    bool zemindemi;
    bool ikinciKezZiplasinmi;
    public float ziplamaGucu;


    private void Awake()
    {
        kiliciVurdumu = false;
    }

        private void Update()
    {
        HareketEt();
        YonuDegistirFNC();
        ZiplaFNC();


        if (Input.GetKeyDown(KeyCode.E) && normalPlayer.activeSelf)
        {
            kiliciVurdumu = true;
            //kilicVurusBoxObje.SetActive(true);
            
        }
        else
        {
            kiliciVurdumu = false;
        }



        if (kiliciVurdumu && normalPlayer.activeSelf)
        {
            NormalAnim.SetTrigger("kiliciVurdu");
        }

        if (normalPlayer.activeSelf)
        {
            NormalAnim.SetBool("zemindemi", zemindemi);
            NormalAnim.SetFloat("HaraketHizi", Mathf.Abs(rb.velocity.x)); //Mathf.Abs ile mutlak deger aliyorum cunku x te - ye dogruda haraket edebiliyorum.
        }

    }

    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal"); //0 ve 1 arasinda deger aliyor otomatik atanmistir yon tuslari ya da a d ile deger alir
        rb.velocity = new Vector2(h * haraketHizi, rb.velocity.y);

    }


    void YonuDegistirFNC()
    {
        if (rb.velocity.x < 0) //eger hiz -x yonunde gidiyorsa sol button or a yani
        {
            transform.localScale = new Vector3(-1, 1, 1); //karakterin x konumunda diger tarafa flip at
            yonSagdami = false;
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one; // one (1,1,1) demek zaten // sifirdan buyukse saga gidiyo yani d ya da sag buttona basiyo oraya dogru cevir dedik.
            yonSagdami = true;
        }
    }


    void ZiplaFNC()
    {                            //burdan cikar isini            //buraya carparsa
        zemindemi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminMaske); //TRUE FALSE DONDU

        if (Input.GetButtonDown("Jump") && (zemindemi || ikinciKezZiplasinmi)) //GetButtonDown("Jump") demek space tusu demek.   horizantal tagi nasil a d sag golu anliyosa Jumpta space i anliyor tanimli
        {
            if (zemindemi)
            {
                ikinciKezZiplasinmi = true;
            }
            else
            {
                ikinciKezZiplasinmi = false;
            }


            rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);


        }

    }
}
