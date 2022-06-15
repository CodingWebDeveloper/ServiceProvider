namespace ServiceProvider.Shared.Requirements
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRequirementInputModel
    {
        [Required]
        public string Content { get; set; }

        public int ServiceId { get; set; }
    }
}
