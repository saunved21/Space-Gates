using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource; //cache


    [SerializeField] float mainThrust = 100f; // parameters
    [SerializeField] float rot = 100f; 

    [SerializeField] AudioClip engine;

    [SerializeField] ParticleSystem MainParticle;
    [SerializeField] ParticleSystem rightParticle;
    [SerializeField] ParticleSystem leftParticle;

    void Start()                                //stat
    {
        rb = GetComponent<Rigidbody>();
        audioSource=GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
            if(!audioSource.isPlaying)
            {

                audioSource.PlayOneShot(engine);
                MainParticle.Play();
            }
            if(!MainParticle.isPlaying)
            {
                MainParticle.Play();
            }
            
        }
        else 
        {
            audioSource.Stop();
            MainParticle.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey("a"))
        {
            applyrot(rot);
            if(!rightParticle.isPlaying)
            {
                rightParticle.Play();
            }
        }
        else if (Input.GetKey("d"))
        {
            applyrot(-rot);
            if(!leftParticle.isPlaying)
            {
                leftParticle.Play();
            }
        }

        else
        {
            rightParticle.Stop();
            leftParticle.Stop();
            {
                
            }
        }
    }

    void applyrot(float rotframe)
    {
        transform.Rotate(Vector3.forward*rotframe*Time.deltaTime); 
        rb.freezeRotation=true;
        rb.freezeRotation=false;
    }
}
