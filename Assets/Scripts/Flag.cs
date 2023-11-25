using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SuperGirl")
        {
            anim.SetBool("Win", true);
            LevelManager.instance.setPoints(Mathf.RoundToInt(LevelManager.instance.getTimeRestante()));
            LevelManager.instance.setWin(true);
            LevelManager.instance.am.newSFX("win");
        }
        StartCoroutine(animeFinish());
    }

    IEnumerator animeFinish()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
