using UnityEngine;
using UnityEngine.UI;

public class GoldDontDestroy : MonoBehaviour
{
  public static int gold;
  public Text goldBanked;
  public Image mask;
  float healthOriginalSize;
  public Image strengthMask;
  float strengthOriginalSize;
  public Image defenseMask;
  float defenseOriginalSize;

  public GameObject healthBar;
  public GameObject strengthBar;
  public GameObject defenseBar;
  public GameObject AndroidControls;

  private void Start()
  {
    this.goldBanked.text = "Gold: 0";
    this.healthOriginalSize = this.mask.rectTransform.rect.width;
    this.strengthOriginalSize = 88;
    this.defenseOriginalSize = 88;
    this.strengthBar.SetActive(false);
    this.defenseBar.SetActive(false);
    this.healthBar.SetActive(false);
  }

  /// <summary>
  /// Ensures there is only one gameobject in existence.
  /// </summary>
  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("GoldCanvas");
    if (objs.Length > 1)
    {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }

  /// <summary>
  /// Switches between masks and sets the value to be filled.
  /// </summary>
  /// <param name="whichMask"></param>
  /// <param name="value"></param>
  public void SetValue(string whichMask, float value)
  {
    switch (whichMask)
    {
      case "HP":
        this.mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.healthOriginalSize * value);
        break;
      case "Strength":
        this.strengthMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.strengthOriginalSize * value);
        break;
      case "Defense":
        this.defenseMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.defenseOriginalSize * value);
        break;
      default:
        break;
    }
  }

  /// <summary>
  /// Changes the amount of gold in inventory, and displays that number.
  /// </summary>
  /// <param name="num"></param>
  public void ChangeGoldDisplay(int num)
  {
    gold += num;
    this.goldBanked.text = "Gold: " + gold;
  }

  /// <summary>
  /// Saves the value of gold.
  /// </summary>
  public void SaveValues()
  {
    SaveSystem.SetInt("Gold", gold);
  }
}
