using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScaffolding : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float power;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = transform.up;
            Debug.Log(dir);
            _rigidbody.AddForce(dir * power, ForceMode.Impulse);
        }
    }
}
