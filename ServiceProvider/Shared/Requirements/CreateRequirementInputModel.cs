namespace ServiceProvider.Shared.Requirements
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRequirementInputModel
    {
        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public int ServiceId { get; set; }
    }
}
