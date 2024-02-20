using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;

    public float lerpSpeed = 1f;
    public float speed = 1;
    public string tagEnemy = "Enemy";
    public string tagEndLine = "EndLine";

    public GameObject endScreen;
    public GameObject startScreen;

    //Private
    private Vector3 _pos;
    private bool _canRun;

    private void Start()
    {
        _canRun = false;
    }
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagEnemy)
            EndGame();


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == tagEndLine)
            EndGame();
    }

    public void StartRun()
    {
        _canRun = true;
        startScreen.SetActive(false);
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }
}
