using System.Collections;
using UnityEngine;

public class SpawmEnemy : MonoBehaviour
{
    public GameObject enemyPre;
    public Transform Player;
    public float speed = 2f;
    void Start()
    {
        StartCoroutine(Spawm());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Spawm()
    {
        while (true)
        {
            int TyLe = Random.Range(1, 4);
            yield return new WaitForSeconds(TyLe);
            spawm1();
            spawm1();
            yield return new WaitForSeconds(1);
            spawm2();
            spawm2();
        }
    }

    void spawm1()
    {
        Vector2 SpawmPos = new Vector2(Random.Range(-6f, 6f), Random.Range(5f, 6f));
        var Enemy = Instantiate(enemyPre, SpawmPos, Quaternion.identity);
        Vector2 huong = ((Vector2)Player.position - SpawmPos).normalized;
        Enemy.GetComponent<Rigidbody2D>().linearVelocity = huong * speed;
    }
    void spawm2()
    {
        Vector2 SpawmPos = new Vector2(Random.Range(-6f, 6f), Random.Range(-5f, -6f));
        var Enemy = Instantiate(enemyPre, SpawmPos, Quaternion.identity);
        Vector2 huong = ((Vector2)Player.position - SpawmPos).normalized;
        Enemy.GetComponent<Rigidbody2D>().linearVelocity = huong * speed;
    }
}
