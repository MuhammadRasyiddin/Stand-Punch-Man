using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public int multiply;

    private void Update()
    {
        Movement();
        Hit();
        Attack();
    }

    private void Movement()
    {
        this.gameObject.transform.Translate(new Vector2(5 * multiply,0) * Time.deltaTime);
    }

    private void Hit() //hit by player
    {
        if (this.gameObject.transform.localPosition.x >= -4f && this.gameObject.transform.localPosition.x <= -2f)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                print("HIT LEFT");
                Destroy(this.gameObject);
            }
        }

        if (this.gameObject.transform.localPosition.x >= 2f && this.gameObject.transform.localPosition.x <= 4f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                print("HIT RIGHT");
                Destroy(this.gameObject);
            }
        }
    }

    private void Attack() //attacking player
    {
        if (this.gameObject.transform.localPosition.x > -2f && this.gameObject.transform.localPosition.x < 0f)
        {
            print("ATTACK LEFT");
            GameObject.Find(GameData.gameObject_gameController).GetComponent<PlayerController>().health--;
            Destroy(this.gameObject);
        }

        if (this.gameObject.transform.localPosition.x < 2 && this.gameObject.transform.localPosition.x > 0f)
        {
            print("ATTACK RIGHT");
            GameObject.Find(GameData.gameObject_gameController).GetComponent<PlayerController>().health--;
            Destroy(this.gameObject);
        }
    }
}
