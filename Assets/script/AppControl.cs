using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppControl : MonoBehaviour
{
    public manageSprite[] ManageSprite;
    public Sprite[] spriteItem;
    public GameObject[] detectStop;
    public GameObject[] detectSpawn;
    public string r1_c1s, r1_c2s, r1_c3s, r1_c4s, r1_c5s;
    public string r2_c1s, r2_c2s, r2_c3s, r2_c4s, r2_c5s;
    public string r3_c1s, r3_c2s, r3_c3s, r3_c4s, r3_c5s;
    public GameObject[] panel;
    public GameObject[] btnAuto;
    public Text txtBalance, txtBet, txtWinLine;
    public bool isAuto,isStop;
    float time;
    public bool isStart;
    int winPoint, bet;
    public int balance;
    public string txt = "true";
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        
    }
    void Start()
    {
        balance = PlayerPrefs.GetInt("DBControl");
        if (balance == 0)
        {
            balance = 100000;
        }
        FindAnyObjectByType<DBpoint>().dataGame();
        checngImage();
        bet = 100;
    }

    private void checngImage()
    {
        List<int> list = new List<int>();
        foreach( var item in ManageSprite )
        {
            foreach( var itemSprite in item.itemRow)
            {
                int K = Random.Range(0,spriteItem.Length);
                while(list.Contains(K))
                    K = Random.Range(0,spriteItem.Length);
                list.Add(K);
                itemSprite.GetComponent<Image>().sprite = spriteItem[K];
            }
            list.Clear();
        }
    }
    
    void Update()
    {
        txtBalance.text = balance.ToString();
        txtBet.text = bet.ToString();
        if(isStart)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                StartCoroutine(openBox());
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(4f);
                    openCheck();
                    yield return new WaitForSeconds(.2f);
                    checkWin();
                    FindAnyObjectByType<buttonControl>().spin.GetComponent<Button>().enabled = true;
                    FindAnyObjectByType<buttonControl>().spin.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                    FindAnyObjectByType<buttonControl>().autoSpin.GetComponent<Button>().enabled = true;
                    FindAnyObjectByType<buttonControl>().autoSpin.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                    FindAnyObjectByType<buttonControl>().home.GetComponent<Button>().enabled = true;
                    FindAnyObjectByType<buttonControl>().home.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                    FindAnyObjectByType<buttonControl>().plus.GetComponent<Button>().enabled = true;
                    FindAnyObjectByType<buttonControl>().plus.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                    FindAnyObjectByType<buttonControl>().incre.GetComponent<Button>().enabled = true;
                    FindAnyObjectByType<buttonControl>().incre.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                }
                isStart = false;
            }
        }
        if (isAuto)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                isAuto = false;
                StartCoroutine(openBox());
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(4f);
                    openCheck();
                    yield return new WaitForSeconds(.2f);
                    checkWin();
                    yield return new WaitForSeconds(.2f);

                    if (isStop)
                    {
                        closBox();
                        isAuto = true;
                    }
                    else if(!isStop)
                    {
                        isAuto = false;
                        FindAnyObjectByType<buttonControl>().spin.GetComponent<Button>().enabled = true;
                        FindAnyObjectByType<buttonControl>().spin.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                        FindAnyObjectByType<buttonControl>().autoSpin.GetComponent<Button>().enabled = true;
                        FindAnyObjectByType<buttonControl>().autoSpin.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                        FindAnyObjectByType<buttonControl>().home.GetComponent<Button>().enabled = true;
                        FindAnyObjectByType<buttonControl>().home.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                        FindAnyObjectByType<buttonControl>().plus.GetComponent<Button>().enabled = true;
                        FindAnyObjectByType<buttonControl>().plus.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                        FindAnyObjectByType<buttonControl>().incre.GetComponent<Button>().enabled = true;
                        FindAnyObjectByType<buttonControl>().incre.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                        btnAuto[0].SetActive(true);
                        btnAuto[1].SetActive(false);
                    }
                    
                }
                
            }
        }
    }

    public void closBox()
    {
        
        time = Random.Range(1.8f, 2.8f);
        winPoint = 0;
        balance -= bet;
        foreach(var item in detectStop)
        {
            item.GetComponent<BoxCollider2D>().enabled = false;
        }
        foreach (var item in detectSpawn)
        {
            item.GetComponent<BoxCollider2D>().enabled = false;
        }
        txtWinLine.text = "";
        FindAnyObjectByType<DBpoint>().dataGame();
    }
    public IEnumerator openBox()
    {
        time = 0;
        foreach(var item in detectStop)
        {
            yield return new WaitForSeconds(1f);
            item.GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }
    private void openCheck()
    {
        foreach(var item in detectSpawn)
        {
             item.GetComponent<BoxCollider2D>().enabled=true;
        }
        
    }
    public void plusVal()
    {
        if (balance >= bet)
        {
            bet += 100;
        }
    }
    public void Increap()
    {
        if (bet > 100)
        {
            bet -= 100;
        }
    }

    //20 line slots
    private void checkWin()
    {
        //1
        if (r2_c1s == r2_c2s && r2_c1s == r2_c3s && r2_c1s == r2_c4s && r2_c1s == r2_c5s)
        {
            getReward();
            txtWinLine.text = "1";
            //print("20");
        }
        //2
        else if(r1_c1s==r1_c2s && r1_c1s == r1_c3s && r1_c1s== r1_c4s && r1_c1s == r1_c5s)
        {
            getReward();
            txtWinLine.text = "2";
           // print("1");
        }

        //3
        else if(r3_c1s==r3_c2s&& r3_c1s==r3_c3s && r3_c1s== r3_c4s && r3_c1s == r3_c5s)
        {
            txtWinLine.text = "3";
            getReward();
           // print("2");
        }
        //4
        else if (r1_c1s == r2_c2s && r1_c1s == r3_c3s && r1_c1s == r2_c4s && r1_c1s == r1_c5s)
        {
            getReward();
            txtWinLine.text = "4";
           // print("3");
        } 
        //5
        else if (r3_c1s == r2_c2s && r3_c1s == r1_c3s && r3_c1s == r2_c4s && r3_c1s == r3_c5s)
        {
            getReward();
            txtWinLine.text = "5";
           // print("4");
        } 
        //6
        else if (r1_c1s == r1_c2s && r1_c1s == r2_c3s && r1_c1s == r1_c4s && r1_c1s == r1_c5s)
        {
            getReward();
            txtWinLine.text = "6";
           // print("5");
        }  
        //7
        else if (r3_c1s == r3_c2s && r3_c1s == r2_c3s && r3_c1s == r3_c4s && r3_c1s == r3_c5s)
        {
            getReward();
            txtWinLine.text = "7";
             //   print("6");
        }
        //8
        else if (r2_c1s == r3_c2s && r2_c1s == r3_c3s && r2_c1s == r3_c4s && r2_c1s == r2_c5s)
        {
            getReward();
            txtWinLine.text = "8";
           // print("7");
        }
        //9
        else if(r2_c1s==r1_c2s && r2_c1s==r1_c3s && r2_c1s== r1_c4s && r2_c1s == r2_c5s)
        {
            getReward();
            txtWinLine.text = "9";
           // print("8");
        }
        //10
        else if(r2_c1s==r1_c2s && r2_c1s==r2_c3s && r2_c1s== r1_c4s && r2_c1s == r2_c5s)
        {
            getReward();
            txtWinLine.text = "10";
            //print("9");
        } 
        //11
        else if(r2_c1s==r3_c2s && r2_c1s==r2_c3s && r2_c1s== r3_c4s && r2_c1s == r2_c5s)
        {
            getReward();
            txtWinLine.text = "11";
            //print("10");
        }
        //12
        else if(r1_c1s==r2_c2s && r1_c1s==r1_c3s && r1_c1s== r2_c4s && r1_c1s == r1_c5s)
        {
            getReward();
            txtWinLine.text = "12";
            //print("11");
        } 
        //13
        else if(r3_c1s==r2_c2s && r3_c1s==r3_c3s && r3_c1s== r2_c4s && r3_c1s == r3_c5s)
        {
            getReward();
            txtWinLine.text = "13";
            //print("12");
        } 
        //14
        else if(r2_c1s==r2_c2s && r2_c1s==r1_c3s && r2_c1s== r2_c4s && r2_c1s == r2_c5s)
        {
            getReward();
            txtWinLine.text = "14";
           // print("13");
        }
        //15
        else if(r2_c1s==r2_c2s && r2_c1s==r3_c3s && r2_c1s== r2_c4s && r2_c1s == r2_c5s)
        {
            getReward();
            txtWinLine.text = "15";
            //print("14");
        }
        //16
        else if(r1_c1s==r2_c2s && r1_c1s==r2_c3s && r1_c1s== r2_c4s && r1_c1s == r1_c5s)
        {
            getReward();
            txtWinLine.text = "16";
           // print("15");
        }
        //17
        else if(r3_c1s==r2_c2s && r3_c1s==r2_c3s && r3_c1s== r2_c4s && r3_c1s == r3_c5s)
        {
            getReward();
            txtWinLine.text = "17";
           // print("16");
        }
        //18
        else if(r1_c1s==r2_c2s && r1_c1s==r3_c3s && r1_c1s== r3_c4s && r1_c1s == r3_c5s)
        {
            getReward();
            txtWinLine.text = "18";
           // print("17");
        }
        //19
        else if(r3_c1s==r2_c2s && r3_c1s==r1_c3s && r3_c1s== r1_c4s && r3_c1s == r1_c5s)
        {
            getReward();
            txtWinLine.text = "19";
           // print("18");
        }
        //20
        else if(r1_c1s==r3_c2s && r1_c1s==r1_c3s && r1_c1s== r3_c4s && r1_c1s == r1_c5s)
        {
            getReward();
            txtWinLine.text = "20";
           // print("19");
        }
    }
    private void getReward()
    {
        winPoint = bet * 10;
        balance += winPoint;
    }
}
