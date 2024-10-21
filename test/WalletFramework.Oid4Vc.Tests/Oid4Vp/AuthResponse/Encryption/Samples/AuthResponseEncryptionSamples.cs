using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WalletFramework.Oid4Vc.Oid4Vp.Models;

namespace WalletFramework.Oid4Vc.Tests.Oid4Vp.AuthResponse.Encryption.Samples;

public class AuthResponseEncryptionSamples
{
    public const string JwkStr =
        "{\"kty\":\"EC\",\"use\":\"enc\",\"alg\":\"ES256\",\"kid\":\"667dd182-9e96-4142-acba-6905506ff306\",\"crv\":\"P-256\",\"x\":\"mXnqTqOetWNehsoaMqJcQ01M4ke1uxcnu2dIPOF8MFY\",\"y\":\"5sQTo8iz7g2P2rSPLRKkFCn_m-prMm1uM2Uc7_RPuNM\",\"d\":\"fQgnoBFNC-G3kjuvTlWEO0VXARVIWW2TkeRKAHVF2m4\"}";

    public const string MdocAuthResponseStr =
        "{\"vp_token\":\"o2ZzdGF0dXMAZ3ZlcnNpb25jMS4waWRvY3VtZW50c4GjZ2RvY1R5cGV3ZXUuZXVyb3BhLmVjLmV1ZGkucGlkLjFsZGV2aWNlU2lnbmVkompkZXZpY2VBdXRooW9kZXZpY2VTaWduYXR1cmWEQ6EBJvb2WEADly72vUPmaNbaxxtffUtW7jE5Rl8WM0ni1Pj65JqNxolQCc9RnT06vNzz7CWcrU8iQsThL4zOG6pG0bcrjHgQam5hbWVTcGFjZXPYGEGgbGlzc3VlclNpZ25lZKJqaXNzdWVyQXV0aIRDoQEmoRghglkCeDCCAnQwggIboAMCAQICAQIwCgYIKoZIzj0EAwIwgYgxCzAJBgNVBAYTAkRFMQ8wDQYDVQQHDAZCZXJsaW4xHTAbBgNVBAoMFEJ1bmRlc2RydWNrZXJlaSBHbWJIMREwDwYDVQQLDAhUIENTIElERTE2MDQGA1UEAwwtU1BSSU5EIEZ1bmtlIEVVREkgV2FsbGV0IFByb3RvdHlwZSBJc3N1aW5nIENBMB4XDTI0MDUzMTA4MTMxN1oXDTI1MDcwNTA4MTMxN1owbDELMAkGA1UEBhMCREUxHTAbBgNVBAoMFEJ1bmRlc2RydWNrZXJlaSBHbWJIMQowCAYDVQQLDAFJMTIwMAYDVQQDDClTUFJJTkQgRnVua2UgRVVESSBXYWxsZXQgUHJvdG90eXBlIElzc3VlcjBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABDhQauGDCoOMOX04n7MrcAbiX_-xO1YUT14jZudkt6tREyIAXV8gyt5FcRsYHhz4ryz97rjL0uogxHO6jMZr3bijgZAwgY0wHQYDVR0OBBYEFIj4QpCxKw1zy1tvydFlXoIcsPpiMAwGA1UdEwEB_wQCMAAwDgYDVR0PAQH_BAQDAgeAMC0GA1UdEQQmMCSCImRlbW8ucGlkLWlzc3Vlci5idW5kZXNkcnVja2VyZWkuZGUwHwYDVR0jBBgwFoAU1FYYwIk46A5YhBjJdmK_q7vFkL4wCgYIKoZIzj0EAwIDRwAwRAIgG3-U85HEM4X1qCKMotVTe3fCPQbBSptTFpbkaYdm8hkCICmJHazX9sVz41Um41v1P-UubwBAuV8XDmp7rDga6AW1WQJ9MIICeTCCAiCgAwIBAgIUB5E9QVZtmUYcDtCjKB_H3VQv72gwCgYIKoZIzj0EAwIwgYgxCzAJBgNVBAYTAkRFMQ8wDQYDVQQHDAZCZXJsaW4xHTAbBgNVBAoMFEJ1bmRlc2RydWNrZXJlaSBHbWJIMREwDwYDVQQLDAhUIENTIElERTE2MDQGA1UEAwwtU1BSSU5EIEZ1bmtlIEVVREkgV2FsbGV0IFByb3RvdHlwZSBJc3N1aW5nIENBMB4XDTI0MDUzMTA2NDgwOVoXDTM0MDUyOTA2NDgwOVowgYgxCzAJBgNVBAYTAkRFMQ8wDQYDVQQHDAZCZXJsaW4xHTAbBgNVBAoMFEJ1bmRlc2RydWNrZXJlaSBHbWJIMREwDwYDVQQLDAhUIENTIElERTE2MDQGA1UEAwwtU1BSSU5EIEZ1bmtlIEVVREkgV2FsbGV0IFByb3RvdHlwZSBJc3N1aW5nIENBMFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEYGzdwFDnc7-Kn5ibAvCOM8ke77VQxqfMcwZL8IaIA-WCROcCfmY_giH92qMru5p_kyOivE0RC_IbdMONvDoUyaNmMGQwHQYDVR0OBBYEFNRWGMCJOOgOWIQYyXZiv6u7xZC-MB8GA1UdIwQYMBaAFNRWGMCJOOgOWIQYyXZiv6u7xZC-MBIGA1UdEwEB_wQIMAYBAf8CAQAwDgYDVR0PAQH_BAQDAgGGMAoGCCqGSM49BAMCA0cAMEQCIGEm7wkZKHt_atb4MdFnXW6yrnwMUT2u136gdtl10Y6hAiBuTFqvVYth1rbxzCP0xWZHmQK9kVyxn8GPfX27EIzzs1kEQ9gYWQQ-pmdkb2NUeXBld2V1LmV1cm9wYS5lYy5ldWRpLnBpZC4xZ3ZlcnNpb25jMS4wbHZhbGlkaXR5SW5mb6Nmc2lnbmVkwHQyMDI0LTA5LTAyVDA5OjMxOjA3Wml2YWxpZEZyb23AdDIwMjQtMDktMDJUMDk6MzE6MDdaanZhbGlkVW50aWzAdDIwMjQtMDktMTZUMDk6MzE6MDdabHZhbHVlRGlnZXN0c6F3ZXUuZXVyb3BhLmVjLmV1ZGkucGlkLjG2AFggm5Ygmbzc_08p5xeH1-kOd7_ViehVUOCQoIJRhmgBC3gBWCBOeIteUDrLxoHH_xkHu0rKGKbQCqhZvv7VVf9e9eYRdwJYIJEw43R8xEPuvWrG0LtyLNU2KchDYlbg8Yl1tBSk-VfgA1ggx0b19PaIWqsg0tW8DXd9alFzWFeigpDcEyqSdLDp_lgEWCDCf_yfKpRgK3LetCVoWtI05ptnX89AKs9JS1dPiPLdNgVYIAG-8noCTV5qI-IOCXXdqOCxizFHPicnEUYyZyEDySAzBlgg1uCrt5IxTQK8gHrtlVMEz3bU3jnfG23ux9OeeUZP62wHWCAylbyJSifrD_GhXicqWYlCkFYNyTwvM4TWvNYHy61mqwhYIMe6Ue9wd91ABoAY2DDYEUbIg0M7BgYtKRGgg63LckrRCVggMnzCpYl1BrK3D8Q79aCSZ8UX44XvkAA-_PGUmvkXROoKWCCRWHYJbQGw5kfU53uIW2n5s1_Tw8IrLdHbpb46ReVimwtYIBGPZQjbqjeqL009cI2UK1BWcIwyoYx6oh36oes4-KAwDFggJNW0cf9LsX1nrvM-dwnrWRB4uN5HJMDgCLCb3y6HVuANWCAj2P5-iWPT-pfdBQyPAxN7t0fkz8yq3SZ3edpmemq7Pw5YINuUTUlEsAe2nDjS55Wn9Q-zT_lzWnOcvqyVtONl1LQYD1gg2QCd-pORB3BGiM6wg-HLlV3okskslt3LNSj6QvC_pEEQWCBoWRb-dzCqx3LhBLGiee4NmGt7JH3KfFp3HHI2c4X78hFYINUFvyvZ9Hff2w7LTXVQNVdx-37CvgczQ2PXxL_lPTzCElggfNKXXokNqABwBuix5Xk4EXKFm7JtBTb_WH3o9Db43JQTWCDqLItBZnBDnEx4LxHWc4wqg192UmWCAOWhVLH-SV9yeBRYIB-a2VEaVR-qJT4DQMokv1CsdB2L-MoTANGcFtb9gsr2FVgg3wsMqNc5rTNPaSADzIJumdFmx7k4JkCnV8uOqExXfDttZGV2aWNlS2V5SW5mb6FpZGV2aWNlS2V5pAECIAEhWCChdPQ8JojEaorBq2rUF0sXF52OR8sNxvcubSgG1cZBYiJYIG-3TNBYu1hakpU7UruiEtS0CVGRdQdD2GfE-bRxXFinb2RpZ2VzdEFsZ29yaXRobWdTSEEtMjU2WEB4UYU9U79UmxunJ0ESJ8jVB0owmOiQXXyh6pKoLI-mmrPPIi9Fz6PKGohaj3zJt0mS-ni_zZSsI-2pO-5rNmmFam5hbWVTcGFjZXOhd2V1LmV1cm9wYS5lYy5ldWRpLnBpZC4xgdgYWFikZnJhbmRvbVDfsA-ViDaPqRM7SB5cC8RcaGRpZ2VzdElEEmxlbGVtZW50VmFsdWVqMTk4NC0wMS0yNnFlbGVtZW50SWRlbnRpZmllcmpiaXJ0aF9kYXRl\",\"presentation_submission\":{\"id\":\"557324f8-7d3e-4a14-87a3-4433bdc64d0c\",\"definition_id\":\"0f460d94-3d21-491d-8fae-70ec8445ac36\",\"descriptor_map\":[{\"id\":\"eu.europa.ec.eudi.pid.1\",\"format\":\"mso_mdoc\",\"path\":\"$\"}]}}";

