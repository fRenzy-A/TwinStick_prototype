using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject finishTextObject;
    public GameObject instructionTextObject;

    private void Start()
    {
        instructionTextObject.SetActive(true);
        finishTextObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Player"))
        {
            instructionTextObject.SetActive(false);
            finishTextObject.SetActive(true);
        }
;
    }

}
