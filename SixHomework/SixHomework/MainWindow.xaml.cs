using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SixHomework
{
    abstract class Body // сам абстрактный класс с фукнциями вычисления площади и объёма фигур
    {
        public abstract double AreaSurfaceCalculation();
        public abstract double VolumeClaculation();
    }
    class Glob : Body // шар 
    {
        public double Radius { get; private set; }

        public Glob(double m_radius)
        {
           Radius = m_radius;

        }

        public override double AreaSurfaceCalculation() // площадь шара
        {
            return Math.Round(Math.Pow(Radius, 2) *Math.PI * 4, 3);
        }
        public override double VolumeClaculation() // объём шара
        {
            return Math.Round(Math.Pow(Radius, 3) * Math.PI * 4 / 3, 3) ;
        }
    }
    class Cube : Body
    {
        public double Side { get; private set; } // сторона квадрата

        public Cube(double m_side)
        {
            Side = m_side;
        }

        public override double AreaSurfaceCalculation()
        {
            return Math.Round(Math.Pow(Side, 2)  * 6, 3);
        }

        public override double VolumeClaculation()
        {
            return Math.Round(Math.Pow(Side, 3), 3) ;
        }
    }
  
    class Cone : Body
    {
        public double Radius { get; private set; } // радиус основания
        public double FoundLenth { get; private set; } // длина образующей конуса

        public Cone(double m_radius, double m_FoundLenth)
        {
            Radius = m_radius;
            FoundLenth = m_FoundLenth;
        }

        public override double AreaSurfaceCalculation() // площадь поверхности конуса
        {
            return Math.Round(Math.PI * Radius * ( Radius + FoundLenth ), 3) ;
        }

        public override double VolumeClaculation() // объём конуса
        {
            return Math.Round(Math.Pow(Radius, 2) * Math.PI / 3, 3) ;
        }

    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculationAV_Click(object sender, RoutedEventArgs e)
        { 
            try // проверка типов введённых типов данных
            {
                double test1 = Convert.ToDouble(tb_radGlob.Text);
                double test2 = Convert.ToDouble(tb_coneRad.Text);
                double test3 = Convert.ToDouble(tbConeLenth.Text);
                double test4 = Convert.ToDouble(tb_cubeSide.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show("Все размерности имеют числовой формат");
                return;
            }
            List<Body> shapes = new List<Body> // создаём список и добавляем всё данные в него
            {
                new Glob(Convert.ToDouble(tb_radGlob.Text)),
                new Cube(Convert.ToDouble(tb_cubeSide.Text)),
                new Cone(Convert.ToDouble(tb_coneRad.Text), Convert.ToDouble(tbConeLenth.Text))
            }; 
            int i = 0;
            foreach (var part in shapes) // выводим полученные данные на экран
            {
                i++;
                switch (i) 
                {
                    case 1:
                        Storage_text.Text += ("Площадь поверхности шара равна: ");
                        Storage_text.Text += part.AreaSurfaceCalculation().ToString();
                        Storage_text.Text += ("\nОбъём шара равен: ");
                        Storage_text.Text += part.VolumeClaculation().ToString();
                        break;
                    case 2:
                        Storage_text.Text += ("\n\nПлощадь поверхности куба равна: ");
                        Storage_text.Text += part.AreaSurfaceCalculation().ToString();
                        Storage_text.Text += ("\nОбъём куба равен: ");
                        Storage_text.Text += part.VolumeClaculation().ToString();
                        break;
                    case 3:
                        Storage_text.Text += ("\n\nПлощадь поверхности конуса равна: ");
                        Storage_text.Text += part.AreaSurfaceCalculation().ToString();
                        Storage_text.Text += ("\nОбъём конуса равен: ");
                        Storage_text.Text += part.VolumeClaculation().ToString();
                        break;
                    default:
                        break;
                }
            }
            MessageBox.Show(Storage_text.Text, "Результаты", MessageBoxButton.OK);
            Storage_text.Clear(); // очищем хранилище текста
            }
        }
    }

