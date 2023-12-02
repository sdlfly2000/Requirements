using Requirement.Common;

namespace Domain.UserStory;

public class UserRequirementReference : Reference
{
    public UserRequirementReference(string code) : base(code, CacheField.UserStory)
    {
    }
}
