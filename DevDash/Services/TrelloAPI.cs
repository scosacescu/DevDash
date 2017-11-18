using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloNet;

namespace DevDash.Services
{
    public class TrelloAPI
    {
        ITrello trello = new Trello(""); 

        public Uri GetTrelloAuthUrl()
        {
            var url = trello.GetAuthorizationUrl("DevDash", Scope.ReadWrite, Expiration.Never);
            return url;
        }

        public  IEnumerable<Board> getUserTrelloBoards(string token)
        {
            trello.Authorize(token);
            var boards = trello.Boards.ForMe();
            return boards;
        }

        public IEnumerable<List> getUserBoardList(string token, IBoardId boardId)
        {
            trello.Authorize(token);
            var lists = trello.Lists.ForBoard(boardId);
            return lists;
        }

        public IEnumerable<Card> getBoardCards(string token, IBoardId boardId)
        {
            trello.Authorize(token);
            var cards = trello.Cards.ForBoard(boardId);
            return cards;
        }

        public void updateCard(string token, IUpdatableCard card)
        {
            trello.Authorize(token);
            trello.Cards.Update(card);
        }

        public void deleteCard(string token, ICardId cardId)
        {
            trello.Authorize(token);
            trello.Cards.Delete(cardId);
        }

        public void createNewCard(string token, NewCard card)
        {
            trello.Authorize(token);
            trello.Cards.Add(card); 
        }

    }
}
