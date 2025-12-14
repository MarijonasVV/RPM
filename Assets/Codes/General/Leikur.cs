using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
public class Leikur : MonoBehaviour
{
    // timi
    public float timi = 180f;
    public TextMeshProUGUI timerText;
    public float timiEftir;
    // byrja texti
    public TextMeshProUGUI byrjatext;

    // leikmaður skjótta
    public PlayerShooting playerShooting;
    public AIShooting playerShooting2;
    
    //leikur
    private bool leikurBuinn;
    private bool leikurByrjadur = false;
    void Start()
    {

        InputSystem.DisableDevice(Keyboard.current);

        //enginn má s´kjótta
        playerShooting.enabled = false;
        playerShooting2.enabled = false;

        // setjir tíma og byrja startcountdown()
        timiEftir = timi;
        StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {

        //byrja texti
        byrjatext.gameObject.SetActive(true);

        byrjatext.text = "3";
        yield return new WaitForSeconds(1f);
        byrjatext.text = "2";
        yield return new WaitForSeconds(1f);
        byrjatext.text = "1";
        yield return new WaitForSeconds(1f);
        byrjatext.text = "GO!";
        yield return new WaitForSeconds(0.7f);

        byrjatext.gameObject.SetActive(false);

        // leikur byrjaður
        leikurByrjadur = true;
        playerShooting.enabled = true;
        playerShooting2.enabled = true;
        InputSystem.EnableDevice(Keyboard.current);

        MeteorSpawn spawn = FindFirstObjectByType<MeteorSpawn>();
        spawn.StartSpawning();
    }
    void Update()
    {
        if (leikurBuinn || !leikurByrjadur) return;

        // countdown
        timiEftir -= Time.deltaTime;
        timiEftir = Mathf.Max(timiEftir, 0f);

        if (timerText != null)
        {
            // display timer
            int minutes = Mathf.FloorToInt(timiEftir / 60);
            int sekondur = Mathf.FloorToInt(timiEftir % 60);
            timerText.text = $"{minutes:00}:{sekondur:00}";
        }

        // reiknir ef það má skjótta
        float skot = 1f - (timiEftir / timi);
        playerShooting.delay = Mathf.Lerp(2f, 0.05f, skot);

        // ef tími er búinn þá er leikur búin
        if (timiEftir <= 0f)
        {
            GameOver go = FindFirstObjectByType<GameOver>();
            if (go != null)
            {
                go.ShowGameOver("Nobody");
            }
            Time.timeScale = 0f;
        }


    }

}
