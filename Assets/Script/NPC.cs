using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour
{

    public Transform ChatBackGround;
    public Transform NPCCharacter;
    private Dialoguesystem dialogueSystem;
    public int t = 0;
    public static int[] dialogueArray = {0,9,9,9,9,9,9,9,9,9}; //初始对话：见到A开始Sentences，见到B-J开始Sentences9
    public static int equipmentLevel = 2; //在ADEGHI领取任务的等级（二级，三级，高级，神级）分别用2，3，4，5表示
    public static string task = "Your Task:\nAsk NPC A what's going on.";
    public static string killed = "";
    public static string newEquipment = "Hair1";
    public static string newEquipment2 = "Hair1";


    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;
    [TextArea(5, 10)]
    public string[] sentences1;
    [TextArea(5, 10)]
    public string[] sentences2;
    [TextArea(5, 10)]
    public string[] sentences3;
    [TextArea(5, 10)]
    public string[] sentences4;
    [TextArea(5, 10)]
    public string[] sentences5;
    [TextArea(5, 10)]
    public string[] sentences6;
    [TextArea(5, 10)]
    public string[] sentences7;
    [TextArea(5, 10)]
    public string[] sentences8;
    [TextArea(5, 10)]
    public string[] sentences9;

    public static bool Court1 = false;
    public static bool Court1Passed = false;
    public static bool Court2 = false;
    public static bool Court2Passed = false;
    public static bool Court3 = false;
    public static bool Court3Failed = false;    //Failed
    public static bool Court4 = false;
    public static bool Court4Passed = false;
    public static bool Court5 = false;
    public static bool Court5Passed = false;
    public static bool Court6 = false;
    public static bool Court6Passed = false;
    public static bool Court7 = false;
    public static bool Court7Passed = false;
    public static bool Court8 = false;
    public static bool Court8Passed = false;
    public static bool Court9 = false;
    public static bool Court9Passed = false;
    public static bool Court10 = false;
    public static bool Court10Passed = false;
    public static bool Court11 = false;
    public static bool Court11Passed = false;
    public static bool Court12 = false;
    public static bool Court12Failed = false;   //Failed
    public static bool Court13 = false;
    public static bool Court13Passed = false;
    public static bool Court14 = false;
    public static bool Court14Passed = false;
    public static bool Court15 = false;
    public static bool Court15Passed = false;
    public static bool Court16 = false;
    public static bool Court16Passed = false;
    public static bool Court17 = false;
    public static bool Court17Failed = false;   //Failed
    public static bool Court18 = false;
    public static bool Court18Passed = false;
    public static bool Court19 = false;
    public static bool Court19Passed = false;
    public static bool Court20 = false;
    public static bool Court20Passed = false;

    void Start()
    {
        dialogueSystem = FindObjectOfType<Dialoguesystem>();
        
    }

    void Update()
    {
        /*Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y += 50;
        ChatBackGround.position = Pos;*/
        if (countedGameIsOn())
        {
            killed = "(" + GameManager.killed + "/" + GameManager.difficulty + ")";
            if (bossIsComing()) killed = "(" + GameManager.killed + "/" + GameManager.difficulty + ")" + "\nA boss is coming!";
        }
        else { killed = ""; }
        
    }

    //在这些场中开始计数
    public static bool countedGameIsOn() {
        if (Court2 && !Court2Passed) return true;
        if (Court4 && !Court4Passed) return true;
        if (Court5 && !Court5Passed) return true;
        if (Court6 && !Court6Passed) return true;
        if (Court7 && !Court7Passed) return true;
        if (Court8 && !Court8Passed) return true;
        if (Court9 && !Court9Passed) return true;
        if (Court10 && !Court10Passed) return true;
        if (Court11 && !Court11Passed) return true;
        if (Court13 && !Court13Passed) return true;
        if (Court14 && !Court14Passed) return true;
        if (Court15 && !Court15Passed) return true;
        if (Court16 && !Court16Passed) return true;
        if (Court18 && !Court18Passed) return true;
        if (Court19 && !Court19Passed) return true;
        return false;
    }
    public static bool bossIsComing() {
        if (Court5 && !Court5Passed) return true;
        if (Court10 && !Court10Passed) return true;
        if (Court15 && !Court15Passed) return true;
        return false;
    }
    
        

    public int dIndex(string Name) {
        switch (Name) {
            case "NPCA": return 0;
            case "NPCB": return 1;
            case "NPCC": return 2;
            case "NPCD": return 3;
            case "NPCE": return 4;
            case "NPCF": return 5;
            case "NPCG": return 6;
            case "NPCH": return 7;
            case "NPCI": return 8;
            case "NPCJ": return 9;
            default: return -1;
        }
    }

    // 判定dialogueArray内容是否为输入的10个数 是则return true（默认两array长度相等）x可代替任何数
    // P.S. char->int（ASCII中'0'为48）      
    public static bool dialogueContent(string content) {
        for (int i = 0; i < 10; i++) {
            if (content[i] != 'x' && dialogueArray[i] != (int)content[i] - 48) return false;
        }
        return true;
    }


    
    public void OnTriggerStay(Collider other)
    {
        t = dialogueArray[dIndex(Name)]; // 根据对方的NPC名字判断对方是哪个NPC，然后到dialogueArray里寻找与对方对话到了第几句

        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<Dialoguesystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 0)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name) {
                case "NPCA":
                    //1. 在出生地出现，先找 A 获得第一个任务「寻找孩子」，并获得第0级的武器。对话：A
                    if (dialogueContent("0999999999"))
                    {
                        dialogueArray[1] = 0;   //之后问B， B会回答你孩子在篮球场
                        //newEquipment = "Weapon0";
                        task = "Your Task:\nAsk NPC B where the child is.";
                    }

                    break;
                case "NPCB":
                    //2. 通过 B 得知孩子在篮球场。对话：B
                    if (dialogueContent("0099999999")) {
                        Court1 = true;    //开启场1
                        task = "Your Task:\nGo to the soccer court to find the child.";
                    }
                    break;
                case "NPCC":
                    //16. 回到 C 处，获得红色头发兑换条件，需获得第二级的装备（武器为锤子）。对话：C
                    if (dialogueContent("6606626669")) {
                        dialogueArray[0]= 4;    //开启对话A4
                        task = "Your Task:\nAsk NPC A to improve your equipment.";
                    }
                    break;
                case "NPCD":
                    //6.任务需要找到 D 先获得一个背包，D 给出新任务。对话：D
                    if (dialogueContent("6690009999"))
                    {
                        Court2 = true;    //开启场2
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCE":
                    //5. F 需要任务穿上白色衣服，去找到 E，获得任务。对话：F E
                    if (dialogueContent("6699009999"))
                    {
                        dialogueArray[3] = 0;   //开启对话D
                        task = "Your Task:\nFind NPC D to get a bag.";
                    }
                    break;
                case "NPCF":
                    //5. F 需要任务穿上白色衣服，去找到 E，获得任务。对话：F E
                    if (dialogueContent("1699909999")){
                        dialogueArray[4] = 0;   //开启对话E
                        dialogueArray[0] = 6;
                        task = "Your Task:\nFind NPC E to get a white cloth.";
                    }
                    break;
                case "NPCG":
                    //11. G 发布任务，要求击杀 X 只篮球场怪物来换取第一级肩甲，完成后G让你找H。对话：G G1
                    if (dialogueContent("6696660919")) {
                        Court4 = true;   //开启场4
                        dialogueArray[8] = 6;
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCH":
                    //12. H 发布任务，要求击杀 X 只足球场怪物来换取第一级手套及鞋子，完成后H让你找A。对话：H H1
                    if (dialogueContent("6696661069")) {
                        Court5 = true;   //开启场5
                        dialogueArray[6] = 6;
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCI":
                    //10. I 要求你去初级网球场证明自己，你完全无法通关，回到 I 处获得一个头盔，
                    //并开启兑换系统，I 告诉你要去找 G 及 H 及 A 寻求帮助。对话：I I1
                    if (dialogueContent("6696619909")) {
                        Court3 = true;     //开启场3
                        dialogueArray[5] = 6;
                        task = "Your Task:\nGo to the soccer court and try to kill the monsters there.";
                    }
                    break;
                case "NPCJ":
                    break;
                default:
                    break;
            }
        
        }
         else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 1)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences1;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    //4. 找到到 A 完成任务，开启武器兑换系统，获得讯息要去寻找先知 F。对话：A1
                    if (dialogueContent("1699999999")) {
                        dialogueArray[5] = 0;   //开启对话F
                        task = "Your Task:\nFind the prophet (NPC F).";
                    }
                    break;
                case "NPCB":
                    break;
                case "NPCC":
                    //18. 去 C 处获得红色头发并寻找先知 F，获得任务尝试通关普通篮球场。对话：C1 F3
                    if (dialogueContent("6616626669")) {
                        dialogueArray[5] = 3;       //开启对话F3
                        dialogueArray[2] = 6;
                        newEquipment = "Hair5";
                        task = "Your Task:\nTalk to NPC F.";
                    }
                    break;
                case "NPCD":
                    //7. 前往初级足球场击杀小怪及 boss，并回到 D 处获得初级背包。对话：D1
                    if (dialogueContent("6691009999")) {
                        dialogueArray[4] = 1;   //开启对话E1
                        newEquipment = "Belt2";
                        task = "Your Task:\nTell NPC E that you have got a bag.";
                    }
                    break;
                case "NPCE":
                    //8. 回到 E 处获得白色衣服，开启衣服兑换系统。对话：E1
                    if (dialogueContent("6691109999")) {
                        dialogueArray[5] = 1;   //开启对话F1
                        dialogueArray[3] = 6;
                        dialogueArray[4] = 6;
                        newEquipment = "Cloth2";
                        task = "Your Task:\nTell NPC F that you have got a white cloth.";
                    }
                    break;
                case "NPCF":
                    //9. F 说必须杀死大魔王才能离开这个世界，不然会永远留在这里，叫你去找 I 变强。对话：F1
                    if (dialogueContent("6696619999")){
                        dialogueArray[8] = 0;    //开启对话I
                        task = "Your Task:\nFind NPC I and have a chat with him.";
                    }
                    break;
                case "NPCG":
                    //11. G 发布任务，要求击杀 X 只篮球场怪物来换取第一级肩甲，完成后G让你找H。对话：G G1
                    if (dialogueContent("6696661969")) {
                        dialogueArray[7] = 0;    //开启对话H
                        newEquipment = "ShoulderPad2";
                        task = "Your Task:\nFind NPC H and have a chat with him.";
                    }
                    break;
                case "NPCH":
                    //12. H 发布任务，要求击杀 X 只足球场怪物来换取第一级手套及鞋子，完成后H让你找A。对话：H H1
                    if (dialogueContent("6696666169")) {
                        dialogueArray[0] = 2;    //开启对话A2
                        dialogueArray[7] = 6;
                        newEquipment = "Glove2";
                        newEquipment2 = "Shoe2";
                        task = "Your Task:\nTalk to NPC A.";
                    }
                    break;
                case "NPCI":
                    //10. I 要求你去初级网球场证明自己，你完全无法通关，回到 I 处获得一个头
                    //盔，并开启兑换系统，I 告诉你要去找 G 及 H 及 A 寻求帮助。对话：I I1
                    if (dialogueContent("6696669919")) {
                        dialogueArray[6] = 0;   //开启对话G
                        newEquipment = "Helm1";
                        task = "Your Task:\nAsk NPC G for help.";
                    }
                    break;
                case "NPCJ":
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 2)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences2;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    //13. A 发布任务，要求击杀 X 只篮球场怪物来换取第一级武器（包括斧头）。对话：A2
                    if (dialogueContent("2696666669"))
                    {
                        Court6 = true;    //开启场6
                        //newEquipment = "Weapon1";
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCB":
                    //21. 向 F 提交任务后，小孩子 B 需要你的帮助，获得任务并尝试通关普通网球场5，失败。对话：F7 B2
                    if (dialogueContent("6266666669")) {
                        Court12 = true;    //开启场12
                        task = "Your Task:\nTry to beat the enemies on the soccer court.";
                    }
                    break;
                case "NPCC":
                    break;
                case "NPCD":
                    break;
                case "NPCE":
                    break;
                case "NPCF":
                    //15. 先知 F 叫你去找他，需要你先获得红色头发，才能接任务。对话：F2
                    if (dialogueContent("3696626669")) {
                        dialogueArray[2] = 0;    //开启对话C
                        dialogueArray[0] = 6;
                        task = "Your Task:\nFind NPC C to get a red hair.";
                    }
                    break;
                case "NPCG":
                    break;
                case "NPCH":
                    break;
                case "NPCI":
                    //27. I 给予高级头盔，叫你去找不同的人增强自己。对话：I2
                    if (dialogueContent("6666666622")) {
                        dialogueArray[8] = 6;    
                        dialogueArray[9] = 6;
                        dialogueArray[0] = 4;   //开启对话A4
                        equipmentLevel = 4;     //四级装备任务
                        newEquipment = "Helm6";
                        task = "Your Task:\nAsk NPC A to improve your equipment.";
                    }
                    break;
                case "NPCJ":
                    //26. 老人 J 要求你通关噩梦网球场7才跟你交流，并叫你找 I。对话：J2
                    if (dialogueContent("6666666662"))
                    {
                        Court15 = true;    //开启场15
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 3)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences3;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    //完成后，让你前往初级网球场通关。对话：A3
                    if (dialogueContent("3696666669"))
                    {
                        Court7 = true; //开启场7
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCB":
                    //22. 小孩子提示使用弓箭，找 A 兑换弓箭，需要先获得白色头发。对话：B3 A7
                    if (dialogueContent("6366666669")){
                        dialogueArray[0] = 7;   //开启对话A7
                        dialogueArray[1] = 6;
                        task = "Your Task:\nAsk NPC A for a new weapon.";
                    }
                    break;
                case "NPCC":
                    //23. 找到 C 获得白色头发任务，通关普通足球场。对话：C3
                    if (dialogueContent("7636666669"))
                    {
                        Court13 = true;    //开启场13
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCD":
                    break;
                case "NPCE":
                    break;
                case "NPCF":
                    //18. 去 C 处获得红色头发并寻找先知 F，获得任务尝试通关普通篮球场5。对话：C1 F3
                    if (dialogueContent("6666636669")) {
                        Court9 = true; //开启场9
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCG":
                    break;
                case "NPCH":
                    break;
                case "NPCI":
                    break;
                case "NPCJ":
                    //29. 通关噩梦网球场后去拜访老人 J，他叫你去排球场1跟其他人对战提升自己，需要胜利 X 场。对话：J3
                    if (dialogueContent("6666666663")) {
                        Court17 = true;    //开启场17
                        task = "Your Task:\nTry to beat the enemies on the soccer court.";
                    }
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 4)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences4;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    //领取任务
                    task = "Your Task:\nBeat the enemies on the soccer court.";
                    switch (equipmentLevel) {
                        case 2:
                            Court8 = true;
                            break;
                        case 3:
                            Court10 = true;
                            break;
                        case 4:
                            Court16 = true;
                            break;
                        case 5:
                            Court18 = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case "NPCB":
                    break;
                case "NPCC":
                    //24. 向 C 提交任务并且找 A 兑换弓箭，通关普通网球场。对话：C4 A8
                    if (dialogueContent("7646666669")) {
                        dialogueArray[0] = 8;   //开启对话A8
                        dialogueArray[2] = 6;
                        newEquipment = "Hair3";
                        task = "Your Task:\nTell NPC A that you have got a white hair.";
                    }
                    break;
                case "NPCD":
                    break;
                case "NPCE":
                    break;
                case "NPCF":
                    //19. 回到 F 处提交任务，获得怪物增强的消息，需要通知各个 NPC。对话：F4
                    if (dialogueContent("6666646669")) {
                        dialogueArray[0] = 4;    //开启对话A4
                        equipmentLevel = 3;      //三级装备任务
                        task = "Your Task:\nAsk NPC A to improve your equipment.";
                    }
                    break;
                case "NPCG":
                    break;
                case "NPCH":
                    break;
                case "NPCI":
                    break;
                case "NPCJ":
                    //31. 完成后向老人 J 提交任务，发现他就是大魔王，开启最终 boss。对话：J4
                    if (dialogueContent("6666666664")) {
                        Court20 = true;    //开启场20
                        task = "Your Task:\nGo to the soccer court and beat the boss.";
                    }
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 5)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences5;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    task = task.Replace("\nAsk NPC A for better equipment.", "");
                    switch (equipmentLevel)
                    {
                        case 2:
                            //newEquipment = "Weapon2";
                            break;
                        case 3:
                            //newEquipment = "Weapon3";
                            break;
                        case 4:
                            //newEquipment = "Weapon4";
                            break;
                        case 5:
                            //newEquipment = "Weapon5";
                            break;
                        default:
                            break;
                    }
                    dialogueArray[0] = 6;
                    break;
                case "NPCB":
                    break;
                case "NPCC":
                    break;
                case "NPCD":
                    task = task.Replace("\nAsk NPC D for better equipment.", "");
                    switch (equipmentLevel)
                    {
                        case 2:
                            newEquipment = "Belt3";
                            break;
                        case 3:
                            newEquipment = "BackPack1";
                            break;
                        case 4:
                            newEquipment = "BackPack2";
                            break;
                        case 5:
                            newEquipment = "Backpack3";
                            break;
                        default:
                            break;
                    }
                    dialogueArray[3] = 6;
                    break;
                case "NPCE":
                    task = task.Replace("\nAsk NPC E for better equipment.", "");
                    switch (equipmentLevel)
                    {
                        case 2:
                            newEquipment = "Cloth3";
                            break;
                        case 3:
                            newEquipment = "Cloth4";
                            break;
                        case 4:
                            newEquipment = "Cloth5";
                            break;
                        case 5:
                            newEquipment = "Cloth6";
                            break;
                        default:
                            break;
                    }
                    dialogueArray[4] = 6;
                    break;
                case "NPCF":
                    //20. 找到各个 NPC 并且领取任务 通过场10即获得第三级装备，回到先知 F 处交任务，获得新任务通关普通足球场5。对话：F5
                    if (dialogueContent("6666656669"))
                    {
                        Court11 = true;
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCG":
                    task = task.Replace("\nAsk NPC G for better equipment.", "");
                    switch (equipmentLevel)
                    {
                        case 2:
                            newEquipment = "ShoulderPad3";
                            break;
                        case 3:
                            newEquipment = "ShoulderPad4";
                            break;
                        case 4:
                            newEquipment = "ShoulderPad5";
                            break;
                        case 5:
                            newEquipment = "ShoulderPad6";
                            break;
                        default:
                            break;
                    }
                    dialogueArray[6] = 6;
                    break;
                case "NPCH":
                    task = task.Replace("\nAsk NPC H for better equipment.", "");
                    switch (equipmentLevel)
                    {
                        case 2:
                            newEquipment = "Glove3";
                            newEquipment2 = "Shoe3";
                            break;
                        case 3:
                            newEquipment = "Glove4";
                            newEquipment2 = "Shoe4";
                            break;
                        case 4:
                            newEquipment = "Glove5";
                            newEquipment2 = "Shoe5";
                            break;
                        case 5:
                            newEquipment = "Glove6";
                            newEquipment2 = "Shoe6";
                            break;
                        default:
                            break;
                    }
                    dialogueArray[7] = 6;
                    break;
                case "NPCI":
                    task = task.Replace("\nAsk NPC I for better equipment.", "");
                    switch (equipmentLevel)
                    {
                        case 2:
                            newEquipment = "Helm4";
                            break;
                        case 3:
                            newEquipment = "Helm5";
                            break;
                        case 4:
                            break;
                        case 5:
                            newEquipment = "Helm7";
                            break;
                        default:
                            break;
                    }
                    dialogueArray[8] = 6;
                    break;
                case "NPCJ":
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 6)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences6;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    break;
                case "NPCB":
                    break;
                case "NPCC":
                    break;
                case "NPCD":
                    break;
                case "NPCE":
                    break;
                case "NPCF":
                    break;
                case "NPCG":
                    break;
                case "NPCH":
                    break;
                case "NPCI":
                    break;
                case "NPCJ":
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 7)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences7;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    //22. 小孩子提示使用弓箭，找 A 兑换弓箭，需要先获得白色头发。对话：B3 A7
                    if (dialogueContent("7666666669")) {
                        dialogueArray[2] = 3;   //开启对话C3
                        task = "Your Task:\nAsk NPC C for a white hair.";
                    }
                    break;
                case "NPCB":
                    break;
                case "NPCC":
                    break;
                case "NPCD":
                    break;
                case "NPCE":
                    break;
                case "NPCF":
                    //21. 向 F 提交任务后，小孩子 B 需要你的帮助，获得任务并尝试通关普通网球场，失败。对话：F7 B2
                    if (dialogueContent("6666676669")) {
                        dialogueArray[1] = 2;    //开启对话B2
                        dialogueArray[5] = 6;
                        task = "Your Task:\nTalk to the kid (NPC B).";
                    }
                    break;
                case "NPCG":
                    break;
                case "NPCH":
                    break;
                case "NPCI":
                    break;
                case "NPCJ":
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 8)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences8;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    //24. 向 C 提交任务并且找 A 兑换弓箭，通关普通网球场。对话：C4 A8
                    if (dialogueContent("8666666669")) {
                        Court14 = true; //开启场14
                        dialogueArray[0] = 6;
                        //newEquipment = "Bow&Arrow";
                        task = "Your Task:\nBeat the enemies on the soccer court.";
                    }
                    break;
                case "NPCB":
                    break;
                case "NPCC":
                    break;
                case "NPCD":
                    break;
                case "NPCE":
                    break;
                case "NPCF":
                    //25. 剧情推进，大魔王复苏倒计时，你去找先知 F，获得任务拜访老人 J。对话：F8
                    if (dialogueContent("6666686669")) {
                        dialogueArray[9] = 2;   //开启对话J2
                        dialogueArray[5] = 6;
                        task = "Your Task:\nFind NPC J and talk to him.";
                    }
                    break;
                case "NPCG":
                    break;
                case "NPCH":
                    break;
                case "NPCI":
                    break;
                case "NPCJ":
                    break;
                default:
                    break;
            }
        }
        else if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F) && t == 9)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences9;
            FindObjectOfType<Dialoguesystem>().NPCName();
            switch (Name)
            {
                case "NPCA":
                    break;
                case "NPCB":
                    break;
                case "NPCC":
                    break;
                case "NPCD":
                    break;
                case "NPCE":
                    break;
                case "NPCF":
                    break;
                case "NPCG":
                    break;
                case "NPCH":
                    break;
                case "NPCI":
                    break;
                case "NPCJ":
                    break;
                default:
                    break;
            }
        }
    }
    

    
    public void OnTriggerExit()
    {
        FindObjectOfType<Dialoguesystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}

