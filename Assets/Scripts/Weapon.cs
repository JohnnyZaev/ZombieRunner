using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private float range = 100f;
    
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
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range);
        Debug.Log(hit.transform.name);
    }
}
