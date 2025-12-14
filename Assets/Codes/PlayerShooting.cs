using UnityEngine;
using TMPro;
using System.Net.Sockets;
public class PlayerShooting : MonoBehaviour
{

    public AudioClip shootSound;
    private AudioSource audioSource;

    public GameObject owner;

    // rockets
    public GameObject rocket;
    public GameObject protect;
    public GameObject shoot;

    //byssan á skipið
    public Transform firePoint;
    private float offset = 2f;

    public TextMeshProUGUI skotText;
    // allt sem tengist að skjóta
    public float delay = 3f;
    public float canShootWindow = 0.3f;
    private float sidastaSkot;
    private bool shootNow = false;
    private float nextWindow;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        float elapsed = Time.time - sidastaSkot;
        float fraction = elapsed / delay;

        // Before shooting window opens
        if (!shootNow)
        {
            if (fraction < 0.33f)
            {
                skotText.text = "Rocket";
            }
            else if (fraction < 0.66f)
            {
                skotText.text = "Protect";
            }
            else if (fraction < 1f)
            {
                skotText.text = "Shoot";
            }
            else
            {
                // Now player can shoot
                shootNow = true;
                nextWindow = Time.time;
                skotText.text = "GO!";
            }
        }
        else
        {
            // Player has a small window to shoot
            if (Time.time - nextWindow > canShootWindow)
            {
                // Missed the shooting window
                shootNow = false;
                sidastaSkot = Time.time;
                skotText.text = "Rocket"; // restart
            }
        }

        // SHOOT INPUT
        if (shootNow)
        {
            if (Input.GetKeyDown(KeyCode.J)) Shoot(protect);
            if (Input.GetKeyDown(KeyCode.K)) Shoot(shoot);
            if (Input.GetKeyDown(KeyCode.L)) Shoot(rocket);
        }
    }

    //fall sem skjóttir
    void Shoot(GameObject rocketPrefab)
    {
        Vector3 spawnPos = new Vector3(
                firePoint.position.x,
                firePoint.position.y,
                firePoint.position.z + offset
            );
        //gerir rocket 
        GameObject newRocket = Instantiate(rocketPrefab, spawnPos, firePoint.rotation);
        audioSource.PlayOneShot(shootSound);
        Rocket r = newRocket.GetComponent<Rocket>();
        r.owner = gameObject;


            //notandi getur ekki skotið aftur
            shootNow = false;
        sidastaSkot = Time.time;
        if (skotText != null)
            skotText.text = "";

    }
}