    public const string SdJwtAuthResponseStr =
        "{\"vp_token\":\"eyJ4NWMiOlsiTUlJQ2REQ0NBaHVnQXdJQkFnSUJBakFLQmdncWhrak9QUVFEQWpDQmlERUxNQWtHQTFVRUJoTUNSRVV4RHpBTkJnTlZCQWNNQmtKbGNteHBiakVkTUJzR0ExVUVDZ3dVUW5WdVpHVnpaSEoxWTJ0bGNtVnBJRWR0WWtneEVUQVBCZ05WQkFzTUNGUWdRMU1nU1VSRk1UWXdOQVlEVlFRRERDMVRVRkpKVGtRZ1JuVnVhMlVnUlZWRVNTQlhZV3hzWlhRZ1VISnZkRzkwZVhCbElFbHpjM1ZwYm1jZ1EwRXdIaGNOTWpRd05UTXhNRGd4TXpFM1doY05NalV3TnpBMU1EZ3hNekUzV2pCc01Rc3dDUVlEVlFRR0V3SkVSVEVkTUJzR0ExVUVDZ3dVUW5WdVpHVnpaSEoxWTJ0bGNtVnBJRWR0WWtneENqQUlCZ05WQkFzTUFVa3hNakF3QmdOVkJBTU1LVk5RVWtsT1JDQkdkVzVyWlNCRlZVUkpJRmRoYkd4bGRDQlFjbTkwYjNSNWNHVWdTWE56ZFdWeU1Ga3dFd1lIS29aSXpqMENBUVlJS29aSXpqMERBUWNEUWdBRU9GQnE0WU1LZzR3NWZUaWZzeXR3QnVKZi83RTdWaFJQWGlObTUyUzNxMUVUSWdCZFh5REsza1Z4R3hnZUhQaXZMUDN1dU12UzZpREVjN3FNeG12ZHVLT0JrRENCalRBZEJnTlZIUTRFRmdRVWlQaENrTEVyRFhQTFcyL0owV1ZlZ2h5dyttSXdEQVlEVlIwVEFRSC9CQUl3QURBT0JnTlZIUThCQWY4RUJBTUNCNEF3TFFZRFZSMFJCQ1l3SklJaVpHVnRieTV3YVdRdGFYTnpkV1Z5TG1KMWJtUmxjMlJ5ZFdOclpYSmxhUzVrWlRBZkJnTlZIU01FR0RBV2dCVFVWaGpBaVRqb0RsaUVHTWwyWXIrcnU4V1F2akFLQmdncWhrak9QUVFEQWdOSEFEQkVBaUFiZjVUemtjUXpoZldvSW95aTFWTjdkOEk5QnNGS20xTVdsdVJwaDJieUdRSWdLWWtkck5mMnhYUGpWU2JqVy9VLzVTNXZBRUM1WHhjT2FudXNPQnJvQmJVPSIsIk1JSUNlVENDQWlDZ0F3SUJBZ0lVQjVFOVFWWnRtVVljRHRDaktCL0gzVlF2NzJnd0NnWUlLb1pJemowRUF3SXdnWWd4Q3pBSkJnTlZCQVlUQWtSRk1ROHdEUVlEVlFRSERBWkNaWEpzYVc0eEhUQWJCZ05WQkFvTUZFSjFibVJsYzJSeWRXTnJaWEpsYVNCSGJXSklNUkV3RHdZRFZRUUxEQWhVSUVOVElFbEVSVEUyTURRR0ExVUVBd3d0VTFCU1NVNUVJRVoxYm10bElFVlZSRWtnVjJGc2JHVjBJRkJ5YjNSdmRIbHdaU0JKYzNOMWFXNW5JRU5CTUI0WERUSTBNRFV6TVRBMk5EZ3dPVm9YRFRNME1EVXlPVEEyTkRnd09Wb3dnWWd4Q3pBSkJnTlZCQVlUQWtSRk1ROHdEUVlEVlFRSERBWkNaWEpzYVc0eEhUQWJCZ05WQkFvTUZFSjFibVJsYzJSeWRXTnJaWEpsYVNCSGJXSklNUkV3RHdZRFZRUUxEQWhVSUVOVElFbEVSVEUyTURRR0ExVUVBd3d0VTFCU1NVNUVJRVoxYm10bElFVlZSRWtnVjJGc2JHVjBJRkJ5YjNSdmRIbHdaU0JKYzNOMWFXNW5JRU5CTUZrd0V3WUhLb1pJemowQ0FRWUlLb1pJemowREFRY0RRZ0FFWUd6ZHdGRG5jNytLbjVpYkF2Q09NOGtlNzdWUXhxZk1jd1pMOElhSUErV0NST2NDZm1ZL2dpSDkycU1ydTVwL2t5T2l2RTBSQy9JYmRNT052RG9VeWFObU1HUXdIUVlEVlIwT0JCWUVGTlJXR01DSk9PZ09XSVFZeVhaaXY2dTd4WkMrTUI4R0ExVWRJd1FZTUJhQUZOUldHTUNKT09nT1dJUVl5WFppdjZ1N3haQytNQklHQTFVZEV3RUIvd1FJTUFZQkFmOENBUUF3RGdZRFZSMFBBUUgvQkFRREFnR0dNQW9HQ0NxR1NNNDlCQU1DQTBjQU1FUUNJR0VtN3drWktIdC9hdGI0TWRGblhXNnlybndNVVQydTEzNmdkdGwxMFk2aEFpQnVURnF2Vll0aDFyYnh6Q1AweFdaSG1RSzlrVnl4bjhHUGZYMjdFSXp6c3c9PSJdLCJraWQiOiJNSUdVTUlHT3BJR0xNSUdJTVFzd0NRWURWUVFHRXdKRVJURVBNQTBHQTFVRUJ3d0dRbVZ5YkdsdU1SMHdHd1lEVlFRS0RCUkNkVzVrWlhOa2NuVmphMlZ5WldrZ1IyMWlTREVSTUE4R0ExVUVDd3dJVkNCRFV5QkpSRVV4TmpBMEJnTlZCQU1NTFZOUVVrbE9SQ0JHZFc1clpTQkZWVVJKSUZkaGJHeGxkQ0JRY205MGIzUjVjR1VnU1hOemRXbHVaeUJEUVFJQkFnPT0iLCJ0eXAiOiJ2YytzZC1qd3QiLCJhbGciOiJFUzI1NiJ9.eyJwbGFjZV9vZl9iaXJ0aCI6eyJfc2QiOlsiWEVKb2JvZ2VsNkxJUDdZNFBFQUhIUUxTcmEwcWdGWnRHVzR0a3RhdVB4cyJdfSwiX3NkIjpbIjVVS040ZDZOTXV1MkJLc0hJY0o5M3pOT21aNXh1SThCZWl4dmNSTUY3RG8iLCJBdXBuUjJwRC1zOWtQQngzc3pEb04ybVBuN0pxMVEyNHRfMjB4eDlFYTU4IiwiSVZBN1RPOUJGejFuVmpZeDZBRURxYlhiaXRDQXQ1X2hTNmtnQ1Atc2xrQSIsIk5YUHhHUXVoR3VqVVAzc19ndVZzNnAxN0pYaVU1djdaeHNraC1lTFRYSVEiLCJPQy01QzctcHVEb0NmZUNFZjlPaDlWNFhVVkRURDBLeFI3VE81dHIyeFN3IiwiY050ckUzYmNWX19NV3hfR2tGYndvNS1fN3dDTU1EaWJqcDJzcElOMVhtTSIsIndha1lzOVQweFNDRjVVZDNFVjFESEs0ZGtYM2lBX1RoVmR5YW5uU0htNUUiXSwiYWRkcmVzcyI6eyJfc2QiOlsiMTdGaWh3V21LbWJBcEM5akV0TzR6clJwSkM3dm5qUXJ1VWtQTmxmdEVhWSIsIkh5T2w4Y0dDT241eW9VNjdNN2NoWWxVeEFHUDBrUmpvbmNuel9vZmhiRlEiLCJaTGJaR2FsY0dpYVRsc3o3em5uSWtrQUprQ2ctTGdvdDZmaUhUMmpaenRBIiwieDZ2S1VEWnJ6WDVqYVBxWndHdF9STzRUcGk3cHlxWTFQVmRXVjktenNUUSJdfSwiaXNzdWluZ19jb3VudHJ5IjoiREUiLCJ2Y3QiOiJ1cm46ZXUuZXVyb3BhLmVjLmV1ZGk6cGlkOjEiLCJpc3N1aW5nX2F1dGhvcml0eSI6IkRFIiwiX3NkX2FsZyI6InNoYS0yNTYiLCJpc3MiOiJodHRwczovL2RlbW8ucGlkLWlzc3Vlci5idW5kZXNkcnVja2VyZWkuZGUvYyIsImNuZiI6eyJqd2siOnsia3R5IjoiRUMiLCJjcnYiOiJQLTI1NiIsIngiOiJ2dTRlS2NHazFsRDdPLXM3cXNjVnhocGltWUxPeUx2TkN0d19qUGpuV0RZIiwieSI6Il9BZ25sa0RBRW9CaC1LbWxqbW43czRpdDdWR1NoUldnVkpFZlk2dUpQLUUifX0sImV4cCI6MTcyNjQ3OTA2NywiaWF0IjoxNzI1MjY5NDY3LCJhZ2VfZXF1YWxfb3Jfb3ZlciI6eyJfc2QiOlsiLTFmclZ2ZFdPSVlqa08zNVM3ZlZMX1FNTnVITGpfMFFMYWJ6Q19oN0lxMCIsIjA4M2hHX09kLURWRG5xaDRwRXNBUlp4RlJxajBDcDN3NTdmQU9KTGNRTXciLCJFNFd0aTZOYUhDQ1F1RmVya3ZMdTE0d0ZsOWRra21Eb0VORk1XVFJmajR3IiwiVHcxMENCR21OcUJqYVJTcEtyUUducTBucjdTeUVhSlgzdl95X1IxNE16MCIsIllsQ05CQzhIQUprVGh0VUxCUGRXQnU3UkN0OHczQ1pWUGVueTBQazAtaHMiLCJoSVdJMThidTNyVEcwVE9sdXVVaHU1U0htcXdMV3hzT1ZLRTF4UTFPSDRvIl19fQ.B2O4xSGfvErZ-XJVCs0hKqLEeFDzeXIHYLpS8wvj-MocQKoiCs9FEDZ-pi4iSQabA52GpmojrXdOuhVzbarloA~WyJhMGNGQ19pNjFuRDBGNkRmeWhrVHVBIiwiZmFtaWx5X25hbWUiLCJNVVNURVJNQU5OIl0~WyItV2JjUEFWa0VSVnl5NDVVMFRMRUFBIiwiZ2l2ZW5fbmFtZSIsIkVSSUtBIl0~WyJFc0dXX3NvbkNxbDBiVTEzMGxyVFdRIiwiYmlydGhkYXRlIiwiMTk4NC0wMS0yNiJd~WyJqUmhGMzJtVjNldEhPSTVaVjMxVHNRIiwiYmlydGhfZmFtaWx5X25hbWUiLCJHQUJMRVIiXQ~WyIyMFJpWDRUY002dW5yS3pxR29kbGZnIiwibmF0aW9uYWxpdGllcyIsWyJERSJdXQ~eyJhbGciOiJFUzI1NiIsInR5cCI6ImtiK2p3dCJ9.eyJhdWQiOiJkZW1vLmNlcnRpZmljYXRpb24ub3BlbmlkLm5ldCIsIm5vbmNlIjoiNXNRTDRBUFU4WmwwLS5ffiIsImlhdCI6MTcyNjY0NjA1NCwic2RfaGFzaCI6IkJ3V012XzJwaGlOdU1USHgwZ0FabWZCZ0gxZjNnSmpYTGFPRDRDX0l5Um8ifQ.X7CYRWzFITJTlp9sk-CAft134kC85p61dtgiwX7gKuPoREgbOR2iD6k-omWU3rh9pWunPnttv30Dpry7T7c-KA\",\"presentation_submission\":{\"id\":\"0a8387d0-7139-4403-af5b-4129f8c18df3\",\"definition_id\":\"pd_example_sd-jwt_for_funke_conformance_test\",\"descriptor_map\":[{\"id\":\"id_example_sd-jwt_for_funke_conformance_test\",\"format\":\"vc+sd-jwt\",\"path\":\"$\"}]}}";

