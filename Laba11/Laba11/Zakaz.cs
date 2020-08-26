using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11
{
    class Zakaz
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string client;
        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        private string cost;
        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        private string photo;
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
    }
}
