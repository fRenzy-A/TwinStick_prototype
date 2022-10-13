using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float firingSpeed;
    // Start is called before the first frame update
    public static PlayerShoot Instance;

    private float lastTimeShot = 0;
    void Awake()
    {
        Instance = GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        if (lastTimeShot + firingSpeed <= Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        }
    }
}
