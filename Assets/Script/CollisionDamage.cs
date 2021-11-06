using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 2;
    public string collisionTag;
    public string collisionTag2;

   
    private void OnCollisionEnter(Collision coll)
    {
        //���� ��� ������� ��������� �������� ���������� � ����������� ������ ������� - Player
        if (coll.gameObject.tag == collisionTag)
        {
            //���� � ����� ������� ��������� Health (������ ������� �� �� �����)
            Health health = coll.gameObject.GetComponent<Health>();
            //� �������� ������� ��������� �����, � ��������� ���������� �����
            
            health.TakeHit(collisionDamage);
            
        }
        if (coll.gameObject.tag == collisionTag2)
        {
            //���� � ����� ������� ��������� Health (������ ������� �� �� �����)
            HealthEnemy health = coll.gameObject.GetComponent<HealthEnemy>();
            //� �������� ������� ��������� �����, � ��������� ���������� �����
            health.TakeHit(collisionDamage);

        }
    }

}
