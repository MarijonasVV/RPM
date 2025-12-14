using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    // líf 
    public int maxHealth = 3;
    private int currentHealth;
    public TextMeshProUGUI lifText;
    public string playerName;
    void Start()
    {
        //setja líf og update display
        currentHealth = maxHealth;
        UpdateUI();
    }
    public void TakeDamage()
    {
        //tekur líf og update
        currentHealth -= 1;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    // update textan ui
    void UpdateUI()
    {
        if (lifText != null)
            lifText.text = "HP: " + currentHealth;
    }
    //fall ef einhver deyr
    void Die()
    {
        gameObject.SetActive(false);
        GameOver go = FindFirstObjectByType<GameOver>();
        if (go != null)
        {
            go.ShowGameOver(playerName);
        }
        Time.timeScale = 0f;
    }
 
        
}
