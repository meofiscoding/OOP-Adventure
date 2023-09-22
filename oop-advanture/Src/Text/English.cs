using System;

namespace oop_advanture.Src.Text
{
    public class English : Language
    {
        public English()
        {   
            ChooseYourName = "Hello, what's your name? ";
            Welcome = "Hello {0}, welcome to the oop-adventure!";
            ChooseYourNameAgain = "Please enter your name: ";
        }
    }
}
