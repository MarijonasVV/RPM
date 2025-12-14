using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuNavigation : MonoBehaviour
{
    public RectTransform[] buttons; 
    public float moveAmount = 40f; 
    public float moveSpeed = 10f;   


    private int index = 0;

    void Start()
    {
    }

    void Update()
    {
        //bætir við eða mínkar eftir hvor user ýtir á w eða s
        if (Input.GetKeyDown(KeyCode.W))
        {
            index -= 1;
            if (index < 0) index = 2;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            index += 1;
            if (index >= buttons.Length) index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Activate(index);
        }

        AnimateMovement();
    }

    //animatar menu takkanan
    void AnimateMovement()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float targetX = (i == index) ? moveAmount : 0f;
            Vector3 pos = buttons[i].anchoredPosition;
            pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * moveSpeed);
            buttons[i].anchoredPosition = pos;
        }
    }


    //ger eftir hvað notandi selectar
    void Activate(int i)
    {
        switch (i)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;

            case 1:
                SceneManager.LoadScene(2);
                break;

            case 2:
                Application.Quit();
                break;
        }
    }
}