    public static AuthorizationResponse MdocResponse =>
        JsonConvert.DeserializeObject<AuthorizationResponse>(MdocAuthResponseStr)!;

    public static AuthorizationResponse SdJwtResponse =>
        JsonConvert.DeserializeObject<AuthorizationResponse>(SdJwtAuthResponseStr)!;

    public static JsonWebKey Jwk => JsonWebKey.Create(JwkStr);

    public const string ValidMdocJwe =
        "eyJhbGciOiJFQ0RILUVTIiwiZXBrIjp7Imt0eSI6IkVDIiwieCI6InljanVpa0VEMml6ekU5blJXemhmZXhRamRQbzBNTkRMZ1BaaGJpeldweDgiLCJ5IjoieEp3cUZES0dEVUY0cXpHV3NPd1cwbDJVZExZOHhiTk1FR1l1RkJRZmJyQSIsImNydiI6IlAtMjU2In0sImVuYyI6IkEyNTZHQ00iLCJhcHYiOiJVVlJKWm1kMVJtRnhUMnRuVlZOS2IwbGhWMjVqUVEiLCJraWQiOiI2NjdkZDE4Mi05ZTk2LTQxNDItYWNiYS02OTA1NTA2ZmYzMDYiLCJhcHUiOiJOZzM5emhQd0lXajZXeDdUWlJYSW1RIn0..7luwGfuN6AmVQ4SZ.wlGmirn2gi5umq67DB1Sl1O3_sVpDICWSAwULJRA7XbV2bTd7ZbaPhCZ7adtsOc5CGhbWEo6m1xBeH4zay0OmkV_Z749neA7RexcfzUkbv_vCbpYzitDEPJifw-UTKbkSS-bcEqqcUTJEf1ifxmk5XpjRjMDh84GQjwMXeiaUGIfCrtvBvwVPTIsEJSizGMrM7XgUrjnMmYSgOvts7uGo3a4ANTNQoAcKd_-y64xMwIYh-e4hC5Vq-Q5XEL2dpwFBGpEfm3UMoqg_hqxWJFg_5-EwIFesEiIL7jorK-ud-R-i4VMiWrxvGo5vt8yrD1FCHpGkvJTodKEQakcdV4NwjEEyqO-28u4D8GSLFUS63YHbNS5T6FjeZp8PTh5r58JR7Z0k4p1M2vfEa5obMINVhV3jkezXojgu1t3KI5KuECsLBkzGKG31pkcPpeP2EiZl91Ve_JENwa6JSPvGnJX1X6NWxJYPUNJ2pogvqL_cX-3H2qLYMBhwWkrsGf5PssrUqXQyscF4I8ZkUaWwAnl-2S83Tz_D7sfvjAXF5LJsU44swywpcNfSGkW5DidRGJTql4UcRIyX1g4LQOJks_BoYJOGPYWCVFOF9aDEPObVWQx5gqiW1BtTvRvF4J_NgUc6VqB3iOKorc7uoxmIXBpBFPnV8k5mo6Z_PFlGUdvtdnDF2-wmoDW-bmsto-H0z6L61S1mcQvjgkMlYZOPPBswhShRcYADwn7bmpsIBkc8W50Y6s6cUSUnNXoZqyaxrCcO1Td3drF7Hsa51RYTCn4hpWjOPTv4TeyPVETjb4C8n8KD0HlzhtNCsyyhFJSeAAeFf7SOzx4OmP-sQFxUF2zzEqx34o9-jm7T-oc5wMTPIgCh-ofZ8rFfA_SyWzCZFTs4FC6Xc9gvuAKQjTJKHDK1eKUvohpzXSAT7ByMhONU3TScgAxEyNEBoiEjaomos2FD3bX5eRJVmGSDFLptTSBxINSyPVQ08dBUbiwe9K0vbPtj9wXu_GTPJ7KRIh7JvEbPgzMiKJZE6EXFJgaPX7Walp-_ZJOjNMi0sUlVIkwxLwuTUS2ISYOAFGXb90RL1op4rblYvnBWM0GhYOmwz_tLvqohCH2-OiIK2CE8e-QnfYmRx7CrpUlRtEFLNhGKtKRXlIkg1WdOB_0z5SzrnQebcayQx7ibKKqL_x5AI7rmqyZziCYSEy1m7_WLeYRLRDnCrgu9t1GDXAD8WHeqMt_v9FLO4_Boy0QtD6QBODf0D2VzlhFK3SCpbsDAGQx7PnX8Cbt4Ma6RYyATP8vrVQQUhMIG0eYZSjv7PRnvZjxuv-EtY0AitElri6aTvITvyikcwWREPIM-GNFxlIAObE2esDkObCyWiEuK-jnditrEdfn2t-yQqoM36yrJ0N5Jj9EOz5bYmbN2-XrSnYZQckmwv2xF4m3jsSrQwmbMZoFdph4wL2_U8FPIVU9uWpbPCJ8AarcYxi4jgdwzXRkSyWGoNuRhcAwloADmdgitmYGWJ4Hahm_pvvJNOVG9m3lsIrdALfHI9lqWNqZf3B4SeDiPr-gRiuDdZGJQ5r2aO2EmdqleFvHDSnBeJ4bo3edgjna9nypArcJFfz6tZCzL0I408Fv0os25H-rVxWjanmUiZS_chQhpkBO76rTM__utQdgD7DTdlM6WL2j487F6xHSuwlY0Yjo0cmGGnfuauyW3XVKwfYWecRpXYt9_0elbDX_VDwqWSUPrt1Ivix6l9GLRHPDh7MAWbK7Uj3uQReA8uKeMrmoyYWUsgW4iBkVv1k0TBKqCJ6J6K04o9kt1lOVb6m3sF-MWUCB5R5duELbjjt-tP5Q5kVLhREA_C-punLQgXIg0HTSCCVQQLunm83VOA97QaBuUzi8Rp1ynC5bFWtecohd0KhrM3P2Li7QlLg-JKkL9SGMSGHyfmgXtqgJPNw_AKxP9wrMbOlkuaXdwkGgZ9LnV1hIrY899_JWsDniH7M1hK2sj6JHv20py40qbpEiG6wMvZNZ4bX26mm2wUoCl3RF_MNO82HPGbvl-wRWil78JF_eKqouzoIUvitShlXBlyKZN9LLFAYv4YEfFs8QAtZB2R4pHZ0Yx4dM45d4hSipvUp9pPI15EM16_J8w4I6emyZoQHdCv8Ob1uCQqKiC0ckCRC5C3e6X2ydl6y7ii8y62lqi544waDbWGLKI2f0V-ZoICDsLXdB-0yinElnB7bfRDhkMaKyA8uwB__i0_QPQ27C2w2EnnbLtusDTrdT7e3SXYMS5k4gnwImVB9MN5MhYtoZ4UpN77uLXGsVlueOBtfA3xeCgsSj6YlAA2QK37_Ljr-lernqPiLQ-SE-z4WuON1NqIomWxF-MjC8d_Tz_XeJyBBdKj49_k_fBoIARXpUCRnS477roTkVEqRA8z3xgCkqSrplvoZWWw9cV3LvOG6WwLZ3n6IyBF57052QVv3dpPb3FxzQwergV6i-Hp0HAW1mSYO5tYqoK6q4YDF7tqZMS5_xmRedpK1MHJnDwxm8_WmYBth1hfO669GLMvqM4E6bx_YypfTZdL9srl1LXyRL09e4in4qHmSTPGaHZrQoNGfQ9XJZQCtcd19lh4-jJzpCdMy1opgBThQh9eszJzrVX33tyUst_sQB35OdubriGJPBZl6kLU-5SD6XKHpnUwhOGDy1caoTJ8oXDpGQ3qUTooculR6xmulSF43sgTN7qUlHOdEHc9ATvmk4g2mJKBsC1tkKYadmBR4WcqxuTMqsxQwIWQrxMFqjdM61mShFUU97wW55taivmD0XxjYwq65BFk0oxRf21xA-m1o9mZ6EjYol86BoCq0VOTNcQEyjiWFzQqYTcI5broVMPoLHGIyJqgZgFbQk5whhvShe7KO6k0KPsikdSiQRvqz20v0GudLYD2S4Lm5EzXUz3h8ETcpAwjD0BzIWUmI26F2dpcAa2XgBzVSS8lLC16U00UjwGKo4-F0bYma9VeaV1sRvPP-6D_fmSzWSz2u3ATKjOX5YRWl6DQSpd81QkMKIHnCxTgckOMIvvlf4vSAllJgLj_FUbZn69Do_NMPrhrtGl7mU28o6Fb7uRObVC9LAYL8cQeFPi3uwwHpDbCOsMCJr5dbUpATwtCdEuTMR1Wr1ff7bOT1F3m44b0M8PYrOEkeHEHqD-AE5m2WqDoCRQYAIyPm7RcwkJuVNVcpcC-71-ODm4z8ex6qnoru-js-ELv94VsiYURzBNlcYpqLb5icFmH61a9B35NyK-a1eltcdY75ataej4Q66wABknX4qqu_wDif3CWi_j3OMnu6bQf-dtnDfIAtMCuOrsPCAZ754B-e95eIJWrn6UFG17ToEs4CDIghi1uEcvzvraF6SFkSwumBsWsqvkexjgwK9DxDqHnW8BlmftJf1hfjH8Fo8AXdFt7-PQsmyxySbQZbh_LEgLJaAjfgpaJr9Ssn-OOgsWWqcMSLYQIXDqVOvtAj39ONQVaZLHrG-fggltSVlbcBDr1q5qe299-qSbo4kh5H3u2raQXeTQ3CTwk2mSjtTNdS5N7csbR3xEo9eHpgJc0GQ3OYKHNhgngT5qVrZxSeMXP8oboMoXamr5p0whGu8wApmQMaozB70-WXvWbgGr6o96tZQVFZxEHLVsU4wiy0-nyZ39L3Kk1Xb5WMm1EyKP9Abcct7AQVBS923nkv-7nK8FzzsZrFJ80VMtydb48Q4sUz0GVCAbo6-OwJSJAQRERhrEIck_Yz173Cklaet2TktOSVxlByDmg_yCAsQy-d6vl3xrgPMeaTzL31Qy24sC3PZCGs3pTatPCKnPV5B_klXWlkjGLxqt-kCHi8t6cm1jk7dkDWcP-1kFCz3Cms1hrUtCqw8JkG0bosqsogNv0HYlJYNhj8zKTvK3UChSzrw1NKFkIApjvUMqPoLNjsv0a76dQnaB6D1J5NisqxUOuC6PAfN6uRDIAQCcoE88Xb_GDeb4M14Bef3HM4dNxUU9tdxTb11CDHi61vDRaYbZWN7JLp_3QQO10naFYp9P_9ADcGHE34eDa_TaB7Q6zLlJnreOsXTq0X2nJhedG38tCEQkVLQg1l4cLVydHDKWMpA317lHMiB5PEof9OHdsIKz80kO_z8C7pH6sMlNCVcNGImJsXZ3uNI8TOnCo2_0-pmfbdnGJ9hSbHoTQzJzD_2jc73CszWH2i6R3Pfs5tFMFXM0_qIrmSZCx3VPEAwQbI1bXNwUMmbZHN-Lo2811b4N15VZGNHWHEjxI5cV1lFCeSoyrNHXdMDfIpW7shvEpbSaTxkl3pVDyamQcsRQ_Q22EQLCMl0I3I1IFVBD1jJSc9VdxelgbyllOW4FbJeInliyRG1tTcV3XMIgWm9aCjOc16ilxwRu_0-p2ln8ja_-vIBhWlJ7epcqFYOgfSQscfACYDhwzyegORZ6T8aYBpNGthkMWBlgw8TF17XDOgouGADacuidW-VuT7p_4AtDKLv3XSPB_4NBPkuWutlBpQrbmFy47qKwSqBc_EFq1Hvof5a7beG8SdlmOJBRq9NHhtLEpFLmc_ML3NnJ1XdOWVR1fT9fQjTVr3ttL7ZVXLn_AoSZwq3GmnnAFunx7HnsWe7_RniMguvlr6Lzdny1Ox6nxocfaE5M4H12nh0poqkhxUlUtgrxJ8zJkCYbd0-4lQjYRlEB0mN-kbxhQr-k571SLMBNTsBIsTqRLZWYpWNK7Y6KdxCYnIVSnW5Xo4Ciu1iPnUf9DWWLOi3eBobZut9UQIsaOJA7BM2iNK91gQmC18JJ6c7g-wZE9uwN_IivMVZQ2kxHh1_Cnj63YGto3JkbZGmOyPDJkClY4UclOWNGJQvkOV-2xumInKQLOpysilh6fp4O6eGYQxtNIdlgdMrSjcbFbXx6nf634kj8V5i4EwPKIdpKEP0b1Y3zJZD8HoskeAFa85J3TDZ4Wv6AUzCTscQuT0fnX38D7_4IgUl7c_YBzEkoEExow2-qH7JSUVOs2lvFD6k7pQjRu2BRChUdUflj2Z2-CH9N4SvOuwJBCK-QychmXueZNXdM0Vx-mVKCBm1jcTyGMaUBjlDI513JyutVkl1DwUmczW3vMUG4gZ4qRKhHpI44uavaFEJw_MBacNyLAPe11ENRsIo2FC-lg4tYFndNshQTjtMP0A3Mw7FKOvUg6B9dyY4FulZfLzSqgjcgK4pkfarxZpxZhZFA6fKO6t4xkoD1dtkCy645YzGdRSVMLb5dTES8xD6lWhdmLs3otlgx4-5fA.ksElsa0Dt451o96nPUPP9w";

