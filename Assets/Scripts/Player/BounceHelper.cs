using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .01f;
    public float scaleBounce = 1.2f;
    public Vector3 scaleStech = new Vector3(1.2f, 1, 1);
    public Ease ease = Ease.OutBack;
    private Sequence bounceSequence;
    private Sequence stetchSequence;
    // Start is called before the first frame update
    public void Bounce()
    {
        float originalScaleX = transform.localScale.x;
        if (bounceSequence == null)
        {
            bounceSequence = DOTween.Sequence();
        }
        // Limpe a sequência de animações atual
        else
        {
            transform.localScale = new Vector3(originalScaleX, 1, 1);
            bounceSequence.Kill();
            bounceSequence = DOTween.Sequence();
        }

        // Adicione a animação à sequência
        bounceSequence.Append(transform.DOScale(new Vector3(originalScaleX, 1.2f, 1.2f), scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo));

    }
    public void Stretch()
    {
        if (stetchSequence == null)
        {
            stetchSequence = DOTween.Sequence();
        }
        // Limpe a sequência de animações atual
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            stetchSequence.Kill();
            stetchSequence = DOTween.Sequence();
        }
        stetchSequence.Append(transform.DOScale(scaleStech, 1f).SetEase(Ease.OutBack));
    }
    public void Unstretch()
    {
        Debug.Log("fui chamado?");
        stetchSequence.Append(transform.DOScale(1, 1f).SetEase(Ease.OutBack));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }


}
