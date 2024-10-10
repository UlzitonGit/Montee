
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image hpBar;
    private float maxHealth = 100;
    public float currentHealth;
    [SerializeField] Volume volume;
    [SerializeField] Animator anim;
    
    void Start()
    {
        currentHealth =  maxHealth;
    }

    
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth > maxHealth)  currentHealth = maxHealth; 
        print(currentHealth / maxHealth);
       
        if(damage > 0) anim.SetTrigger("damage");
        hpBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth <= 0)
        { 
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene);
        }
        else
        {
            volume.weight = 1 - (currentHealth / maxHealth);
        }
    }
}
