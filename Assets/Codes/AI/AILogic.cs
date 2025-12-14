using UnityEngine;
using System.Collections;
public class AILogic : MonoBehaviour
{
    //hraði
    public float speed = 5f;

    //random range sem vélmenni þarf að bíða
    public float waitTimeMin = 1f;        
    public float waitTimeMax = 3f;

    //space sem vélmenni má bara lappa
    public BoxCollider movementBounds;

    //þar sem vélmenni á að fara
    private Vector3 targetPos;

    //hreyfa
    private bool moving = false;

    void Start()
    {
        //fall sem veljir target
        PickNewTarget();
    }

    void Update()
    {
        if (movementBounds == null) return;

        //éf færa
        if (moving)
        {
            //fara þar sem targetr er
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            // ef nálægt target
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                //stop movement
                moving = false;

                //
                StartCoroutine(WaitThenMove());
            }
        }
    }

    //bíða smá áður nýtt target
    IEnumerator WaitThenMove()
    {
        yield return new WaitForSeconds(Random.Range(waitTimeMin, waitTimeMax));
        PickNewTarget();
    }


    //fall veljir random target sem vélmenni á að fara að
    void PickNewTarget()
    {
        if (movementBounds == null) return;


        //boundry
        Bounds b = movementBounds.bounds;


        //random range sem það á að fara
        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);
        float z = transform.position.z;

        //target þar sem ai þarf að fara
        targetPos = new Vector3(x, y, z);

        //má færa þar
        moving = true;
    }
}