    public const string ValidSdJwtJwe =
        "eyJhbGciOiJFQ0RILUVTIiwiZXBrIjp7Imt0eSI6IkVDIiwieCI6IkVtQ0JCc2ozWDFlRmM4dW52d2hmR0x0MGZuM1lRdTRjS2VwTWZNV0lmajQiLCJ5IjoiRlp5dUsxcHJaQktnTmlFeHA5dmJqSG4zSV9zUzl5Q0RLMkwzX3NSVDJwMCIsImNydiI6IlAtMjU2In0sImVuYyI6IkEyNTZHQ00iLCJhcHYiOiJZbGhvTkV0bFZUVnhRV0pIZFdjNVVYSkdNRW81ZHciLCJraWQiOiI2NjdkZDE4Mi05ZTk2LTQxNDItYWNiYS02OTA1NTA2ZmYzMDYifQ..EQEZCUawOkIkqGbF.Vx5WUpFW6Q_QluDSW7tXXmN94AWU6XbGYZEeySVnMGKE7LFLdUPPRhNlgFs2tGlzPAHCnH0H5fhvoCF3pi5JGI4SN4vknzDQardtuQ0IuwxmwCNXwajjvD6a2qPVly5g-OsyG8PXLBfABQHyuofprWU0IDaYV7-BueJzXsGOmzTLzoeGs7zmtTTRaYUdAyZaOVemxP9UyEY8oSLf5L9sefq-BQrWhSyb39uSENUDdQfacoEHkeuzbdwXZ-fhIQWT8wJeBVtiT7H-UNUM12u9Q47lDee6pvajn5K0U6P8a81Nl3zdopibHQ7LeXwTNHFY72-z0lLeRcNDF08PaoeqnymdcGwyNhqnXJRwNFKOrokkf94vF0RQUqUIxfy1JCM6DmHDsWVPwanvhDplfL-TuUFXn31qxBqd7IWI1uu6mQMxXaxkBTgwkcZLPIZAXFX7FRW12Zgfb7DwcEG1yg87ljsTGUo20Pc4iFjbu3w6piZ8_Jr9MLa_cpKifzdBnCP5MSsY1xzgTsFv0OD1vohs6u4TDPViKU6g4fNgkTzsdgDJh0tKCmoMsgPoXC8JJr_jWlaGgwuMLidr6696TzjnQ3cUbaeb2MyK_M7Kv8OVBgtY_WU3fGzQd5AsWZY9sb5uetebdgqU5S6EmJpL49X1MbeltMgKIlN3eQjllNauL96xIhmDBCLP0hfXEw1ieqBonKS6qlQ1AAXNRCOjSfFSdnr_wH1smoteRTRDlafjmeCBSel3IQr6tOHCIKBXJW9Hm3H4dZmfpeIQwALf3d6FF54s7h_xqxcprr2TPuTVok7jlszTPF5tEeiaZNjncUKlMAHbrRQsAKSfmBV-RmkeK_6u2AM9AM8lroeDQYHEqz1LNsZnWiRBimFsS0aRZcCLhRnuPdZd8Y5N01qcgG94Ym1v0KfmkqbVwnmRgBEg5lUERU2n0dP9bIpYwP4q-8uOE_j1OSwBEJ8ieEzW8qOWuHh4HiUMBcP9QuwCwa6sxz7SATlPuZw5pxZT7WQwHkznHMHjt_f5OAq5pelUFtbxGRLE0tVtqLELHRyPkh1sfdgJu5XHLH3JjMnryko4mO4aTu5E4d_3Z6sEYr1Mw3gRrM4gxvnAbEZ-zwE1gR2-JPLOrRLdcV-It219kbuIDMrjhT64Ptz8-ichT5tY_7mp6c1RbVldD7vExEXW3NMX31M4yjZ1IoQJN0OfBkesLKtgAeF-8njkqn7sPUb4vziepTRx8dupptXiAauWBnQR4zChbVvZhF5qP_K9ZJt2sMA-CxZHgf10xAmsJpqrQi-40i0iHAY7SaqGEGJor9myMZ6bbPPskBgZauzYm5aken6wduqm3mnAWa7CxyKuqFaxwlNUTLFk6n0u3yifYz7VdI-8fxST6U0TNA7i1ox562DrdqR-V-DIXnMNWsJ7elGv1TSUqgStuttac04UWoTua4IM-0MuvHzM1s1weGMDlibDb6ht76FpeVSWnYf0pRTCkCZ5FkuwNdWX4dqFrxfKRGuTPRxb7G3j6Qj2UEJ0esYfkF8jS8dXu4U1ebu9y1gdNbH6EhQ_qzRcnbF6lQfkpo1UQOhM9hp2ugH6JzSEyX0ILl5ssUdDZedaUspcpoUzVgoCCKbEpgofOWSVS8bUoNTZ0dg1dpmGt7tMXCWz09dERXRoggr2N-mSSpm8L6XQlQR8sgI8o7DnvZmHtnSN8xnMRecbrfCKNOU9yQGEAi2CDwnfJ92Ogrhot1sbUzvd5HDS4Gh2ZpiJdUXkp2hVYjIOng_opHSRy7A2fKOW8YCiPWevzbETd_P76_axSiKe7uy1JGoHqeDf-itx6-w-kZveJMY3RarT5r8WxNrXHYJWDQawDrywOm8uGVw15DSUcFws3QvKf8fVm5GX8qvGJgYI2_ZkGetGP-31T-mvjF_4zWpPdrOLdhTSWDZf_LJrwLWgKaPcwYKMmkx1N2PFupewKACO7aVpAGy-4Pq5ffOKIW9ld_d5UlsQRshS2BjTC3IX8vrgvnB6dgolJo4zyo11WHUSYuRw9NXAB3x2cnhAOIc19hJ4tIo1LzL0FCst46_F5drzcG4u82ZIDbTI_IqAb_IcVOWDJnx9s2Ut2Q53E0SRqz9PLT2XWZmsG1BFjFhOCw1-I1Wu0nK3PTfZqTmxcVOtJsvzUnFXEd2VjTPSVym7bdMJLIgC91DlJB4_WZLKRmOerAif93hRrwA1g4mLeYvExv1CM4Ppo2LFd759RIrl_VAsK28W0mRk5e-mjZBn1RVIgPShw1UO2eJyUMPtdVgMa4DKw61LJt5-K5VryTEvZI2mdjKYAnPc03jBMnH1aDpIgHhk4Q2yGSpNytgvE_yPF_Q2ofvcG7gpjciiGvwwdUkBlk0U4e2sDrwybAaJuE1uxHdo-sH3zNZoUvFwvU8qw1oEeaKz2K0FPH244YWwKCXeQBIASwSdFjjjQA5inGoWpf9rHhRtKvJ0BtixONKjV_BxhxS06NENlu072jjRItdHlpW3FaxAn0UsJvaj6eb1LbclsZzMJ8dpNRQkk93C2itIuwGjvx4V3dCGuks6Da-fQNFd_aZLrDtXT4cnQSZh29HkKmi4X9Wts3W5huWZHNB9Kad3dCHKMvmUCQcEpMeYQ0OizydC7NeQjDU6aCK4fFysOfyxD0MvVBrqcYytVG66QRFoeCAvCC2oZCu6C525WeuGjMIRn-w2gbFKb-CvkAVU7owGjTSXKupyET-EgHQJFM5Vxkp47x6uLFpBF7CnSjrCsqBGYjYsYkamuBtEO02tGnGdkZRp-6jpNA9p2wFLOCVWr9G-YXbDfHClcTKFWmSzGWyvBKdB4gDiR30noz2viyLQBkb5VJtSK-v5aCrQoyVzGQqJP5I1ppwm0vsyFpFYqclZByY5iunXhLlbabulMGtQjqASrPIcxcFr2z8sO4QbsguPcsnGDhIUPtTbWllmeDoBuzgjM9CXSbWWFKtqS_YoTRMpoDpqvx7MQp1uLd0GXskSf0XPaOXx5Ji_a8FJJpWgZ-APfNzOs4m70av_Oa5fbF74UhaT5vm_Rn4dcn0lk1rdmS9XB2mwJu9Ig83yAbfIjDB5RxHPtA5F-BcODF64N3m1ne3YU6qZY55m1THTe4RF_wkXpVAmv5RE-rcSExu949tiADcXqAQeClq5Y6e-4WYCJwoMVSbVHdYwF94msbK_F_WSixxvWnQfzX7H_1NK36hYkLh7mXPCsFRP54fd2ZrF-Aeu8kdoI72ewshdM6XEInhiRybFYRQtxJA-VQ4wMeyTApJeT-9m4ACH1Od14wS1I425LGOi1VmoBs65ttob-UGFaLA5qvqlacDviLUKKuT8P7tEn2yC2qthmMh7DkH3MApCu9WVfAnJXTaFvdWf-od0Mi7llVWSQfGfTXeAQ8Lyu1Pu3mH8SxamPjoXlUX3miNxDQsf97bUkKB_aeRUq8kqrWZyw7CeufZ9MqdeNteJpWqLU2Mt0OioNwddqsIPZ12Kkk6oOmyhmCSOhQSqcA4Xpwt8Hqywsdwdn9S43-MOuUmyqjaBxcnLf_pL7PNw04MBTXJw3QLtP93-o8Izlg4ELqd8NznNh9lCFOB3Y6z37ULmNLBpIuwUKWQhO6VwrxyUg--1OgqhcHvWkLM2hy9yj9DuyRPDMSuwyONac5MMNVuR2jUqpohAwKYteIqbQZJZPmtKsrpYv2u8B-Dr7ZZAGTP7jXW_NOVD7ORjF49WRfqCqcO2HydvbnBJMtZxtLmpVSEAjU1NofzZ4eBv8kjQoEBF_3Hr9t3GgC1Ke5WbaI1vy8jSkK4smge-BqH4J2Tsf4djAYsnH8O7gjXLN5rR54AegpNkVrb3lO-wE7zwytmF8y6lt7aWUIRhpln4_BoVdF9boInXe6lsWvL2_UPDKGkGQDlLhE6D5bO1tClukLnuREaFMyfJhNJLxbrGfe4LRY8MiCJai4J36rbFsU6MBGU3lyO3SDAwywPwpTX1lRrEskPk2YyuwL9J_8Uk0uqzn0SsF4O0QuLubD08BDwKz-Yy53jR2YIZryyEDHnJ4odqfd7MKI-cxbGqujT-7_kGf0ckTp7oP4Iej7_ZtG-gYFlaCcAuW0pbg1-nj8U6okvG7ZhXLIMnYFsXBjtQz0J5SQ-FLvft6w06Uik01Si4l1rnevotf8_UpesrkcOiB54yUqXPL3p_Loyiu5ythi5Bt2nJ6z6XHdeWbpeK-epoec3uS1OxQ45zdArudQPFQzt2rxOM0ja8bokxt__oaXqJCD05lPpspRO-X0BrG9NXUIZnN8Rq7hjTEXiQCbjug1z3byWLYole-Gu6Ddlc5eu-8Ug4EzzzL9CQCgFdmSOl-cG7u-C-QnQRbx6im5kTqmmnYVlqdH5Zn39Dbxp8FPgvW0Q7n4MMUwMr-VTw5lD-1Rb-frEyMiIYYH1yWF8HoxKWuqvi4lJ-SVZ2U5GEKxdE-7-u5WVXlrLxHOLtDUFOoFxmxS_NcoyznPCDNOtx8xT4Wohh6U2Ubk50-2whmc-xqqKflG8U51NqYCgtWrkhhCN8IuGkIxXErBviUzlRk8i-rlLRrooCO4JkQ1yPiPCSPKUHB88b4XM6jem3yj7OTQhaGggHN9c4foR38MtNEDFVbYQrjqG9Vwr223y50p50F2G3lPCDVp7SuOj-htlG-QiKPPEPeHoFXBx4km7tWskvO2CyVlxTmGD0ynryfLMS9CKXlsKraId_bS_PnjgaejOXSQJS_aSN9Mbai9yxOeqTPzdZEV6D3Hodsex45jB7qXc8m1wjSVy7Zoc4sob6Z41I9cCJbBFCZ2P9yrXngEOZkXnYHm7erGMJeFti9h6NVOTSY-379dH5gEILNOY8TbEF_zwqypgkUiZsw0664PeBxpVY0Ex67OYXyBF5RQjezOXV1ZqSxR3mQWVfvS3Sj18WdkoL1sSS5B1FNBRswcpZ_tb8U6lwHO00caLozLSi1b9WUA4Z9Q9EVc5Ly4BNngyJJNclG2yoMcleWKWzshzwQRwghrRe78o6lQ7MYE4RGp_Z30514SC7KPQ_dfS2c54DQ7caw_BBzbgIQpKGV58YTS71QWukxVQ_I_l-KehK1Iuv-VDPe489I2fgAt7waz_eXUTBaxm6Xyq3Ow3Qar1qL34Y6kjhJzt8-7srH1hL6fHklKGrikaFfOJebj3GT2buyQyOFLP9Z8q3UjUij1WK2C6D7aongMOjymMra-5tSNSVYLLfRGbZYvp-JxpY3XqjhvUXiQaqYhRQ5tnUNU2sWGpmAps84RnF-JHJ8x_B5Cf32MBfqgwsa9MLwQpKtXwBjRVQuOUBW0zviLUB7QGgCvM66LhifvlCoHAxo5K57ERMfWij7JblAL1O-sfi-ZtzqNdjKo1SNO_AQzqEHAQUfriAZgvA27tBSp3TumVuFz9enRA4UPhLfK-XLRVhR1tVbeFzQFWlLdYmR7_DO1ejJrjPt15-jg8DDpc2D7oW_tnQuJCuIZHGblrbBmcswOqRlFrNTBvDrl9T10IUDiRjMdBhgbve_6bOxWu4w1gCeOxWL_MiFl0kLm3o4NW-CTrXsYagm4A8caT39_cxOvLpcr5u_UKa9cqyfIXkQIaNg2fh7yi9MAqxAqpXx1T9LKWUhHoH2zi1TBtrJ9rS4uj46rWpHtsOtMSnt6Qe62gdakhks5DZHMQVceAgCqkwCdkFJlq_RwHDJF6Nr6ZxbbZP-8ualZ3Djt7i2rB2r0wHyncNtQ05EZ3r8sFrX-ZcMu8MrH156yZl5j1DO_wPU3NU93klizj1cdrBS2dymo4bLdLb75T0FCaoEhbNlSl4w157aFZDAcrBCmAfqvvD94zbEmgWv5Or4VTQqV94BJazD1Sui-Km85h_kv2oURD15KId3fwXcR6ypgfbXN_3fbZgnCAPeaSVBOTB4UdGspVKl_SsJT279lwYon13FWIlJp00fR2pXRCefpG_s-U_fBeXGFIEmQpDycQ2Gkg6BFDSrKYtQqq3mxGXeZQM6-D0-D9CLzKIlZp2Th0AVjEEDFGMy-8NcTXgG5CWHia7YRDbAeiZ7_c8g5PgWVqz4clIvIP4lVSJJCWe5O9LHmbLoMl7QT1KGqHdwdNke06sDQipX3GrV9QzM85LOA2Kx9HfNqdw0TNW6drQoehPLbMbC2053CGe4pTGHUnO__nv1yxIZ9PObH8-VRdZag3DKpr-K6D16nmsGHyQObnmf9DdNOi0gWo-FtSZfaTO8ctHtNNf2KPt8_fmkczL4vGl7Bt9Wnu9hj9oJSfsRj6zmsiV5q43pOR8Mw9vDvZElYSNrNDKhJQf5r2bIziikGxvaWsV2ZLP5vfUXCyzfAB2JMniatnPUP9xONljvHqNH8ozDSe9p_raq8mqNSOZ8zpgrvUqAUAlg2D3MYvNcFXtouyCFgu_r4iv-N9W1jjJwjRpT03rTIVNf-PVeQFyUc9xcdstZ5s0SzSay0JwAdGsrRG9GQ6PmUGOACZsPvAbogb5qHbQ-CSpnmpxmIK1sYTcwEz5yqykOlOjHqnC8--2LqdnlpvaDLiZZfUp4qGC93FDaoZMlFli7cCgeWFvAmZZlQzK8Lun1Qkl3cKL0fgDk1vNDJj2s6d4bmjQVOUrdRlWj47vcL7TBIDHpRBEeGXFGMvNL2phYqSEnTA17qHgx9N8NrfL0gb6EeIFcG6ToTFdE9YyY5xTinDmW2NrpZXWdqXoGE6Ckde7T9xp5zVM5iWH_JuRylosSseceIUrtm0NsQUB1bLWNCp-97OO5OOXghBQWdzT3inv0m6X6XmbC36PILwLWZSvwOyjA4YeyAzJmzy81RCNs3PKRkwucWrAOPyO1-eMO9Cs8qjf8Ulq5yMig_dqLBTLmXy--0FHSdURoS1_pnVOqZscqFIjtgYLVgPAhEjKRAhcOQrcd35N1ubnjEcPAmd-l8_1Mv5CLhTxr5Dt7BYWtisxDJDgyHg6YmQuZ_sM-6IOcR_cgerGktCBFzIVzt20pL20PTT9eBYCFhxWytcbCUQy3kyASw.kDLow87Q2E8b5J-lBOK2Fg";
}