using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class MeteorZone : MonoBehaviour
{
    // uppl fyrir metero
    public float baseRadius = 0.2f;     
    public float maxRadius = 0.9f;        
    public float growthFactor = 0.4f;     
    public float warningTime = 1.5f;    
    public float activeTime = 0.2f;
    // public int damage = 1;

    //mesh meteor prefab
    private MeshRenderer mesh;

    // uppl bool
    private bool active = false;
    private bool hasHit = false;
    void Start()
    {
        //tekur meshrenderer
        mesh = GetComponent<MeshRenderer>();

        //tekur tíman sem er eftir og gerir math til að reikna stærð
        float gameProgress = 0f;
        Leikur leikur = FindFirstObjectByType<Leikur>();
        if (leikur != null)
        {
            float elapsed = leikur.timi - leikur.timiEftir;
            gameProgress = Mathf.Clamp01(elapsed / leikur.timi);
        }
        float radius = Mathf.Lerp(baseRadius, maxRadius, gameProgress * growthFactor);
        transform.localScale = new Vector3(radius, radius, 0.1f);

        StartCoroutine(WarnThenActivate());

        IEnumerator WarnThenActivate()
        {

            //breyttir litinn í gulan
            mesh.material.SetColor("_BaseColor", new Color(1f, 1f, 0f, 0.4f));

            yield return new WaitForSeconds(warningTime);

            //breyttir í rautt
            mesh.material.SetColor("_BaseColor", new Color(1f, 0f, 0f, 0.4f));

            //má gera damage
            active = true;

            yield return new WaitForSeconds(activeTime);

            //má hita aftur 
            hasHit = false;
            //remove meteor
            Destroy(gameObject);
        }
    }


    //ef snertir object
    private void OnTriggerStay(Collider other)
    {
        //ef ekki active gerir ekkert damage
        if (!active) return;

        //ef það er búið að hitta þá má það ekki gera fleira damage
        if (hasHit) return;

        //sækir í líf objectið
        Health health = other.GetComponent<Health>();
        if (health != null)
        {

            //taka damge og hasHit er true þannig það hittir ekki aftur
            health.TakeDamage();
            hasHit = true; 
    }
    }
}
