using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int Health = 3;

    private int CurrentHealth = 0;

    [SerializeField] private Image Heathbar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = Health;

        Heathbar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage()
    {
        CurrentHealth -= 1;

        Heathbar.fillAmount = (float)CurrentHealth / Health;

        if (CurrentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
