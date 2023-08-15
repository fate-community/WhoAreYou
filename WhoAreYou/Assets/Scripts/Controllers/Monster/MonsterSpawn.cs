using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;


public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    public int poolCount = 10;
    [SerializeField]
    public GameObject monster;
    public List<GameObject> monsterObjectPool;
    public BoxCollider area;

    static bool isRespawn = false;
    int deadIndex = 100;

    // Start is called before the first frame update
    void Start()
    {
        monsterObjectPool = new List<GameObject>();
        area = GetComponent<BoxCollider>();

        StopAllCoroutines();

        for (int i = 0; i < poolCount; i++)
        {
            GameObject gameObject = Instantiate(monster);

            monsterObjectPool.Add(gameObject);

            StartCoroutine(Spawn(i));
        }

        InvokeRepeating("Respawn", 5, 10);
    }

    private void Update()
    {
        for (int i = 0; i < poolCount; i++)
        {
            if (monsterObjectPool[i].activeSelf == false)   // 비활성화 된 인덱스 찾기 (죽은 몬스터 찾기)
            {
                deadIndex = i;
                isRespawn = false;
            }
        }
    }

    private void Respawn()
    {
        Debug.Log(deadIndex);

        if (deadIndex < poolCount)
        {
            GameObject gameObject = monsterObjectPool[deadIndex];     // 죽은 몬스터 
            gameObject.SetActive(true);    // 부활시킴

            isRespawn = true;    // 리스폰 체크
            Debug.Log("리스폰");

            if (!isRespawn)   // 리스폰 체크되면 실행 안되어야 하고 인덱스가 바뀌면 실행 한번 되야하는거니까 인덱스 바뀔때마다 체크해줘
            {
                gameObject.transform.position = GetRandomPosition();
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + UnityEngine.Random.Range(-1 * (size.x / 2f), size.x / 2f);
        float posZ = basePosition.z + UnityEngine.Random.Range(-1 * (size.z / 2f), size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, 0f, posZ);

        return spawnPos;
    }

    private IEnumerator Spawn(int index)
    {

        GameObject selectedPrefab = monsterObjectPool[index];

        if (selectedPrefab.activeSelf == false)
        {
            selectedPrefab.SetActive(true);
        }

        selectedPrefab.transform.position = GetRandomPosition();

        yield return new WaitForSecondsRealtime(1.0f);
    }

}
