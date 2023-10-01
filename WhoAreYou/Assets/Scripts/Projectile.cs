using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f; // 프로젝타일의 이동 속도
    public float lifetime = 3f; // 프로젝타일의 수명 (초)

    private void Start()
    {
        // 일정 시간이 지난 후에 프로젝타일을 파괴합니다.
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // 프로젝타일을 앞으로 이동시킵니다.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어에 부딪히면 프로젝타일을 파괴합니다.
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
