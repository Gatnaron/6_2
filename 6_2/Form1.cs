using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum EngineType { Gas, Disel, Electro };
        public enum Privod { Front, Back, Full }
        public enum Color { White, Silver, Black, Green, Red, Blue, Purple, Yellow }
        public class Car
        {
            public Car() { }
            public Car(string Firm_, string Model_, string Info_, int Year_, float Enginee_v, int mileage, bool mech, bool rwheel, EngineType type_e, Privod priv, Color colr)
            {
                Firm = Firm_; Model = Model_; Info = Info_; Year = Year_; EngineV = Enginee_v;
                milecage = mileage; Mechanical = mech; RightWHeel = rwheel; Engine = type_e;
                Wheel_Drive = priv; car_color = colr;
            }

            public string Firm, Model, Info;
            public int Year;
            public float EngineV = 3.0f;
            public int milecage = 0;
            public bool Mechanical = true;
            public bool RightWHeel = false;
            public EngineType Engine;
            public Privod Wheel_Drive;
            public Color car_color;
        }

        public void ShowCarInfo(Car car)
        {
            textBox_Firm.Text = car.Firm;
            textBox_Info.Text = car.Info;
            textBox_Model.Text = car.Model;

            switch (car.car_color)
            {
                case Color.White:
                    comboBox_Color.SelectedIndex = 0;
                    break;
                case Color.Silver:
                    comboBox_Color.SelectedIndex = 1;
                    break;
                case Color.Black:
                    comboBox_Color.SelectedIndex = 2;
                    break;
                case Color.Green:
                    comboBox_Color.SelectedIndex = 3;
                    break;
                case Color.Red:
                    comboBox_Color.SelectedIndex = 4;
                    break;
                case Color.Blue:
                    comboBox_Color.SelectedIndex = 5;
                    break;
                case Color.Purple:
                    comboBox_Color.SelectedIndex = 6;
                    break;
                case Color.Yellow:
                    comboBox_Color.SelectedIndex = 7;
                    break;
                default:
                    break;
            }
            switch (car.Engine)
            {
                case EngineType.Gas:
                    comboBox_EngineType.SelectedIndex = 0;
                    break;
                case EngineType.Disel:
                    comboBox_EngineType.SelectedIndex = 1;
                    break;
                case EngineType.Electro:
                    comboBox_EngineType.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
            switch (car.Wheel_Drive)
            {
                case Privod.Front:
                    comboBox_Privod.SelectedIndex = 0;
                    break;
                case Privod.Back:
                    comboBox_Privod.SelectedIndex = 1;
                    break;
                case Privod.Full:
                    comboBox_Privod.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
            checkBox_Mechanical.Checked = car.Mechanical;
            checkBox_RightWHeel.Checked = car.RightWHeel;

            numericUpDown_engine_v.Value = Convert.ToDecimal(car.EngineV);
            numericUpDown_mileage.Value = Convert.ToDecimal(car.milecage);
            numericUpDown_year.Value = Convert.ToDecimal(car.Year);
        }
        //____________________________________________________________________
        List<Car> Objects = new List<Car>();
        //
        void RefreshListBox()
        {
            int sel_ind = listBox1.SelectedIndex;
            listBox1.Items.Clear();
            foreach (Car item in Objects)
            {
                listBox1.Items.Add(item.Model + " " + item.Firm);
            }
            if (Objects.Count > sel_ind)
                listBox1.SelectedIndex = sel_ind;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            EngineType eng = EngineType.Gas;
            switch (comboBox_EngineType.SelectedIndex)
            {
                case 0:
                    eng = EngineType.Gas;
                    break;
                case 1:
                    eng = EngineType.Disel;
                    break;
                case 2:
                    eng = EngineType.Electro;
                    break;
                default:
                    break;
            }
            Privod prv = Privod.Front;
            switch (comboBox_Privod.SelectedIndex)
            {
                case 0:
                    prv = Privod.Front;
                    break;
                case 1:
                    prv = Privod.Back;
                    break;
                case 2:
                    prv = Privod.Full;
                    break;
                default:
                    break;
            }
            Color clr = Color.White;
            switch (comboBox_Color.SelectedIndex)
            {
                case 0:
                    clr = Color.White;
                    break;
                case 1:
                    clr = Color.Silver;
                    break;
                case 2:
                    clr = Color.Black;
                    break;
                case 3:
                    clr = Color.Green;
                    break;
                case 4:
                    clr = Color.Red;
                    break;
                case 5:
                    clr = Color.Blue;
                    break;
                case 6:
                    clr = Color.Purple;
                    break;
                case 7:
                    clr = Color.Yellow;
                    break;
                default:
                    break;
            }
            Car c = new Car(textBox_Firm.Text, textBox_Model.Text, textBox_Info.Text, Convert.ToInt32(numericUpDown_year.Value), (float)numericUpDown_engine_v.Value, Convert.ToInt32(numericUpDown_mileage.Value), checkBox_Mechanical.Checked, checkBox_RightWHeel.Checked, eng, prv, clr);
            
                if (listBox1.SelectedIndex >= 0)
                    Objects.Insert(listBox1.SelectedIndex, c);
                else Objects.Add(c);
                
                RefreshListBox();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Objects.RemoveAt(listBox1.SelectedIndex);
                RefreshListBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ShowCarInfo(Objects[listBox1.SelectedIndex]);
            }
        }
    }
}
