﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour {
    GameObject WarriorClass;
    Warrior wrr;

    private int countLVL = 1, _lvlForUnblockSkills = 0, _lvlForSkills = 0;
    private double nextLvl = 100;
    void Start () {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();
    }
	
	void Update () {
        if (wrr.pXP >= nextLvl)
        {
            countLVL++;
            wrr.level = countLVL;
            wrr.pXP = 1;
            nextLvl *= 1.2;
            _lvlForUnblockSkills++;
            _lvlForSkills++;
        }
	}
    public double GetNextLvl
    {
        get { return nextLvl; }
    }
    public int lvlForUnblockSkills
    {
        get { return _lvlForUnblockSkills; }
        set { _lvlForUnblockSkills = value; }
    }
    public int lvlForSkills
    {
        get { return _lvlForSkills; }
        set { _lvlForSkills = value; }
    }
}
