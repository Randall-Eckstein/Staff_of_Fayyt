using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public int HP;
  public int damageLow;
  public int damageHigh;
  public int speed;
  public float visionRange;
  public int defense;
  public int goldLow;
  public int goldHigh;

  private GameObject target;
  private Rigidbody2D rb;
  private BoxCollider2D bc2d;
  private GoldDontDestroy _goldReference;
  private PlayerScript playerScript;

  private bool canMove;

  private void Start()
  {
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();
    this.rb = this.GetComponent<Rigidbody2D>();
    this.bc2d = this.GetComponent<BoxCollider2D>();
    this.target = GameObject.FindGameObjectWithTag("Player");
    this.playerScript = this.target.GetComponent<PlayerScript>();
    this.canMove = false;
  }

  /// <summary>
  /// Determines if enemy has hit player, and if so, calculates damage.
  /// If this enemy has died, calculate the gold and give it to the player.
  /// Destroy this enemy.
  /// </summary>
  /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
  {
    PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
    if (!(player is null))
    {
      int damageDoneToMe = player.DoDamage() - this.defense;
      this.HP -= damageDoneToMe;
      if (this.HP <= 0)
      {
        SoundManager.PlaySound(SoundManager.Sound.gold);
        int randGold = Random.Range(this.goldLow, this.goldHigh + 1);
        this._goldReference.ChangeGoldDisplay(randGold);
        Destroy(this.gameObject);
      }
      else
      {
        int damage = Random.Range(this.damageLow, this.damageHigh);
        damage = Mathf.RoundToInt(damage * player.defensePercent);
        int clampedDamage = Mathf.Clamp(damage - player.defenseRaw, 0, 9999);
        player.ChangeHealth(clampedDamage * -1);
      }
    }
  }

  /// <summary>
  /// Tests if an enemy can move, and moves it.
  /// </summary>
  private void Update()
  {
    if (this.playerScript.moved == true)
    {
      this.canMove = true;
    }
    if (this.canMove == true)
    {
      if (this.playerScript.isActiveAndEnabled)
      {
        Vector3 locationNow = this.target.transform.position;
        this.TestMoveType(locationNow);
        this.canMove = false;
      }
    }
  }

  /// <summary>
  /// If player is in range, move toward player.
  /// If not, move in a random direction.
  /// </summary>
  /// <param name="location"></param>
  public void TestMoveType(Vector3 location)
  {
    this.bc2d.enabled = false;
    Vector3 direction = location - this.transform.position;
    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction);
    {
      if (hit.transform.CompareTag("Player"))
      {
        this.MoveToPlayer(direction);
      }
      else if (hit.transform.CompareTag("Wall"))
      {
        this.RandomMovement();
      }
      else if (hit.transform.CompareTag("Enemy"))
      {
        this.MoveToPlayer(direction);
      }
      else
      {
        this.RandomMovement();
      }
    }
    this.bc2d.enabled = true;
  }

  /// <summary>
  /// move in a direction based on a random value.
  /// </summary>
  public void RandomMovement()
  {
    Vector2 position = this.rb.position;
    int rand = Random.Range(0, 4);
    if (rand == 0)
    {
      position.x++;
    }
    else if (rand == 1)
    {
      position.x--;
    }
    else if (rand == 2)
    {
      position.y++;
    }
    else if (rand == 3)
    {
      position.y--;
    }
    else
    {
      Debug.LogError("You reached a move position random choice integer that is out of bounds.");
    }
    this.rb.MovePosition(position);
  }

  /// <summary>
  /// Move toward player if player is in view.
  /// </summary>
  /// <param name="direction"></param>
  public void MoveToPlayer(Vector3 direction)
  {
    //if distance between enemy and player's x value is greater than its 
    //y value, move toward player along x axis
    //otherwise, move along the y axis.
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    angle /= 90;
    angle = Mathf.Round(angle);
    angle *= 90;
    Vector2 pos = this.rb.position;

    //if angle = 0   :  Add to x
    //if angle = 90  :  Add to y
    //if angle = -180:  Subtract from x
    //if angle = -90 :  Subtract from y

    switch (angle)
    {
      case 0:
        pos.x++;
        break;
      case -180:
        pos.x--;
        break;
      case 90:
        pos.y++;
        break;
      case -90:
        pos.y--;
        break;
      default:
        break;
    }
    this.rb.MovePosition(pos);
  }
}