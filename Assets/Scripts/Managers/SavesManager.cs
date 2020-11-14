using UnityEngine;

public class SavesManager : MonoBehaviour
{
  UpgradesManager upgrades;
  PlayerScript player;
  GoldDontDestroy goldReference;
  AssetManager assets;

  private void Start()
  {
    this.upgrades = GameObject.Find("UpgradesManager").GetComponent<UpgradesManager>();
    this.player = GameObject.Find("Player").GetComponent<PlayerScript>();
    this.goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();
    this.assets = GameObject.Find("AssetManager").GetComponent<AssetManager>();
  }

  /// <summary>
  /// Saves details in save file one.
  /// </summary>
  public void save1()
  {
    Debug.Log("Saved Save 1");
    SaveSystem.ReInitialize("Save1.bin");
    this.upgrades.SaveValues();
    SaveSystem.SetInt("Gold", GoldDontDestroy.gold);
    this.player.SaveValues();
    SaveSystem.SaveToDisk();
    this.assets.MenuClose();
  }

  /// <summary>
  /// Loads values from save file 1.
  /// </summary>
  public void load1()
  {
    SaveSystem.ReInitialize("Save1.bin");
    this.upgrades.LoadValues();
    this.goldReference.ChangeGoldDisplay(GoldDontDestroy.gold * -1);
    this.goldReference.ChangeGoldDisplay(SaveSystem.GetInt("Gold"));
    this.player.LoadValues();
    this.assets.MenuClose();
  }

  /// <summary>
  /// saves details in save file 2.
  /// </summary>
  public void save2()
  {
    Debug.Log("Saved Save 1");
    SaveSystem.ReInitialize("Save2.bin");
    this.upgrades.SaveValues();
    SaveSystem.SetInt("Gold", GoldDontDestroy.gold);
    this.player.SaveValues();
    SaveSystem.SaveToDisk();
    this.assets.MenuClose();
  }

  /// <summary>
  /// loads values from save file 2.
  /// </summary>
  public void load2()
  {
    SaveSystem.ReInitialize("Save2.bin");
    this.upgrades.LoadValues();
    this.goldReference.ChangeGoldDisplay(GoldDontDestroy.gold * -1);
    this.goldReference.ChangeGoldDisplay(SaveSystem.GetInt("Gold"));
    this.player.LoadValues();
    this.assets.MenuClose();
  }

  /// <summary>
  /// saves details in save file 3.
  /// </summary>
  public void save3()
  {
    Debug.Log("Saved Save 1");
    SaveSystem.ReInitialize("Save3.bin");
    this.upgrades.SaveValues();
    SaveSystem.SetInt("Gold", GoldDontDestroy.gold);
    this.player.SaveValues();
    SaveSystem.SaveToDisk();
    this.assets.MenuClose();
  }

  /// <summary>
  /// loads values from save file 3.
  /// </summary>
  public void load3()
  {
    SaveSystem.ReInitialize("Save3.bin");
    this.upgrades.LoadValues();
    this.goldReference.ChangeGoldDisplay(GoldDontDestroy.gold * -1);
    this.goldReference.ChangeGoldDisplay(SaveSystem.GetInt("Gold"));
    this.player.LoadValues();
    this.assets.MenuClose();
  }

}
