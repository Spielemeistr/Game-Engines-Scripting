using UnityEngine;

public class BulletMovementEnemy : MonoBehaviour
{
    public float speed = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthSystem>().ApplyDamage();
        }
    }
}
