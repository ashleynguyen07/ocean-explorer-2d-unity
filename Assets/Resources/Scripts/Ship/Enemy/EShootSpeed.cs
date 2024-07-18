using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EShootSpeed : MonoBehaviour
{

    GameObject prefabBullet;
    Rigidbody2D rb;
    [SerializeField]
    EnemyHealthBar enemyHealthBar;
    float timeShoot;
    bool callOneTime, callOneTimeStop;
    GameObject tmp1;
    int MaxHeal, count;
    void Start()
    {
        count = 0;
        timeShoot = 2.5f;
        UpdateBullet();
        callOneTime = callOneTimeStop =true;
        MaxHeal = enemyHealthBar.GetCurrentHealth();
    }
    private void Update()
    {
        if (enemyHealthBar.GetCurrentHealth() <= (70 * MaxHeal / 100) && callOneTime)
        {
            callOneTime = false;
            timeShoot = 0.5f;
            StartCoroutine(Shoot1());
            StartCoroutine(Shoot2());
        }
        else if (enemyHealthBar.GetCurrentHealth() <= (50 * MaxHeal / 100) && callOneTimeStop)
        {
            StartCoroutine(StopShoot());
            callOneTimeStop = false;
        }
    }
    private void UpdateBullet()
    {
        prefabBullet = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/bulletEnemy/bulletE2.prefab", typeof(GameObject));

        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeShoot);
        Vector3 temp = transform.position;
        temp.y -=1;
       GameObject tmp = Instantiate(prefabBullet, temp, Quaternion.Euler(0, 0, -90f));
       rb = tmp.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (0f, -10f);
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot1()
    {

        yield return new WaitForSeconds(timeShoot);
        Vector3 temp = transform.position;
        temp.y -= 1f;
        GameObject tmp = Instantiate(prefabBullet, temp, Quaternion.Euler(0, 0, -90f));
        rb = tmp.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-3f, -10f);
        StartCoroutine(Shoot1());
    }
    IEnumerator Shoot2()
    {

        yield return new WaitForSeconds(timeShoot);
        Vector3 temp = transform.position;
        temp.y -= 1f;
        GameObject tmp = Instantiate(prefabBullet, temp, Quaternion.Euler(0, 0, -90f));
        rb = tmp.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(3f, -10f);
        StartCoroutine(Shoot2());
    }

    IEnumerator StopShoot()
    {
        StopAllCoroutines();
        StartCoroutine( ShootCirCle());
        yield return null;
    }
    IEnumerator ShootCirCle()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject child = gameObject.transform.GetChild(1).gameObject;
        Vector3 temp = child.transform.position;
        tmp1 = Instantiate(prefabBullet, temp, Quaternion.Euler(0, 0, -90f));
        rb = tmp1.GetComponent<Rigidbody2D>();
        if (temp.y > 6)
        {
            rb.velocity = new Vector2(temp.x*2f, 10f);
        }else rb.velocity = new Vector2(temp.x*2f, -10f);
        StartCoroutine(ShootCirCle());
    }

}
