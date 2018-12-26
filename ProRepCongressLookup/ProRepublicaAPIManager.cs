using Newtonsoft.Json;
using ProRepCongressLookup.Models;
using ProRepCongressLookup.APIModels;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using ProRepCongressLookup.APIKeys;

namespace ProRepCongressLookup
{
    public class ProRepublicaAPIManager
    {
        private static RestClient GetRestClient => new RestClient("https://api.propublica.org/");
        private static RestRequest GetRestRequest(string apiRequest, Method method)
        {
            RestRequest RestRequest = new RestRequest(apiRequest, method);
            RestRequest.AddHeader("X-API-Key", APIKey.X_API_Key);
            RestRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");

            return RestRequest;
        }
        private static ModelType GetRestSharpResults<ModelType>(string apiRequest, Method method)
        {
            JsonSerializer JsonSerializer = new Newtonsoft.Json.JsonSerializer();
            RestSharpService RestSharpService = new RestSharpService(JsonSerializer);
            return RestSharpService.Deserialize<ModelType>(GetRestClient.Execute(GetRestRequest(apiRequest, method)));
        }


        public static List<MemberModel> GetAllCongressMembers(Chamber chamber, int congress)
        {
            List<MemberModel> Members = new List<MemberModel>();
            ListOfMembersAPIModel ListOfMembersModel = GetRestSharpResults<ListOfMembersAPIModel>(APIRoutes.MemberRoutes.GetAllCongressMembers(chamber, congress), Method.GET);

            foreach (MemberModel memberModel in ListOfMembersModel.results[0].members.Take(3))
            {
                SetCongressMemberRoles(memberModel);
                SetCongresssMemberVotes(memberModel);

                Members.Add(memberModel);
            }

            return Members;
        }

        private static void SetCongressMemberRoles(MemberModel member)
        {
            MemberRolesAPIModel MemberRolesAPIModel = GetRestSharpResults<MemberRolesAPIModel>(APIRoutes.MemberRoutes.GetMemberByID(member.id), Method.GET);
            member.roles = MemberRolesAPIModel.results[0].roles;
        }

        private static void SetCongresssMemberVotes(MemberModel member)
        {
            MemberVotePositionAPIModel MemberVotePositionAPIModel = GetRestSharpResults<MemberVotePositionAPIModel>(APIRoutes.MemberRoutes.GetMemberVotePositions(member.id), Method.GET);
            member.votes = MemberVotePositionAPIModel.results[0].votes;
        }
    }
}
