using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAimController : MonoBehaviour
{
    public Transform camera;
    public Transform torsoBone;
    public Vector3 originalRotation;

    public Transform lookFrom;
    private LineRenderer lRen;
    public GameObject cursor;
    public Transform laserFrom;
    // Start is called before the first frame update
    void Start()
    {
        lRen = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 targetDir = (lookFrom.position - camera.transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDir);

        torsoBone.transform.rotation = targetRotation * Quaternion.Euler(originalRotation);

        // Keep this in mind.
        //Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(cursor.transform.GetComponent<RectTransform>().position + Vector3.up * cursor.transform.GetComponent<RectTransform>().rect.height * 0.5f);
        //screenToWorldPoint += Camera.main.transform.forward * 5f;

        lRen.SetPosition(0, laserFrom.position);
        lRen.SetPosition(1, laserFrom.position + (laserFrom.transform.forward * 5f));

    }
}
