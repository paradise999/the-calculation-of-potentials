using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        Form2 form = new Form2();
        bool flag = false;
        int month, xmin, xmax, x1 = 0;
        int[] num = new int[4];
        string date, summ, now;
        string[] matrix = new string[13];
        int[] col = new int[13];
        int[] sum = new int[6];
        string[] summd = new string[4];
        int[,] pot = new int[31,13];
        public Form1()
        {
            InitializeComponent();
            DrawGraph();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
                       
        }

        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            pane.XAxis.Title = "Дни";
            pane.YAxis.Title = "Потенциал";
            pane.Title = "График активности";
            pane.XAxis.Min = 0;
            pane.XAxis.Max = 31;
            pane.YAxis.Min = 0;
            pane.YAxis.Max = 10;
            // Создадим список точек
            PointPairList list = new PointPairList();

            

            // Заполняем список точек
            for (int x = 1; x <= xmax; x += 1)
            {
                // добавим в список точку
                list.Add(x, pot[x - 1, x1]);
            }

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться зелёным цветом (Color.Green),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("Sinc", list, Color.Green, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
        }

        private void vivod(string date)
        {
            int c;
            string loc;
            if ((matrix[0] != null) && (matrix[0] != ""))
                form.textBox0.Text = matrix[0];
            else
                form.textBox0.Text = "-";
            if ((matrix[1] != null) && (matrix[1] != ""))
                form.textBox1.Text = matrix[1];
            else
                form.textBox1.Text = "-";
            if ((matrix[2] != null) && (matrix[2] != ""))
                form.textBox2.Text = matrix[2];
            else
                form.textBox2.Text = "-";
            if ((matrix[3] != null) && (matrix[3] != ""))
                form.textBox3.Text = matrix[3];
            else
                form.textBox3.Text = "-";
            if ((matrix[4] != null) && (matrix[4] != ""))
                form.textBox4.Text = matrix[4];
            else
                form.textBox4.Text = "-";
            if ((matrix[5] != null) && (matrix[5] != ""))
                form.textBox5.Text = matrix[5];
            else
                form.textBox5.Text = "-";
            if ((matrix[6] != null) && (matrix[6] != ""))
                form.textBox6.Text = matrix[6];
            else
                form.textBox6.Text = "-";
            if ((matrix[7] != null) && (matrix[7] != ""))
                form.textBox7.Text = matrix[7];
            else
                form.textBox7.Text = "-";
            if ((matrix[8] != null) && (matrix[8] != ""))
                form.textBox8.Text = matrix[8];
            else
                form.textBox8.Text = "-";
            if ((matrix[9] != null) && (matrix[9] != ""))
                form.textBox9.Text = matrix[9];
            else
                form.textBox9.Text = "-";
            if ((matrix[10] != null) && (matrix[10] != ""))
                form.textBox10.Text = matrix[10];
            else
                form.textBox10.Text = "-";
            if ((matrix[11] != null) && (matrix[11] != ""))
                form.textBox11.Text = matrix[11];
            else
                form.textBox11.Text = "-";
            if ((matrix[12] != null) && (matrix[12] != ""))
                form.textBox12.Text = matrix[12];
            else
                form.textBox12.Text = "-";
            form.textBox17.Text = sum[0].ToString(summ);
            form.textBox18.Text = sum[1].ToString(summ);
            form.textBox19.Text = sum[2].ToString(summ);
            form.textBox20.Text = sum[3].ToString(summ);
            form.textBox21.Text = "(" + sum[4].ToString(summ) + ")";
            form.textBox22.Text = "(" + sum[5].ToString(summ) + ")";
            form.textBox13.Text = summd[0];
            form.textBox14.Text = summd[1];
            form.textBox15.Text = summd[2];
            form.textBox16.Text = summd[3];
            if (col[0] < 2) form.textBox0.BackColor = Color.Red;
            else
            {
                if (col[0] > 2) form.textBox0.BackColor = Color.Green;
                else form.textBox0.BackColor = Color.Yellow;
            }
            if (col[1] < 3) form.textBox1.BackColor = Color.Red;
            else
            {
                if (col[1] > 3) form.textBox1.BackColor = Color.Green;
                else form.textBox1.BackColor = Color.Yellow;
            }
            if (col[2] < 3) form.textBox2.BackColor = Color.Red;
            else
            {
                if (col[2] > 3) form.textBox2.BackColor = Color.Green;
                else form.textBox2.BackColor = Color.Yellow;
            }
            if (col[3] < 2) form.textBox3.BackColor = Color.Red;
            else
            {
                if (col[3] > 2) form.textBox3.BackColor = Color.Green;
                else form.textBox3.BackColor = Color.Yellow;
            }
            if (col[4] < 1) form.textBox4.BackColor = Color.Red;
            else
            {
                if (col[4] > 1) form.textBox4.BackColor = Color.Green;
                else form.textBox4.BackColor = Color.Yellow;
            }
            if (col[5] < 1) form.textBox5.BackColor = Color.Red;
            else
            {
                if (col[5] > 1) form.textBox5.BackColor = Color.Green;
                else form.textBox5.BackColor = Color.Yellow;
            }
            if (col[6] < 1) form.textBox6.BackColor = Color.Red;
            else
            {
                if (col[6] > 1) form.textBox6.BackColor = Color.Green;
                else form.textBox6.BackColor = Color.Yellow;
            }
            if (col[7] < 1) form.textBox7.BackColor = Color.Red;
            else
            {
                if (col[7] > 1) form.textBox7.BackColor = Color.Green;
                else form.textBox7.BackColor = Color.Yellow;
            }
            if (col[8] < 1) form.textBox8.BackColor = Color.Red;
            else
            {
                if (col[8] > 1) form.textBox8.BackColor = Color.Green;
                else form.textBox8.BackColor = Color.Yellow;
            }
            if (col[9] < 1) form.textBox9.BackColor = Color.Red;
            else
            {
                if (col[9] > 1) form.textBox9.BackColor = Color.Green;
                else form.textBox9.BackColor = Color.Yellow;
            }
            if (col[10] < 1) form.textBox10.BackColor = Color.Red;
            else
            {
                if (col[10] > 1) form.textBox10.BackColor = Color.Green;
                else form.textBox10.BackColor = Color.Yellow;
            }
            if (col[11] < 1) form.textBox11.BackColor = Color.Red;
            else
            {
                if (col[11] > 1) form.textBox11.BackColor = Color.Green;
                else form.textBox11.BackColor = Color.Yellow;
            }
            if (col[12] < 1) form.textBox12.BackColor = Color.Red;
            else
            {
                if (col[12] > 1) form.textBox12.BackColor = Color.Green;
                else form.textBox12.BackColor = Color.Yellow;
            }
            form.label1.Text = "1.";
            foreach (char a in date)
            {
                if (Int32.TryParse("" + a, out c))
                    form.label1.Text = form.label1.Text + " " + a + " +";
            }
            form.label1.Text = form.label1.Text.Remove(form.label1.Text.Length - 1, 1);
            form.label1.Text = form.label1.Text + "=";
            loc = sum[0].ToString();
            form.label2.Text = "2.";
            if (sum[0] >= 12)
            {
                loc = sum[0].ToString();
                foreach (char a in loc)
                    form.label2.Text = form.label2.Text + " " + a + " +";
                form.label2.Text = form.label2.Text.Remove(form.label2.Text.Length - 1, 1);
                form.label2.Text = form.label2.Text + "=";
            }
            else
                form.label2.Text = form.label2.Text + " x";
            form.label3.Text = "3.";
            form.label3.Text = form.label3.Text + " " + sum[0] + " - " + date[0] + " * 2 =";
            form.label4.Text = "4.";
            if (sum[2] >= 12)
            {                
                loc = sum[2].ToString();
                foreach (char a in loc)
                    form.label4.Text = form.label4.Text + " " + a + " +";
                form.label4.Text = form.label4.Text.Remove(form.label4.Text.Length - 1, 1);
                form.label4.Text = form.label4.Text + "=";
            }
            else
                form.label4.Text = form.label4.Text + " x";
            form.label5.Text = "5.";
            form.label5.Text = form.label5.Text + " " + sum[0] + " + " + sum[2] + " =";
            form.label6.Text = "6.";
            form.label6.Text = form.label6.Text + " " + sum[1] + " + " + sum[3] + " =";
        }

    
    private void chet(char a, char b)
        {
            if (a == '0')
            {
                matrix[0] = matrix[0] + a;
                col[0] = col[0] + 1;
                if (b == '1') { matrix[10] = matrix[10] + '1' + a; col[10] = col[10] + 1; }
                }
            if (a == '1')
            {
                if (b == '1')
                {
                    matrix[11] = matrix[11] + '1' + a;
                    col[11] = col[11] + 1;
                    matrix[1] = matrix[1].Remove(matrix[1].Length - 1);
                    col[1] = col[1] - 1;
                }
                else { matrix[1] = matrix[1] + a; col[1] = col[1] + 1; }
                }
            if (a == '2')
            {
                matrix[2] = matrix[2] + a;
                col[2] = col[2] + 1;
                if (b == '1') { matrix[12] = matrix[12] + '1' + a; col[12] = col[12] + 1; }
            }
            if (a == '3') { matrix[3] = matrix[3] + a; col[3] = col[3] + 1; }
            if (a == '4') { matrix[4] = matrix[4] + a; col[4] = col[4] + 1; }
            if (a == '5') { matrix[5] = matrix[5] + a; col[5] = col[5] + 1; }
            if (a == '6') { matrix[6] = matrix[6] + a; col[6] = col[6] + 1; }
            if (a == '7') { matrix[7] = matrix[7] + a; col[7] = col[7] + 1; }
            if (a == '8') { matrix[8] = matrix[8] + a; col[8] = col[8] + 1; }
            if (a == '9') { matrix[9] = matrix[9] + a; col[9] = col[9] + 1; }
        }
        private void chetdop(char a, char b, char c)
        {
            if (a == '0')
            {
                matrix[0] = matrix[0] + c;
                if (b == '1') matrix[10] = matrix[10] + '1' + c;
                }
            if (a == '1')
            {
                if (b == '1')
                {
                    matrix[11] = matrix[11] + '1' + c;
                    matrix[1] = matrix[1].TrimEnd(c);
                }
                else matrix[1] = matrix[1] + c; 
                }
            if (a == '2')
            {
                matrix[2] = matrix[2] + c;                
                if (b == '1') matrix[12] = matrix[12] + '1' + c;
            }
            if (a == '3') matrix[3] = matrix[3] + c;
            if (a == '4') matrix[4] = matrix[4] + c;
            if (a == '5') matrix[5] = matrix[5] + c; 
            if (a == '6') matrix[6] = matrix[6] + c; 
            if (a == '7') matrix[7] = matrix[7] + c; 
            if (a == '8') matrix[8] = matrix[8] + c; 
            if (a == '9') matrix[9] = matrix[9] + c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x1 = 1;
            DrawGraph();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x1 = 2;
            DrawGraph();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x1 = 3;
            DrawGraph();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            x1 = 4;
            DrawGraph();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            x1 = 5;
            DrawGraph();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            x1 = 6;
            DrawGraph();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            x1 = 7;
            DrawGraph();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            x1 = 8;
            DrawGraph();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            x1 = 9;
            DrawGraph();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            x1 = 10;
            DrawGraph();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            x1 = 11;
            DrawGraph();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            x1 = 12;
            DrawGraph();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            x1 = 0;
            DrawGraph();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            switch (x1)
            {
                case 0:
                    MessageBox.Show("Рядок 0 - минулий досвід у циклі надсистеми\nРівень минулого досвіду - архетип, з якого суб'єкт починає розвиток, ступінь готовності використовувати минулі нагромадження в системних відносинах. Чим більше цифр 0, тим більше багатство минулого досвіду, але велика небезпека прояву консерватизму суб'єкта, тому що він прагне спиратися у своїй активності на минулі нагромадження більше, ніж на розвиток свідомості в сьогоденні; чим менше -навпаки.Консерватизм може виявлятися як проходження в житті звичкам і традиціям, що довели учора свою ефективність, унаслідок чого вони мають сьогодні привабливість подібно \"золоченій клітці\".");
                    break;
                case 1:
                    MessageBox.Show("Квадрат 1 (1-я детермінанта суб'єкта).\nЖиттєва активність, гнучкість у реалізації індивідуальних інтересів, актуалізація, при цьому прояв визначеного ступеня центризму, самости, а також лідерства. Ступінь впливу на навколишнє середовище і, у той же час, залежності від матеріальних факторів у просторі життя; ступінь досконалості матеріального (психофізичного) будівлі і форми організації елементів структури, також творча активність, самоорганізація.");
                    break;
                case 2:
                    MessageBox.Show("Квадрат 2.\nВзаємодії, що народжують емоційно-почуттєвий початок у суб'єкті, простір взаємин, неусвідомлюваний причинність прояву сфери бажань, прагнень, спонтанних імпульсів і ступінь їхнього контролю. Уміння взаємодіяти, правильно організовувати відносини з протилежною підлогою, уміння контролювати свої емоції як наслідок самоприйняття.");
                    break;
                case 3:
                    MessageBox.Show("Квадрат 3.\nДинамізм процесів у житті, вольовий активний початок, сила потяга, воля, рішучість, здібності до мобілізації в діях, практичність як уміння реалізувати здатності; метушливість, егоїзм, визначений рівень агресії як \"надмірна напористість\". Ступінь виразності в людини прагнення до цілеспрямованого придбання знань про навколишній світ, наполегливість і спрямованість у цьому. Це зв'язує детермінанту 3 із творчим відношенням до професії.");
                    break;
                case 4:
                    MessageBox.Show("Квадрат 4.\nЯк причинність взаємодії - ступінь прагнення до новизни, реформам, перетворенням, трансформація свідомості, здатність до зміни  системи, ступінь психічної стійкості, контрастності при прояві якостей суб'єкта в різних ситуаціях. Здатність спонтанно виражати свої почуття. Характеризує імпульсивність, здатність до перетворення старих форм, до нового нестандартного мислення. Відношення підлог (секс); ритм життя, ступінь стійкості нервової системи.");
                    break;
                case 5:
                    MessageBox.Show("Квадрат 5.\nСтупінь розширення свідомості і сфери впливу на навколишній світ, простір включення в усвідомлений вплив і керування перехідним процесом на якісно новий рівень системної структури, організаторські здібності. Визначається ступінь усвідомлення людиною своїх потреб і почуттів, мудрість прийняття життєвих обставин. Витонченість сприйняття навколишнього світу за допомогою удосконалювання взаимоприятия в системних відносинах, здатність до інтеграції. Оригінальність виявлена як можливість творчої реалізації, як організаторські здібності, нестандартність і креативность рішень.Полярний прояв як ступінь перекрученого розуміння творчості, що виражається в станах захопленості, задоволення, насолоди.");
                    break;
                case 6:
                    MessageBox.Show("Квадрат 6.\nТворчі устремління в багаторівневих відносинах, підвищена сензитивность, підсвідоме сприйняття навколишніх причинних системних відносин, креативность творення і керування якісно новими взаємозв'язками, швидке встановлення глибоких контактів з людьми. Для креативных людей - витончена интуитивность, вище відчування; для бездіяльних - вище неуцтво й омани, відсутність знань про шляхи розвитку, нездатність застосування знань для творчості в навколишньому світі, ейфорія, ідеалізація, використання здібностей у сфері почуттєвих ілюзій і матеріальних прагнень. Визначає пошук шляху преосвітнього розвитку, у т.ч. підсвідоме сприйняття гармонії навколишнього світу.");
                    break;
                case 7:
                    MessageBox.Show("Квадрат 7.\nРозумові здібності, інтелектуальна сприйнятливість, товариськість, контактність, заповзятливість, гнучкість розуму в сфері конкретних матеріальних справ і дій, швидкість реакції, чіткість формулювання думок, нестандартність. Визначає творчу спрямованість особистості як здатність до гнучкого креативному мисленню, визначаючи рівень розвитку інтелекту. Ступінь повноти розуміння творчості в матерії, рівень розуміння суті керування матерією, перевага раціонального над ірраціональним.");
                    break;
                case 8:
                    MessageBox.Show("Квадрат 8.\nСистемність, принципи структуризації, здатність до синтезу, ступінь сприйняття єдиної системи розвитку в будь-яких проявах навколишнього світу, здатність створення упорядкованої системи зі стану хаосу, самоконтроль, внутрішня цілісність, стрижень як основа життя, самоаналіз, дисципліна, досвід, стратегічне мислення, у відносинах з колективом - прояв самости, самоізоляція. Здатність суб'єкта оцінити свої якості, що характеризує принцип структуризації системного підходу. Ступінь пізнання мотиву розвитку, прояв самоконтролю, відповідальності, створення передумов прояву творчого мислення, бачення перспективи розвитку, цілісності.");
                    break;
                case 9:
                    MessageBox.Show("Квадрат 9.\nАктивне пізнання конкретних причинних взаємозв'язків, пізнання інтуїтивної, ірраціональної, трансцендентальної свідомості, що синтезує здатність. Ступінь досконалості побудови світоглядних концепцій, мыслеформ. Можливість використовувати накопичений досвід у практичних цілях, активно пізнавати синтезуючі інтуїтивні рівні, усвідомлюючи шляху творчості, прояву эстетического смаку, гармонії, почуття гумору.");
                    break;
                case 10:
                    MessageBox.Show("Квадрат 10.\nЕнергія концентрації волі, спрямованої до трансформації неефективних структур, воля і вплив на великі маси людей. Творча чи руйнівна сила. прагнення до володіння з егоїстичних цілей або креативность керування, виходячи з мети більшої системи. Здатність бачити своє життя цілісної, усвідомлюючи і відчуваючи нерозривність потоку часу життєвих подій. Підвищена конфликтность як початковий і неусвідомлений пошук найбільш ефективного шляху розвитку за допомогою руйнування старої форми недосконалого життя і відновлення відносин через творче колективне мислення.");
                    break;
                case 11:
                    MessageBox.Show("Квадрат 11.\nПідсвідома  активність, що трансформує, трансмутація і перетворення, яскраво виражене прагнення до пізнання спрямованості розвитку надсистеми, сверхдетализация, поглиблення зокрема, часом на шкоду цілому. Здатність до цілісного сприйняття світу і системних відносин з людьми, до розуміння гармонії зв'язку пара протилежностей. Рівень перетворення колективно-несвідомого в колективно-свідоме як здатність до творчого групового мислення, здатність до передбачення майбутніх подій");
                    break;
                case 12:
                    MessageBox.Show("Квадрат 12.\nЗбагнення вищих закономірностей розвитку, розуміння вищої мети, місіонерство. Прагнення до узагальнення, синтезу раціонального й ірраціонального. Невміння жити \"по - новому\", коли старе не відповідає актуальним задачам удосконалювання, конфликтность у колективі. Ступінь незалежності цінностей і поводження суб'єкта від впливу ззовні як здатність народжувати нові структуровані відносини, як взаємодія на новому рівні емоційної чистоти. Це зв'язує детермінанту з емоційністю, эмпатией.");
                    break;

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {           
            form.Show();
        }

        private void chetsum()
        {
            int c;
            int i =0;
            int[] m = new int[4];
            int[] d = new int[4];
            string loc;
            for (int j = 1; j <= 12; j++)
            {
                i = 0;
                if (matrix[j] != null)
                {
                    if (j < 10)
                    {
                        foreach (char a in matrix[j])
                        {
                            if ((Int32.TryParse("" + a, out c) && (i == 0)))
                            {
                                if (j < 4) m[0] = m[0] + c;
                                if ((j < 7) && (j >= 4)) m[1] = m[1] + c;
                                if ((j >= 7) && (j < 10)) m[2] = m[2] + c;

                            }
                            else
                            {
                                i = 1;
                                if (Int32.TryParse("" + a, out c))
                                {
                                    if (j < 4) d[0] = d[0] + c;
                                    if ((j < 7) && (j >= 4)) d[1] = d[1] + c;
                                    if ((j >= 7) && (j < 10)) d[2] = d[2] + c;
                                }
                            }
                        }
                    }
                    if (j == 10)
                    {
                        foreach (char a in matrix[10])
                        {
                            if (Int32.TryParse("" + a, out c) && (i == 0))
                            {
                                if (c == 0) m[3] = m[3] + 10;

                            }
                            else
                            {
                                i = 1;
                                if ((Int32.TryParse("" + a, out c)) && (c == 0))
                                {
                                    d[3] = d[3] + 10;
                                }
                            }
                        }
                    }
                    if (j == 11)
                    {
                        int q = 0;
                        int o = 0;
                        foreach (char a in matrix[11])
                        {
                            if (Int32.TryParse("" + a, out c) && (i == 0))
                            {
                                q = q + 1;
                            }
                            else
                            {                                
                                i = 1;                                
                                if (Int32.TryParse("" + a, out c))
                                {
                                    o = o + 1;
                                }
                            }
                        }
                        m[3] = m[3] + 11 * q / 2;
                        d[3] = d[3] + 11 * o / 2;
                    }
                    if (j == 12)
                    {
                        foreach (char a in matrix[12])
                        {
                            if (Int32.TryParse("" + a, out c) && (i == 0))
                            {
                                if (c == 2) m[3] = m[3] + 12;

                            }
                            else
                            {
                                i = 1;
                                if ((Int32.TryParse("" + a, out c)) && (c == 2))
                                {
                                    d[3] = d[3] + 12;
                                }
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < 4; k++)
            {
                while (m[k] > 12)
                {
                    loc = m[k].ToString();
                    m[k] = 0;
                    foreach (char a in loc) m[k] = m[k] + Int32.Parse("" + a);
                }
                while (d[k] > 12)
                {
                    loc = d[k].ToString();
                    d[k] = 0;
                    foreach (char a in loc) d[k] = d[k] + Int32.Parse("" + a);
                }
                num[k] = m[k];
                summd[k] = m[k].ToString() + "(" + d[k].ToString() + ")";
            }

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
        private void day(string today)
        {
            char b = '0';
            string loc;
            int c;
            date = today;            
            foreach (char a in date)
            {                
                chet(a, b);
                b = a;
                if (Int32.TryParse("" + a, out c)) sum[0] = sum[0] + Int32.Parse("" + a);             
            }         
            if (sum[0] >= 12)
            {
                b = '0';
                loc = sum[0].ToString();
                foreach (char a in loc)
                {
                    sum[1] = sum[1] + Int32.Parse("" + a);
                    chet(a, b);
                    b = a;                    
                }                
            }
            loc = sum[1].ToString();
            b = '0';
            foreach (char a in loc)
            {
                chet(a, b);
                b = a;
            }
            sum[2] = sum[0] - Int32.Parse("" + date[0]) * 2;            
            if (sum[2] >= 12)
            {
                b = '0';
                loc = sum[2].ToString();
                foreach (char a in loc)
                {
                    sum[3] = sum[3] + Int32.Parse("" + a);
                    chet(a, b);
                    b = a;                    
                }                
            }
            loc = sum[3].ToString();
            b = '0';
            foreach (char a in loc)
            {
                chet(a, b);
                b = a;
            }
            sum[4] = sum[0] + sum[2];            
            loc = sum[4].ToString();
            b = '0';
            foreach (char a in loc)
            {
                chetdop(a, b, '(');
                b = a;
            }
            b = '0';
            foreach (char a in loc)
            {
                chet(a, b);
                b = a;
            }
            b = '0';
            foreach (char a in loc)
            {
                chetdop(a, b, ')');
                b = a;
            }
            sum[5] = sum[1] + sum[3];
            loc = sum[5].ToString();
            b = '0';
            foreach (char a in loc)
            {
                chetdop(a, b, '(');
                b = a;
            }
            b = '0';
            foreach (char a in loc)
            {
                chet(a, b);
                b = a;
            }
            b = '0';
            foreach (char a in loc)
            {
                chetdop(a, b, ')');
                b = a;
            }
            chetsum();
        }
        private void clear()
        {
            date = null;
            summ = null;
            for(int l = 0; l <= 12; l++)
            {
                matrix[l] = "";
                col[l] = 0;              
            }
            for (int l = 0; l <= 5; l++)
            {
                sum[l] = 0;
            }
            for (int l = 0; l <= 3; l++)
            {
                summd[l] = "";
            }
            if (flag)
                dataGridView1.Rows.Clear();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            date = textBox14.Text;
            now = date;
            day(date);
            vivod(date);
            string loc1 = "" + date[3] + date[4];
            month = Int32.Parse(loc1);
            if (month % 2 == 0) xmax = 30;
            if (month % 2 != 0) xmax = 31;
            if (month == 2) xmax = 28;            
            for (int v = 1; v < xmax; v++)
            {
                now = now.Remove(0, 2);
                if (v < 10)
                {
                    now = now.Insert(0, "0" + v);
                }
                else
                {
                    now = now.Insert(0, "" + v);
                }
                day(now);
                for (int z = 0; z < 13; z++)
                {
                    pot[v - 1, z] = col[z];
                }                
                clear();
            }
            int w;
            if (month % 2 == 0)
                for (w = 0; w < 13; w++)
                    dataGridView1.Rows.Add(pot[0, w], pot[1, w], pot[2, w], pot[3, w], pot[4, w], pot[5, w], pot[6, w], pot[7, w], pot[8, w], pot[9, w], pot[10, w], pot[11, w], pot[12, w], pot[13, w], pot[14, w], pot[15, w], pot[16, w], pot[17, w], pot[18, w], pot[19, w], pot[20, w], pot[21, w], pot[22, w], pot[23, w], pot[24, w], pot[25, w], pot[26, w], pot[27, w], pot[28, w], pot[29, w]);
            if (month % 2 != 0)
                for (w = 0; w < 13; w++)
                    dataGridView1.Rows.Add(pot[0, w], pot[1, w], pot[2, w], pot[3, w], pot[4, w], pot[5, w], pot[6, w], pot[7, w], pot[8, w], pot[9, w], pot[10, w], pot[11, w], pot[12, w], pot[13, w], pot[14, w], pot[15, w], pot[16, w], pot[17, w], pot[18, w], pot[19, w], pot[20, w], pot[21, w], pot[22, w], pot[23, w], pot[24, w], pot[25, w], pot[26, w], pot[27, w], pot[28, w], pot[29, w], pot[30, w]);
            if (month == 2)
                for (w = 0; w < 13; w++)
                    dataGridView1.Rows.Add(pot[0, w], pot[1, w], pot[2, w], pot[3, w], pot[4, w], pot[5, w], pot[6, w], pot[7, w], pot[8, w], pot[9, w], pot[10, w], pot[11, w], pot[12, w], pot[13, w], pot[14, w], pot[15, w], pot[16, w], pot[17, w], pot[18, w], pot[19, w], pot[20, w], pot[21, w], pot[22, w], pot[23, w], pot[24, w], pot[25, w], pot[26, w], pot[27, w]);
            flag = true;
            DrawGraph();

        }
    }
}

