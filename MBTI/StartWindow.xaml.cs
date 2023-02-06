using System.Windows;

namespace MBTI
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        Person person = new Person();
        public StartWindow()
        {
            InitializeComponent();
            TBStart.Text = $@"С помощью этого теста можно определить склонность к виду деятельности, характер решения вопросов и другие особенности поведения. MBTI содержит 4 шкалы для исследования личности:

Шкала EI: тип энергии (экстраверт — интроверт);
Шкала SN: тип мышления (сенсорик — интуит);
Шкала TF: стиль поведения (логик — этик);
Шкала JP: стиль жизни (рационал — иррационал).";
        }

        private void BTStart_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(person).Show();
            Close();
        }
    }
}
