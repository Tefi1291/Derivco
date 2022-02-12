namespace QuestionTwo
{
    public interface IHighCard
    {
        PlayResultEnum Play(bool suitPrecedenceOn = false);
    }
}