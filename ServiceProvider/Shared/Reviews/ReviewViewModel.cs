namespace ServiceProvider.Shared.Reviews
{
    using System;

    public class ReviewViewModel
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public string CreatorUserName { get; set; }

        public string CreatorProfilePicture { get; set; }

        public string Content { get; set; }

        public int ServiceId { get; set; }

        public int Rate { get; set; }

        //public DateTime CreatedOn { get; set; }
    }
}
