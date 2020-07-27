﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform firePoint;
    public Bullet bullet;
    public float shootingSpeed;
    [SerializeField] private PhotonView _photonView;

    void FixedUpdate() {
        if (_photonView.IsMine) {
            _photonView.RPC("Fire",RpcTarget.All);
        }
    }

    [PunRPC]
    public void Fire() {
        GameObject projectile = Instantiate(bullet.gameObject, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shootingSpeed, ForceMode2D.Impulse);
    }
}
