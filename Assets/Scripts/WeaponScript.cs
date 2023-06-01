using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform Barrel;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;

    private Animator weaponAnimator;
    private float fireTimer;

    public int municoes = 15;
    public int municoesReserva = 30;

    float reloadDelay = 1f;
    float timeReload = 0;
    float timeReloading = 0;
    float timeToReload = 2.4f;
    bool recarregando = false;

    public AudioClip pistola;
    public AudioClip armaVazia;
    public AudioClip recarregar;
    public AudioSource audios;


    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting(){
        if(Input.GetMouseButtonDown(0) && CanShoot() && !recarregando)
        {
            Shoot();
        }
        if(municoes != 15)
        {
            if (Input.GetKeyDown("r") && Time.time - timeReload > reloadDelay)
            {
                timeReload = Time.time;
                timeReloading = timeReload;
                recarregando = true;
                audios.PlayOneShot(recarregar, 1);
            }
            if(recarregando)
            {
                if(Time.time - timeReloading > timeToReload)
                {
                    if(municoesReserva - municoes >= 15)
                    {
                        municoesReserva -= 15 - municoes;
                        municoes = 15;
                        recarregando = false;
                    }
                    else
                    {
                        municoes += municoesReserva;
                        municoesReserva = 0;
                        recarregando = false;
                    }
                }
            }
        }
    }

    private void Shoot(){
        fireTimer = Time.time +fireRate;

        if (municoes > 0)
        {
            Instantiate(bullet, Barrel.position, Barrel.rotation);
            weaponAnimator.SetTrigger("Fire");

            audios.PlayOneShot (pistola, 1);
            municoes--;
        }
        else
        {
            audios.PlayOneShot (armaVazia, 1);
        }
    }

    private bool CanShoot(){
        return Time.time > fireTimer;
    }

}
