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

namespace ResistorCalculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            CalculateResistance();
        }

        private void CalculateResistance() {
            if(Band1.SelectedIndex > -1 && Band2.SelectedIndex > -1 && Band3.SelectedIndex > -1 && Band4.SelectedIndex > -1) {
                //read values
                int firstNum = Band1.SelectedIndex;
                int secondNum = Band2.SelectedIndex;
                int multiplier = Band3.SelectedIndex;
                int tolerance = Band4.SelectedIndex;
                
                //calculate resistance in Ohms
                float resistance = ((10 * firstNum) + secondNum);

                if (multiplier < 10)
                    resistance *= (float)Math.Pow(10, multiplier);
                else if (multiplier == 10)
                    resistance *= (float)Math.Pow(10, -1);
                else
                    resistance *= (float)Math.Pow(10, -2);



                //convert to kilo, mega, giga
                string units = "Ω";

                if (resistance >= 1000 && resistance < 1000000) {
                    resistance /= 1000;
                    units = "kΩ";
                } else if (resistance >= 1000000 && resistance < 1000000000) {
                    resistance /= 1000000;
                    units = "MΩ";
                } else if (resistance >= 1000000000) {
                    resistance /= 1000000000;
                    units = "GΩ";
                }

                ResistanceLabel.Content = resistance.ToString() + units;
                ToleranceLabel.Content = GetTolerance(tolerance);
            }
        }

        private void Band1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ImgBand1.Fill = new SolidColorBrush(GetColorForBand123(Band1.SelectedIndex));
            CalculateResistance();
        }

        private void Band2_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ImgBand2.Fill = new SolidColorBrush(GetColorForBand123(Band2.SelectedIndex));
            CalculateResistance();
        }

        private void Band3_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ImgBand3.Fill = new SolidColorBrush(GetColorForBand123(Band3.SelectedIndex));
            CalculateResistance();
        }

        private void Band4_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ImgBand4.Fill = new SolidColorBrush(GetColorForBand4(Band4.SelectedIndex));
            CalculateResistance();
        }
        
        private Color GetColorForBand123(int index) {
            switch(index) {
                case 0:
                    return Color.FromRgb(0, 0, 0); //black
                case 1:
                    return Color.FromRgb(81, 38, 39); //brown
                case 2:
                    return Color.FromRgb(204, 0, 0); //red
                case 3:
                    return Color.FromRgb(216, 115, 71); //orange
                case 4:
                    return Color.FromRgb(230, 201, 81); //yellow
                case 5:
                    return Color.FromRgb(82, 143, 101); //green
                case 6:
                    return Color.FromRgb(15, 81, 144); //blue
                case 7:
                    return Color.FromRgb(105, 103, 206); //violet
                case 8:
                    return Color.FromRgb(125, 125, 125); //gray
                case 9:
                    return Color.FromRgb(255, 255, 255); //white
                case 10:
                    return Color.FromRgb(192, 131, 39); //gold
                default:
                    return Color.FromRgb(191, 190, 191); //silver
            }            
        }

        private Color GetColorForBand4(int index) {
            switch(index) {
                case 0:
                    return Color.FromRgb(81, 38, 39); //brown
                case 1:
                    return Color.FromRgb(204, 0, 0); //red
                case 2:
                    return Color.FromRgb(82, 143, 101); //green
                case 3:
                    return Color.FromRgb(15, 81, 144); //blue
                case 4:
                    return Color.FromRgb(105, 103, 206); //violet
                case 5:
                    return Color.FromRgb(125, 125, 125); //gray
                case 6:
                    return Color.FromRgb(192, 131, 39); //gold
                default:
                    return Color.FromRgb(191, 190, 191); //silver
            }
        }

        private string GetTolerance(int index) {
            switch(index) {
                case 0:
                    return "±1%"; //brown
                case 1:
                    return "±2%"; //red
                case 2:
                    return "±0.5%"; //green
                case 3:
                    return "±0.25%"; //blue
                case 4:
                    return "±0.1%"; //violet
                case 5:
                    return "±0.05%"; //gray
                case 6:
                    return "±5%"; //gold
                default:
                    return "±10%"; //silver
            }
        }
    }
}
