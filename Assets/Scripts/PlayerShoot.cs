using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private InputAction _shoot;

    public GameObject BulletObject;

    public GameObject SpawnPoint;

    private bool CanShoot = true;

    public float Cooldown = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shoot = InputSystem.actions.FindAction("Attack");

        _shoot.performed += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot(InputAction.CallbackContext context)
    {
        if (CanShoot)
        {
            CanShoot = false;
            
            Invoke("ResetCanShoot", Cooldown);

            GameObject Bullet = Instantiate(BulletObject, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }

    void ResetCanShoot()
    {
        CanShoot = true;
    }
}
