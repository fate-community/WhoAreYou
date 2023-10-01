using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f; // ������Ÿ���� �̵� �ӵ�
    public float lifetime = 3f; // ������Ÿ���� ���� (��)

    private void Start()
    {
        // ���� �ð��� ���� �Ŀ� ������Ÿ���� �ı��մϴ�.
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // ������Ÿ���� ������ �̵���ŵ�ϴ�.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ �ε����� ������Ÿ���� �ı��մϴ�.
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
