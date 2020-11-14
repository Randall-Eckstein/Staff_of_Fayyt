using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  public int maxHealth = 30;
  public int attackLow;
  public int attackHigh;
  public float defensePercent;
  public int defenseRaw;
  public int defensePotion;
  public int attackPotion;

  public int potionDuration;

  public int breadHeal;
  public int appleHeal;
  public int appleDefense;
  public bool moved;

  public int health { get { return this.currentHealth; } }
  int currentHealth;

  Rigidbody2D rigidbody2d;
  public GameObject defenseGlow;
  public GameObject strengthGlow;

  [SerializeField]
  private int healthNow;
  private GoldDontDestroy _goldReference;
  private AssetManager _assetManagerReference;

  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
    if (objs.Length > 1)
    {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }

  private void Start()
  {
    this.rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
    this.defenseGlow.SetActive(false);
    this.strengthGlow.SetActive(false);
    this.currentHealth = this.maxHealth;
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();
    this._goldReference.healthBar.SetActive(false);
    this._goldReference.AndroidControls.SetActive(false);
    this._goldReference.SetValue("HP", 1);
    this._assetManagerReference = GameObject.Find("AssetManager").GetComponent<AssetManager>();
    this.defensePercent = 0.9f;
    this.defenseRaw = 0;
    this.defensePotion = 2;
    this.attackPotion = 2;
    this.breadHeal = 15;
    this.appleHeal = 5;
    this.potionDuration = 30;
    this.appleDefense = 0;
    this.attackLow = 3;
    this.attackHigh = 5;
    this.moved = false;
  }

  private void Update()
  {
    this.healthNow = this.health;
    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
    {
      this.AndroidMoveLeft();
      this.moved = true;
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
    {
      this.AndroidMoveRight();
      this.moved = true;
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
    {
      this.AndroidMoveUp();
      this.moved = true;
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
    {
      this.AndroidMoveDown();
      this.moved = true;
    }
    else if (Input.GetKeyDown(KeyCode.Escape))
    {
      this._assetManagerReference.MenuAccess();
    }
  }

  /// <summary>
  /// Change the players health either up or down.
  /// </summary>
  /// <param name="amount"></param>
  public void ChangeHealth(int amount)
  {
    this._goldReference.healthBar.SetActive(true);
    this.currentHealth = Mathf.Clamp(this.currentHealth + amount, 0, this.maxHealth);
    this._goldReference.SetValue("HP", this.currentHealth / (float)this.maxHealth);
    if (this.currentHealth == 0)
    {
      this._goldReference.healthBar.SetActive(false);
      this.defenseGlow.SetActive(false);
      this.strengthGlow.SetActive(false);
      this._goldReference.defenseBar.SetActive(false);
      this._goldReference.strengthBar.SetActive(false);
      this._assetManagerReference.GameOver();
    }
  }

  /// <summary>
  /// Plays a sound, and calculates a random number based on current upgrades.
  /// </summary>
  /// <returns>damage amount</returns>
  public int DoDamage()
  {
    SoundManager.PlaySound(SoundManager.Sound.hit);
    int rand = Random.Range(this.attackLow, this.attackHigh + 1);
    return rand;
  }

  /// <summary>
  /// Changes the native defense based on current upgrades.
  /// Manipulates the amount of defense increase, and the duration.
  /// </summary>
  /// <param name="length"></param>
  /// <param name="howMuch"></param>
  public void ChangeDefense(int length, int howMuch)
  {
    this.StartCoroutine(this.DefenseChange(length, howMuch));
  }

  /// <summary>
  /// Changes the native strength based on current upgrades.
  /// Manipulates the amount of strength increase and the duration.
  /// </summary>
  /// <param name="duration"></param>
  /// <param name="howHigh"></param>
  public void ChangeStrength(int duration, int howHigh)
  {
    this.StartCoroutine(this.StrengthChange(duration, howHigh));
  }

  /// <summary>
  /// Initiates defense glow, and cancels it at the end of the co-routine.
  /// Coroutine to count down the time of the defense change.
  /// Sends the call to reduce the HUD during change.
  /// </summary>
  /// <param name="howLong"></param>
  /// <param name="howMuch"></param>
  /// <returns></returns>
  IEnumerator DefenseChange(int howLong, int howMuch)
  {
    this.defenseRaw += howMuch;
    this.defenseGlow.SetActive(true);
    this._goldReference.defenseBar.SetActive(true);
    for (int i = howLong; i >= 0; i--)
    {
      this._goldReference.SetValue("Defense", i / (float)this.potionDuration);
      yield return new WaitForSecondsRealtime(1);
    }
    this.defenseRaw -= howMuch;
    this.defenseGlow.SetActive(false);
    this._goldReference.defenseBar.SetActive(false);
  }

  /// <summary>
  /// Initiates strength glow, and cancels it at the end of the co-routine.
  /// Coroutine to count down the time of the strength change.
  /// Sends the call to reduce the HUD during change.
  /// </summary>
  /// <param name="duration"></param>
  /// <param name="howHigh"></param>
  /// <returns></returns>
  IEnumerator StrengthChange(int duration, int howHigh)
  {
    this.attackLow += howHigh;
    this.attackHigh += howHigh;
    this.strengthGlow.SetActive(true);
    this._goldReference.strengthBar.SetActive(true);
    for (int i = duration; i >= 0; i--)
    {
      this._goldReference.SetValue("Strength", i / (float)this.potionDuration);
      yield return new WaitForSecondsRealtime(1);
    }
    this.attackHigh -= howHigh;
    this.attackLow -= howHigh;
    this.strengthGlow.SetActive(false);
    this._goldReference.strengthBar.SetActive(false);
  }

  /// <summary>
  /// play a sound on winning the game.
  /// </summary>
  public void PlayWinSound()
  {
    this.StartCoroutine(this.WinSound());
  }

  /// <summary>
  /// play a sound on losing the game.
  /// </summary>
  public void PlayLoseSound()
  {
    this.StartCoroutine(this.LoseSound());
  }

  /// <summary>
  /// plays the sound after a short duration to ensure it is not cut short
  /// by a scene change.
  /// </summary>
  /// <returns></returns>
  IEnumerator LoseSound()
  {
    yield return new WaitForSeconds(0.5f);
    SoundManager.PlaySound(SoundManager.Sound.die);
  }

  /// <summary>
  /// plays the sound after a short duration to ensure it is not cut short
  /// by a scene change.
  /// </summary>
  /// <returns></returns>
  IEnumerator WinSound()
  {
    yield return new WaitForSeconds(0.5f);
    SoundManager.PlaySound(SoundManager.Sound.win);
  }

  /// <summary>
  /// Uses the save system to retain all values between game sessions.
  /// </summary>
  public void SaveValues()
  {
    SaveSystem.SetFloat("defensePercent", this.defensePercent);
    SaveSystem.SetInt("defenseRaw", this.defenseRaw);
    SaveSystem.SetInt("defensePotion", this.defensePotion);
    SaveSystem.SetInt("attackPotion", this.attackPotion);
    SaveSystem.SetInt("breadHeal", this.breadHeal);
    SaveSystem.SetInt("appleHeal", this.appleHeal);
    SaveSystem.SetInt("potionDuration", this.potionDuration);
    SaveSystem.SetInt("appleDefense", this.appleDefense);
    SaveSystem.SetInt("attackLow", this.attackLow);
    SaveSystem.SetInt("attackHigh", this.attackHigh);
    SaveSystem.SetInt("maxHealth", this.maxHealth);
  }

  /// <summary>
  /// uses the save system to load values between game sessions.
  /// </summary>
  public void LoadValues()
  {
    this.defensePercent = SaveSystem.GetFloat("defensePercent");
    this.defenseRaw = SaveSystem.GetInt("defenseRaw");
    this.defensePotion = SaveSystem.GetInt("defensePotion");
    this.attackPotion = SaveSystem.GetInt("attackPotion");
    this.breadHeal = SaveSystem.GetInt("breadHeal");
    this.appleHeal = SaveSystem.GetInt("appleHeal");
    this.potionDuration = SaveSystem.GetInt("potionDuration");
    this.appleDefense = SaveSystem.GetInt("appleDefense");
    this.attackLow = SaveSystem.GetInt("attackLow");
    this.attackHigh = SaveSystem.GetInt("attackHigh");
    this.maxHealth = SaveSystem.GetInt("maxHealth");
    this.ChangeHealth(this.maxHealth);
  }

  /// <summary>
  /// Alternative movement for Android.
  /// </summary>
  public void AndroidMoveLeft()
  {
    Vector2 position = this.rigidbody2d.position;
    position.x--;
    this.rigidbody2d.MovePosition(position);
    SoundManager.PlaySound(SoundManager.Sound.walk);
    this.moved = true;
  }

  /// <summary>
  /// Alternative movement for Android.
  /// </summary>
  public void AndroidMoveRight()
  {
    Vector2 position = this.rigidbody2d.position;
    position.x++;
    this.rigidbody2d.MovePosition(position);
    SoundManager.PlaySound(SoundManager.Sound.walk);
    this.moved = true;
  }

  /// <summary>
  /// Alternative movement for Android.
  /// </summary>
  public void AndroidMoveUp()
  {
    Vector2 position = this.rigidbody2d.position;
    position.y++;
    this.rigidbody2d.MovePosition(position);
    SoundManager.PlaySound(SoundManager.Sound.walk);
    this.moved = true;
  }

    /// <summary>
  /// Alternative movement for Android.
  /// </summary>
  public void AndroidMoveDown()
  {
    Vector2 position = this.rigidbody2d.position;
    position.y--;
    this.rigidbody2d.MovePosition(position);
    SoundManager.PlaySound(SoundManager.Sound.walk);
    this.moved = true;
  }

  /// <summary>
  /// Late update moves the bool to false to allow it to be the last action
  /// taken.  This ensures that all enemies will have a chance to move,
  /// regardless of when their script is called.
  /// </summary>
  private void LateUpdate()
  {
    if (this.moved == true)
    {
      this.moved = false;
    }
  }
}

