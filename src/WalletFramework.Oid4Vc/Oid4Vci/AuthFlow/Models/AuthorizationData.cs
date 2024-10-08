using System.Globalization;
using LanguageExt;
using Newtonsoft.Json.Linq;
using WalletFramework.Core.Functional;
using WalletFramework.Oid4Vc.Oid4Vci.Authorization.Models;
using WalletFramework.Oid4Vc.Oid4Vci.CredOffer.Models;
using WalletFramework.Oid4Vc.Oid4Vci.Issuer.Models;

namespace WalletFramework.Oid4Vc.Oid4Vci.AuthFlow.Models;

public record AuthorizationData(
    ClientOptions ClientOptions,
    IssuerMetadata IssuerMetadata,
    AuthorizationServerMetadata AuthorizationServerMetadata,
    Option<OAuthToken> OAuthToken,
    List<CredentialConfigurationId> CredentialConfigurationIds);

public static class AuthorizationDataFun
{
    private const string ClientOptionsJsonKey = "client_options";
    private const string IssuerMetadataJsonKey = "issuer_metadata";
    private const string AuthorizationServerMetadataJsonKey = "authorization_server_metadata";
    private const string CredentialOAuthToken = "credential_oauth_token";
    private const string CredentialConfigurationIdsJsonKey = "credential_configuration_ids";
    
    public static JObject EncodeToJson(this AuthorizationData data)
    {
        var clientOptions = JObject.FromObject(data.ClientOptions);

        var issuerMetadata = data.IssuerMetadata.EncodeToJson();
        
        var authServerMetadata = JObject.FromObject(data.AuthorizationServerMetadata);

        var oAuthToken = data.OAuthToken.MatchUnsafe(
            Some: JObject.FromObject,
            None: () => null);
        
        var ids = data.CredentialConfigurationIds.Select(id => id.ToString());
        var idsArray = new JArray(ids);
        
        return new JObject
        {
            { ClientOptionsJsonKey, clientOptions },
            { IssuerMetadataJsonKey, issuerMetadata },
            { AuthorizationServerMetadataJsonKey, authServerMetadata },
            { CredentialOAuthToken, oAuthToken },
            { CredentialConfigurationIdsJsonKey, idsArray }
        };
    }

    public static AuthorizationData DecodeFromJson(JObject json)
    {
        var clientOptions = json[ClientOptionsJsonKey]!.ToObject<ClientOptions>()!;
        
        var issuerMetadata = IssuerMetadata
            .ValidIssuerMetadata(json[IssuerMetadataJsonKey]!.ToObject<JObject>()!)
            .UnwrapOrThrow();
        
        var authServerMetadata = json[AuthorizationServerMetadataJsonKey]!.ToObject<AuthorizationServerMetadata>()!;
        
        var credentialOAuthToken  = json[CredentialOAuthToken]!.ToObject<OAuthToken>()!;
        
        var configIds = json[CredentialConfigurationIdsJsonKey]!.Cast<JValue>().Select(value =>
        {
            var str = value.ToString(CultureInfo.InvariantCulture);
            return CredentialConfigurationId
                .ValidCredentialConfigurationId(str)
                .UnwrapOrThrow();

        }).ToList();
        
        return new AuthorizationData(clientOptions, issuerMetadata, authServerMetadata, credentialOAuthToken, configIds);
    }
}
