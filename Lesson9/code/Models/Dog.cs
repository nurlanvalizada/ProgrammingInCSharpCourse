﻿using System;

namespace Lesson9.Models
{
    //private
    //protected


    //internal
    //protected internal
    //public


    //types - class
    //type members - methods, fields, properties

    public class Dog : Animal
    {
        public string Voice;

        internal string SomeProperty;

        private string Color;
        protected string Loyality;

        public Dog(string name, string voice) : base(name)
        {
            Voice = voice;
            Color = "Red";
        }

        public new void Move()
        {
            Console.WriteLine("Dog moving and color is " + Color);
        }

        private void Run()
        {
            Console.WriteLine("Dog running");
        }

        protected void Save()
        {

        }
    }

    public class CobanIti : Dog
    {
        public CobanIti(string name, string voice, string cins) : base(name, voice)
        {
            Loyality = "Very loyal";
            Save();
        }
    }
}