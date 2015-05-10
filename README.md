##**1.Oпис на апликацијата**##

Предмет на оваа апликација е создавање на играта ***Balloon Shooter***. Идејата на целата игра е во пукањето на што повеќе балони, и притоа избегнување на бомбите кои во спротивно даваат негативни поени.
Со цел да обезбедиме поголемо задоволство кај играчот, а воедно и поголем предизвик, имплементиравме и три нивоа на тежина на кои може да се игра играта, секој со соодветни потешкотии да се достигне што подобар резултат.
Времетраењето на самата игра е 1 и пол минута,но тоа се намалува доколку не погодиме некој балон.
Дизајнот на самата игра е во согласно со идејата на самата игра, во кој играчот лесно ќе може да стигне до посакуваната информација (старт на играта, прикажување на листа на најдобри поени, упатство на играта и сл.).

##**2.Упатство за користење**##

###**2.1 Нова игра**###

Почетното мени (сл.1) што се стартува при стартување на играта е со интересен дизајн, кој овозможува стартување на играта ***(Click to play)***, пристап до упатството со правила за игра ***(How to play)***, прикажување на листата на најдобри резултати ***(Best players)***, одбирање на нивото за играта ***(Difficulty)*** и излез од игра ***(Exit game)***.
Доколку сакаме да стартуваме нова игра,прво треба да ја избереме едно од трите нивоа на тежина: Easy, Medium и Hard.
![alt tag](https://scontent-ams.xx.fbcdn.net/hphotos-xpa1/v/t34.0-12/11210164_985430238134256_494889737_n.jpg?oh=8d9efed9f68b3d7e5385b170830b61ca&oe=55525529)

Сл.1

###**2.2 Hоw to play**###

Во оваа форма (Сл.2) се чува упатството кое ги содржи правилата на играта.
![alt tag](https://scontent-ams.xx.fbcdn.net/hphotos-xpt1/v/t34.0-12/11262935_985430678134212_1214505658_n.jpg?oh=5ae4abb72edbaf10e47d440c6aba151b&oe=55528CC0)
Сл.2

###**2.3 High scores**###

Во овој дел (Сл.3) се чува листа на најдобри поени, подредени по опаѓачки редослед.
![alt tag](https://scontent-ams.xx.fbcdn.net/hphotos-xta1/v/t34.0-12/11121760_985430764800870_1022837609_n.jpg?oh=5e30bcb4dc2ef6d9597259d4e1bb3bf9&oe=55518ACC) 
Сл.3

###**2.4 Игра**###

На сл.4 е прикажана интерфејсот на самата игра. Во горниот лев агол постојат копчиња за паузирање на играта и нејзино продолжување на играта, како и за прекинување на играта. На десната страна е сместено преостатаното време, кое се намалува со секој поминат непукнат балон.
![alt tag](https://scontent-ams.xx.fbcdn.net/hphotos-xpf1/v/t34.0-12/11074536_985430891467524_66591867_n.jpg?oh=b1ccc3df80a64b9347f2509cf7d5e444&oe=55527E64) 
Сл.4

###**2.5 Congratulations**###

По истекувањето на времето се појавува форма ***Congratulations***, во која се напишани вкупниот број на освоени поени. Во неа се бара од играчот да го напише неговото име, за да потоа биде ставено во листата на најдобри играчи.

![alt tag](https://scontent-ams.xx.fbcdn.net/hphotos-xpt1/v/t34.0-12/11225961_985425934801353_1497413523_n.jpg?oh=392dc5521384f4f94ea4413b77cb1409&oe=55524BE9)

Сл.5

##**3.Претставување на проблемот**##

###**3.1 Податочни структури и функции**###

Главните податоци и функции за играта се чуваат во ***public class BallList***, која содржи листа на објекти од ***public class Ball***, која претставува основниот објект во целата игра.

```
public class BallList
    {
public List<Ball> Balls { get; set; }
public int points { get; set; }
private SoundPlayer[] sounds;
}
```

Во оваа класа, е сместена функцијата која претставува основна за проверка играчот погодил балон, а со тоа и освоил поени. Оваа функција го користи методот ***isHit(float x,float y)*** од класата ***Ball***, која е објаснета подоле во текстот.
Со креирање на секој балон, тој се додава во главната листа каде се чуваат сите балони видливи за играчот. За секој од балоните (објекти од класата ***Ball***), се чува и ***Boolean Flag***, со која одбележуваме дали балонот е погоден. Потоа, повторно ја изминуваме листата, и овојпат проверуваме дали сме погодиле балон или бомба (и бомба е објект од класата ***Ball***). Aко сме погодиле бомба, се одземаат 5 поени од вкупниот број на поени досега, ако е балон, се додаваат 10 поени. Со секој клик на маусот се генерира и звук, во зависно дали сме погодиле балон или бомба.

```
public void CheckForExplosions(floatx,float y)
        {
for (int i = 0; i<Balls.Count; i++)
            {
for (int j = i + 1; j <Balls.Count; j++)
                {
if (Balls[i].IsHit(x,y))
                    {
                        Balls[i].Flag = true;
                    }
                }
            }
for (int i = Balls.Count - 1; i>= 0; i--)
            {
if (Balls[i].Flag)
                {
if (Balls[i].bomba == true)
                    {
sounds[0].Play();
points -= 5;
                    }
else
                    {
Random random = newRandom();
int ran = random.Next(1, 5);
sounds[ran].Play();
points += 10;
                    }
Balls.RemoveAt(i);
                }
else
                {
sounds[7].Play();
                }   
            }
        }
```
```
public class Ball
    {
public Point Center { get; set; }
public Color Color { get; set; }
public bool bomba { get; set; }
public Image slika { get; set; }
Image [] niza;
public double Velocity { get; set; }
public double Angle { get; set; }
private float velocityX;
private float velocityY;
public bool Flag { get; set; }
public bool IsColided { get; set; }
}
```
Во функцијата ***CheckForExplosions(float x,float y)***, гo користиме методот ***isHit(float x,float y)*** од класата ***Ball***, со која всушност проверуваме дали сме го погодиле балонот. Во оваа проверка ја користиме и позицијата на која кликнал играчот, која ја пренесуваме како аргументи на функцијата.

```
public bool IsHit(float x, float y)
        {
Point nova = newPoint((int)x, (int) y);

if (nova.Y<= (Center.Y + 90) &&nova.Y>= (Center.Y ))
            {
if (nova.X<= (Center.X + 65) &&nova.X>= (Center.X))
return true;
else return false;
            }
else
return false;
}
```
Исто така, имаме ***public class Player***, која го претставува секој играч со името и вкупниот број на освоени поени. Тука ја имаме преоптоварено функцијата ***toString()*** со која се запишува играчот во формат “име – вкупно поени”.

```
public class Player
    {
public string name { get; set; }
public int points { get; set; }
}
public override string ToString()
        {
return this.name + "   -   " + this.points;
        }
        
```

Во класата на основтана форма ***(Form1.cs)*** се сместени сите функции  и настани кои ја прават играта онаква каква што е. Времетраењето на самата игра е 1 и пол минута. Тоа го следиме со поставување на тајмер на самата форма и со секое отчукување на 1 секунда, се генерираат нови балони во зависнот од тежината што играчот ја одбрал. Интересно во овој дел е дека бројот на балоните се зголемува, како што се намалува времето за игра. Па така, до 30тата секунда имаме една брзина на појавување на балоните. Во интервал од 30тата-90тата секунда,појавувањето е побрзо и на крај тоа го достигнува својот максимум. Доколку не е пукнат некој балон, од преостанатото време се одземаат 5 секунди.
Генерирањето на нови балони ја правиме со помош на вградената класа ***Random***, со чија помош ја одредуваме локацијата на која ќе се појави новиот балон. Исто така истата класа ја користиме за да одредиме и каков балон (или бомба) треба да се појави, чувајќи ги сликите од сите балони и бомбата во низа од слики ***(Image [] niza)***.

```
void timer_Tick(object sender, EventArgs e)
        {
doc.MoveBalls();
if (verticalProgressBar1.Value <= 95)
            {
if (doc.CheckMissed())
                {
                    verticalProgressBar1.Value += 5;
                }
            }
else
            {
if (doc.CheckMissed())
                {
                    verticalProgressBar1.Value = 100;
                }
            }
if(nivo.Equals("Easy"))
            {
if (count1 <= 30)
            {
if (count % 25 == 0)
                {
Random random = new Random();
Point newLocation = new Point(random.Next(100, this.width - 230), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                }
            }
else if(count1 > 30 && count < 90)
            {
if (count % 20 == 0)
                {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.Width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                }
            }
else
            {
if (count % 15 == 0)
                {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.Width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                }
            }
          }
else if(nivo.Equals("Medium"))
            {
if (count1 <= 30)
                {
if (count % 20 == 0)
                    {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                    }
                }
else if (count1 > 30 && count < 90)
                {
if (count % 15 == 0)
                    {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.Width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                    }
                }
else
                {
if (count % 10 == 0)
                    {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.Width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                    }
                }
            }
else
            {
if (count1 <= 30)
                {
if (count % 15 == 0)
                    {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                    }
                }
else if (count1 > 30 && count < 90)
                {
if (count % 10 == 0)
                    {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.Width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                    }
                }
else
                {
if (count % 5 == 0)
                    {
Random random = new Random();
Point newLocation = new Point(random.Next(70, this.Width - 150), height);
int x = random.Next(0, 4);
Ball nov = new Ball(newLocation, Color.Red, niza[x]);
if (x == 1)
nov.bomba = true;
doc.AddBall(nov);
                    }
                }
            }
count++;
Invalidate(true);
        }
```
