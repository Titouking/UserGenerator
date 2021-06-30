using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersGenerator.Clients;

namespace UsersGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserGenClient _userGenClient;

        public IndexModel(IUserGenClient userGenClient)
        {
            _userGenClient = userGenClient;
        }

        public new UserGenResponse.User User { get; set; }

        public async Task OnGet()
        {
            var userGenResponse = await _userGenClient.GetRandomUser();
            if (userGenResponse.Results.Length == 1)
            {
                User = userGenResponse.Results[0];
            }
            else
            {
                // invalid user object
            }
        }
    }
}
