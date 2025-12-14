using Unity.VisualScripting;
using UnityEngine;

public class AIShooting : MonoBehaviour
{

    public AudioClip shootSound;
    private AudioSource audioSource;



    public GameObject owner;

    //rocket prefab
    public GameObject rocket;
    public GameObject protect;
    public GameObject shoot;

    //byssa
    public Transform firePoint;
    private float offset = -2f;


    //shot delay og allt það e
    public float delay = 3f;
    public float canShootWindow = 0.3f;
    private float sidastaSkot;
    private bool shootNow = false;
    private float nextWindow;

    //ai 
    public bool autoShoot = true;
    public bool randomShoot = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //reikna hveru mikið tími er eftir þangað til notandi getur skotið
        float timiEftirSkot = Time.time - sidastaSkot;
        float eftir = delay - timiEftirSkot;

        //ef það er ekker bil eftir þá má notandi skjóta
        if (eftir <= 0f && !shootNow)
        {
            shootNow = true;
            nextWindow = Time.time;
            if (autoShoot && Random.value > 0.3f)
            {
                shootRocket();
            }
        }
        // ef tímin til að skjóta er búin
        if (shootNow && Time.time - nextWindow > canShootWindow)
        {
            shootNow = false;
            sidastaSkot = Time.time;
        }
    }

    // vélmenni skot
    void shootRocket()
    {
        
        GameObject rocketPrefab = null;

        //random rocket
        if (randomShoot)
        {
            int random = Random.Range(0, 3);
            switch (random)
            {
                case 0: rocketPrefab = rocket; break;
                case 1: rocketPrefab = shoot; break;
                case 2: rocketPrefab = protect; break;
            }
        }

        // skjótir rocket
        if (rocketPrefab != null)
        {
            Vector3 spawnPos = new Vector3(
                firePoint.position.x,
                firePoint.position.y,
                firePoint.position.z + offset
            );
            GameObject newRocket = Instantiate(rocketPrefab, spawnPos, (firePoint.rotation * Quaternion.Euler(0, 180f, 0)));
            audioSource.PlayOneShot(shootSound);
            Rocket r = newRocket.GetComponent<Rocket>();
            r.owner = gameObject;

            shootNow = false;
            sidastaSkot = Time.time;
        }
    }
}
