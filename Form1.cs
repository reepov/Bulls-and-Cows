using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net;

namespace Быки_и_Коровы_
{
    public partial class Form1 : Form
    {
        bool logic = true;              // инициализация необходимых элементов
        int? [] var = new int?[4];
        public Button[] buttons;
        int[] c = new int[4];
        int Byki = 0;
        int Korovy = 0;

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false; // Запрет на расширение в полный экран
            this.Text = "Быки и Коровы!"; // Название формы
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           this.BackgroundImage = new Bitmap(Properties.Resources.RULE); // Установка фонового изображения начальной заставки
            richTextBox1.Font = new Font(richTextBox1.Text, 100); // Изменение размера шрифта
            richTextBox2.Font = new Font(richTextBox1.Text, 18);
            buttons = new Button [] { button1, button2, button3, button4, button5, button6, button7, button8, button9, 
                                            button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22};
            for (int i = 0; i < buttons.Length; i++)
            { 
                buttons[i].Visible = false; // Видимость кнопок
            }
            richTextBox1.Visible = false;
            richTextBox2.Visible = false;
            timer2.Interval = 5000; // Таймер на 5 секунд
            timer1.Interval = 38000; // Таймер на 37 секунд
            timer2.Enabled = true; // Таймер включен
            timer1.Enabled = true; // Таймер включен
            timer1.Start(); // Таймер запущен
            timer2.Start(); // Таймер запущен
            SoundPlayer simpleSound = new SoundPlayer(); // обьявление переменной класса SoundPlayer
            simpleSound.Stream = Properties.Resources.Main; // Чтение аудио из Ресурсов формы
            simpleSound.Play(); // Циклическое повторение аудио
        }
        private void button1_Click(object sender, EventArgs e) // Начать игру
        {
            this.BackgroundImage = new Bitmap(Properties.Resources.b); // Установка фонового изображения поля игры
            button1.Visible = false; // Невидимость/видимость кнопок
            button2.Visible = true;
            button3.Visible = false;
            button6.Visible = false;
            for (int i = 9; i < 20; i++)
            {
                buttons[i].Visible = true;
            }
            richTextBox1.Visible = true;
            richTextBox2.Visible = true;
            Random rand = new Random();
            c[0] = rand.Next(0, 9);
            c[1] = rand.Next(0, 9);
            while (c[1] == c[0])
                c[1] = rand.Next(0, 9);
            c[2] = rand.Next(0, 9);
            while (c[2] == c[1] || c[2] == c[0])
                c[2] = rand.Next(0, 9);
            c[3] = rand.Next(0, 9);
            while (c[3] == c[2] || c[3] == c[1] || c[3] == c[0])
                c[3] = rand.Next(0, 9);
        }
        private void button2_Click(object sender, EventArgs e) // Выйти в главное меню
        {
            this.BackgroundImage = new Bitmap(Properties.Resources.anypics_ru_52522); // Установка фона формы
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 7 || i == 8) continue;
                buttons[i].Visible = false;
            }
            button1.Visible = true;
            button3.Visible = true;
            button6.Visible = true;
            richTextBox1.Visible = false;
            richTextBox2.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e) // Настройки
        {
            this.BackgroundImage = new Bitmap(Properties.Resources._2VNJME); // Установка фонового изображения меню настроек
            button1.Visible = false; // Видимость кнопок
            button2.Visible = true;
            button3.Visible = false;
            button7.Visible = true;
            if (logic) button4.Visible = true;
            else button5.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e) // Отключить звук
        {
            
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.OST); // Извлечение аудио из ресурсов 
            simpleSound.Stop(); // Остановка аудио
            button4.Visible = false;
            button5.Visible = true;
            logic = false;
        }
        private void button5_Click(object sender, EventArgs e) // Включить звук
        {
            
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.OST); // Загрузка файлов из ресурсов
            simpleSound.PlayLooping(); // Повторяющееся включение аудио
            button4.Visible = true; // Невидимость/видимость кнопок
            button5.Visible = false;
            logic = true;
        }
        private void button6_Click(object sender, EventArgs e) // Выход 
        {
            Close(); // Закрытие формы
        }
       
        private void button7_Click(object sender, EventArgs e) // Прочитать правила игры
        {
            this.BackgroundImage = Properties.Resources.RULE; // Вывод правил игры на фон формы
            button2.Visible = false; // Видимость кнопок
            if (logic) button4.Visible = false;
            else button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e) // Вернуться назад
        {
            this.BackgroundImage = new Bitmap(Properties.Resources._2VNJME); // Установка фона формы
            button2.Visible = true;     // Видимость кнопок
            if (!logic) button5.Visible = true;
            else button4.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e) // Пропустить
        {
            timer1.Stop(); // Остановка таймера
            timer1.Enabled = false; // Выключение таймера
            this.BackgroundImage = new Bitmap(Properties.Resources.anypics_ru_52522); // Установка фонового изображения главного меню
            SoundPlayer simpleSound = new SoundPlayer(); // обьявление переменной класса SoundPlayer
            simpleSound.Stream = Properties.Resources.OST; // Чтение аудио из Ресурсов формы
            simpleSound.PlayLooping(); // Циклическое повторение аудио
            button1.Visible = true; // Видимость/невидимость кнопок
            button3.Visible = true;
            button6.Visible = true;
            button9.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e) // Таймер на заставку
        {
            this.BackgroundImage = new Bitmap(Properties.Resources.anypics_ru_52522); // Установка фонового изображения главного меню
            SoundPlayer simpleSound = new SoundPlayer(); // обьявление переменной класса SoundPlayer
            simpleSound.Stream = Properties.Resources.OST; // Чтение аудио из Ресурсов формы
            simpleSound.PlayLooping(); // Циклическое повторение аудио
            button1.Visible = true; // Видимость/невидимость кнопок
            button3.Visible = true;
            button6.Visible = true;
            button9.Visible = false;
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e) // Таймер на пропуск
        {
            timer2.Stop(); // Остановка таймера
            timer2.Enabled = false; // Выключение таймера
            button9.Visible = true;
        }
        private void Digit(int digit)
        {
            if (var[0] == null) var[0] = digit;
            else if (var[1] == null) var[1] = digit;
            else if (var[2] == null) var[2] = digit;
            else if (var[3] == null) var[3] = digit;
            richTextBox1.Text = richTextBox1.Text + digit.ToString();
        }
        private void button10_Click(object sender, EventArgs e) // Цифра 1
        {
            Digit(1);
        }
        private void button11_Click(object sender, EventArgs e) // Цифра 2
        {
            Digit(2);
        }
        private void button12_Click(object sender, EventArgs e) // Цифра 3
        {
            Digit(3);
        }
        private void button13_Click(object sender, EventArgs e) // Цифра 4
        {
            Digit(4);
        }
        private void button14_Click(object sender, EventArgs e) // Цифра 5
        {
            Digit(5);
        }
        private void button15_Click(object sender, EventArgs e) // Цифра 6
        {
            Digit(6);
        }
        private void button16_Click(object sender, EventArgs e) // Цифра 7
        {
            Digit(7);
        }
        private void button17_Click(object sender, EventArgs e) // Цифра 8
        {
            Digit(8);
        }
        private void button18_Click(object sender, EventArgs e) // Цифра 9
        {
            Digit(9);
        }
        private void button19_Click(object sender, EventArgs e) // Цифра 0
        {
            Digit(0);
        }
        private void button20_Click(object sender, EventArgs e) // Проверить
        {
            button20.Visible = false;
            button21.Visible = true;
            Byki = Korovy = 0;
            richTextBox1.Clear();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (c[i] == var[j].Value)
                        if (i == j)
                            Korovy++;
                        else Byki++;
            if (Korovy != 4)
            {

                richTextBox2.AppendText("В твоём числе " + Byki + " быков и " + Korovy + " коров!");
                for (int i = 0; i < var.Length; i++)
                {
                    var[i] = null;
                }
            }

            else
            {
                richTextBox2.AppendText("Слишком быстро ты выиграл.");
                button22.Visible = true;
                button21.Visible = false;
            }
        }
        private void button21_Click(object sender, EventArgs e) // Повторить
        {
            button20.Visible = true;
            button21.Visible = false;
            richTextBox2.Clear();
        }
        private void button22_Click(object sender, EventArgs e) // Начать заново
        {
            for (int i = 0; i < var.Length; i++)
            {
                var[i] = null;
            }
            button22.Visible = false;
            this.BackgroundImage = new Bitmap(Properties.Resources.anypics_ru_52522); // Установка фона формы
            button1.Visible = true; // Невидимость/видимость кнопок
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = true;
            button7.Visible = false;
            for (int i = 9; i < 20; i++)
            {
                buttons[i].Visible = false;
            }
            richTextBox1.Visible = false;
            richTextBox2.Visible = false;
            richTextBox2.Clear();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}