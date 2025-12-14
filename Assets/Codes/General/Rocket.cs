using System.Net.Sockets;
using UnityEngine;
//enum sem geymir tegundir fyrir rockets
public enum RocketType
{
    Protect,
    Shoot,
    Rockets
}
public class Rocket : MonoBehaviour
{

    //hver skjóttir eldflaug
    public GameObject owner;

    //tegund rocket 
    public RocketType rocketTegund;

    //properties rocket
    public float speed = 5f;
    public float lif = 10f;
    // public int damage = 1;

    void Start()
    {
        //eyða ef til á skjáinn
        Destroy(gameObject, lif);
    }

    // rocket hreyfist 
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    // ef snerit eitthvað
    void OnTriggerEnter(Collider other)
    {
        
        //ef hit hlutiur er rocket frá hinn leikmann
        Rocket otherRocket = other.GetComponent<Rocket>();


        // 
        if (otherRocket != null && otherRocket.owner == owner)  
        {
            return;
        }
   
        if (otherRocket != null)
        {

            // fall sem kíkir hvað hitt rocket er
            Beats(otherRocket);
        }

        //sækir í líf hinn leikmans
        Health target = other.GetComponent<Health>();
        if (target != null)
        {

            //fall sem lætur target taka damage
            target.TakeDamage();

            //eyðir rocket
            Destroy(gameObject);
        }
    }

    //fall sem kíkir ef eldflaug vinnur
    void Beats(Rocket other)
    {

        // hvort rocket vinnur eða jafntefli
        bool vinnur = false;
        bool jafntefli = false;

        // fer í gegnum possibilites af tapa og vinna
        if (rocketTegund == RocketType.Protect && other.rocketTegund == RocketType.Rockets)
        {
            vinnur = true;
        }
        else if (rocketTegund == RocketType.Rockets && other.rocketTegund == RocketType.Shoot)
        {
            vinnur = true;
        }
        else if (rocketTegund == RocketType.Shoot && other.rocketTegund == RocketType.Protect)
        {
            vinnur = true;
        }
        else if (rocketTegund == other.rocketTegund)
        {
            jafntefli = true;
        }

        // eyðir rocket eftir hvort það vann eða ekki
        if (vinnur)
        {
            Destroy(other.gameObject);
        }
        else if (jafntefli)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            return;
        }
        else if (!vinnur)
        {
            Destroy(gameObject);
        }
   
    }
}

