using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7_8wpf
{
   public class TODOList : INotifyPropertyChanged
    {

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private bool IsDone = false;
        public bool Done
        {
            get { return IsDone; }
            set
            {
                if (IsDone == value)
                    return;
                IsDone = value;
                OnPropertyChanged("Done");
            }
        }
        private string info;
        public string Info
        {
            get { return info; }
            set
            {
                if (info == value)
                    return;
                info = value;
                OnPropertyChanged("Info");
            }
        }
        private string difficult;
        public string Difficult
        {
            get { return difficult; }
            set
            {
                if (difficult == value)
                    return;
                difficult = value;
                OnPropertyChanged("Difficult");
            }
        }
        private string categoria;
        public string Categoria
        {
            get { return categoria; }
            set
            {
                if (categoria == value)
                    return;

                categoria = value;
                OnPropertyChanged("Categoria");
            }
        }

        public DateTime CreationDate { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
