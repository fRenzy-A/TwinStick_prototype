using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
public class BreakableWall : MonoBehaviour
{
    public int HitPoints;
    private bool Hit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Enemy Bullet")
        {
            HitPoints = HitPoints - 1;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

    }
}
