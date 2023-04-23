using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private  ShootController _shootController;
    private InputValue _shoot;

    private void Awake()
    {
        _shootController = new ShootController();
    }

    private void OnEnable()
    {
        _shootController.Enable();
    }

    private void OnDisable()
    {
        _shootController.Disable();
    }

    private void Update()
    {
        if (_shootController.Shoot.Shoot.triggered)
        {
            Debug.Log("We pew pew");
        }
    }
}
