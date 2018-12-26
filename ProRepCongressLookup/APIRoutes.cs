using System;

namespace ProRepCongressLookup
{
    public static class APIRoutes
    {
        public static class MemberRoutes
        {
            public static string GetAllCongressMembers(Chamber chamber, int congress) => $"https://api.propublica.org/congress/v1/{congress}/{chamber.Description()}/members.json";
            public static string GetMemberByID(string id) => $"https://api.propublica.org/congress/v1/members/{id}";

            // I don't need all these routes at the moment. I'll be loading all the members into a database. I can do my own queries from there.
            //public static string GetAllNewMembers() => "https://api.propublica.org/congress/v1/members/new.json";
            //public static string GetMemberByState(Chamber chamber, State state) => $"https://api.propublica.org/congress/v1/members/{chamber.Description()}/{state.Description()}/current.json";
            //public static string GetMemberByState(Chamber chamber, State state, int district) => $"https://api.propublica.org/congress/v1/members/{chamber.Description()}/{state.Description()}/{district}/current.json";
            //public static string GetMembersLeavingOffice(Chamber chamber, int congress) => $"https://api.propublica.org/congress/v1/{congress}/{chamber.Description()}/members/leaving.json";
            public static string GetMemberVotePositions(string id) => $"https://api.propublica.org/congress/v1/members/{id}/votes.json";
            //public static string GetMemberVoteComparison(Chamber chamber, int congress, string memberID1, string memberID2) => $" https://api.propublica.org/congress/v1/members/{memberID1}/votes/{memberID2}/{congress}/{chamber.Description()}.json";
            //public static string GetBillsCosponsoredByMember(string id) => $"https://api.propublica.org/congress/v1/members/{id}/bills/cosponsored.json";
            //public static string GetQuarterlyOfficeExpensesByMember(string id, DateTime year, int quarter) => $"https://api.propublica.org/congress/v1/members/A000374/office_expenses/{year.Year}/{quarter}.json";
            //public static string GetQuarterlyOfficeExpensesByMemberAndCategory(string id, ExpenseCategory expenseCategory) => $"https://api.propublica.org/congress/v1/members/{id}/office_expenses/category/{expenseCategory.Description()}.json";
            //public static string GetQuarterlyOfficeExpensesByCategory(ExpenseCategory expenseCategory, DateTime year, int quarter) => $"https://api.propublica.org/congress/v1/office_expenses/category/{expenseCategory.Description()}/{year.Year}/{quarter}.json";
        }

        public static class BillRoutes
        {
            public static string GetBillByTitleKeywords(string query) => $"https://api.propublica.org/congress/v1/bills/search.json?query={query}";
            public static string GetRecentBills(Chamber chamber, BillType billType, int congress) => $"https://api.propublica.org/congress/v1/{congress}/{chamber.Description()}/bills/{billType.Description()}.json";
            public static string GetRecentBillsByMember(string id, BillType billType) => $"https://api.propublica.org/congress/v1/members/{id}/bills/{billType.Description()}.json";
            public static string GetRecentBillsBySubject(string subject) => $"https://api.propublica.org/congress/v1/bills/subjects/{subject}.json";
            public static string GetUpcomingBills(Chamber chamber) => $"https://api.propublica.org/congress/v1/bills/upcoming/{chamber.Description()}.json";
            public static string GetSpecificBillByID(string id, int congress) => $"https://api.propublica.org/congress/v1/{congress}/bills/{id}.json";
            public static string GetAmendmentsForBill(string id, int congress) => $"https://api.propublica.org/congress/v1/{congress}/bills/{id}/amendments.json";
            public static string GetSubjectForBill(string id, int congress) => $"https://api.propublica.org/congress/v1/{congress}/bills/{id}/subjects.json";
            public static string GetRelatedBillsForBill(string id, int congress) => $"https://api.propublica.org/congress/v1/{congress}/bills/{id}/related.json";
            public static string GetBillSubjectByKeywords(string query) => $"https://api.propublica.org/congress/v1/bills/subjects/search.json?query={query}";
            public static string GetCosponsorsforBill(string id, int congress) => $"https://api.propublica.org/congress/v1/{congress}/bills/{id}/cosponsors.json";
        }
    }
}
