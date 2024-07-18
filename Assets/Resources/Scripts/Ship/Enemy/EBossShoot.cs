using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EBossShoot : MonoBehaviour
{
    GameObject prefabBullet;
    Rigidbody2D rbLeft, rbRight , rb;
    [SerializeField]
    EnemyHealthBar enemyHealthBar;
    float timeShoot, x;
    bool callOneTime, callOneTimeStop, onetime;
    GameObject tmpLeft, tmpRight;
    int MaxHeal, count;
    void Start()
    {
        x = 1f;
        count = 0;
        timeShoot = 2.5f;
        UpdateBullet();
        callOneTime = callOneTimeStop = onetime =true;
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
        temp.y -= 1;
        GameObject tmp = Instantiate(prefabBullet, temp, Quaternion.Euler(0, 0, -90f));
        rb = tmp.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -10f);
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
        StartCoroutine(ShootCirCle());
        yield return null;
    }
    IEnumerator ShootCirCle()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject childLeft = gameObject.transform.GetChild(1).gameObject;
        GameObject childRight = gameObject.transform.GetChild(2).gameObject;
        Vector3 tempLeft = childLeft.transform.position;
        Vector3 tempRight = childRight.transform.position;
        tmpLeft = Instantiate(prefabBullet, tempLeft, Quaternion.Euler(0, 0, -90f));
        tmpRight = Instantiate(prefabBullet, tempRight, Quaternion.Euler(0, 0, -90f));
        rbLeft = tmpLeft.GetComponent<Rigidbody2D>();
        rbRight = tmpRight.GetComponent<Rigidbody2D>();
        rbLeft.velocity = new Vector2(tempLeft.x * (-1.8f), -10f);
        rbRight.velocity = new Vector2(tempRight.x * (-1.8f), -10f);
        StartCoroutine(ShootCirCle());
        if (onetime)
        {
            onetime = false;
            yield return new WaitForSeconds(10f);
            StopAllCoroutines();
            StartCoroutine(Shoot());
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        StopAllCoroutines();
        StartCoroutine(ShootCirCle1());
    }
    IEnumerator ShootCirCle1()
    {
        yield return new WaitForSeconds(0.3f);
        x -= 15 * Time.deltaTime;
        GameObject childLeft = gameObject.transform.GetChild(1).gameObject;
        GameObject childRight = gameObject.transform.GetChild(2).gameObject;
        Vector3 tempLeft = childLeft.transform.position;
        Vector3 tempRight = childRight.transform.position;
        tmpLeft = Instantiate(prefabBullet, tempLeft, Quaternion.Euler(0, 0, -90f));
        tmpRight = Instantiate(prefabBullet, tempRight, Quaternion.Euler(0, 0, -90f));
        rbLeft = tmpLeft.GetComponent<Rigidbody2D>();
        rbRight = tmpRight.GetComponent<Rigidbody2D>();
        rbLeft.velocity = new Vector2(-x*8f, -10f);
        rbRight.velocity = new Vector2(x*8f, -10f);
        StartCoroutine(ShootCirCle1());
        yield return new WaitForSeconds(5f);
        StopAllCoroutines();
        StartCoroutine(Shoot1());
        StartCoroutine(Shoot2());
        StartCoroutine(Shoot());
    }
}
