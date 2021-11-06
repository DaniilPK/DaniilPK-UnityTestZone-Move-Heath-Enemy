using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    //Значение здоровья
    public int health;
    //Максимальное значение здоровья
    public int maxHealth;
    public GameObject Enemy;
    //Функция получения урона
    public void TakeHit(int damage)
    {
        health -= damage;

        //Если здоровье меньше 0 - уничтожить объект на котором весит этот скрипт
        if (health <= 0)
        {
            StartCoroutine(ExampleCoroutine());
        }

    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Запуск корутина");
        health = 100000;
        yield return new WaitForSeconds(5);
        Debug.Log("Спавн 3 врагов");
        float x = 11.96f;
        float y = 0.56f;
        float z = Random.Range(-15.61f, 6.4f);
        Vector3 pos = new Vector3(x, y, z);
        Instantiate(Enemy, pos, Quaternion.identity);

        Instantiate(Enemy, pos, Quaternion.identity);

        Instantiate(Enemy, pos, Quaternion.identity);
        Destroy(gameObject);
    }

    //Функция прибавления здоровья
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        //Если здоровье, после пополнения, больше максимального значения - здоровье будет равно максимальному значению.
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
