namespace HumanVSAi.Api.DTOs
{
    public class SubmitGuessRequestDto
    {
        public int ImageId { get; set; }
        public bool GuessIsAI { get; set; }
    }
}
