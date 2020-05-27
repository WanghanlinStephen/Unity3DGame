这个版本加入了剧情推进 任务获取及完成 和装备获取
（操作方式：T： 查看任务 再按取消
E：把背包里的装备print在console里（现有背包容量不够导致后面的装备看不见 先知道现在有的装备可以先这样查看）
Z/X/C/V：通过目前允许进入的最高级篮球/足球/网球/排球场 ）


对人物说的话（Sentences）进行了些许改动 如果之后要再改动谈话内容请注意：
！！！只要Sentence的size=1，请不要再扩大size，否则可能会有小bug出现！！！
（不影响游戏运行 但是多出的对话可能会看不到 转而看到下一个对话的第二句）
（只是小部分句子存在的bug）

任务显示方式很简单（就是把一个string打出来而已） 
在GUIScript里面 这个script附加给了Hero 若想对显示方式改进就在这里修改




接下来是与其他部分的联动 先是装备：
全部需要的装备名字如下：
头发Hair1 Hair3 Hair5
背包Belt1 Belt2 Belt3 BackPack1 BackPack2 BackPack3 
衣服Cloth1 Cloth2 Cloth3 Cloth4 Cloth5 Cloth6 
肩甲ShoulderPad1-6 
手套Glove1-6
鞋子Shoe1-6
头盔Helm1 Helm4-7
其中初始装备为Hair1 Belt1(这个看上去不太像背包 对于剧情那部分影响不大) Cloth1 ShoulderPad1 Glove1 Shoe1
而武器部分目前动作问题没解决 之后再定 目前暂时起名为：
Weapon1 ... Weapon5 Bow&Arrow
现在获得他们后 背包会显示白格子

装备等级	出门装	1级	2级 	3级		4（高）级		5（神）级
武器	Weapon0 Weapon1 Weapon2 Weapon3 	Weapon4 	Weapon5  	// Bow&Arrow			
头发	Hair1 									// Hair3（白） Hair5（红）
背包	Belt1 	Belt2 	Belt3 	BackPack1 	BackPack2 	BackPack3 
衣服	Cloth1 	Cloth2 	Cloth3 	Cloth4 		Cloth5 		Cloth6 
肩甲	SP1	SP2	SP3	SP4		SP5		SP6		//SP: ShoulderPad
手套	Glove1	Glove2	Glove3	Glove4		Glove5		Glove6
鞋子	Shoe1	Shoe2	Shoe3	Shoe4		Shoe5		Shoe6	
头盔		Helm1 	Helm4	Helm5		Helm6		Helm7	









然后是打怪 这部分与whl的部分结合
目前为了推进剧情用ZXCV直接通过（或尝试通过并失败）最高级的球场 之后要用打怪来代替
再Class NPC里面有一些public static bool来判断是否进场 进什么难度的场 以及是否通关（或尝试通过并失败）：
basketballCourt1 	basketballCourt1Passed
basketballCourt2 	basketballCourt2Passed
...
basketballCourt8 	basketballCourt8Passed
soccerCourt1 	soccerCourt1Passed
...
soccerCourt8 	soccerCourt8Passed
tennisCourt1 	tennisCourt1Failed
...
tennisCourt8 	tennisCourt8Passed
volleyballCourt1 	volleyballCourt1Failed
volleyballCourt2 	volleyballCourt2Passed
volleyballCourt3 	volleyballCourt3Passed
只有tennisCourt1 tennisCourt5 volleyballCourt1 想要玩家Fail



最后附上剧情 在大纲2.0的基础上做出了些许改动：

A武器 B小孩 C染发 D背包 E衣服 F先知 G肩甲 H手套鞋子 I头盔 J大boss
（大原则：不完成前一个任务，下一个任务不会解锁）
1. 在出生地出现，先找 A 获得第一个任务「寻找孩子」，并获得Weapon0。对话：A
2. 通过 B 得知孩子在篮球场1。对话：B
3. 进入篮球场1，完成打斗教程，击杀怪物及 boss，出现孩子。
4. 找到到 A 完成任务，开启武器兑换系统，获得讯息要去寻找先知 F。对话：A1
5. F 需要任务穿上白色衣服，去找到 E，获得任务。对话：F E
6. 任务需要找到 D 先获得一个背包，D 给出新任务。对话：D
7. 前往足球场1击杀小怪及 boss，并回到 D 处获得一级背包Belt2。对话：D1
8. 回到 E 处获得白色衣服Cloth2，开启衣服兑换系统。对话：E1
9. F 说必须杀死大魔王才能离开这个世界，不然会永远留在这里，叫你去找 I 变强。对话：F1
10. I 要求你去网球场1证明自己，你完全无法通关，回到 I 处获得一个头盔Helm1，
并开启兑换系统，I 告诉你要去找 G 及 H 及 A 寻求帮助。对话：I I1
11. G 发布任务，要求通过篮球场2来换取第一级肩甲ShoulderPad1，完成后G让你找H。对话：G G1
12. H 发布任务，要求通过足球场2来换取第一级手套及鞋子Glove1 Shoe1，完成后H让你找A。对话：H H1
13. A 发布任务，要求通过篮球场3来换取第一级武器Weapon1。对话：A2
14. 完成后，让你网球场2通关。对话：A3
15. 先知 F 叫你去找他，需要你先获得红色头发Hair5，才能接任务。对话：F2
16. 回到 C 处，获得红色头发兑换条件，需获得第二级的装备（武器为锤子）。对话：C

17. 前往不同的 NPC 处获得兑换任务并完成。（通关副本篮4足3网3）
（然后获得二级的Weapon Belt/BackPack Cloth ShoulderPad Glove Shoe Helm）
18. 去 C 处获得红色头发并寻找先知 F，获得任务尝试通关篮球场5。对话：C1 F3
19. 回到 F 处提交任务，获得怪物增强的消息，需要通知各个 NPC。对话：F4

20. 找到各个 NPC 并且领取任务 通过球场篮6足4网4即获得第三级装备，回到先知 F 处交任务，获得新任务通关足球场5。对话：F5
21. 向 F 提交任务后，小孩子 B 需要你的帮助，获得任务并尝试通关网球场5，失败。对话：F7 B2
22. 小孩子提示使用弓箭，找 A 兑换弓箭，需要先获得白色头发。对话：B3 A7
23. 找到 C 获得白色头发任务，通关普通足球场6。对话：C3
24. 向 C 提交任务获得白色头发Hair3并且找 A 兑换弓箭Bow&Arrow，通关网球场6。对话：C4 A8
25. 剧情推进，大魔王复苏倒计时，你去找先知 F，获得任务拜访老人 J。对话：F8
26. 老人 J 要求你通关网球场7然后找 I。对话：J2
27. I 给予你4级头盔，叫你去找不同的人增强自己。对话：I2

28. 找不同 NPC 获得（除头盔）4级装备，需要通关副本篮7足7网8。
29. 通关噩梦网球场后去拜访老人 J，他叫你去排球场1跟其他人对战提升自己，但失败。对话：J3

30. 给出提示前往NPC处获得神级装备（需要通关副本篮8足8网9），之后通关排球场2。
31. 完成后向老人 J 提交任务，发现他就是大魔王，开启最终 boss(排球场3)。对话：J4
