namespace ChatHistory.Domain.Dto
{
    public sealed record ChatEventStatisticsByHourDto
    {
        public ChatEventStatisticsByHourDto(DateTime utcTimeStamp, int joinedCount, int leftCount, int highFiveRecipientsCount, int highFiveInitiatorsCount, int commentCount)
        {
            UtcTimeStamp = utcTimeStamp;
            JoinedCount = joinedCount;
            LeftCount = leftCount;
            HighFiveRecipientsCount = highFiveRecipientsCount;
            HighFiveInitiatorsCount = highFiveInitiatorsCount;
            CommentCount = commentCount;
        }

        public DateTime UtcTimeStamp { get; set; }

        public int JoinedCount { get; set; }

        public int LeftCount { get; set; }

        public int HighFiveRecipientsCount { get; set; }

        public int HighFiveInitiatorsCount { get; set; }

        public int CommentCount { get; set; }
    }
}
