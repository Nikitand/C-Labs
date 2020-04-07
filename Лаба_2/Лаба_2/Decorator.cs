using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_2
{
    public interface IElement
    {
        string text { get; set; }
        void print();
    }
    public class Element : IElement
    {
        public string text { get; set; }
        public void print()
        {
            Console.Write($"Print text: {text } ");
        }
    }

    public class ElementDecorator : IElement
    {
        protected readonly IElement Component;
        public ElementDecorator(IElement component)
        {
            Component = component;
        }
        public virtual string text
        {
            get { return Component.text; }
            set { Component.text = value; }
        }
        public virtual void print()
        {
            Component.print();
        }
    }
    public class newelement : ElementDecorator
    {
        public newelement(IElement component) : base(component)
        {
        }
        public override void print()
        {
            Console.WriteLine("|->");
            base.print();
            Console.WriteLine("<-|");
        }
    }
}
