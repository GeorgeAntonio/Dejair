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

    private GameController gameController;

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

        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting(){
        int municao = gameController.getMunicao();
        int municoesReserva = gameController.getMunicaoReserva();
        if (Input.GetMouseButtonDown(0) && CanShoot() && !recarregando)
        {
            Shoot();
        }
        if(municao != 15)
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
                    if(municoesReserva - municao >= 15)
                    {
                        //municoesReserva -= 15 - municao;
                        //municao = 15;
                        recarregando = false;
                        gameController.setMunicao(15);
                        gameController.setMunicaoReserva(municoesReserva - (15 - municao) );
                    }
                    else
                    {
                        //municao += municoesReserva;
                        //municoesReserva = 0;
                        recarregando = false;
                        gameController.setMunicao(municao + municoesReserva);
                        gameController.setMunicaoReserva(0);
                    }
                }
            }
        }
    }

    private void Shoot(){
        fireTimer = Time.time +fireRate;
        int municao = gameController.getMunicao();

        if (municao > 0)
        {
            Instantiate(bullet, Barrel.position, Barrel.rotation);
            weaponAnimator.SetTrigger("Fire");

            audios.PlayOneShot (pistola, 1);
            gameController.setMunicao(municao - 1);

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
