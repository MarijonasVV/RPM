using UnityEngine;

public class Movement : MonoBehaviour {
    // hraði leikmans
    public float speed = 5f;

    void Update()
    {
        // leikmaður hreyfa
        float moveX = 0f;
        float moveY = 0f;

        // leikmaður ýttir á takan til að hreyfa skipið
        if (Input.GetKey(KeyCode.W)) moveY = 1f;

        if (Input.GetKey(KeyCode.S)) moveY = -1f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            transform.localEulerAngles = new Vector3(0, 0, 25);
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX = 1f;
            transform.localEulerAngles = new Vector3(0, 0, -25);
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        // hreyfir skippið
        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;
    }
} 

