using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DG.Tweening;

public class coinsAnimationManager : Singleton<coinsAnimationManager>
{
    public List<ItemCollactableCoin> itens;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;


    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
    }

    public void registerCoin(ItemCollactableCoin i)
    {
        if (itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartAnimations();
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }
    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }
        yield return null;
        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, .2f);
            yield return new WaitForSeconds(.1f);
        }

    }
}
