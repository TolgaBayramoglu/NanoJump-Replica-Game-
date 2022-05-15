using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
/// ///////////////////////////////////////GEMLERÝN KENDÝ ETRAFINDA VE SÝLÝNDÝRÝN ETRAFINDADÖNMESÝNÝ SAÐLAYAN SCRÝPT

    public bool ActivateRotate;//
    public float RotationSpeedX;
    public float RotationSpeedY;
    public float RotationSpeedZ;
    public bool ActivateRotateAround;
    public float RotationSpeed;
    public GameObject PivotObject;

    void Start()
    {

    }

    void Update()
    {


        if (ActivateRotate == true)
        {
            transform.Rotate(new Vector3(RotationSpeedX, RotationSpeedY, RotationSpeedZ) * Time.deltaTime);
        }
        if (ActivateRotateAround == true)
        {
            transform.RotateAround(PivotObject.transform.position, new Vector3(0, 1, 0), RotationSpeed * Time.deltaTime);
        }

    }
}
