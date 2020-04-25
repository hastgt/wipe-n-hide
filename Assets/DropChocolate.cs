using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChocolate : MonoBehaviour
{
    public Sprite[] stains;
    public float growthRate = 0.1f;
    public float backOffset = 0.3f;
    public float timer = 0f;

    private void Awake()
    {
        ResetTimer();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            ResetTimer();
            Drop();
        }
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.F))
        {
            Drop();
        }
    }

    void Drop()
    {
        GameObject go = new GameObject();
        go.name = "ChocolatePool";
        go.transform.localScale = Vector3.zero;
        go.transform.position = this.transform.position + this.transform.forward * -1 * backOffset;
        go.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));

        SpriteRenderer rend = go.AddComponent<SpriteRenderer>();
        CircleCollider2D coll = go.AddComponent<CircleCollider2D>();
        coll.isTrigger = true;
        coll.radius = 1f;
        coll.tag = "Chocolate";
        int randomIndex = Random.Range(0, stains.Length);
        rend.sprite = stains[randomIndex];
        StartCoroutine(Pool(rend));
    }

    void ResetTimer()
    {
        timer = Random.Range(0.01f, 3f);
    }

    IEnumerator Pool(SpriteRenderer rend)
    {
        float targetScale = Random.Range(0.1f, 2f);
        while(rend.transform.localScale.x < targetScale)
        {
            rend.transform.localScale += new Vector3(growthRate, growthRate, 0f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
