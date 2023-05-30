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

    AudioSource somDeTiro;

    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
        somDeTiro = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting(){
        if(Input.GetMouseButtonDown(0) && CanShoot()){
            Shoot();
        }
    }

    private void Shoot(){
        fireTimer = Time.time +fireRate;

        Instantiate(bullet, Barrel.position, Barrel.rotation);
        weaponAnimator.SetTrigger("Fire");

        somDeTiro.Play(0);
    }

    private bool CanShoot(){
        return Time.time > fireTimer;
    }

}
