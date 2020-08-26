using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Serialization;
using System.Windows.Markup;
namespace Laba7_8wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<TODOList> lists = new ObservableCollection<TODOList>();


        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            this.Language = XmlLanguage.GetLanguage(App.Language.IetfLanguageTag);
            InitializeComponent();


            List<string> styles = new List<string> { "light", "Green" };
            StyleBox.SelectionChanged += ThemeChange;
            StyleBox.ItemsSource = styles;
            StyleBox.SelectedItem = "light";

            void ThemeChange(object sender, SelectionChangedEventArgs e)
            {
                string style = StyleBox.SelectedItem as string;
                // определяем путь к файлу ресурсов
                var uri = new Uri("Themes/" + style + ".xaml", UriKind.Relative);
                // загружаем словарь ресурсов
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            // создаем привязку команды
            this.Cursor = new Cursor(@"D:\универ\4 сем\ООП\Laba7-8wpf\Laba7-8wpf\bin\Debug\cursor .cur");

            TODOLIST.SelectionChanged += TODOLIST_SelectionChanged;
            CommandBinding createcommandBinding = new CommandBinding();
            CommandBinding deletecommandBinding = new CommandBinding();
            CommandBinding editcommandBinding = new CommandBinding();
            CommandBinding savecommand = new CommandBinding();
            CommandBinding opencommandbin = new CommandBinding();
            CommandBinding ExitcommandBinding = new CommandBinding();

            CommandBinding SearchCommandBinding = new CommandBinding();

            ///////////////////////////
            SearchCommandBinding.Command = ApplicationCommands.Find;
            SearchCommandBinding.Executed += Search;
            Finds.CommandBindings.Add(SearchCommandBinding);
            ///////////////////////////////
            savecommand.Command = ApplicationCommands.Save;
            savecommand.Executed += savecommand_Executed;
            Save.CommandBindings.Add(savecommand);
            ////////////////////////////
            opencommandbin.Command = ApplicationCommands.Open;
            opencommandbin.Executed += Open_Executed;
            Open.CommandBindings.Add(opencommandbin);
            ////////////////////////////
            ExitcommandBinding.Command = ApplicationCommands.Close;
            ExitcommandBinding.Executed += ExitcommandBinding_execute;
            Exit.CommandBindings.Add(ExitcommandBinding);



            /////////////////////
            // устанавливаем команду           
            createcommandBinding.Command = ApplicationCommands.New;
            // устанавливаем метод, который будет выполняться при вызове команды
            createcommandBinding.Executed += Create_Executed;
            // добавляем привязку к коллекции привязок элемента Button
            Add.CommandBindings.Add(createcommandBinding);


            ////////////////////
            deletecommandBinding.Command = ApplicationCommands.Delete;
            deletecommandBinding.Executed += Delete_Executed;
            //delete.CommandBindings.Add(deletecommandBinding);
            /////////////////////
            editcommandBinding.Command = ApplicationCommands.Replace;
            editcommandBinding.Executed += Edit_Executed;
            Edit.CommandBindings.Add(editcommandBinding);

            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }
        }
        private void userconrol(object sender, RoutedEventArgs e)
        {
            Window window = new Window1();
            window.Show();

        }
        private void ExitcommandBinding_execute(object sender, ExecutedRoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Search(object sender, ExecutedRoutedEventArgs e)
        {
            ObservableCollection<TODOList> ts = new ObservableCollection<TODOList>();
            if (Find.Text != null)
            {
                foreach (var el in Find.Text.Split(' '))
                {
                    Regex r = new Regex(@"\w*" + el + @"\w*", RegexOptions.IgnoreCase);
                    foreach (var o in lists.Where(x => (r.IsMatch(x.Name) || r.IsMatch(x.Info) || r.IsMatch(x.Categoria))))
                    {
                        if (ts.FirstOrDefault(x => x == o) == null)
                            ts.Add(o);

                    }
                }
            }
            TODOLIST1.ItemsSource = ts;
        }
        private void ThemeChange(string path)
        {
            // определяем путь к файлу ресурсов
            var uri = new Uri(path, UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //// очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            //// добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lists = Serialization.Des<ObservableCollection<TODOList>>();
            TODOLIST.ItemsSource = lists;
        }
        private void savecommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Serialization.Serialaze<ObservableCollection<TODOList>>(lists);
        }
            private void TODOLIST_SelectionChanged(object sender, SelectionChangedEventArgs ee)
            {

                if (TODOLIST.SelectedItem != null)
                {
                    TODOList CurrentTask = (TODOList)TODOLIST.SelectedItem;
                    name.Text = CurrentTask.Name;
                    phonesList.Text = CurrentTask.Difficult;
                    cat.Text = CurrentTask.Categoria;
                    Done.Header = CurrentTask.Done;
                    info.Text = CurrentTask.Info;

                }
            }
            private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                TODOList CurrentTask = (TODOList)TODOLIST.SelectedItem;
                if (CurrentTask != null)
                {
                    CurrentTask.Name = name.Text;
                    CurrentTask.Info = info.Text;
                    CurrentTask.Done = Convert.ToBoolean(Done.Header);
                    CurrentTask.Categoria = cat.Text;
                    CurrentTask.Difficult = phonesList.Text;
                    TODOLIST.ItemsSource = lists;

                }
                else
                {
                    MessageBox.Show("Нечего изменять");
                }
            }

        void Create_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            TODOList tODOList = new TODOList();


            if (calendar1.SelectedDate != null)
            {

                tODOList.Name = name.Text;
                tODOList.Info = info.Text;
                tODOList.Difficult = phonesList.Text;
                tODOList.Categoria = cat.Text;
                tODOList.CreationDate = (DateTime)calendar1.SelectedDate;
                lists.Add(tODOList);
                TODOLIST.ItemsSource = lists;
            }
            else
            {
                MessageBox.Show("Выберите дату ");
            }



        }
        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var index = TODOLIST.SelectedIndex;
            TODOLIST.Items.RemoveAt(index);
        }

        private void Easy_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Hard_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Medium_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);

            }

        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }

        }


        private void phonesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void inter(object sender, ExecutedRoutedEventArgs e)
        {
            Window window = new Window1();
            window.Show();
            MessageBox.Show(" Пользовательская команда была выполнена");
        }
    }
    public class NewCustomCommand
    {
        private static RoutedUICommand pnvCommand;
        static NewCustomCommand()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.P, ModifierKeys.Alt, "Alt+P"));
            pnvCommand = new RoutedUICommand("PNV", "PNV", typeof(NewCustomCommand), inputs);
        }
        public static RoutedUICommand PnvCommand
        {
            get
            {
                return pnvCommand;
            }
        }
    }
}
            