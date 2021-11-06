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
        //Если тег объекта коллайдер которого столкнулся с коллайдером нашего объекта - Player
        if (coll.gameObject.tag == collisionTag)
        {
            //Берём у этого объекта компонент Health (Скрипт который на нём висит)
            Health health = coll.gameObject.GetComponent<Health>();
            //И вызываем функцию получения урона, в агрументе переменная урона
            
            health.TakeHit(collisionDamage);
            
        }
        if (coll.gameObject.tag == collisionTag2)
        {
            //Берём у этого объекта компонент Health (Скрипт который на нём висит)
            HealthEnemy health = coll.gameObject.GetComponent<HealthEnemy>();
            //И вызываем функцию получения урона, в агрументе переменная урона
            health.TakeHit(collisionDamage);

        }
    }

}
