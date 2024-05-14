using System.Collections;
using UnityEngine;

public class EnemySpon : MonoBehaviour
{
    public GameObject GroundEnemy;
    public GameObject FlyEnemy;
    public GameObject UpDownEnemey;

    public int groundenemysponspeed;
    public int flyenemysponspeed;
    public int updownenemeysponspeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Groundenemey());
        StartCoroutine(Flyenemy());
        StartCoroutine(Updownenemey());
    }

   private IEnumerator Groundenemey()
    {
        while (true)
        {
            yield return new WaitForSeconds(groundenemysponspeed);
            float x = Random.Range(10f ,10f );
            float y = Random.Range(-3f ,-1f );
            Vector2 pos = new Vector2(x,y);
            Instantiate(GroundEnemy, pos, Quaternion.identity);
        }
    }
    private IEnumerator Flyenemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(flyenemysponspeed);
            float x = Random.Range(10f, 10f);
            float y = Random.Range(3f, 1f);
            Vector2 pos = new Vector2(x,y);
            Instantiate(FlyEnemy, pos, Quaternion.identity);
        }
    }
    private IEnumerator Updownenemey()
    {
        while (true)
        {
            yield return new WaitForSeconds(updownenemeysponspeed);
            float x = Random.Range(10f, 10f);
            float y = Random.Range(-3f, 0f);
            Vector2 pos = new Vector2(x, y);
            Instantiate(UpDownEnemey, pos, Quaternion.identity);
        }
    }

}
