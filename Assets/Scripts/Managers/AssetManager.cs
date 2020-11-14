using UnityEngine;
using UnityEngine.SceneManagement;

public class AssetManager : MonoBehaviour
{
  private static AssetManager _instance;
  public static AssetManager Instance
  {
    get
    {
      if (_instance == null)
      {
        Debug.LogError("Asset Manager is NULL.");
      }
      return _instance;
    }
  }

  private GameObject player;
  private Canvas inventoryCanvas;
  private Canvas upgradesCanvas;
  private Canvas goldCanvas;
  private Canvas exitScreen;
  private SpriteRenderer playerSprite;
  private PlayerScript playerScript;
  private Inventory inventoryScript;
  private UpgradesManager upgrades;
  private GoldDontDestroy _goldReference;
  private LoadingDontDestroy load;

  public bool hasStaff;
  public bool menuOpen;

  public GameObject[] sounds;

  private void Start()
  {
    this.player = GameObject.Find("Player");
    this.inventoryScript = this.player.GetComponent<Inventory>();
    this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    this.playerScript = this.player.GetComponent<PlayerScript>();
    this.inventoryCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
    this.upgradesCanvas = GameObject.Find("UpgradesManager").GetComponent<Canvas>();
    this.goldCanvas = GameObject.Find("Gold Canvas").GetComponent<Canvas>();
    this.exitScreen = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();
    this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();
    this.playerSprite.enabled = false;
    this.inventoryCanvas.enabled = false;
    this.upgradesCanvas.enabled = false;
    this.exitScreen.enabled = false;
    this.hasStaff = false;
    this.menuOpen = false;
  }

  /// <summary>
  /// self-reference
  /// </summary>
  private void Awake()
  {
    _instance = this;
  }

  /// <summary>
  /// calls the method to move in Android
  /// </summary>
  public void moveUp()
  {
    this.playerScript.AndroidMoveUp();
  }

  /// <summary>
  /// calls the method to move in Android
  /// </summary>
  public void moveDown()
  {
    this.playerScript.AndroidMoveDown();
  }

  /// <summary>
  /// calls the method to move in Android
  /// </summary>
  public void moveRight()
  {
    this.playerScript.AndroidMoveRight();
  }

  /// <summary>
  /// calls the method to move in Android
  /// </summary>
  public void moveLeft()
  {
    this.playerScript.AndroidMoveLeft();
  }

/// <summary>
/// Open and closes the menu.
/// </summary>
  public void MenuAccess()
  {
    this.exitScreen = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
    if (this.menuOpen == true)
    {
      this.exitScreen.enabled = false;
      this.menuOpen = false;
    }
    else
    {
      this.exitScreen.enabled = true;
      this.menuOpen = true;
    }
  }

  /// <summary>
  /// Closes the menu screen.
  /// </summary>
  public void MenuClose()
  {
    this.exitScreen = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
    this.exitScreen.enabled = false;
    this.menuOpen = false;
  }

  /// <summary>
  /// Loads the home screen, and turns off all other game objects.
  /// </summary>
  public void MainMenu()
  {
    SceneManager.LoadScene("HomeScreen");
    this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();
    this.load.GetGoing();

    this.player = GameObject.Find("Player");
    this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    this.inventoryCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
    this.upgradesCanvas = GameObject.Find("UpgradesManager").GetComponent<Canvas>();

    this.playerSprite.enabled = false;
    this.inventoryCanvas.enabled = false;
    this.upgradesCanvas.enabled = false;
  }

  /// <summary>
  /// returns player to max health, and set player at the beginning
  /// of the dungeon.
  /// </summary>
  public void Restart()
  {
    this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();
    this.load.GetGoing();

    this.player = GameObject.Find("Player");
    this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    this.playerScript = this.player.GetComponent<PlayerScript>();
    this.inventoryCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
    this.upgradesCanvas = GameObject.Find("UpgradesManager").GetComponent<Canvas>();
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();

    this.playerSprite.enabled = true;
    this.playerScript.ChangeHealth(this.playerScript.maxHealth);
    this.inventoryCanvas.enabled = true;
    this.upgradesCanvas.enabled = false;
    this._goldReference.healthBar.SetActive(true);
    this._goldReference.AndroidControls.SetActive(true);

    SceneManager.LoadScene("Dungeon");
  }

