using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private int damage = 25;
    [SerializeField] private ParticleSystem shootVFX;
    [SerializeField] private GameObject hitEffect;
    
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
        shootVFX.Play();
        RaycastHit hit;
        if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
