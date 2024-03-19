using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text distanceToGround;
    [SerializeField] Lander lander;

    private void Update()
    {
        distanceToGround.text = lander.DistanceToGround.ToString("F2");
    }
}
