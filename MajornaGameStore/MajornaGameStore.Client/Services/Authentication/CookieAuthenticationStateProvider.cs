using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using MajornaGameStore.Shared.Dtos;
using Microsoft.AspNetCore.Components.Authorization;

namespace MajornaGameStore.Client.Services.Authentication;

public class CookieAuthenticationStateProvider(HttpClient httpClient) : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient = httpClient;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity());

        try
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "manage/info");
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            var userResponse = await httpClient.SendAsync(requestMessage);

            if (userResponse.IsSuccessStatusCode)
            {
                var userInfo = await userResponse.Content.ReadFromJsonAsync<UserInfoDto>();

                if (userInfo is not null)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, userInfo.Email!),
                        new(ClaimTypes.Email, userInfo.Email!)
                        //lägg till roll här?
                    };
                    var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));
                    user = new ClaimsPrincipal(id);
                }
            }

            return new AuthenticationState(user);
        }
        catch
        {
            return new AuthenticationState(user);
        }
    }

    public async Task<bool> LoginAndGetAuthenticationState(LoginDto loginDto)
    {

        var jsonContent = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "login?useCookies=true")
        {
            Content = jsonContent
        };
        requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        var userResponse = await httpClient.SendAsync(requestMessage);

        if (userResponse.IsSuccessStatusCode)
        {

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return true;
        }
        else
        {

            return false;
        }
    }
}