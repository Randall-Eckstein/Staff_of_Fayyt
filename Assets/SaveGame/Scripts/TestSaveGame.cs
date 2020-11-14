using UnityEngine;
using UnityEngine.UI;

public class TestSaveGame : MonoBehaviour
{
  //INT (UI)
  [Header("Save int")]
  public Text countIntText;
  public InputField inputIntField;
  public int cubeIntCount = 0;
  [Space(10)]

  //Next variables
  [Header("Save next")]
  public float floatCount;
  public Vector2 vect2;
  public Vector3 vect3;
  public Color color;
  public string stringSave;
  public bool saveBool;




  // Use this for initialization
  private void Start()
  {

    //Load Save int
    this.cubeIntCount = SaveSystem.GetInt("cubeCount");
    this.countIntText.text = this.cubeIntCount.ToString();

    //Load save Next
    this.floatCount = SaveSystem.GetFloat("float");
    this.saveBool = SaveSystem.GetBool("bool");
    this.vect2 = SaveSystem.GetVector2("vect2");
    this.vect3 = SaveSystem.GetVector3("vect3");
    this.color = SaveSystem.GetColor("color");
    this.stringSave = SaveSystem.GetString("string");



  }


  //Button Save INT
  public void SaveCube()
  {
    this.countIntText.text = this.inputIntField.text;
    this.cubeIntCount = int.Parse(this.inputIntField.text);

    //Save "cubeCount"
    SaveSystem.SetInt("cubeCount", this.cubeIntCount);
  }

  //Save "NEXT"
  private void OnApplicationQuit()
  {

    SaveSystem.SetFloat("float", this.floatCount);
    SaveSystem.SetBool("bool", this.saveBool);
    SaveSystem.SetVector2("vect2", this.vect2);
    SaveSystem.SetVector3("vect3", this.vect3);
    SaveSystem.SetColor("color", this.color);
    SaveSystem.SetString("string", this.stringSave);
  }

  //Save "NEXT"
  private void OnApplicationPause(bool pause)
  {
    if (pause)
    {
      SaveSystem.SetFloat("float", this.floatCount);
      SaveSystem.SetBool("bool", this.saveBool);
      SaveSystem.SetVector2("vect2", this.vect2);
      SaveSystem.SetVector3("vect3", this.vect3);
      SaveSystem.SetColor("color", this.color);
      SaveSystem.SetString("string", this.stringSave);
    }
  }

}
