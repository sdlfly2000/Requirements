namespace Domain.UserStory
{
    public class UserRequirementEntity : BaseRecord
    {
        private string _id { get; }

        public UserRequirementReference ID { get => new UserRequirementReference(_id); }

        public string? UserRequirementId {  get; }

        public virtual List<UserStoryEntity> UserStories { get; private set; } = new List<UserStoryEntity>();

        public UserRequirementEntity()
        {
            _id = Guid.NewGuid().ToString();
        }

        public void AddUserStory(UserStoryEntity userStory)
        {
            UserStories.Add(userStory);
        }
    
        public static UserRequirementEntity Create(
            string title,
            string? description,
            Guid? ownerId,
            TimeSpan? period,
            Guid? createdById)
        {
            return new UserRequirementEntity
            {
                Title = title,
                Description = description ?? string.Empty,
                OwnerId = ownerId,
                StartedOn = DateTime.UtcNow,
                Period = period,
                Status = RecordStatus.Initial,
                ModifiedOn = DateTime.UtcNow,
                ModifiedById = ownerId,
                CreatedOn = DateTime.UtcNow,
                CreatedById = createdById          
            };
        }
    }
}