  /// <summary>
  /// turns off player sprite, inventory canvas, and upgrades canvas
  /// in preparation for moving to the upgrades screen.
  /// </summary>
  public void Upgrades()
  {

    this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();
    this.load.GetGoing();

    this.player = GameObject.Find("Player");
    this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    this.inventoryCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
    this.upgradesCanvas = GameObject.Find("UpgradesManager").GetComponent<Canvas>();

    this.playerSprite.enabled = false;
    this.inventoryCanvas.enabled = false;
    this.upgradesCanvas.enabled = true;

    SceneManager.LoadScene("Upgrades");
  }

  /// <summary>
  /// handles the sound of losing the game.  Also clears out all inventory,
  /// and closes any other canvases in order to display the game over screen
  /// correctly.
  /// </summary>
  public void GameOver()
  {
    SceneManager.LoadScene("GameOver");

    this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();
    this.load.GetGoing();

    this.player = GameObject.Find("Player");
    this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    this.inventoryScript = this.player.GetComponent<Inventory>();
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();
    this.inventoryCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
    this.upgradesCanvas = GameObject.Find("UpgradesManager").GetComponent<Canvas>();
    this.playerScript = this.player.GetComponent<PlayerScript>();
    this.playerScript.PlayLoseSound();


    this.playerSprite.enabled = false;

    for (int i = 0; i < this.inventoryScript.slots.Length; i++)
    {
      if (this.inventoryScript.isfull[i] == true)
      {
        this.inventoryScript.isfull[i] = false;
        foreach (Transform child in this.inventoryScript.slots[i].transform)
        {
          Destroy(child.gameObject);
        }
      }
    }

    this.inventoryCanvas.enabled = false;
    this.upgradesCanvas.enabled = false;
    this._goldReference.AndroidControls.SetActive(false);
  }

  /// <summary>
  /// loads the winning scene and plays the winning sound.
  /// closes all canvases and game objects.
  /// </summary>
  public void Win()
  {
    SceneManager.LoadScene("Win");

    this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();
    this.load.GetGoing();

    this.hasStaff = false;

    this.player = GameObject.Find("Player");
    this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    this.playerScript = this.player.GetComponent<PlayerScript>();
    this.playerScript.PlayWinSound();
    this.inventoryCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
    this.upgradesCanvas = GameObject.Find("UpgradesManager").GetComponent<Canvas>();
    this.goldCanvas = GameObject.Find("Gold Canvas").GetComponent<Canvas>();

    this.playerSprite.enabled = false;
    this.inventoryCanvas.enabled = false;
    this.upgradesCanvas.enabled = false;
    this.goldCanvas.enabled = false;
  }

  /// <summary>
  /// resets all stats to original values.
  /// </summary>
  public void ResetAllStats()
  {
    this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();
    this.load.GetGoing();

    this.upgrades = GameObject.Find("UpgradesManager").GetComponent<UpgradesManager>();
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();

    this.playerScript.maxHealth = 30;
    this.playerScript.attackLow = 3;
    this.playerScript.attackHigh = 5;
    this.playerScript.defensePercent = .9f;
    this.playerScript.defenseRaw = 0;
    this.playerScript.defensePotion = 2;
    this.playerScript.attackPotion = 2;
    this.playerScript.breadHeal = 15;
    this.playerScript.appleHeal = 5;
    this.playerScript.potionDuration = 30;
    this.playerScript.appleDefense = 0;
    this.upgrades.ResetValues();
    this._goldReference.ChangeGoldDisplay(GoldDontDestroy.gold * -1);
    this._goldReference.SetValue("HP", 1);

    SceneManager.LoadScene("HomeScreen");

    this.player = GameObject.Find("Player");
    this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    this.inventoryCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
    this.upgradesCanvas = GameObject.Find("UpgradesManager").GetComponent<Canvas>();
    this.goldCanvas = GameObject.Find("Gold Canvas").GetComponent<Canvas>();

    this.playerSprite.enabled = false;
    this.inventoryCanvas.enabled = false;
    this.upgradesCanvas.enabled = false;
    this.goldCanvas.enabled = true;
  }

  /// <summary>
  /// Exits the game.
  /// </summary>
  public void Exit()
  {
    Debug.Log("Pressed the EXIT button.");
    Application.Quit();
  }

  /// <summary>
  /// Destroys residual sound objects if there are more than 8 in memory.
  /// This build-up is to prevent sound objects being destroyed
  /// before they have played completely.
  /// </summary>
  private void LateUpdate()
  {
    this.sounds = GameObject.FindGameObjectsWithTag("Sound");
    if (this.sounds.Length > 8)
    {
      for (int i = 0; i < this.sounds.Length - 6; i++)
      {
        Destroy(this.sounds[i]);
      }
    }
  }
}
