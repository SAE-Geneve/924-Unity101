using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class SpaceCraftController : MonoBehaviour
{
    [SerializeField] private float _linearSpeed = 0.1f;
    [SerializeField] private float _rollSpeed = 0.1f;
    [SerializeField] private float _spinSpeed = 0.1f;
    
    [SerializeField] private float _linearForce = 0.1f;
    [SerializeField] private float _rollForce = 0.1f;
    [SerializeField] private float _spinForce = 0.1f;

    private bool _boosterInput = false;
    private float _rollInput = 0f;
    private float _spinInput = 0f;
    
    private Rigidbody _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // if (_rigidbody == null)
        // {
        //     Debug.Log("No rigidbody attached");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // No physics controller -----------------------------------------
        // if (_boosterInput)
        // {
        //     transform.Translate(0, 0, _speed * Time.deltaTime);
        // }
        //
        // transform.Rotate(_rollInput * _rollSpeed * Time.deltaTime, _spinInput * _spinSpeed * Time.deltaTime, 0);

        // Full physics controller ---------------------------------------
        if (_boosterInput)
        {
            _rigidbody.AddForce(transform.forward * _linearForce);
        }
        _rigidbody.AddRelativeTorque(_rollInput * _rollForce, _spinInput * _spinForce, 0);
        
        //
        // // Semi-Physics controller
        // Debug.Log("Object velocities : " + _rigidbody.linearVelocity + " : " + _rigidbody.angularVelocity);
        // if (_boosterInput)
        // {
        //     _rigidbody.linearVelocity = transform.forward * _linearSpeed;
        // }

        
    }

    void OnRollUpDown(InputValue value)
    {
        _rollInput = value.Get<float>();
    }

    void OnSpinLeftRight(InputValue value)
    {
        _spinInput = value.Get<float>();
    }

    void OnBooster(InputValue value)
    {
        _boosterInput = value.isPressed;
    }
}