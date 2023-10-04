using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FailTigger : MonoBehaviour
{
    public float FailTriggerMoveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<BoxCollider>().isTrigger == false)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Vector3.forward * FailTriggerMoveSpeed*Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            GameController.State = GameState.Fail;
        }
    }
}
