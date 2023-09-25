using System;
using System.Text;

namespace oop_advanture.Src.Texts
{
    public partial class Language
    {
        private readonly StringBuilder _stringBuilder = new();
        public virtual string Join(List<string> list, string conjunction)
        {
            _stringBuilder.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                _stringBuilder.Append(list[i]);
                if (i < list.Count - 2)
                {
                    _stringBuilder.Append(Text.Language.Comma).Append(Text.Language.Space);
                }
                else if (i == list.Count - 2)
                {
                    _stringBuilder.Append(Text.Language.Space).Append(conjunction).Append(Text.Language.Space);
                }
            }
            return _stringBuilder.ToString();
        }
    }
}
