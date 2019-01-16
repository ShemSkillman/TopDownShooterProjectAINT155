﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Slider ammoBar;
    public Slider weaponHeatBar;
    public Text scoreText;
    public Text weaponsText;

    public int playerScore = 0;

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;        
        AddScore.OnSendScore += UpdateScore;
        Player.OnUpdateAmmoCount += UpdateAmmoCount;
        Player.OnUpdateWeaponHeat += UpdateWeaponHeat;

    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
        Player.OnUpdateAmmoCount -= UpdateAmmoCount;
        Player.OnUpdateWeaponHeat -= UpdateWeaponHeat;
        PlayerPrefs.SetInt("Score", playerScore);
    }


    private void Start()
    {
        playerScore = PlayerPrefs.GetInt("Score");
        scoreText.text = "SCORE: " + playerScore.ToString();
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        scoreText.text = "SCORE: " + playerScore.ToString();
    }

    private void UpdateAmmoCount(int theAmmoCount)
    {
        ammoBar.value = theAmmoCount;
    }

    private void UpdateWeaponHeat(int theWeaponHeat)
    {
        weaponHeatBar.value = 100 - theWeaponHeat;
    }
}