using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    //�������� ��������
    public int health;
    //������������ �������� ��������
    public int maxHealth;
    public GameObject Enemy;
    //������� ��������� �����
    public void TakeHit(int damage)
    {
        health -= damage;

        //���� �������� ������ 0 - ���������� ������ �� ������� ����� ���� ������
        if (health <= 0)
        {
            StartCoroutine(ExampleCoroutine());
        }

    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("������ ��������");
        health = 100000;
        yield return new WaitForSeconds(5);
        Debug.Log("����� 3 ������");
        float x = 11.96f;
        float y = 0.56f;
        float z = Random.Range(-15.61f, 6.4f);
        Vector3 pos = new Vector3(x, y, z);
        Instantiate(Enemy, pos, Quaternion.identity);

        Instantiate(Enemy, pos, Quaternion.identity);

        Instantiate(Enemy, pos, Quaternion.identity);
        Destroy(gameObject);
    }

    //������� ����������� ��������
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        //���� ��������, ����� ����������, ������ ������������� �������� - �������� ����� ����� ������������� ��������.
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
