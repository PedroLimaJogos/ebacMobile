using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;
    public List<LevelPieceBasedSetup> levelPieceBasedSetups;

    public float timeBetweenPieces = .3f;
    [SerializeField] private int _index;
    private GameObject _currentLevel;




    [Header("Level Pieces")]


    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBasedSetup _currSetup;

    private void Start()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }



    private void ResetLevelIndex()
    {
        _index = 0;
    }

    #region 
    private void CreateLevelPieces()
    {
        CleanSpawnedPieces();

        if (_currSetup != null)
        {
            _index++;
            if (_index >= levelPieceBasedSetups.Count)
            {
                ResetLevelIndex();
            }

        }
        _currSetup = levelPieceBasedSetups[_index];

        for (int i = 0; i < _currSetup.piecesStartNumber; i++)
        {
            Debug.Log("criando inicio");
            CreateLevelPiece(_currSetup.levelPiecesStart);
        }
        for (int i = 0; i < _currSetup.piecesNumber; i++)
        {
            Debug.Log("criando meio");
            CreateLevelPiece(_currSetup.levelPieces);
        }
        for (int i = 0; i < _currSetup.piecesEndNumber; i++)
        {
            Debug.Log("criando fim");
            CreateLevelPiece(_currSetup.levelPiecesEnd);
        }

        colorManager.Instance.ChangeColorByType(_currSetup.artType);
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in _spawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }
        yield return null;
        for (int i = 0; i < _spawnedPieces.Count; i++)
        {
            _spawnedPieces[i].transform.DOScale(1, .2f);
            yield return new WaitForSeconds(.1f);
        }

    }

    public artManager.ArtType randomizaArt()
    {
        artManager.ArtType art = artManager.ArtType.TYPE_01; ;

        int escolha = UnityEngine.Random.Range(0, 3);
        if (escolha == 0)
        {
            art = artManager.ArtType.TYPE_01;

        }
        else if (escolha == 1)
        {
            art = artManager.ArtType.TYPE_02;

        }
        else if (escolha == 2)
        {
            art = artManager.ArtType.BEACH;

        }

        return art;
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        _currSetup.artType = randomizaArt();

        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.changePiece(artManager.Instance.getSetupByType(_currSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnedPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();
    }

    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("troca");
            CreateLevelPieces();
        }
    }

    IEnumerator CreateLevelPiecesCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < _currSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }
}