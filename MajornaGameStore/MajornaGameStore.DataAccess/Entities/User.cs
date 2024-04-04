using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;

namespace MajornaGameStore.DataAccess.Entities;

public class User : IdentityUser
{
    public ICollection<Review> Reviews { get; set; }
}