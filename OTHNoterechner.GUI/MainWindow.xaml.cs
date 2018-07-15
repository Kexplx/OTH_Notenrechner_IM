using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace OTHNoterechner.GUI
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var sumGrades = 0d;
            var sumWeights = 0d;

            foreach (var item in GrdFirstStudyPart.Children)
            {
                if (item is TextBox itemAsTextBox)
                {
                    if (!CheckInput(itemAsTextBox.Text))
                    {
                        itemAsTextBox.Text = string.Empty;
                    }

                    if (itemAsTextBox.Text == "")
                    {
                        continue;
                    }

                    if (itemAsTextBox.Name.Contains("AW"))
                    {
                        sumGrades += double.Parse(itemAsTextBox.Text) * 0.5;
                        sumWeights += 0.5;
                        continue;
                    }

                    sumGrades += double.Parse(itemAsTextBox.Text) * 1;
                    sumWeights++;
                }
            }

            foreach (var item in GrdSecondStudyPart.Children)
            {
                if (item is TextBox itemAsTextBox)
                {
                    if(!CheckInput(itemAsTextBox.Text))
                    {
                        itemAsTextBox.Text = string.Empty;
                    }

                    if(itemAsTextBox.Text == "")
                    {
                        continue;
                    }

                    if (itemAsTextBox.Name.Contains("AW"))
                    {
                        sumGrades += double.Parse(itemAsTextBox.Text) * 0.5;
                        sumWeights += 0.5;
                        continue;
                    }

                    sumGrades += (double.Parse(itemAsTextBox.Text) * 2);
                    sumWeights += 2;
                }
            }

            foreach (var item in GrdThirdStudyPart.Children)
            {
                if (item is TextBox itemAsTextBox)
                {
                    if (!CheckInput(itemAsTextBox.Text))
                    {
                        itemAsTextBox.Text = string.Empty;
                    }

                    if (itemAsTextBox.Text == "")
                    {
                        continue;
                    }

                    sumGrades += double.Parse(itemAsTextBox.Text) * 2;
                    sumWeights += 2;
                }
            }

            if (TxtBa.Text != "")
            {
                if (!CheckInput(TxtBa.Text))
                {
                    TxtBa.Text = string.Empty;
                }

                sumGrades += double.Parse(TxtBa.Text) * 6;
                sumWeights += 6;
            }

            TxtGrade.Text = (sumGrades / sumWeights).ToString();
        }

        public bool CheckInput(string text)
        {
            var isDouble = double.TryParse(text, out double value);

            if (value != 1 & value != 1.3 & value != 1.7 & value != 2 & value != 2.3 & value != 2.7 & value != 3 & value != 3.3 & value != 3.7 & value != 4)
            {
                return false;
            }

            return true;
        }

        private void Label_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            new InfoWindow().Show();
        }
    }
}
