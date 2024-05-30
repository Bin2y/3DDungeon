using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CharacterManager.Instance.Player.savePoint = transform.position;
            Destroy(gameObject);
        }
    }
}
