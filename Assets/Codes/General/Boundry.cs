using UnityEngine;

public class Boundary : MonoBehaviour
{
    // boundry
    public BoxCollider boundary; 

    void LateUpdate()
    {
        //ef ekki til
        if (boundary == null) return;

        //boudnyr og postiiton
        Bounds b = boundary.bounds;
        Vector3 pos = transform.position;

        //gera clamp þannig ekkert fer úr því
        pos.x = Mathf.Clamp(pos.x, b.min.x, b.max.x);
        pos.y = Mathf.Clamp(pos.y, b.min.y, b.max.y);
        pos.z = Mathf.Clamp(pos.z, b.min.z, b.max.z);
        transform.position = pos;
    }
}
