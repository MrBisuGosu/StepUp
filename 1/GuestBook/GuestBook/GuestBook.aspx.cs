using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace GuestBook
{
    public partial class GuestBook : System.Web.UI.Page
    {
        DataTable Table = new DataTable();
        StreamReader Reader;
        StreamWriter Writer;
        protected void Page_Load(object sender, EventArgs e)
        {
            AddMessageButton.Click += new EventHandler(AddMessageButton_Click);
            TimerTimer.Tick += new EventHandler<EventArgs>(TimerTimer_Tick);
            Table.Columns.Add("Дата");
            Table.Columns.Add("Время");
            Table.Columns.Add("Имя");
            Table.Columns.Add("E-mail");
            Table.Columns.Add("Сообщение");
            FillGuestBookGridVew();
        }

        public void FillGuestBookGridVew()
        {
            /*
            Метод предназначен для прочтения файла RowsGuestBook.txt, если его нет, то он будет создан.
            Разбивает каждую строку файла на пять частей (дата, время, имя, e-mail, сообщение) и заполняет
            этими частями строки таблицы. Далее данные DataTable переносяться в GridView.
            */
            // Открытие файла RowsGuestBook.txt.
            var Open = new FileStream(Request.PhysicalApplicationPath + "RowsGuestBook.txt", FileMode.OpenOrCreate);
            // Открытие потока для чтения всех записей из файла.
            Reader = new StreamReader(Open);
            /*
            В качестве разделителя частей строки файла выбран Tab, потому что Tab невозможно ввести в текстовое поле.
            После нажатия клавиши Tab происходит переход в следующее текстовое поле.
            */
            Char[] Separator = { '\t' }; // Массив из одного символа.
            while (Reader.EndOfStream == false)
            {
                var Row = Reader.ReadLine();
                // Функция Split делит строку на пять частей и присваивает каждую часть элементам массива.
                var Massive_parts_row = Row.Split(Separator);
                // Заполнение одной строки таблицы.
                Table.LoadDataRow(Massive_parts_row, true);
            }
            GuestBookGridVew.DataSource = Table;
            // Обновление сетки данных.
            GuestBookGridVew.DataBind();
            Table.Clear();
            Reader.Close();
            Open.Close();
        }

        protected void TimerTimer_Tick(object sender, EventArgs e)
        {
            TimeTextBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        protected void AddMessageButton_Click(object sender, EventArgs e)
        {
            /*
            Если проверка текстовых полей показала, что они заполенны верно, то открывается поток
            для добавления данных в конец файла.
            */
            if (Page.IsValid == false)
                return;
            Writer = new StreamWriter(Request.PhysicalApplicationPath + "RowsGuestBook.txt", true);
            // true означает разрешение на добавление строк в файл.
            // Запись в файл нового сообщения, между полями - символ табуляции.
            Writer.WriteLine("{0:D}" + " \t" + "{1}" + " \t" + "{2}" + " \t" + "{3}" + " \t" + "{4}", DateTime.Now, DateTime.Now.ToString("HH:mm:ss"), YourNameTextBox.Text, YourEmailTextBox.Text, YourMessageTextBox.Text);
            // Очистка полей и закрытие потока.
            YourNameTextBox.Text = String.Empty;
            YourEmailTextBox.Text = String.Empty;
            YourMessageTextBox.Text = String.Empty;
            Writer.Close();
            FillGuestBookGridVew();
        }
    }
}