using UnityEngine;
using System.Collections;
public class MeteorSpawn : MonoBehaviour
{
    // meteor prefab
    public GameObject meteorPrefab;

    //leikmen
    public Transform player;
    public Transform player2;

    //fall sem byjara spawnlooopið
    public void StartSpawning()
    {
        StartCoroutine(SpawnLoop());
    }
    IEnumerator SpawnLoop()
    {
        //leikur object
        Leikur leikur = FindFirstObjectByType<Leikur>();

        //á meðan leikur er í gangi
        while (true)
        {

            //spawn nálægt leikmann
            SpawnMeteorNear(player);
            SpawnMeteorNear(player2);
            //þbí meiri tími sem leikurinn tekur þá spawnar fljóatari hringir
            float progress = 0f;
            if (leikur != null)
            {
                float elapsed = leikur.timi - leikur.timiEftir;
                progress = Mathf.Clamp01(elapsed / leikur.timi);
            }

            float waitTime = Mathf.Lerp(2.5f, 0.7f, progress);

            yield return new WaitForSeconds(waitTime);
        }
    }

    //metoer spawn fall
    void SpawnMeteorNear(Transform target)
    {
        if (target == null) return;

        //tekur x og y postition random nálægt leikmenn
        float randomX = Random.Range(target.position.x - 3f, target.position.x + 3f);
        float randomY = Random.Range(target.position.x - 0.2f, target.position.x + 0.2f);

        //spawnar meteor þar
        Vector3 spawnPos = new Vector3(randomX, randomY, target.position.z);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
    }
}
