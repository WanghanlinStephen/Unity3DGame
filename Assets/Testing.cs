using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public string d, od;
    public string getDialogueArray()
    {
        string dialogue = "";
        foreach (var i in NPC.dialogueArray) dialogue += (i.ToString());
        return dialogue;
    }

    // Start is called before the first frame update
    void Start()
    {
        od = getDialogueArray();
        print(od);
    }

    // Update is called once per frame
    void Update()
    {
        if (NPC.Court1Passed && NPC.dialogueContent("0099999999"))
        {
            NPC.dialogueArray[0] = 1;      //通过场1则可触发A1对话
            NPC.dialogueArray[1] = 6;
            NPC.task = "Your Task:\nTell NPC A that you have found the child.";
        }
        if (NPC.Court2Passed && NPC.dialogueContent("6690009999"))
        {
            NPC.dialogueArray[3] = 1;      //通过场2则可触发D1对话
            NPC.task = "Your Task:\nTell NPC D that you have killed the monsters.";
        }
        if (NPC.Court3Failed && NPC.dialogueContent("6696669909"))
        {
            NPC.dialogueArray[8] = 1;       //尝试场3并失败则可触发I1对话
            NPC.task = "Your Task:\nBack to NPC I to ask for help.";
        }
        if (NPC.Court4Passed && NPC.dialogueContent("6696660969"))
        {
            NPC.dialogueArray[6] = 1;      //通过场4则可触发G1对话
            NPC.task = "Your Task:\nTell NPC G that you have completed the task.";
        }
        if (NPC.Court5Passed && NPC.dialogueContent("6696666069"))
        {
            NPC.dialogueArray[7] = 1;      //通过场5则可触发H1对话
            NPC.task = "Your Task:\nTell NPC H that you have completed the task.";
        }
        if (NPC.Court6Passed && NPC.dialogueContent("2696666669"))
        {
            NPC.dialogueArray[0] = 3;      //通过场6则可触发A3对话
            NPC.task = "Your Task:\nTell NPC A that you have completed the task.";
        }
        if (NPC.Court7Passed && NPC.dialogueContent("3696666669"))
        {
            NPC.dialogueArray[5] = 2;      //通过场7则可触发F2对话
            NPC.task = "Your Task:\nTalk to NPC F.";
        }
        if (NPC.Court8Passed && NPC.dialogueContent("4606626669"))
        {
            NPC.dialogueArray[0] = 5;      //通过场8则可触发A5 D5 E5 G5 H5 I5对话
            NPC.dialogueArray[3] = 5;
            NPC.dialogueArray[4] = 5;
            NPC.dialogueArray[6] = 5;
            NPC.dialogueArray[7] = 5;
            NPC.dialogueArray[8] = 5;
            NPC.task = "Your Task:\nAsk NPC A for better equipment.\nAsk NPC D for better equipment.\nAsk NPC E for better equipment.\nAsk NPC G for better equipment.\nAsk NPC H for better equipment.\nAsk NPC I for better equipment.";
        }
        if (NPC.dialogueContent("6606626669") && NPC.Court8Passed)
        {
            NPC.dialogueArray[2] = 1;      //获得全部二级装备则触发C1对话
            NPC.task = "Your Task:\nTell NPC C that you have got better equipment.";
        }

        if (NPC.Court9Passed && NPC.dialogueContent("6666636669"))
        {
            NPC.dialogueArray[5] = 4;      //通过场9则可触发F4对话
            NPC.task = "Your Task:\nTell NPC F that you have completed the task.";
        }

        if (NPC.Court10Passed && NPC.dialogueContent("4666646669"))
        {
            NPC.dialogueArray[0] = 5;      //通过场10则可触发A5 D5 E5 G5 H5 I5对话
            NPC.dialogueArray[3] = 5;
            NPC.dialogueArray[4] = 5;
            NPC.dialogueArray[6] = 5;
            NPC.dialogueArray[7] = 5;
            NPC.dialogueArray[8] = 5;
            NPC.task = "Your Task:\nAsk NPC A for better equipment.\nAsk NPC D for better equipment.\nAsk NPC E for better equipment.\nAsk NPC G for better equipment.\nAsk NPC H for better equipment.\nAsk NPC I for better equipment.";
        }
        if (NPC.dialogueContent("6666646669") && NPC.Court10Passed)
        {
            NPC.dialogueArray[5] = 5;      //获得全部三级装备则触发F5对话
            NPC.task = "Your Task:\nTell NPC F that you have got better equipment.";
        }

        if (NPC.Court11Passed && NPC.dialogueContent("6666656669"))
        {
            NPC.dialogueArray[5] = 7;      //通过场11则可触发F7对话
            NPC.task = "Your Task:\nTell NPC F that you have completed the task.";
        }
        if (NPC.Court12Failed && NPC.dialogueContent("6266666669"))
        {
            NPC.dialogueArray[1] = 3;       //尝试场12并失败则可触发B3对话
            NPC.task = "Your Task:\nTalk to NPC B.";
        }
        if (NPC.Court13Passed && NPC.dialogueContent("7636666669"))
        {
            NPC.dialogueArray[2] = 4;      //通过场13则可触发C4对话
            NPC.task = "Your Task:\nTell NPC C that you have completed the task.";
        }
        if (NPC.Court14Passed && NPC.dialogueContent("6666666669"))
        {
            NPC.dialogueArray[5] = 8;      //通过场14则可触发F8对话
            NPC.task = "Your Task:\nAsk NPC F what happened.";
        }
        if (NPC.Court15Passed && NPC.dialogueContent("6666666662"))
        {
            NPC.dialogueArray[8] = 2;      //通过场15则可触发I2对话
            NPC.task = "Your Task:\nTalk to NPC I and ask for better equipment.";
        }
        if (NPC.Court16Passed && NPC.dialogueContent("4666666666"))
        {
            NPC.dialogueArray[0] = 5;      //通过场16则可触发A5 D5 E5 G5 H5对话
            NPC.dialogueArray[3] = 5;
            NPC.dialogueArray[4] = 5;
            NPC.dialogueArray[6] = 5;
            NPC.dialogueArray[7] = 5;
            NPC.task = "Your Task:\nAsk NPC A for better equipment.\nAsk NPC D for better equipment.\nAsk NPC E for better equipment.\nAsk NPC G for better equipment.\nAsk NPC H for better equipment.";
        }
        if (NPC.dialogueContent("6666666666") && NPC.Court16Passed)
        {
            NPC.dialogueArray[9] = 3;      //获得全部四级装备则触发J3对话
            NPC.task = "Your Task:\nTell NPC J that you have got better equipment.";
        }
        if (NPC.Court17Failed && NPC.dialogueContent("6666666663"))
        {
            NPC.dialogueArray[9] = 7;   //尝试排球场1并失败则可J7对话（停滞,J7对剧情推进无实际意义）
            NPC.dialogueArray[0] = 4;    //开启对话A4
            NPC.equipmentLevel = 5;      //五级装备任务
            NPC.task = "Your Task:\nAsk NPC A to improve your equipment.";
        }
        if (NPC.Court18Passed && NPC.dialogueContent("4666666667"))
        {
            NPC.dialogueArray[0] = 5;      //通过场18则可触发A5 D5 E5 G5 H5 I5对话
            NPC.dialogueArray[3] = 5;
            NPC.dialogueArray[4] = 5;
            NPC.dialogueArray[6] = 5;
            NPC.dialogueArray[7] = 5;
            NPC.dialogueArray[8] = 5;
            NPC.task = "Your Task:\nAsk NPC A for better equipment.\nAsk NPC D for better equipment.\nAsk NPC E for better equipment.\nAsk NPC G for better equipment.\nAsk NPC H for better equipment.\nAsk NPC I for better equipment.";
        }
        if (NPC.dialogueContent("6666666667") && NPC.Court18Passed)
        {
            NPC.Court19 = true;             //开启场19
            NPC.task = "Your Task:\nBeat the enemies on the soccer court.";
        }
        if (NPC.Court19Passed && NPC.dialogueContent("6666666667"))
        {
            NPC.dialogueArray[9] = 4;       //通过场19则可触发J4对话
            NPC.task = "Your Task:\nTell NPC J that you have completed the task.";
        }
        if (NPC.Court20Passed && NPC.dialogueContent("6666666664"))
        {
            NPC.task = "Your Task:\nGAME OVER. CONGRATULATIONS.";
        }


        d = getDialogueArray();
        if (d != od) {
            print(d);
            od = d;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (NPC.Court20)
            {
                NPC.Court20Passed = true;
                print("Court20Passed");
            }
            else if (NPC.Court19)
            {
                NPC.Court19Passed = true;
                print("Court19Passed");
            }
            else if (NPC.Court18)
            {
                NPC.Court18Passed = true;
                print("Court18Passed");
            }
            else if (NPC.Court17)
            {
                NPC.Court17Failed = true;
                print("Court17Failed");
            }
            else if (NPC.Court16)
            {
                NPC.Court16Passed = true;
                print("Court16Passed");
            }
            else if (NPC.Court15)
            {
                NPC.Court15Passed = true;
                print("Court15Passed");
            }
            else if (NPC.Court14)
            {
                NPC.Court14Passed = true;
                print("Court14Passed");
            }
            else if (NPC.Court13)
            {
                NPC.Court13Passed = true;
                print("Court13Passed");
            }
            else if (NPC.Court12)
            {
                NPC.Court12Failed = true;
                print("Court12Failed");
            }
            else if (NPC.Court11)
            {
                NPC.Court11Passed = true;
                print("Court11Passed");
            }
            else if (NPC.Court10)
            {
                NPC.Court10Passed = true;
                print("Court10Passed");
            }
            else if (NPC.Court9)
            {
                NPC.Court9Passed = true;
                print("Court9Passed");
            }
            else if (NPC.Court8)
            {
                NPC.Court8Passed = true;
                print("Court8Passed");
            }
            else if (NPC.Court7)
            {
                NPC.Court7Passed = true;
                print("Court7Passed");
            }
            else if (NPC.Court6)
            {
                NPC.Court6Passed = true;
                print("Court6Passed");
            }
            else if (NPC.Court5)
            {
                NPC.Court5Passed = true;
                print("Court5Passed");
            }
            else if (NPC.Court4)
            {
                NPC.Court4Passed = true;
                print("Court4Passed");
            }
            else if (NPC.Court3)
            {
                NPC.Court3Failed = true;
                print("Court3Failed");
            }
            else if (NPC.Court2)
            {
                NPC.Court2Passed = true;
                print("Court2Passed");
            }
            else if (NPC.Court1)
            {
                NPC.Court1Passed = true;
                print("Court1Passed");
            }
        }
    }
}
