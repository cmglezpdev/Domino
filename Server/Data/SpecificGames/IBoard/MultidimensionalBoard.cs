namespace Server.Data.Classes;

using System.Collections.Generic;
using Server.Data.Interfaces;

public class MultidimensionalBorad : IBoard
{
    private int maxIdOfToken;
    private Token[,] board = new Token[100,100]; 
    private int[] movx = {-1, 1, 0, 0};
    private int[] movy = {0, 0, -1, 1};
    int marginLeft = 0;
    int marignTop = 0;
    int middle = 50;

    public List<Token> BuildTokens(int MaxIdOfToken)
    {
        this.maxIdOfToken = MaxIdOfToken;
        List<Token> tokens = new List<Token>();

        for(int i = 0; i <= MaxIdOfToken; i++){
            for(int j = i; j <= MaxIdOfToken; j++){
                tokens.Add(new Token(i , j));
            }
        }
        return tokens;
    }
    public void PlaceToken(Token token, int IdPlayer)
    {
        if( marginLeft == 0 && marignTop == 0 ) {
            board[0,0] = token;
            marginLeft ++;
            return;
        }

        Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>(); 

    }

    public bool ValidPlay(Token token)
    {
        throw new NotImplementedException();
    }
   
    public Token[][] TokensInBoard => throw new NotImplementedException();

    public int[] PlayerByTokens => throw new NotImplementedException();

    public int MaxIdOfToken => throw new NotImplementedException();
}