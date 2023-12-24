using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakibi : MonoBehaviour
{
    public Transform takipEdilecekObje; // Karakterinizin Transform bileşeni

    public Vector3 offset; // İstenilen konum farkı

    void Update()
    {
        // Kameranın karakterin pozisyonunu takip etmesi
        transform.position = takipEdilecekObje.position + offset;
    }
}
