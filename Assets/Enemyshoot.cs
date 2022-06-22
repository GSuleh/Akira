using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Enemyshoot : MonoBehaviour
{
    [SerializeField]
    private aggro aggrodetection;

    [SerializeField]
    [Range(0.2f, 2.5f)]
    private float firerate = 2f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 2;

    [SerializeField]
    private Transform firepoint;

    [SerializeField]
    private AudioSource gunshot;

    private float timer;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        aggrodetection = GetComponent<aggro>();
        gunshot = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        anim.SetBool("isaim", false);
        if (timer >= firerate)
        {
            if (aggrodetection != null)
            {
                timer = 0f;
                FireGun();
                gunshot.Play();
            }
        }

    }

    private void FireGun()
    {
        Debug.DrawRay(firepoint.position, firepoint.forward * 100, Color.red, 2f);
        Ray ray = new Ray(firepoint.position, firepoint.forward);

        RaycastHit hitInfo;

        anim.SetBool("isaim", true);


        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var objhealth = hitInfo.collider.GetComponent<Playerhealth>();

            if (objhealth != null)
                objhealth.TakeDamage(damage);
        }
    }
}
