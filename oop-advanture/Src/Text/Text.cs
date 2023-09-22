using System;

namespace oop_advanture.Src.Text
{
    public static class Text
    {
        // This property will exist in the entire program
        private static Language _language ;

        // Using static getter to make sure only one instance of language could be instantiated
        public static Language Language
        {
            get
            {
                return _language ??= new English();
            }
        }

        public static void SetLanguage(Language language)
        {
            _language = language;
        }
    }
}
