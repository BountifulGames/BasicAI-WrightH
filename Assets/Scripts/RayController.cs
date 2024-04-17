using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10f;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Character target = hit.transform.GetComponent<Character>();
            if (target != null)
            {
                target.TakeDamage(20f);

            }
        }
    }
}
