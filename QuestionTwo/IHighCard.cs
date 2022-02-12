using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionTwo
{
    public interface IHighCard
    {
        PlayResultEnum Play(bool suitPrecedenceOn = false);
    }
}
