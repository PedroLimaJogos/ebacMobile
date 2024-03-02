using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementHelper : MonoBehaviour
{
    public List<Transform> positions;
    public float duration = 1f;
    public float durationStart = 1f;


    private int _index = 1;
    private void Start()
    {
        //transform.position = positions[0].transform.position;
        NextIndex();

        if (positions.Count > 0) StartCoroutine(StartMovement());
    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }
    IEnumerator StartMovement()
    {
        float time = 0;

        while (true)
        {
            var currentPosition = transform.position;

            while (time < duration)
            {

                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0;

            yield return null;
        }
    }
}
