using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp8
{
    internal class Program
    {
        class Scene
        {
            public void NotYourItem()
            {
                Console.Clear();
                Console.WriteLine("보유중인 아이템이 아닙니다.");
                System.Threading.Thread.Sleep(1000);
            }

            public void UnEquipExit()
            {
                Console.Clear();
                Console.WriteLine("아이템을 착용 해제 하셨습니다.");
                System.Threading.Thread.Sleep(1000);
            }

            public void EquipExit()
            {
                Console.Clear();
                Console.WriteLine("아이템을 착용 하셨습니다.");
                System.Threading.Thread.Sleep(1000);
            }
            public void Exit()
            {
                Console.Clear();
            }
            public void AnotherKey()
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력 입니다. 잠시 후 다시 입력해 주세요.");
                System.Threading.Thread.Sleep(1000);
            }
        }
        class Input
        {
            public string read;
        }
        
        interface IAction
        {
           public void Fight(Player player);
        }

        interface IEquip
        {
            public string isequip(Player player);                      // 착용 했을때 일어날 일 공격력 증가 E출력 등등
            public string unequip(Player player);                     // 착용 해제 할때 일어날 일 E출력해제 
            public void isReSale(Player player);
        }

        class RestRoom
        {
            public void healing(Player player)
            {
                if (player.gold >= 500 && player.hp < 100)
                {
                    Console.Clear();
                    Console.WriteLine("휴식 중 입니다...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("휴식 중 입니다. . .");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("휴식 중 입니다...");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("휴식을 완료했습니다.");
                    System.Threading.Thread.Sleep(1000);
                    
                    player.gold -= 500;
                    player.hp = 100;
                }
                else if (player.hp >= 100)
                {
                    Console.Clear();
                    Console.WriteLine("이미 최대 체력입니다.");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Gold가 부족합니다.");
                    System.Threading.Thread.Sleep(1000);
                }
            }

        }

        class Player : IAction
        {
            public int level;
            public string job;
            public int damage;
            public int shield;
            public int hp;
            public int gold;
            public Player()                             //생성자
            {
                level = 1;
                job = "전사";
                damage = 10;
                shield = 5;
                hp = 100;
                gold = 1500;    
            }
            public void ShowPlayerInfo(List<Item> items)        //이 메서드는 도저히 방법이 생각이 안나서 챗지피티한테 도움 받았습니다.수치만 오르면 되는줄 알았는데
            {                                                   //알고 보니 옆에 (+{아이템스텟})이 있는걸 마지막에 보고 하나 만들었다가 이건 새로 만들다 보니 제출 시간까지 시간도 없어서 도움을 받았습니다. 
                int bonusDamage = 0;                            //덕분에 매개변수에 리스트도 들어간다는걸 배웠습니다. 다른건 전부 제가 만들었습니다!!
                int bonusShield = 0;                            

                foreach (var item in items)
                {
                    if (item.isEquip)
                    {
                        if (item.itemNum == 1) bonusShield += item.status;
                        else bonusDamage += item.status;
                    }
                }

                Console.WriteLine($"Lv. {level}\nChad ( {job} )");

                Console.WriteLine($"공격력 : {damage + bonusDamage} {(bonusDamage > 0 ? $"(+{bonusDamage})" : "")}");
                Console.WriteLine($"방어력 : {shield + bonusShield} {(bonusShield > 0 ? $"(+{bonusShield})" : "")}");
                Console.WriteLine($"체 력 : {hp}");
                Console.WriteLine($"Gold : {gold} G\n");
            }

            public void Fight(Player player)
            {
                Random random = new Random();
                int isClear = random.Next(0, 101);
                int smallDamage = 20 - player.shield;
                int bigDamage = 35 - player.shield;
                int isDamage = random.Next(0, 2);
                int isGold = random.Next(player.damage, player.damage * 2 + 1);
               
                Console.Clear();
                Console.WriteLine("던전 도는중...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("던전 도는중. . .");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("던전 도는중...");
                System.Threading.Thread.Sleep(1000);

                if (player.shield < 5 && isClear <= 40)
                {
                    player.hp = player.hp / 2;
                    Console.Clear();
                    Console.WriteLine("던전 실패 (현재 체력의 절반을 잃었습니다)");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    if (player.level % 2 == 0)
                        player.level++;
                    else
                    {
                        player.damage++;
                        player.level++;
                    }
                   
                    player.gold += 1000 + isGold;
                    player.shield++;
                    Console.Clear();
                    Console.WriteLine("레벨이 올랐습니다.");
                   
                    if (isDamage == 0)
                    {
                        player.hp = player.hp - smallDamage;
                        Console.WriteLine("1000G 를 획득하셨습니다. ");
                        Console.WriteLine($"{isGold}G만큼의 보너스 Gold를 획득하셨습니다.");
                        Console.WriteLine($"작은 타격 ({smallDamage})만큼의 체력을 잃었습니다.");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else if(isDamage == 1)
                    {
                        player.hp = player.hp - bigDamage;
                        Console.WriteLine("1000G 를 획득하셨습니다. ");
                        Console.WriteLine($"{isGold}G만큼의 보너스 Gold를 획득하셨습니다.");
                        Console.WriteLine($"(큰 타격 {bigDamage})만큼의 체력을 잃었습니다.");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }

        }

        class Item : IEquip
        {
            public int itemNum { get; set; }           // 속성은 왜 써야하는지 잘 모르겠습니다!...
            public string itemName;                    // 외부에서 값을 바꾸는걸 막기 위함이라고 했는데 그 개념이 잘 이해가 안갑니다.
            public int status;                         
            public string ex;
            public int price;
            public bool isSale;
            public bool isEquip;

            public string isequip(Player player)        // 착용 했을때 일어날 일 공격력 증가 E출력 등등
            {
                if (itemNum == 1)
                {
                    isEquip = true;
                    player.shield += this.status;
                }
                else
                {
                    isEquip = true;
                    player.damage += this.status;
                }

                return "E";                  
            }
            public string unequip(Player player)        // 착용 해제 할때 일어날 일 스텟해제 E출력해제 
            {
                if (itemNum == 1)
                {
                    isEquip = false;
                    player.shield -= this.status;
                }
                else                           
                {
                    isEquip = false;
                    player.damage -= this.status;
                }

                return " ";                   
            }
            public void isReSale(Player player)
            {
                Scene scene = new Scene();
                if (this.isSale)
                {
                    scene.NotYourItem();
                }
                else
                {
                    this.isSale = true;
                    player.gold += (this.price * 85) / 100;
                    this.isEquip = false;
                   
                    scene.Exit();
                    Console.WriteLine("판매가 완료되었습니다.");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            public void IsSameType(List<Item> items)
            {
                if (items[1].isEquip || items[2].isEquip || items[3].isEquip)
                {
                    Console.Clear();
                    items[1].isEquip = false;
                    items[2].isEquip = false;
                    items[3].isEquip = false;
                  
                    this.isEquip = true;
                    Console.WriteLine("기존 착용중이던 아이템이 해제되었습니다.");
                    System.Threading.Thread.Sleep(1000);
                }
            }

            public Item(int itemNum,string itemName,int status,string ex,int price,bool isSale,bool isEquip)
            {
                this.itemNum = itemNum;
                this.itemName = itemName;
                this.status = status;
                this.ex = ex;
                this.price = price;
                this.isSale = isSale;
                this.isEquip = isEquip;

            }
            public void ShowItemInMyBag()
            {
                string noneE = "";
                string useE = "E";
                if (this.itemNum == 1 && isEquip == true)
                    Console.WriteLine($"[{useE}]-{this.itemNum} {this.itemName}  | 방어력 +{this.status}  | {this.ex}");
                else if(itemNum == 1 && isEquip == false)
                    Console.WriteLine($"[{noneE}]-{this.itemNum} {this.itemName}  | 방어력 +{this.status} | {this.ex}");
                else if (this.itemNum != 1 && isEquip == true)
                    Console.WriteLine($"[{useE}]-{this.itemNum} {this.itemName}  | 공격력 +{this.status} | {this.ex}");
                else if (this.itemNum != 1 && isEquip == false)
                    Console.WriteLine($"[{noneE}]-{itemNum} {itemName}  | 공격력 +{status} | {ex}");

                //if (itemNum == 1 && isEquip == true)
                //    Console.WriteLine($"[{useE}]-{itemNum} {itemName}  | 방어력 +{status} | {ex}");
                //else if (itemNum == 1 && isEquip != true)
                //    Console.WriteLine($"[{noneE}]-{itemNum} {itemName}  | 방어력 +{status} | {ex}");
                //else if (itemNum == 2 && isEquip == true)
                //    Console.WriteLine($"[{useE}]-{itemNum} {itemName}  | 공격력 +{status} | {ex}");
                //else if (itemNum == 2 && isEquip != true)
                //    Console.WriteLine($"[{noneE}]-{itemNum} {itemName}  | 공격력 +{status} | {ex}");
                //else if (itemNum == 3 && isEquip == true)
                //    Console.WriteLine($"[{useE}]-{itemNum} {itemName}  | 공격력 +{status} | {ex}");              처음엔 이렇게 만들었다가 줄일 수 있어보여 줄였습니다.
                //else if (itemNum == 3 && isEquip != true)
                //    Console.WriteLine($"[{noneE}]-{itemNum} {itemName}  | 공격력 +{status} | {ex}");
                //else if (itemNum == 4 && isEquip == true)
                //    Console.WriteLine($"[{useE}]-{itemNum} {itemName}  | 공격력 +{status} | {ex}");
                //else if (itemNum == 4 && isEquip != true)
                //    Console.WriteLine($"[{noneE}]-{itemNum} {itemName}  | 공격력 +{status} | {ex}");
            }
            public void ShowItemInShop()
            {
                if(isSale == true)
                    if (itemNum == 1)
                        Console.WriteLine($"-{itemNum} {itemName}  | 방어력 + {status} | {ex}  |  {price}");
                    else
                        Console.WriteLine($"-{itemNum} {itemName}  | 공격력 + {status} | {ex}  |  {price}");
                else if (isSale == false)
                    {
                    if (isSale == true)
                        Console.WriteLine($"-{itemNum} {itemName}  | 방어력 + {status} | {ex}  |  구매완료");
                    else
                        Console.WriteLine($"-{itemNum} {itemName}  | 공격력 + {status} | {ex}  |  구매완료");
                }
            }
        }

        static void Main(string[] args)
        {
            bool isGameOn = true;
            Scene scene = new Scene();
            Input input = new Input();
            Player player1 = new Player();
            List<Item> itemlist = new List<Item>();
            RestRoom restRoom = new RestRoom();

            itemlist.Add(new Item(1, "무쇠갑옷     ",5, "수련에 도움을 주는 갑옷입니다.", 1000, true, false));
            itemlist.Add(new Item(2, "스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 800, true, false));
            itemlist.Add(new Item(3, "낡은 검      ", 2, "쉽게 볼 수 있는 낡은 검입니다.", 600, true, false));
            itemlist.Add(new Item(4, "기사의 검    ", 12, "기사 계급이 사용하던 양날 한손검 입니다", 1200, true, false));
            player1.gold = 10000000;
            
            while (isGameOn)
            {
/*메인화면*/    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.Write("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 휴식하기\n5. 던전입장\n\n0. 게임종료 \n\n원하시는 행동을 입력해주세요.\n>>");
                input.read = Console.ReadLine();

                switch (input.read)
                {       
                        //상태보기
 /*상태화면*/           case "1" :
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("상태보기\n캐릭터의 정보가 표시됩니다\n");
                            player1.ShowPlayerInfo(itemlist);
                            Console.Write("\n\n0. 나가기\n\n원하시는 행동을 입력해 주세요.\n>>");
                            input.read = Console.ReadLine();

                            if (input.read != "0")
                                scene.AnotherKey();
                            else
                            {
                                scene.Exit();
                                break;
                            }
                        }
                        break;
                    //인벤토리
                    case "2":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
                            Console.Write("1. 장착 관리\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                            input.read = Console.ReadLine();

                            switch (input.read)
                            {
 /*장착관리*/                       case "1":
                                    if (itemlist[0].isSale == false || itemlist[1].isSale == false || itemlist[2].isSale == false || itemlist[3].isSale == false)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("인벤토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n");
                                        Console.WriteLine("[아이템 목록]\n");
                                        
                                        foreach (Item item in itemlist)
                                        {
                                            if (item.isSale == false)
                                                item.ShowItemInMyBag();
                                        }
                                       
                                        Console.Write("\n\n0. 나가기\n\n\n장착 혹은 해제할 아이템 번호를 입력해 주세요.\n>>");
                                        input.read = Console.ReadLine();
                                       
                                        switch (input.read)
                                        {
                                            case "1":
                                                if (!itemlist[0].isEquip && !itemlist[0].isSale)
                                                {
                                                    itemlist[0].isequip(player1);
                                                    itemlist[0].ShowItemInMyBag();
                                                    scene.EquipExit();
                                                    break;
                                                }
                                                else if (itemlist[0].isEquip && !itemlist[0].isSale)
                                                {
                                                    itemlist[0].unequip(player1);
                                                    scene.UnEquipExit();
                                                }
                                                else scene.NotYourItem();
                                                break;
                                            case "2":
                                                if (!itemlist[1].isEquip && !itemlist[1].isSale)
                                                {
                                                    itemlist[1].IsSameType(itemlist);
                                                    itemlist[1].isequip(player1);
                                                    itemlist[1].ShowItemInMyBag();
                                                    scene.EquipExit();
                                                    break;
                                                }
                                                else if (itemlist[1].isEquip && !itemlist[1].isSale)
                                                {
                                                    itemlist[1].unequip(player1);
                                                    scene.UnEquipExit();
                                                }
                                                else scene.NotYourItem();
                                                break;
                                            case "3":
                                                if (!itemlist[2].isEquip && !itemlist[2].isSale)
                                                {
                                                    itemlist[2].IsSameType(itemlist);
                                                    itemlist[2].isequip(player1);
                                                    itemlist[2].ShowItemInMyBag();
                                                    scene.EquipExit(); 
                                                    break;
                                                }
                                                else if (itemlist[2].isEquip && !itemlist[2].isSale)
                                                {
                                                    itemlist[2].unequip(player1);
                                                    scene.UnEquipExit();
                                                }
                                                else scene.NotYourItem(); 
                                                break;
                                            case "4":
                                                if (!itemlist[3].isEquip && !itemlist[3].isSale)
                                                {
                                                    itemlist[3].IsSameType(itemlist);
                                                    itemlist[3].isequip(player1);
                                                    itemlist[3].ShowItemInMyBag();
                                                    scene.EquipExit();
                                                    break;
                                                }
                                                else if (itemlist[3].isEquip && !itemlist[3].isSale)
                                                {
                                                    itemlist[3].unequip(player1);
                                                    scene.UnEquipExit();
                                                }
                                                else scene.NotYourItem();
                                                break;
                                            case "0":
                                                scene.Exit();
                                                break;
                                            default:
                                                scene.AnotherKey();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("보유중인 아이템이 없습니다. 상점에서 구매 후 이용해 주세요.");
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                    break;
                                case "0":
                                    scene.Exit();
                                    break;
                                default:
                                    scene.AnotherKey();
                                    break;
                            }
                            if (input.read == "0") break;
                        }
                            break;
                        //상점
 /*상점*/               case "3":
                        Console.Clear();
                        Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.");
                        Console.WriteLine($"\n[보유 골드]\n{player1.gold}G\n\n[아이템 목록]");
                        
                        foreach (Item item in itemlist)
                        {
                            item.ShowItemInShop();
                        }

                        Console.Write("\n\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                        input.read = Console.ReadLine();

                        switch(input.read)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("\n\n[아이템 리스트]\n\n");
                              
                                foreach (Item item in itemlist)
                                {
                                    item.ShowItemInShop();
                                }
                              
                                Console.Write("\n\n구매하실 아이템 번호를 입력해주세요.\n>>");
                                input.read = Console.ReadLine();

                                switch (input.read)
                                {
 /*상점 구매*/                          case "1":
                                        if (itemlist[0].isSale == true && player1.gold >= 1000)
                                        {
                                            itemlist[0].isSale = false;
                                            player1.gold -= 1000;
                                            scene.Exit();
                                            Console.WriteLine($"구매하신 아이템 : {itemlist[0].itemName}");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else if (itemlist[0].isSale == true && player1.gold < 1000)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("보유하신 Gold가 부족합니다.");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else
                                            scene.Exit();
                                            Console.WriteLine("이미 구매한 아이템 입니다.");
                                            System.Threading.Thread.Sleep(1000);
                                        break;
                                        case "2":
                                        if (itemlist[1].isSale == true && player1.gold >= 800)
                                        {
                                            itemlist[1].isSale = false;
                                            player1.gold -= 800; 
                                            scene.Exit();
                                            Console.WriteLine($"구매하신 아이템 :{itemlist[1].itemName}");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else if (itemlist[1].isSale == true && player1.gold < 800)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("보유하신 Gold가 부족합니다.");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else
                                            scene.Exit();
                                            Console.WriteLine("이미 구매한 아이템 입니다.");
                                            System.Threading.Thread.Sleep(1000);
                                        break;
                                    case "3":
                                        if (itemlist[2].isSale == true && player1.gold >= 600)
                                        {
                                            itemlist[2].isSale = false;
                                            player1.gold -= 600;
                                            scene.Exit();
                                            Console.WriteLine($"구매하신 아이템 :{itemlist[2].itemName}");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else if (itemlist[2].isSale == true && player1.gold < 600)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("보유하신 Gold가 부족합니다.");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else
                                            scene.Exit();
                                            Console.WriteLine("이미 구매한 아이템 입니다.");
                                            System.Threading.Thread.Sleep(1000);
                                        break;
                                    case "4":
                                        if (itemlist[3].isSale == true && player1.gold >= 1200)
                                        {
                                            itemlist[3].isSale = false;
                                            player1.gold -= 600;
                                            scene.Exit();
                                            Console.WriteLine($"구매하신 아이템 :{itemlist[3].itemName}");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else if (itemlist[3].isSale == true && player1.gold < 1200)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("보유하신 Gold가 부족합니다.");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                        }
                                        else
                                            scene.Exit();
                                        Console.WriteLine("이미 구매한 아이템 입니다.");
                                        System.Threading.Thread.Sleep(1000);
                                        break;
                                    case "0":
                                        scene.Exit();
                                        break;
                                    default:
                                        scene.AnotherKey();
                                        break;
                                }
                                break;
  /*상점 판매*/                 case "2":
                                Console.Clear();
                                Console.WriteLine("\n\n[아이템 리스트]\n\n");
                               
                                foreach (Item item in itemlist)
                                {
                                    item.ShowItemInShop();
                                }
                               
                                Console.Write("\n\n판매하실 아이템 번호를 입력해주세요.\n>>");
                                input.read = Console.ReadLine();
                               
                                switch (input.read)
                                {
                                    case "1":
                                        if (itemlist[0].isSale || !itemlist[0].isSale)
                                        {
                                            itemlist[0].isReSale(player1);
                                            break;
                                        }
                                        break;
                                    case "2":
                                        if (itemlist[1].isSale || !itemlist[1].isSale)
                                        {
                                            itemlist[1].isReSale(player1);
                                            break;
                                        }
                                        break;
                                    case "3":
                                        if (itemlist[2].isSale || !itemlist[2].isSale)
                                        {
                                            itemlist[2].isReSale(player1);
                                            break;
                                        }
                                        break;
                                    case "4":
                                        if (itemlist[3].isSale || !itemlist[3].isSale)
                                        {
                                            itemlist[3].isReSale(player1);
                                            break;
                                        }break;
                                    case "0":
                                        Console.Clear();
                                        scene.Exit();
                                        break;
                                    default:
                                        scene.AnotherKey();
                                        break;
                                }
                                break; //케이스2 브레이크
                            case "0":
                                Console.Clear();
                                scene.Exit();
                                break;
                            default:
                                scene.AnotherKey();
                                break;
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine($"\n휴식하기\n\n500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 {player1.gold} G)");
                        Console.WriteLine("\n1.휴식하기\n0. 나가기");
                        Console.Write("\n원하시는 행동을 입력해주세요.\n >> ");
                        input.read = Console.ReadLine();
                          
                        switch (input.read)
                            {
                                case "1":
                                    restRoom.healing(player1);
                                    break;
                                case "0":
                                    Console.Clear();
                                    scene.Exit();
                                    break;
                                default:
                                    scene.AnotherKey();
                                    break;
                            }
                        break;
/*던전 입장*/           case "5":
                        Console.Clear();
                        Console.WriteLine("던전입장\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                        Console.Write("\n\n1. 쉬운 던전     | 방어력 5 이상 권장\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                        input.read = Console.ReadLine();

                        switch (input.read)
                        {
                            case "1":
                                player1.Fight(player1);
                                if (player1.hp < 0)
                                {
                                    isGameOn = false;
                                    Console.WriteLine("캐릭터가 죽었습니다.\n게임이 종료되었습니다.");
                                }
                                break;
                                case "0":
                                scene.Exit();
                                break;
                                default:
                                scene.AnotherKey();
                                break;
                        }
                        break; // case5 브레이크
                    case "0":
                        Console.Clear();
                        isGameOn = false;
                        Console.WriteLine("게임이 종료 되었습니다.");
                        break;
                    default:
                        scene.AnotherKey();
                        break;
                }
            }
        }
    }
}
