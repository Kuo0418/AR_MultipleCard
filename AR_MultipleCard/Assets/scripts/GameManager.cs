using UnityEngine;

public class GameManager : MonoBehaviour
{
    //註解
    //定義欄位-儲存資料
    //語法:
    //修飾詞 類型 名稱;
    //私人 private(預設)-不會顯示在屬性面板
    //公開 public       -會顯示在屬性面板
    // C#支援中文
    //欄位標題
    //語法 : [Header("文字訊息")]
    [Header("兔子")]
    public Transform rabbit;
    [Header("蝙蝠")]
    public Transform bat;
    [Header("虛擬搖桿")]
    public FixedJoystick Joystick;
    [Header("旋轉速度") , Range(0.1f,20f)]
    public float turn = 1.5f;
    [Header("縮放"), Range(0f, 5f)]
    public float size = 0.015f;
    [Header("兔子動畫元件")]
    public Animator aniRabbit;
    [Header("蝙蝠動畫元件")]
    public Animator aniBat;

    //Range : 範圍
    //也可用語法：
    //[Header("")]
    //[Rande(0.1f,20f)

    //如果要兩個不同速度
    //[Header("")]
    //public float turn = 1.5f
    //[Header("")]
    //pubilc float turna = 2f
    //*下方也要改

    //事件 : 在特定時間會執行的區塊(名稱為藍色)
    //開始事件 : 遊戲開始執行一次 - 初始設定
    private void Start()
    {
        print("開始事件");
    }
    //public float test = 1;
    //public float test2 = 1;

    //更新事件 : 遊戲每個影格會執行一次
    //一秒60格(60FPS)
    //一秒執行約60次
    //控制物件移動、旋轉、縮放或玩家輸入
    private void Update()
    {
        print("更新事件");
        print(Joystick.Vertical);      //虛擬搖桿 的 垂直資訊，float 浮點數有小數點的數值

        bat.Rotate(0, Joystick.Horizontal * turn, 0);  //蝙蝠.旋轉(x,y,z) - (0,虛擬搖桿的水平,0)   
        rabbit.Rotate(0, Joystick.Horizontal * turn, 0); //兔子.旋轉
        //+= 累加(遞增) : 原有的數值遞增上去
        bat.localScale += new Vector3(1, 1, 1) * Joystick.Vertical * size;    //蝙蝠.區域尺寸 = 新 三維向量(1,1,1) * 虛擬搖桿垂直
        rabbit.localScale += new Vector3(1,1,1) * Joystick.Vertical * size;   //兔子.區域尺寸 
        bat.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(bat.localScale.x, 0.5f, 3.5f);
        rabbit.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(rabbit.localScale.x, 0.5f, 3.5f);

        //test = Mathf.Clamp(test, 0.5f, 9.9f);
        //print(Mathf.Clamp(test2, 0, 10));
    }

    //定義方法   Method
    //定義程式區塊
    //語法1：
    //修飾詞 類型 名稱 () {}
    //要給按鈕呼叫必須設為公開  pubilc
    //無類型 void
    public void Attack()
    {
        print("攻擊");
        aniBat.SetTrigger("攻擊觸發");
    }
    public void Move()
    {
        print("移動");
        aniBat.SetTrigger("移動觸發");
    }
    public void Die()
    {
        print("死亡");
        aniBat.SetTrigger("死亡觸發");
    }

    //定義方法   Method
    //語法2：修飾詞 類型 名稱(參數1，參數2，˙˙˙˙˙){}

    public void PlayAnimation(string aniName)
    {
        print(aniName);
        aniBat.SetTrigger(aniName);
        aniRabbit.SetTrigger(aniName);
    }
}
