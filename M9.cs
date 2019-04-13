using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M9 : MonoBehaviour
{
    [Header("Basic Stats:")]
    public string Name = "M9";
    public float Clip = 8f;
    public float Reserve = 16f;
    public float range = 50f;
    public float damage = 5f;

    [Header("UI")]
    public Text ClipUI;
    public Text ReserveUI;
    public Text WeaponName;

    [Header("FX:")]
    public AudioSource Audio;
    public Animation animation;
    public GameObject fpscam;
    public GameObject blood;

    public void Update()
    {
        ClipUI.text = Clip.ToString();
        ReserveUI.text = Reserve.ToString();
        WeaponName.text = Name;

        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

    }

    void Fire ()
    {
        Audio.Play();
        animation.Play();
        Clip = Clip - 1f;

        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {

            EnemyAI enemy = hit.transform.gameObject.GetComponent<EnemyAI>();

            if (enemy != null)
            {
                GameObject imactGo = Instantiate(blood, hit.point, Quaternion.identity);
                enemy.TakeDamage(damage);
                Destroy(imactGo, 2f);
            }

        }

        if (Clip <= 0f)
        {
            Reserve = Reserve - 8f;
            Clip = Clip + 8f;
        }

    }


}
