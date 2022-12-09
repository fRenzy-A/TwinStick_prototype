using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBreak : MonoBehaviour
{
    public int HitPoints;
    private bool Hit;
    private void OnTriggerEnter(Collider other)
    {
        while (HitPoints > 0)
        {
            if (other.gameObject.tag == "Bullet")
            {
                HitPoints = HitPoints - 1;
            }
            if (HitPoints == 0)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
        }

    }
}
