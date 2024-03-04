using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollactableBase : MonoBehaviour
{
    public string tagCompare = "player";
    //public ParticleSystem particleSystem;
    public float timeToHide = 3f;
    public GameObject graphicItem;
    public ParticleSystem particleSystem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(tagCompare))
        {
            Collect();
            PlayerController.Instance.Bounce();
        }
    }
    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke(nameof(HideObject), timeToHide);
        OnCollect();
    }

    private void HideObject()
    {

        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {

        if (particleSystem != null)
        {
            particleSystem.transform.SetParent(null);
            particleSystem.Play();
        }



        if (audioSource != null) audioSource.Play();
    }

    private void Update()
    {

    }

}

