using UnityEngine;

public class TimeController : MonoBehaviour
{
    private PlayerController _Controller;

    [SerializeField] private float SlowTimeValue = 0.05f;

    [SerializeField] private float TransitionSpeed = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Controller = GetComponent<PlayerController>();
        
        Time.timeScale = SlowTimeValue;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Controller.speed > 0.01 || !_Controller._CharacterController.isGrounded)
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1, TransitionSpeed);
        }
        else
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, SlowTimeValue, TransitionSpeed);
        }

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
