using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TrelloNet;

namespace DevDash.Services
{
    public class TrelloAPI
    {
        private string trelloKey;
        ITrello trello;

        public TrelloAPI(IConfiguration configuration)
        {
            trelloKey = configuration["Keys:TrelloClientKey"];
            trello = new Trello(trelloKey);
        }

        public string GetTrelloAuthUrl()
        {
            var url = trello.GetAuthorizationUrl("DevDash", Scope.ReadWrite, Expiration.Never);
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["return_url"] = "http://devdash20171205121647.azurewebsites.net/authentication/authorizetrelloajax/";
            query["response_type"] = "token";
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }

        public IEnumerable<Board> GetUserTrelloBoards(string token)
        {
            trello.Authorize(token);
            Member me = trello.Members.Me();
            var boards = trello.Boards.ForMe();
            return boards;
        }

        public Board GetSingleBoard(string token, string id)
        {
            trello.Authorize(token);
            var board = trello.Boards.WithId(id);
            return board;
        }

        public IEnumerable<List> GetUserBoardList(string token, IBoardId boardId)
        {
            trello.Authorize(token);
            var lists = trello.Lists.ForBoard(boardId);
            return lists;
        }

        public IEnumerable<Card> GetBoardCards(string token, IBoardId boardId)
        {
            trello.Authorize(token);
            var cards = trello.Cards.ForBoard(boardId);
            return cards;
        }

        public void UpdateCard(string token, IUpdatableCard card)
        {
            trello.Authorize(token);
            trello.Cards.Update(card);
        }

        public void DeleteCard(string token, ICardId cardId)
        {
            trello.Authorize(token);
            trello.Cards.Delete(cardId);
        }

        public void CreateNewCard(string token, NewCard card)
        {
            trello.Authorize(token);
            trello.Cards.Add(card);
        }

    }
}
