using Requirement.Common;

namespace Domain.UserStory;

public class UserStoryReference : Reference
{
    public UserStoryReference(string code) : base(code, CacheField.UserStory)
    {
    }
}
