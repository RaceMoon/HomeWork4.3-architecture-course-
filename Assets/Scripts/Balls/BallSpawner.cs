using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallSpawner : MonoBehaviour
{
    public Action<Ball> BallSpawned;
    public Action BallSpawnEnded;

    public bool IsWork { get; private set; }

    private const int OneSecond = 1;

    private const float MinOffsetX = -0.3f;
    private const float MaxOffsetX = 0.3f;
    private const int FactorForOffset = 100;

    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _baseSpawnTime;
    [SerializeField] private int _ballPerSecond;
    [SerializeField] private Transform _ballInSceneContainer;

    private float _spawnTime;

    private BallFactory _ballFactory;

    [Inject]
    private void Construct(BallFactory ballFactory)
    {
        _ballFactory = ballFactory;
    }

    public void StartSpawn()
    {
        _spawnTime = _baseSpawnTime;
        IsWork = true;
        StartCoroutine(nameof(SpawnObject));
    }

    public void StopSpawn()
    {
        IsWork = false;
        StopCoroutine(nameof(SpawnObject));
    }

    private void Update()
    {
        if (IsWork)
        {
            if (_spawnTime > 0)
            {
                _spawnTime -= Time.deltaTime;
            }
            else
            {
                StopSpawn();
                BallSpawnEnded?.Invoke();
            }
        }
    }

    private IEnumerator SpawnObject()
    {
        BallType type = (BallType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(BallType)).Length);

        Vector3 spawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position;
        float offcet = UnityEngine.Random.Range(MinOffsetX * FactorForOffset, MaxOffsetX * FactorForOffset) / FactorForOffset;

        Vector3 spawnPointWithOffcet = new Vector3(spawnPoint.x + offcet, spawnPoint.y, spawnPoint.z);

        Ball ball = _ballFactory.Get(_ballPrefab, type, spawnPointWithOffcet, _ballInSceneContainer);
        BallSpawned?.Invoke(ball);

        yield return new WaitForSeconds(OneSecond / _ballPerSecond);

        StartCoroutine(nameof(SpawnObject));
    }
}
