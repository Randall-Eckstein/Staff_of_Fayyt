using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("Upgrades");
    if (objs.Length > 1)
    {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }

  public Text healthGold;
  public Text healthInfo;
  public Text attackGold;
  public Text attackInfo;
  public Text defenseGold;
  public Text defenseInfo;
  public Text breadGold;
  public Text breadInfo;
  public Text attackPotionGold;
  public Text attackPotionInfo;
  public Text defensePotionGold;
  public Text defensePotionInfo;
  public Text potionDurationGold;
  public Text potionDurationInfo;
  public Text appleGold;
  public Text appleInfo;

  private PlayerScript _playerReference;
  private GoldDontDestroy _goldReference;

  private int healthCounter = 0;
  private int attackCounter = 0;
  private int defenseCounter = 0;
  private int breadCounter = 0;
  private int appleCounter = 0;
  private int attackPotionCounter = 0;
  private int defensePotionCounter = 0;
  private int potionDurationCounter = 0;

  private void Start()
  {
    this._playerReference = GameObject.Find("Player").GetComponent<PlayerScript>();
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();
  }

  /// <summary>
  /// returns upgrade values to original values.
  /// </summary>
  public void ResetValues()
  {
    this.healthCounter = 0;
    this.attackCounter = 0;
    this.defenseCounter = 0;
    this.breadCounter = 0;
    this.appleCounter = 0;
    this.attackPotionCounter = 0;
    this.defensePotionCounter = 0;
    this.potionDurationCounter = 0;
    this.healthGold.text = "50 Gold";
    this.healthInfo.text = "30 => 35";
    this.attackGold.text = "30 Gold";
    this.attackInfo.text = "3 - 5 dmg\nto\n4 - 6 dmg";
    this.defenseGold.text = "150 Gold";
    this.defenseInfo.text = "10% => 20%";
    this.breadGold.text = "50 Gold";
    this.breadInfo.text = "Restore\n15 => 20 hp";
    this.appleGold.text = "50 Gold";
    this.appleInfo.text = "5 hp / +1 def\nto\n5 hp / +2 def";
    this.attackPotionGold.text = "100 Gold";
    this.attackPotionInfo.text = "+2 => +3 atk";
    this.defensePotionGold.text = "100 Gold";
    this.defensePotionInfo.text = "+2 => +3 def";
    this.potionDurationGold.text = "300 Gold";
    this.potionDurationInfo.text = "30 sec =>\n45 sec";
  }

  /// <summary>
  /// Controls the amount of health a player has, ensures player has
  /// sufficient gold, and removes gold from player inventory.
  /// </summary>
  public void Health()
  {
    switch (this.healthCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 50)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-50);
          this._playerReference.maxHealth = 35;
          this.healthGold.text = "100 Gold";
          this.healthInfo.text = "35 => 40";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 100)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-100);
          this._playerReference.maxHealth = 40;
          this.healthGold.text = "150 Gold";
          this.healthInfo.text = "40 => 45";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 150)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-100);
          this._playerReference.maxHealth = 45;
          this.healthGold.text = "200 Gold";
          this.healthInfo.text = "45 => 50";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 200)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-200);
          this._playerReference.maxHealth = 50;
          this.healthGold.text = "300 Gold";
          this.healthInfo.text = "50 => 55";
        }
        break;

      case 4:
        if (GoldDontDestroy.gold >= 300)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-300);
          this._playerReference.maxHealth = 55;
          this.healthGold.text = "400 Gold";
          this.healthInfo.text = "55 => 70";
        }
        break;

      case 5:
        if (GoldDontDestroy.gold >= 400)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-400);
          this._playerReference.maxHealth = 70;
          this.healthGold.text = "500 Gold";
          this.healthInfo.text = "70 => 85";
        }
        break;

      case 6:
        if (GoldDontDestroy.gold >= 500)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-500);
          this._playerReference.maxHealth = 85;
          this.healthGold.text = "600 Gold";
          this.healthInfo.text = "85 => 100";
        }
        break;

      case 7:
        if (GoldDontDestroy.gold >= 600)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-600);
          this._playerReference.maxHealth = 100;
          this.healthGold.text = "800 Gold";
          this.healthInfo.text = "100 => 125";
        }
        break;

      case 8:
        if (GoldDontDestroy.gold >= 800)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-800);
          this._playerReference.maxHealth = 125;
          this.healthGold.text = "1000 Gold";
          this.healthInfo.text = "125 => 150";
        }
        break;

      case 9:
        if (GoldDontDestroy.gold >= 1000)
        {
          this.healthCounter++;
          this._goldReference.ChangeGoldDisplay(-1000);
          this._playerReference.maxHealth = 150;
          this.healthGold.text = "Maxed";
          this.healthInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Controls the amount of damage a player can do, ensures player has
  /// sufficient gold, and removes gold from player inventory.
  /// </summary>
  public void Attack()
  {
    switch (this.attackCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 30)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-30);
          this._playerReference.attackLow = 4;
          this._playerReference.attackHigh = 6;
          this.attackGold.text = "60 Gold";
          this.attackInfo.text = "4 - 6 dmg\nto\n5 - 7 dmg";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 60)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-60);
          this._playerReference.attackLow = 5;
          this._playerReference.attackHigh = 7;
          this.attackGold.text = "90 Gold";
          this.attackInfo.text = "5 - 7 dmg\nto\n6 - 8 dmg";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 90)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-90);
          this._playerReference.attackLow = 6;
          this._playerReference.attackHigh = 8;
          this.attackGold.text = "120 Gold";
          this.attackInfo.text = "6 - 8 dmg\nto\n7 - 10 dmg";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 120)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-120);
          this._playerReference.attackLow = 7;
          this._playerReference.attackHigh = 10;
          this.attackGold.text = "150 Gold";
          this.attackInfo.text = "7 - 10 dmg\nto\n8 - 11 dmg";
        }
        break;

      case 4:
        if (GoldDontDestroy.gold >= 150)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-150);
          this._playerReference.attackLow = 8;
          this._playerReference.attackHigh = 11;
          this.attackGold.text = "200 Gold";
          this.attackInfo.text = "8 - 11 dmg\nto\n9 - 12 dmg";
        }
        break;

      case 5:
        if (GoldDontDestroy.gold >= 200)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-200);
          this._playerReference.attackLow = 9;
          this._playerReference.attackHigh = 12;
          this.attackGold.text = "300 Gold";
          this.attackInfo.text = "9 - 12 dmg\nto\n10 - 15 dmg";
        }
        break;

      case 6:
        if (GoldDontDestroy.gold >= 300)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-300);
          this._playerReference.attackLow = 10;
          this._playerReference.attackHigh = 15;
          this.attackGold.text = "400 Gold";
          this.attackInfo.text = "10 - 15 dmg\nto\n12 - 18 dmg";
        }
        break;

      case 7:
        if (GoldDontDestroy.gold >= 400)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-400);
          this._playerReference.attackLow = 12;
          this._playerReference.attackHigh = 18;
          this.attackGold.text = "600 Gold";
          this.attackInfo.text = "12 - 18 dmg\nto\n14 - 20 dmg";
        }
        break;

      case 8:
        if (GoldDontDestroy.gold >= 600)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-600);
          this._playerReference.attackLow = 14;
          this._playerReference.attackHigh = 20;
          this.attackGold.text = "1000 Gold";
          this.attackInfo.text = "14 - 20 dmg\nto\n16 - 24 dmg";
        }
        break;

      case 9:
        if (GoldDontDestroy.gold >= 1000)
        {
          this.attackCounter++;
          this._goldReference.ChangeGoldDisplay(-1000);
          this._playerReference.attackLow = 16;
          this._playerReference.attackHigh = 24;
          this.attackGold.text = "Maxed";
          this.attackInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Controls the defense a player has, ensures player has
  /// sufficient gold, and removes gold from player inventory.
  /// </summary>
  public void Defense()
  {
    switch (this.defenseCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 150)
        {
          this.defenseCounter++;
          this._goldReference.ChangeGoldDisplay(-150);
          this._playerReference.defensePercent = 0.8f;
          this.defenseGold.text = "300 Gold";
          this.defenseInfo.text = "20% => 30%";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 300)
        {
          this.defenseCounter++;
          this._goldReference.ChangeGoldDisplay(-300);
          this._playerReference.defensePercent = 0.7f;
          this.defenseGold.text = "1000 Gold";
          this.defenseInfo.text = "30% => 40%";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 1000)
        {
          this.defenseCounter++;
          this._goldReference.ChangeGoldDisplay(-1000);
          this._playerReference.defensePercent = 0.6f;
          this.defenseGold.text = "4000 Gold";
          this.defenseInfo.text = "40% => 50%";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 4000)
        {
          this.defenseCounter++;
          this._goldReference.ChangeGoldDisplay(-4000);
          this._playerReference.defensePercent = 0.5f;
          this.defenseGold.text = "Maxed";
          this.defenseInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Controls the amount of health bread can give, ensures player has
  /// sufficient gold, and removes gold from player inventory.
  /// </summary>
  public void Bread()
  {
    switch (this.breadCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 50)
        {
          this.breadCounter++;
          this._goldReference.ChangeGoldDisplay(-50);
          this._playerReference.breadHeal = 20;
          this.breadGold.text = "150 Gold";
          this.breadInfo.text = "Restore\n20 => 25 hp";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 150)
        {
          this.breadCounter++;
          this._goldReference.ChangeGoldDisplay(-150);
          this._playerReference.breadHeal = 25;
          this.breadGold.text = "350 Gold";
          this.breadInfo.text = "Restore\n25 => 35 hp";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 350)
        {
          this.breadCounter++;
          this._goldReference.ChangeGoldDisplay(-350);
          this._playerReference.breadHeal = 35;
          this.breadGold.text = "500 Gold";
          this.breadInfo.text = "Restore\n35 => 50 hp";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 500)
        {
          this.breadCounter++;
          this._goldReference.ChangeGoldDisplay(-500);
          this._playerReference.breadHeal = 50;
          this.breadGold.text = "1000 Gold";
          this.breadInfo.text = "Restore\n50 => 75 hp";
        }
        break;

      case 4:
        if (GoldDontDestroy.gold >= 1000)
        {
          this.breadCounter++;
          this._goldReference.ChangeGoldDisplay(-1000);
          this._playerReference.breadHeal = 75;
          this.breadGold.text = "Maxed";
          this.breadInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Controls the amount of health and duration/ amount of defense an apple
  /// can give, ensures player has sufficient gold, and removes gold 
  /// from player inventory.
  /// </summary>
  public void Apple()
  {
    switch (this.appleCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 50)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-50);
          this._playerReference.appleHeal = 5;
          this._playerReference.appleDefense = 2;
          this.appleGold.text = "100 Gold";
          this.appleInfo.text = "5 hp / +2 def\nto\n10 hp / +1 def";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 100)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-100);
          this._playerReference.appleHeal = 10;
          this._playerReference.appleDefense = 1;
          this.appleGold.text = "150 Gold";
          this.appleInfo.text = "10 hp / +1 def\nto\n10 hp / +2 def";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 150)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-150);
          this._playerReference.appleHeal = 10;
          this._playerReference.appleDefense = 2;
          this.appleGold.text = "200 Gold";
          this.appleInfo.text = "10 hp / +2 def\nto\n15 hp / +1 def";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 200)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-200);
          this._playerReference.appleHeal = 15;
          this._playerReference.appleDefense = 1;
          this.appleGold.text = "250 Gold";
          this.appleInfo.text = "15 hp / +1 def\nto\n15 hp / +2 def";
        }
        break;

      case 4:
        if (GoldDontDestroy.gold >= 250)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-250);
          this._playerReference.appleHeal = 15;
          this._playerReference.appleDefense = 2;
          this.appleGold.text = "300 Gold";
          this.appleInfo.text = "15 hp / +2 def\nto\n20 hp / +1 def";
        }
        break;

      case 5:
        if (GoldDontDestroy.gold >= 300)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-300);
          this._playerReference.appleHeal = 20;
          this._playerReference.appleDefense = 1;
          this.appleGold.text = "350 Gold";
          this.appleInfo.text = "20 hp / +1 def\nto\n20 hp / +2 def";
        }
        break;

      case 6:
        if (GoldDontDestroy.gold >= 350)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-350);
          this._playerReference.appleHeal = 20;
          this._playerReference.appleDefense = 2;
          this.appleGold.text = "400 Gold";
          this.appleInfo.text = "20 hp / +2 def\nto\n25 hp / +1 def";
        }
        break;

      case 7:
        if (GoldDontDestroy.gold >= 400)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-400);
          this._playerReference.appleHeal = 25;
          this._playerReference.appleDefense = 1;
          this.appleGold.text = "450 Gold";
          this.appleInfo.text = "25 hp / +1 def\nto\n25 hp / +2 def";
        }
        break;

      case 8:
        if (GoldDontDestroy.gold >= 450)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-450);
          this._playerReference.appleHeal = 25;
          this._playerReference.appleDefense = 2;
          this.appleGold.text = "500 Gold";
          this.appleInfo.text = "25 hp / +2 def\nto\n30 hp / +2 def";
        }
        break;

      case 9:
        if (GoldDontDestroy.gold >= 500)
        {
          this.appleCounter++;
          this._goldReference.ChangeGoldDisplay(-500);
          this._playerReference.appleHeal = 30;
          this._playerReference.appleDefense = 2;
          this.appleGold.text = "Maxed";
          this.appleInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Controls the additional damage a player deals, ensures player has
  /// sufficient gold, and removes gold from player inventory.
  /// </summary>
  public void AttackPotion()
  {
    switch (this.attackPotionCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 100)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-100);
          this._playerReference.attackPotion = 3;
          this.attackPotionGold.text = "200 Gold";
          this.attackPotionInfo.text = "+3 => +4 atk";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 200)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-200);
          this._playerReference.attackPotion = 4;
          this.attackPotionGold.text = "350 Gold";
          this.attackPotionInfo.text = "+4 => +5 atk";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 350)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-350);
          this._playerReference.attackPotion = 5;
          this.attackPotionGold.text = "500 Gold";
          this.attackPotionInfo.text = "+5 => +6 atk";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 500)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-500);
          this._playerReference.attackPotion = 6;
          this.attackPotionGold.text = "700 Gold";
          this.attackPotionInfo.text = "+6 => +7 atk";
        }
        break;

      case 4:
        if (GoldDontDestroy.gold >= 700)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-700);
          this._playerReference.attackPotion = 7;
          this.attackPotionGold.text = "900 Gold";
          this.attackPotionInfo.text = "+7 => +8 atk";
        }
        break;

      case 5:
        if (GoldDontDestroy.gold >= 900)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-900);
          this._playerReference.attackPotion = 8;
          this.attackPotionGold.text = "1200 Gold";
          this.attackPotionInfo.text = "+8 => +9 atk";
        }
        break;

      case 6:
        if (GoldDontDestroy.gold >= 1200)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-1200);
          this._playerReference.attackPotion = 9;
          this.attackPotionGold.text = "1500 Gold";
          this.attackPotionInfo.text = "+9 => +10 atk";
        }
        break;

      case 7:
        if (GoldDontDestroy.gold >= 1500)
        {
          this.attackPotionCounter++;
          this._goldReference.ChangeGoldDisplay(-1500);
          this._playerReference.attackPotion = 10;
          this.attackPotionGold.text = "Maxed";
          this.attackPotionInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Controls the additional damage a player can handle, ensures player has
  /// sufficient gold, and removes gold from player inventory.
  /// </summary>
  public void DefensePotion()
  {
    switch (this.defensePotionCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 100)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-100);
          this._playerReference.defensePotion = 3;
          this.defensePotionGold.text = "200 Gold";
          this.defensePotionInfo.text = "+3 => +4 def";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 200)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-200);
          this._playerReference.defensePotion = 4;
          this.defensePotionGold.text = "350 Gold";
          this.defensePotionInfo.text = "+4 => +5 def";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 350)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-350);
          this._playerReference.defensePotion = 5;
          this.defensePotionGold.text = "500 Gold";
          this.defensePotionInfo.text = "+5 => +6 def";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 500)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-500);
          this._playerReference.defensePotion = 6;
          this.defensePotionGold.text = "700 Gold";
          this.defensePotionInfo.text = "+6 => +7 def";
        }
        break;

      case 4:
        if (GoldDontDestroy.gold >= 700)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-700);
          this._playerReference.defensePotion = 7;
          this.defensePotionGold.text = "900 Gold";
          this.defensePotionInfo.text = "+7 => +8 def";
        }
        break;

      case 5:
        if (GoldDontDestroy.gold >= 900)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-900);
          this._playerReference.defensePotion = 8;
          this.defensePotionGold.text = "1200 Gold";
          this.defensePotionInfo.text = "+8 => +9 def";
        }
        break;

      case 6:
        if (GoldDontDestroy.gold >= 1200)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-1200);
          this._playerReference.defensePotion = 9;
          this.defensePotionGold.text = "1500 Gold";
          this.defensePotionInfo.text = "+9 => +10 def";
        }
        break;

      case 7:
        if (GoldDontDestroy.gold >= 1500)
        {
          this.defensePotionCounter++;
          this._goldReference.ChangeGoldDisplay(-1500);
          this._playerReference.defensePotion = 10;
          this.defensePotionGold.text = "Maxed";
          this.defensePotionInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Controls the duration of potion efficacy, ensures player has
  /// sufficient gold, and removes gold from player inventory.
  /// </summary>
  public void PotionDuration()
  {
    switch (this.potionDurationCounter)
    {
      case 0:
        if (GoldDontDestroy.gold >= 300)
        {
          this.potionDurationCounter++;
          this._goldReference.ChangeGoldDisplay(-300);
          this._playerReference.potionDuration = 45;
          this.potionDurationGold.text = "600 Gold";
          this.potionDurationInfo.text = "45 sec =>\n60 sec";
        }
        break;

      case 1:
        if (GoldDontDestroy.gold >= 600)
        {
          this.potionDurationCounter++;
          this._goldReference.ChangeGoldDisplay(-600);
          this._playerReference.potionDuration = 60;
          this.potionDurationGold.text = "1000 Gold";
          this.potionDurationInfo.text = "60 sec =>\n75 sec";
        }
        break;

      case 2:
        if (GoldDontDestroy.gold >= 1000)
        {
          this.potionDurationCounter++;
          this._goldReference.ChangeGoldDisplay(-1000);
          this._playerReference.potionDuration = 75;
          this.potionDurationGold.text = "2000 Gold";
          this.potionDurationInfo.text = "75 sec =>\n90 sec";
        }
        break;

      case 3:
        if (GoldDontDestroy.gold >= 2000)
        {
          this.potionDurationCounter++;
          this._goldReference.ChangeGoldDisplay(-2000);
          this._playerReference.potionDuration = 90;
          this.potionDurationGold.text = "4000 Gold";
          this.potionDurationInfo.text = "90 sec =>\n105 sec";
        }
        break;

      case 4:
        if (GoldDontDestroy.gold >= 4000)
        {
          this.potionDurationCounter++;
          this._goldReference.ChangeGoldDisplay(-4000);
          this._playerReference.potionDuration = 105;
          this.potionDurationGold.text = "8000 Gold";
          this.potionDurationInfo.text = "105 sec =>\n120 sec";
        }
        break;

      case 5:
        if (GoldDontDestroy.gold >= 8000)
        {
          this.potionDurationCounter++;
          this._goldReference.ChangeGoldDisplay(-8000);
          this._playerReference.potionDuration = 120;
          this.potionDurationGold.text = "Maxed";
          this.potionDurationInfo.text = "";
        }
        break;

      default:
        break;
    }
  }

  /// <summary>
  /// Uses the save system to record the upgrade values.
  /// </summary>
  public void SaveValues()
  {
    SaveSystem.SetInt("healthCounter", this.healthCounter);
    SaveSystem.SetInt("attackCounter", this.attackCounter);
    SaveSystem.SetInt("defenseCounter", this.defenseCounter);
    SaveSystem.SetInt("breadCounter", this.breadCounter);
    SaveSystem.SetInt("appleCounter", this.appleCounter);
    SaveSystem.SetInt("attackPotionCounter", this.attackPotionCounter);
    SaveSystem.SetInt("defensePotionCounter", this.defensePotionCounter);
    SaveSystem.SetInt("potionDurationCounter", this.potionDurationCounter);
    SaveSystem.SetString("healthGold", this.healthGold.text);
    SaveSystem.SetString("healthInfo", this.healthInfo.text);
    SaveSystem.SetString("attackGold", this.attackGold.text);
    SaveSystem.SetString("attackInfo", this.attackInfo.text);
    SaveSystem.SetString("defenseGold", this.defenseGold.text);
    SaveSystem.SetString("defenseInfo", this.defenseInfo.text);
    SaveSystem.SetString("breadGold", this.breadGold.text);
    SaveSystem.SetString("breadInfo", this.breadInfo.text);
    SaveSystem.SetString("appleGold", this.appleGold.text);
    SaveSystem.SetString("appleInfo", this.appleInfo.text);
    SaveSystem.SetString("attackPotionGold", this.attackPotionGold.text);
    SaveSystem.SetString("attackPotionInfo", this.attackPotionInfo.text);
    SaveSystem.SetString("defensePotionGold", this.defensePotionGold.text);
    SaveSystem.SetString("defensePotionInfo", this.defensePotionInfo.text);
    SaveSystem.SetString("potionDurationGold", this.potionDurationGold.text);
    SaveSystem.SetString("potionDurationInfo", this.potionDurationInfo.text);
  }

  /// <summary>
  /// uses the save system to return the upgrade values
  /// </summary>
  public void LoadValues()
  {
    this.healthCounter = SaveSystem.GetInt("healthCounter");
    this.attackCounter = SaveSystem.GetInt("attackCounter");
    this.defenseCounter = SaveSystem.GetInt("defenseCounter");
    this.breadCounter = SaveSystem.GetInt("breadCounter");
    this.appleCounter = SaveSystem.GetInt("appleCounter");
    this.attackPotionCounter = SaveSystem.GetInt("attackPotionCounter");
    this.defensePotionCounter = SaveSystem.GetInt("defensePotionCounter");
    this.potionDurationCounter = SaveSystem.GetInt("potionDurationCounter");
    this.healthGold.text = SaveSystem.GetString("healthGold");
    this.healthInfo.text = SaveSystem.GetString("healthInfo");
    this.attackGold.text = SaveSystem.GetString("attackGold");
    this.attackInfo.text = SaveSystem.GetString("attackInfo");
    this.defenseGold.text = SaveSystem.GetString("defenseGold");
    this.defenseInfo.text = SaveSystem.GetString("defenseInfo");
    this.breadGold.text = SaveSystem.GetString("breadGold");
    this.breadInfo.text = SaveSystem.GetString("breadInfo");
    this.appleGold.text = SaveSystem.GetString("appleGold");
    this.appleInfo.text = SaveSystem.GetString("appleInfo");
    this.attackPotionGold.text = SaveSystem.GetString("attackPotionGold");
    this.attackPotionInfo.text = SaveSystem.GetString("attackPotionInfo");
    this.defensePotionGold.text = SaveSystem.GetString("defensePotionGold");
    this.defensePotionInfo.text = SaveSystem.GetString("defensePotionInfo");
    this.potionDurationGold.text = SaveSystem.GetString("potionDurationGold");
    this.potionDurationInfo.text = SaveSystem.GetString("potionDurationInfo");
  }
}