using UnityEngine;

public class BulletAutoDestroy : MonoBehaviour
{
    [SerializeField] private float Duration = 2;
    
    void Start()
    {
        Invoke("Kill", Duration);
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
