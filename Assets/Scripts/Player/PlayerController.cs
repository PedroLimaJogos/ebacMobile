using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;

    public float lerpSpeed = 1f;
    public float speed = 1;
    private float _currentSpeed;
    [Header("TextMeshPro")]
    public TextMeshPro textMeshPro;
    [Header("Initializers")]
    private Vector3 _startPosition;
    public string tagEnemy = "Enemy";
    public string tagEndLine = "EndLine";
    public bool invencible = false;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    public GameObject endScreen;
    public GameObject startScreen;

    //Private
    private Vector3 _pos;
    private bool _canRun;

    private void Start()
    {
        ResetSpeed();
        _startPosition = transform.position;
        _canRun = false;
    }
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagEnemy)
            if (!invencible) EndGame();


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

    #region POWER UP;
    //SPEED
    public void SetPowerUpText(string s)
    {
        textMeshPro.text = s;
    }
    public void PowerSpeedUp(float f)
    {
        Debug.Log(_currentSpeed);
        _currentSpeed = f;
        Debug.Log(_currentSpeed);
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    //INVENCIBLE
    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    //Height
    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        // var p = transform.position;
        // p.y = _startPosition.y + amount;
        // transform.position = p;

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }
    public void ResetHeight()
    {
        // var p = transform.position;
        // p.y = _startPosition.y;
        // transform.position = p;

        transform.DOMoveY(_startPosition.y, .1f);
    }

    //COIN COLLECTOR
    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion
}
