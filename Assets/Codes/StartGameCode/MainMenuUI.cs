using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    public Transform ship;
    public float floatSpeed = 2f;
    public float floatAmount = 0.25f;

    private Vector3 startPos;
    void Start()
    {
        startPos = ship.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        ship.position = new Vector3(startPos.x, newY, startPos.z);
    }
    
   public void byrjaLeik()
    {
        SceneManager.LoadScene(1);
    }
    public void multiplayerLeik()
    {
        SceneManager.LoadScene(2);
    }
    public void qutiLeik()
    {

    }
}
