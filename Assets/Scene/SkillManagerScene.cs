using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManagerScene : MonoBehaviour {

    GameObject WarriorClass, LvlManagerClass;
    LvlManager lvlmng;
    Warrior wrr;
    public GameObject UnblockButton1, UnblockButton2, UnblockButton3;
    public Button Skill1, Skill2, Skill3;
    public GameObject LvlUpSkill1, LvlUpSkill2, LvlUpSkill3;

    public bool[] unlockedAb;  //массив, который показывает, разблокирован (тру) или заблокирован (фолс)
    int[] levelAb;      //уровень каждого из скилов
    public int _level;     //общий уровень игрока
    int lvlForSkills = 1;
    bool flagLvlFirSkills = false;

    void Start () {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();

        LvlManagerClass = GameObject.Find("Main Camera");
        lvlmng = LvlManagerClass.GetComponent<LvlManager>();

        unlockedAb = new bool[3];                       //инициализация
        levelAb = new int[3];
        unlockedAb = wrr.unlockedabilities;
        levelAb = wrr.levelofabilities;
        _level = wrr.level;

        UnblockButton1.SetActive(false);
        UnblockButton2.SetActive(false);
        UnblockButton3.SetActive(false);

        Skill1.interactable = false;
        Skill2.interactable = false;
        Skill3.interactable = false;

        LvlUpSkill1.SetActive(false);
        LvlUpSkill2.SetActive(false);
        LvlUpSkill3.SetActive(false);
    }

    public void Decrement(int IDSKILL)  //уменьшить уровень скила сюда посылать ID ВНИМАНИЕ 1,2,3 !!!
    {
        if (unlockedAb[IDSKILL - 1] == false)
            return;
        else
        {
            if (levelAb[IDSKILL - 1] > 0)
            {
                levelAb[IDSKILL - 1]--;
                _level++;
            }
        }
    }
    public void Increment(int IDSKILL)  //увеличить уровень скила сюда посылать ID ВНИМАНИЕ 1,2,3 !!!
    {
        if (unlockedAb[IDSKILL - 1] == false)
            return;
        else
        {
            if (_level > 0)
            {
                levelAb[IDSKILL - 1]++;
                _level--;
            }
        }
    }
    public void UnlockAbility(int IDSKILL)  //разблокировать заблокированное... сюда посылать ID ВНИМАНИЕ 1,2,3 !!!
    {
        if (unlockedAb[IDSKILL - 1] == false)
        {
            unlockedAb[IDSKILL - 1] = true;
            lvlmng.lvlForUnblockSkills--;
            lvlmng.lvlForSkills--;
        }
            UnblockButton1.SetActive(false);
            UnblockButton2.SetActive(false);
            UnblockButton3.SetActive(false);
    }
    void Update()
    {
        if (lvlmng.lvlForUnblockSkills != 0)
        {
            if (unlockedAb[0] !=  true)
                UnblockButton1.SetActive(true);
            if (unlockedAb[1] != true)
                UnblockButton2.SetActive(true);
            if (unlockedAb[2] != true)
                UnblockButton3.SetActive(true);
        }
        if (unlockedAb[0] == true)
            Skill1.interactable = true;
        if (unlockedAb[1] == true)
            Skill2.interactable = true;
        if (unlockedAb[2] == true)
            Skill3.interactable = true;
        if ( (lvlmng.lvlForSkills != 0) && (unlockedAb[0] == true) )
            LvlUpSkill1.SetActive(true);
        else
            LvlUpSkill1.SetActive(false);
        if ( (lvlmng.lvlForSkills != 0) && (unlockedAb[1] == true) )
            LvlUpSkill2.SetActive(true);
        else
            LvlUpSkill2.SetActive(false);
        if ( (lvlmng.lvlForSkills != 0) && (unlockedAb[2] == true) )
            LvlUpSkill3.SetActive(true);
        else
            LvlUpSkill3.SetActive(false);
    }
    public void SaveChanges() //сохранялка
    {
        //из переменных записать всё в объект класса и отправить/записать/ну хоть что-то сделать с этим....
        Debug.Log("ТИпо тут на сервак отправилось или что-то в этом роде... А пока 404. Will be added soon :)"); // СДЕЛАТЬ СОХРАНЯЛКУ!!!
    }

}
