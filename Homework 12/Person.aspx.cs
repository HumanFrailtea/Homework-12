using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework_12
{
    public partial class Person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<person> mylist = new List<person>();
            person p1 = new person("Mark", 12, 6.2);
            person p2 = new person("John", 15, 5.0);
            person p3 = new person("Rob", 10, 4.0);
            person p4 = new person("Rick", 17, 5.0);
            person p5 = new person("Morty", 23, 6.1);
            person p6 = new person("Evan", 10, 4.2);
            person p7 = new person("Grady", 12, 3.2);
            person p8 = new person("Zach", 12, 7.2);
            person p9 = new person("Martin", 12, 9.2);
            person p10 = new person("Marcus", 12, 4.2);

            mylist.Add(p1);
            mylist.Add(p2);
            mylist.Add(p3);
            mylist.Add(p4);
            mylist.Add(p5);
            mylist.Add(p6);
            mylist.Add(p7);
            mylist.Add(p8);
            mylist.Add(p9);
            mylist.Add(p10);
            //1st requirement
            //PersonGridView.DataSource = from a in mylist select a;
            //PersonGridView.DataSource = from a in mylist where a.Age <= 12 select a;
            PersonGridView.DataBind();
            //2nd requirement = average height
            //count how many people
            int personCount = (from pa in mylist
                              orderby pa.Name, pa.Height, pa.Age
                              select pa).Count();

            double average = 0;
            double sum = 0;
            foreach(var pp in mylist )
            {
                sum += pp.Height;
            }
            average = sum / personCount;
            PersonGridView.DataSource = from a in mylist where a.Height >= average && a.Age <=12 select a;
            PersonGridView.DataBind();

        }

        public class person
        {
            String name;
            int age;
            double height;

            public person(string name, int age, double height)
            {
                this.Name = name;
                this.Age = age;
                this.Height = height;
            }

            public string Name { get => name; set => name = value; }
            public int Age { get => age; set => age = value; }
            public double Height { get => height; set => height = value; }
        }
    }
}