
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image hpBar;
    private float maxHealth = 100;
    public float currentHealth;
    
    void Start()
    {
        currentHealth =  maxHealth;
    }

    
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth > maxHealth)  currentHealth = maxHealth; 
        print(currentHealth / maxHealth);
        hpBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth <= 0)
        { 
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene);
        }
    }
}
