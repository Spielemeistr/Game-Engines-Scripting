using UnityEngine;

public class BulletMovementEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

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
