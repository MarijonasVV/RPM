using UnityEngine;
public class CameraPlayer : MonoBehaviour
{

    // myndavél leikmans
    //public Camera cam;

    // smá plás frá edge af skjáinn
    //public float minMargin = 0.05f;

    void LateUpdate()
    {
        // starðfræði til að reyikna hvað leikmaður getur fært sig
        //Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        //viewPos.x = Mathf.Clamp(viewPos.x, minMargin, 1f - minMargin);
        //viewPos.y = Mathf.Clamp(viewPos.y, minMargin, 1f - minMargin);

        // 
        //Vector3 newPos = cam.ViewportToWorldPoint(viewPos);
        //newPos.z = transform.position.z;
        //transform.position = newPos;
    }
}
