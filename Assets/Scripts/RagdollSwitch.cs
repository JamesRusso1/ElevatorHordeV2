using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollSwitch : MonoBehaviour
{
    //This coding was provided by John Blanch and Zach has edited it 
    public BoxCollider mainCollider;
    public GameObject mainPlayer;
    public Animator mainPlayerAnimator;
    public NavMeshAgent AI;
    public Rigidbody[] bones;
    public int RagdollForce;
    public int RagdollForceAxe;

    void Start()
    {
        GetRagdollBits();
        ragDollOff();
        bones = GetComponentsInChildren<Rigidbody>();
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Sword")
        {
            ragDollOn();
            //AI.enabled = false;

            foreach (Rigidbody bone in bones)
            {
                bone.AddForce(transform.forward * RagdollForce);
            }
        }

        if (Collision.gameObject.tag == "Axe")
        {
            ragDollOn();

            foreach (Rigidbody bone in bones)
            {
                bone.AddForce(transform.forward * RagdollForceAxe);
            }
        }
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidBody;

    void GetRagdollBits()
    {
        ragDollColliders = mainPlayer.GetComponentsInChildren<Collider>();
        limbsRigidBody = mainPlayer.GetComponentsInChildren<Rigidbody>();
    }

    void ragDollOn()
    {
        mainPlayerAnimator.enabled = false;

        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidBody)
        {
            rigid.isKinematic = false;
        }
        GetComponent<Enemy>().enabled = false;

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void ragDollOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidBody)
        {
            rigid.isKinematic = true;
        }

        mainPlayerAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}