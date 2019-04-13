using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UMP45 : MonoBehaviour
{

    [Header("Basic Stats:")]
    public string Name = "UMP-45";
    public float Damage = 10f;
    public float range = 50f;
    public float clip = 25f;
    public float reserve = 100f;

    [Header("Needs:")]
    public GameObject fpscam;

    [Header("FX")]
    public AudioSource ShootSound;
    public AudioSource ReloadSound;
    public Animation Recoil;
    public GameObject blood;

    [Header("UI")]
    public Text ClipUI;
    public Text ReserveUI;
    public Text WeaponUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (clip <= 0f)
        {
            reserve = reserve - 25f;
            Debug.Log("Reloading");
        }

        ClipUI.text = clip.ToString();
        ReserveUI.text = reserve.ToString();
        WeaponUI.text = Name;

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
            {

                Fire();

            }
        }
    }


    void Fire ()
    {
        ShootSound.Play();
        Recoil.Play();
        clip = clip - 1f;

        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            EnemyAI enemy = hit.transform.gameObject.GetComponent<EnemyAI>();

            if (enemy != null)
            {
                GameObject imactGo = Instantiate(blood, hit.point, Quaternion.identity);
                enemy.TakeDamage(Damage);
                Destroy(imactGo, 2f);
            }
        }

    }
  }
