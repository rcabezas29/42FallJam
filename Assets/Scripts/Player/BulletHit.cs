using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    ColorManager        hitColor;
    ColorManager        myColor;

    public GameObject   normalKillEffect;

    void Start()
    {
        myColor = gameObject.GetComponent<ColorManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (myColor.color == 0)
        {
            IsKillable ik;

            ik = col.gameObject.GetComponent<IsKillable>();
            if (ik != null)
            {
                GameObject nke = Instantiate(normalKillEffect);
                nke.transform.position = col.gameObject.transform.position;
                ParticleSystem  ps = nke.GetComponent<ParticleSystem>();
                ps.Play();
                Destroy(col.gameObject);
            }
        }
        hitColor = col.gameObject.GetComponent<ColorManager>();
        if (hitColor != null)
        {
            if (myColor.color == 1)
                ExplodeEnemy(col);
            else if (myColor.color == 2)
                MakeHealer(col);
            hitColor.color = myColor.color;
        }
        Destroy(gameObject);
    }

    private void ExplodeEnemy(Collider2D col)
    {
        EnemyExploder   exp;

        exp = col.gameObject.GetComponent<EnemyExploder>();
        if (exp == null)
            col.gameObject.AddComponent(typeof(EnemyExploder));
    }

    private void MakeHealer(Collider2D col)
    {
        IsHealer    ih;

        ih = col.gameObject.GetComponent<IsHealer>();
        if (ih == null)
            col.gameObject.AddComponent(typeof(IsHealer));
    }
}
