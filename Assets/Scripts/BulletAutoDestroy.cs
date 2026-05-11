using UnityEngine;

public class BulletAutoDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Kill", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
